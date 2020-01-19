﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Kinetix.Tools.Model.FileModel;
using Kinetix.Tools.Model.Loaders;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace Kinetix.Tools.Model
{
    public class ModelStore
    {
        private readonly ModelConfig _config;
        private readonly DomainFileLoader _domainFileLoader;
        private readonly IMemoryCache _fsCache;
        private readonly ILogger<ModelStore> _logger;
        private readonly ModelFileLoader _modelFileLoader;
        private readonly IEnumerable<IModelWatcher> _modelWatchers;

        private readonly IDictionary<string, Domain> _domains = new Dictionary<string, Domain>();
        private readonly IDictionary<FileName, ModelFile> _modelFiles = new Dictionary<FileName, ModelFile>();

        private readonly ConcurrentDictionary<FileName, ModelFile> _pendingUpdates = new ConcurrentDictionary<FileName, ModelFile>();

        private bool loaded = false;

        public ModelStore(DomainFileLoader domainFileLoader, IMemoryCache fsCache, ModelFileLoader modelFileLoader, ILogger<ModelStore> logger, ModelConfig config, IEnumerable<IModelWatcher> modelWatchers)
        {
            _config = config;
            _domainFileLoader = domainFileLoader;
            _fsCache = fsCache;
            _logger = logger;
            _modelFileLoader = modelFileLoader;
            _modelWatchers = modelWatchers;
        }
        
        public IEnumerable<Class> Classes => _modelFiles.SelectMany(mf => mf.Value.Classes);
        public IEnumerable<ModelFile> Files => _modelFiles.Values;        

        public IDisposable BeginWatch()
        {
            _logger.LogInformation("Lancement du mode watch...");
            var fsWatcher = new FileSystemWatcher(_config.ModelRoot, "*.yml");
            fsWatcher.Changed += OnFSChangedEvent;
            fsWatcher.Created += OnFSChangedEvent;
            fsWatcher.IncludeSubdirectories = true;
            fsWatcher.EnableRaisingEvents = true;
            return fsWatcher;
        }

        public void LoadFromConfig()
        {
            _domains.Clear();
            _modelFiles.Clear();

            _logger.LogInformation("Chargement des domaines...");

            foreach (var domain in _domainFileLoader.LoadDomains(_config.Domains))
            {
                _domains.TryAdd(domain.Name, domain);
            }

            _logger.LogInformation("Chargement des classes...");

            var files = Directory.EnumerateFiles(_config.ModelRoot, "*.yml", SearchOption.AllDirectories)
               .Where(f => f != _config.Domains);

            foreach (var file in files)
            {
                var modelFile = _modelFileLoader.LoadModelFile(file);
                _modelFiles.Add(modelFile.Name, modelFile);
            }

            var relationshipErrors = new List<string>();
            foreach (var modelFile in ModelUtils.Sort(_modelFiles.Values, GetDependencies))
            {
                relationshipErrors.AddRange(ResolveRelationships(modelFile));
            }
            if (relationshipErrors.Any())
            {
                foreach (var error in relationshipErrors)
                {
                    _logger.LogError(error);
                }
                throw new Exception("Erreur lors de la lecture du modèle.");
            }

            _logger.LogInformation("Chargement des listes de référence...");
            LoadReferenceLists();

            _logger.LogInformation("Modèle chargé avec succès.");

            _logger.LogInformation($"Watchers enregistrés : {string.Join(", ", _modelWatchers.Select(mw => mw.Name))}");
            foreach (var modelWatcher in _modelWatchers)
            {
                modelWatcher.OnFilesChanged(Files);
            }

            _logger.LogInformation("Génération initiale terminée avec succès.");

            loaded = true;
        }    

        private IEnumerable<ModelFile> GetDependencies(ModelFile modelFile)
        {
            return modelFile.Dependencies
               .Select(dep =>
               {
                   if (!_modelFiles.TryGetValue(dep, out var depFile))
                   {
                       _logger.LogError($"{modelFile.Path}[6,0] - Le fichier référencé '{dep}' est introuvable.");
                       throw new Exception($"Erreur lors de la résolution des dépendances");
                   }

                   return depFile;
               });
        }

        private void LoadReferenceLists()
        { 
            var staticLists = ReferenceListsLoader.LoadReferenceLists(_config.StaticLists);
            var referenceLists = ReferenceListsLoader.LoadReferenceLists(_config.ReferenceLists);

            var classMap = _modelFiles.SelectMany(mf => mf.Value.Classes)
                .ToDictionary(c => c.Name, c => c);

            foreach (var (className, referenceValues) in staticLists.Concat(referenceLists))
            {
                if (classMap.TryGetValue(className, out var classe))
                {
                    ReferenceListsLoader.AddReferenceValues(classe, referenceValues);
                }
                else
                {
                    throw new Exception($"Une liste de référence pour la classe {className} a été définie, alors que cette classe est introuvable.");
                }
            }
        }

        private void OnFSChangedEvent(object sender, FileSystemEventArgs e)
        {
            _fsCache.Set(e.FullPath, e, new MemoryCacheEntryOptions()
                .AddExpirationToken(new CancellationChangeToken(new CancellationTokenSource(TimeSpan.FromMilliseconds(500)).Token))
                .RegisterPostEvictionCallback((k, v, r, a) =>
                {
                    if (r != EvictionReason.TokenExpired)
                    {
                        return;
                    }
                    OnModelFileChange((string)k);
                }));
        }

        private void OnModelFileChange(string filePath)
        {           
            try
            {
                _logger.LogInformation(string.Empty);
                _logger.LogInformation($"Fichier {filePath.ToRelative()} modifié...");

                if (!loaded)
                {
                    _logger.LogInformation("Attente de la fin de la génération initiale pour continuer...");
                    var waitTask = Task.Run(async () =>
                    {
                        while (!loaded)
                        {
                            await Task.Delay(500);
                        }
                    });
                    waitTask.Wait();
                }

                var file = _modelFileLoader.LoadModelFile(filePath);

                _modelFiles[file.Name] = file;
                _pendingUpdates.AddOrUpdate(file.Name, file, (_, __) => file);

                var relationshipErrors = new List<string>();
                var filesToGenerate = new List<ModelFile>();
                foreach (var update in _pendingUpdates.Values)
                {
                    relationshipErrors.AddRange(ResolveRelationships(update));
                    filesToGenerate.Add(update);
                    foreach (var dep in _modelFiles.Values.Where(f => f.Dependencies.Any(d => d.Equals(update.Name))))
                    {
                        relationshipErrors.AddRange(ResolveRelationships(dep));
                        filesToGenerate.Add(dep);
                    }
                }

                if (relationshipErrors.Any())
                {
                    foreach (var error in relationshipErrors)
                    {
                        _logger.LogError(error);
                    }
                    throw new Exception("Erreur lors de la lecture du modèle.");
                }

                if (_pendingUpdates.Values.SelectMany(f => f.Classes).Any(c => c.Stereotype != null))
                {
                    LoadReferenceLists();
                }

                foreach (var modelWatcher in _modelWatchers)
                {
                    modelWatcher.OnFilesChanged(filesToGenerate);
                }

                _logger.LogInformation($"Mise à jour terminée avec succès.");

                _pendingUpdates.Clear();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }

        private IEnumerable<string> ResolveRelationships(ModelFile modelFile)
        {
            var referencedClasses = GetDependencies(modelFile)
                .SelectMany(m => m.Classes)
                .Concat(modelFile.Classes)
                .ToDictionary(c => c.Name, c => c);

            foreach (var (obj, relation) in modelFile.Relationships)
            {
                switch (obj)
                {
                    case Class classe:
                        if (!referencedClasses.TryGetValue(relation.Value, out var extends))
                        {
                            yield return $"{modelFile.Path}[{relation.Start.Line},{relation.Start.Column}] - La classe '{relation.Value}' est introuvable dans le fichier ou l'un de ses dépendances. ({modelFile}/{classe.Name})";
                            break;
                        }
                        classe.Extends = extends;
                        break;
                    case RegularProperty rp:
                        if (!_domains.TryGetValue(relation.Value, out var domain))
                        {
                            yield return $"{modelFile.Path}[{relation.Start.Line},{relation.Start.Column}] - Le domaine '{relation.Value}' est introuvable. ({modelFile}/{rp.Class.Name}/{rp.Name})";
                            break;
                        }
                        rp.Domain = domain;
                        break;
                    case AssociationProperty ap:
                        if (!referencedClasses.TryGetValue(relation.Value, out var association))
                        {
                            yield return $"{modelFile.Path}[{relation.Start.Line},{relation.Start.Column}] - La classe '{relation.Value}' est introuvable dans le fichier ou l'une de ses dépendances. ({modelFile}/{ap.Class.Name}/{{association}})";
                            break;
                        }
                        ap.Association = association;
                        break;
                    case CompositionProperty cp:
                        if (!referencedClasses.TryGetValue(relation.Value, out var composition))
                        {
                            yield return $"{modelFile.Path}[{relation.Start.Line},{relation.Start.Column}] - La classe '{relation.Value}' est introuvable dans le fichier ou l'une de ses dépendances. ({modelFile}/{cp.Class.Name}/{{composition}})";
                            break;
                        }
                        cp.Composition = composition;
                        break;
                    case AliasProperty alp:
                        if (!referencedClasses.TryGetValue(relation.Peer!.Value, out var aliasedClass))
                        {
                            yield return $"{modelFile.Path}[{relation.Peer.Start.Line},{relation.Peer.Start.Column}] - La classe '{relation.Peer!.Value}' est introuvable dans le fichier ou l'une de ses dépendances. ({modelFile}/{alp.Class.Name}/{{alias}})";
                            break;
                        }
                        var aliasedProperty = aliasedClass.Properties.SingleOrDefault(p => p.Name == relation.Value);
                        if (aliasedProperty == null)
                        {
                            yield return $"{modelFile.Path}[{relation.Start.Line},{relation.Start.Column}] - La propriété '{relation.Value}' est introuvable sur la classe '{aliasedClass.Name}'. ({modelFile}/{alp.Class.Name}/{{alias}})";
                            break;
                        }
                        alp.Property = (IFieldProperty)aliasedProperty;
                        break;
                }
            }

            foreach (var classe in modelFile.Classes)
            {
                if (classe.Properties.Count(p => p.PrimaryKey) > 1)
                {
                    throw new Exception($"La classe {classe.Name} du fichier {modelFile} doit avoir une seule clé primaire ({string.Join(", ", classe.Properties.Where(p => p.PrimaryKey).Select(p => p.Name))} trouvées)");
                }
            }
        }
    }
}
