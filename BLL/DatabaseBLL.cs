using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;
using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class DatabaseBLL
    {
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private readonly string _instanceName;

        public DatabaseBLL(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;
        }

        /// <summary>
        /// Crea una base de datos en la instancia SQL Server configurada.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos a crear.</param>
        /// <param name="customDataPath">Ruta personalizada para el archivo de datos (opcional).</param>
        /// <param name="customLogPath">Ruta personalizada para el archivo de log (opcional).</param>
        /// <param name="recoveryModel">Modelo de recuperación, por defecto "FULL".</param>
        public void CrearBaseDeDatos(string databaseName, string customDataPath = null, string customLogPath = null, string recoveryModel = "FULL")
        {
            try
            {
                // Se obtiene la información de la instancia (por ejemplo, rutas predeterminadas).
                var instanceInfo = InstanceDAL.GetInstanceInfo(_instanceName, _connectionStrategy);
                string dataPath = customDataPath ?? instanceInfo.DataPath;
                string logPath = customLogPath ?? instanceInfo.LogPath;

                // La BLL llama a la DAL pasándole los parámetros necesarios.
                DatabaseDAL.CrearBaseDeDatos(databaseName, dataPath, logPath, recoveryModel, _connectionStrategy, _instanceName);

                Console.WriteLine($"Base de datos '{databaseName}' creada exitosamente en la instancia {_instanceName}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina una base de datos en la instancia SQL Server configurada.
        /// </summary>
        public void EliminarBaseDeDatos(string databaseName)
        {
            try
            {
                // La BLL delega la eliminación a la DAL.
                DatabaseDAL.EliminarBaseDeDatos(databaseName, _connectionStrategy, _instanceName);
                Console.WriteLine($"Base de datos '{databaseName}' eliminada exitosamente en la instancia {_instanceName}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Toma un backup de la base de datos.
        /// </summary>
        /// <param name="backupType">Tipo de backup: "FULL", "TLOG" o "DIFERENCIAL".</param>
        /// <param name="customBackupPath">Ruta personalizada para el backup (opcional).</param>
        public void TakeBackup(string databaseName, string backupType, string customBackupPath = null)
        {
            try
            {
                // Se valida el tipo de backup (la validación también podría hacerse en la DAL).
                /*string backupClause;
                switch (backupType.ToUpper())
                {
                    case "FULL":
                        backupClause = "DATABASE";
                        break;
                    case "TLOG":
                        backupClause = "LOG";
                        break;
                    case "DIFERENCIAL":
                        backupClause = "DATABASE WITH DIFFERENTIAL";
                        break;
                    default:
                        throw new ArgumentException("Tipo de backup no válido. Use 'FULL', 'TLOG' o 'DIFERENCIAL'.");
                }*/

                // Se obtiene la ruta de backup predeterminada de la instancia.
                var instanceInfo = InstanceDAL.GetInstanceInfo(_instanceName, _connectionStrategy);
                string backupPath = customBackupPath ?? instanceInfo.BackupPath;

                // Se delega a la DAL la ejecución del backup.
                DatabaseDAL.TakeBackup(databaseName, backupType, backupPath, _connectionStrategy, _instanceName);

                Console.WriteLine($"Backup {backupType} de la base de datos '{databaseName}' creado exitosamente en '{backupPath}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al tomar el backup {backupType} de la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Recupera la lista de bases de datos en la instancia.
        /// </summary>
                /// <param name="includeStatus">Indica si se incluye el estado y modelo de recuperación.</param>
        /// <param name="includeSize">Indica si se incluye información de tamaño y archivos.</param>
        /// <param name="includeBackups">Indica si se incluye información de backups.</param>
        public List<DatabaseInfo> GetDatabases(bool includeStatus = false, bool includeSize = false, bool includeBackups = false)
        {
            try
            {
                return DatabaseDAL.GetDatabases(_instanceName, _connectionStrategy, includeStatus, includeSize, includeBackups);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de bases de datos: {ex.Message}", ex);
            }
        }

        public void ToggleDatabaseState(string databaseName, string targetState)
        {
            try
            {
                // Llama al método de la DAL para cambiar el estado
                DatabaseDAL.ToggleDatabaseState(_instanceName, _connectionStrategy, databaseName, targetState);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cambiar el estado de la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }


        /// <summary>
        /// Realiza un shrink (reducción de tamaño) a la base de datos.
        /// </summary>
        public void ShrinkBaseDeDatos(string databaseName, string databaseFile, int shrinkInt)
        {
            try
            {
                DatabaseDAL.ShrinkDatabase(_instanceName, _connectionStrategy, databaseName, databaseFile, shrinkInt);
                Console.WriteLine($"Base de datos '{databaseName}' reducida exitosamente en la instancia {_instanceName}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al reducir la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene la lista de nombres de archivos de una base de datos, filtrados por tipo.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos.</param>
        /// <param name="fileType">Tipo de archivo: "Data" o "Log".</param>
        /// <returns>Lista de nombres de archivos.</returns>
        public List<string> GetDatabaseFiles(string databaseName, string fileType)
        {
            try
            {
                return DatabaseDAL.GetDatabaseFiles(_instanceName, _connectionStrategy, databaseName, fileType);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los archivos de la base de datos: {ex.Message}", ex);
            }
        }
    }
}
