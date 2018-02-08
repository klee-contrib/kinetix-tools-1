﻿using System.IO;
using Kinetix.ClassGenerator.Model;

namespace Kinetix.ClassGenerator.SchemaGenerator
{
    /// <summary>
    /// Générateur de Transact-SQL.
    /// </summary>
    public class SqlServerSchemaGenerator : AbstractSchemaGenerator
    {
        /// <summary>
        /// Séparateur de lots de commandes Transact-SQL.
        /// </summary>
        protected override string BatchSeparator => "go";

        /// <summary>
        /// Indique si le moteur de BDD visé supporte "primary key clustered ()".
        /// </summary>
        protected override bool SupportsClusteredKey => true;

        /// <summary>
        /// Gère l'auto-incrémentation des clés primaires en ajoutant identity à la colonne.
        /// </summary>
        /// <param name="writerCrebas">Flux d'écriture création bases.</param>
        protected override void WriteIdentityColumn(StreamWriter writerCrebas)
        {
            writerCrebas.Write(" identity(2020, 1)");
        }

        /// <summary>
        /// Ecrit dans le writer le script de création du type.
        /// </summary>
        /// <param name="classe">Classe.</param>
        /// <param name="writerType">Writer.</param>
        protected override void WriteType(ModelClass classe, StreamWriter writerType)
        {
            string typeName = classe.DataContract.Name.ToUpperInvariant() + "_TABLE_TYPE";
            writerType.WriteLine("/**");
            writerType.WriteLine("  * Création du type " + classe.DataContract.Name.ToUpperInvariant() + "_TABLE_TYPE");
            writerType.WriteLine(" **/");
            writerType.WriteLine("If Exists (Select * From sys.types st Join sys.schemas ss On st.schema_id = ss.schema_id Where st.name = N'" + typeName + "')");
            writerType.WriteLine("Drop Type " + typeName + '\n');
            writerType.WriteLine("Create type " + typeName + " as Table (");
        }
    }
}
