// Archivo: BLL/IndexBLL.cs
using System;
using System.Collections.Generic;
using Domain;
using DAL.Implementations.SQLServer;
using DAL.Contracts;

namespace BLL
{
    public class IndexBLL
    {
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public IndexBLL(IDatabaseConnectionStrategy connectionStrategy)
        {
            _connectionStrategy = connectionStrategy;
        }

        /// <summary>
        /// Obtiene la lista de índices para la tabla especificada.
        /// Primero busca en qué base se encuentra el objeto y luego ejecuta sp_helpindex.
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia SQL.</param>
        /// <param name="tableName">Nombre de la tabla (valor de TableUsed).</param>
        /// <returns>Lista de IndexInfo.</returns>
        public List<IndexInfo> GetIndexes(string instanceName, string tableName)
        {
            try
            {
                // Obtener el nombre de la base de datos donde se encuentra el objeto.
                string databaseName = IndexRepository.GetDatabaseNameForObject(instanceName, _connectionStrategy, tableName);
                if (string.IsNullOrEmpty(databaseName))
                {
                    throw new Exception($"No se encontró la base de datos para el objeto '{tableName}'.");
                }
                // Obtener los índices usando el databaseName encontrado.
                return IndexRepository.GetIndexes(instanceName, _connectionStrategy, databaseName, tableName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener índices para la tabla '{tableName}': {ex.Message}", ex);
            }
        }
    }
}
