// Archivo: DAL/Implementations/SQLServer/IndexRepository.cs
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using DAL.Contracts;

namespace DAL.Implementations.SQLServer
{
    public static class IndexRepository
    {
        /// <summary>
        /// Busca en todas las bases de datos de la instancia el objeto con el nombre especificado 
        /// y retorna el nombre de la base de datos donde se encontró.
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia SQL.</param>
        /// <param name="connectionStrategy">Estrategia de conexión.</param>
        /// <param name="objectName">Nombre del objeto (tabla) a buscar.</param>
        /// <returns>El nombre de la base de datos en que se encuentra el objeto o null si no se encontró.</returns>
        public static string GetDatabaseNameForObject(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string objectName)
        {
            string databaseName = null;

            // Construye la consulta para recorrer cada base usando sp_MSforeachdb
            string query = $@"
EXEC sp_MSforeachdb 
    'IF EXISTS (
         SELECT 1 FROM [?].sys.objects WHERE name = ''{objectName}''
     )
     BEGIN
         SELECT TOP 1 ''?'' AS DatabaseName FROM [?].sys.objects WHERE name = ''{objectName}''
     END';";

            using (SqlConnection connection = connectionStrategy.GetConnection(instanceName))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        databaseName = result.ToString();
                    }
                }
            }
            return databaseName;
        }

        /// <summary>
        /// Método auxiliar para "sanitizar" el nombre de la tabla:
        /// elimina los corchetes y, si está presente el esquema, retorna solo el nombre de la tabla.
        /// </summary>
        /// <param name="tableName">Nombre de la tabla en formato [schema].[tablename] o [tablename]</param>
        /// <returns>Nombre de la tabla sin corchetes ni esquema.</returns>
        private static string SanitizeTableName(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return tableName;

            // Eliminar corchetes
            string sanitized = tableName.Replace("[", "").Replace("]", "");

            // Si existe un punto, se asume que viene en el formato "schema.tablename"
            int dotIndex = sanitized.IndexOf('.');
            if (dotIndex >= 0 && dotIndex < sanitized.Length - 1)
            {
                sanitized = sanitized.Substring(dotIndex + 1);
            }
            return sanitized;
        }

        /// <summary>
        /// Ejecuta sp_helpindex en la base de datos especificada para obtener los índices de la tabla indicada.
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia SQL.</param>
        /// <param name="connectionStrategy">Estrategia de conexión.</param>
        /// <param name="databaseName">Nombre de la base de datos donde se encuentra el objeto.</param>
        /// <param name="tableName">Nombre de la tabla (puede venir en formato con esquema y corchetes).</param>
        /// <returns>Lista de objetos IndexInfo.</returns>
        public static List<IndexInfo> GetIndexes(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string databaseName, string tableName)
        {
            List<IndexInfo> indexes = new List<IndexInfo>();

            // Limpiar el nombre de la tabla
            string sanitizedTableName = SanitizeTableName(tableName);

            // Construir la query para cambiar el contexto a la base de datos y ejecutar sp_helpindex
            string query = $"USE [{databaseName}]; EXEC sp_helpindex '{sanitizedTableName}';";

            using (SqlConnection connection = connectionStrategy.GetConnection(instanceName))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // sp_helpindex devuelve columnas: index_name, index_description, keys
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            indexes.Add(new IndexInfo
                            {
                                IndexName = reader["index_name"].ToString(),
                                IndexDescription = reader["index_description"].ToString(),
                                Keys = reader["index_keys"].ToString()
                            });
                        }
                    }
                }
            }

            return indexes;
        }
    }
}
