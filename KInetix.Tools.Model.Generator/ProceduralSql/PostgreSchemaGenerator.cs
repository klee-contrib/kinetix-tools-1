﻿using System.IO;
using Kinetix.Tools.Model.Config;
using Microsoft.Extensions.Logging;

namespace Kinetix.Tools.Model.Generator.ProceduralSql
{
    /// <summary>
    /// Générateur de PL-SQL.
    /// </summary>
    public class PostgreSchemaGenerator : AbstractSchemaGenerator
    {
        public PostgreSchemaGenerator(string appName, ProceduralSqlConfig config, ILogger<ProceduralSqlGenerator> logger)
            : base(appName, config, logger)
        {
        }

        protected override string BatchSeparator => ";";

        protected override bool SupportsClusteredKey => false;

        protected override bool UseQuotes => false;

        /// <summary>
        /// Gère l'auto-incrémentation des clés primaires en ajoutant identity à la colonne.
        /// </summary>
        /// <param name="writerCrebas">Flux d'écriture création bases.</param>
        protected override void WriteIdentityColumn(StreamWriter writerCrebas)
        {
            writerCrebas.Write(" generated by default as identity");
        }
    }
}
