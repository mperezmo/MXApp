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
        /// <param name="customDataPath">Ruta personalizada para los archivos de datos (opcional).</param>
        /// <param name="customLogPath">Ruta personalizada para los archivos de log (opcional).</param>
        public void CrearBaseDeDatos(string databaseName, string customDataPath = null, string customLogPath = null, string recoveryModel= "FULL")
        {
            try
            {
                // Obtener los paths configurados en la instancia si no se especifican custom paths
                var instanceInfo = InstanceDAL.GetInstanceInfo(_instanceName, _connectionStrategy);
                string dataPath = customDataPath ?? instanceInfo.DataPath;
                string logPath = customLogPath ?? instanceInfo.LogPath;

                // Construir el comando para crear la base de datos
                string createDbCommand = $@"
                CREATE DATABASE [{databaseName}]
                ON PRIMARY
                (
                    NAME = '{databaseName}_Data',
                    FILENAME = '{dataPath}\\{databaseName}_Data.mdf',
                    SIZE = 10MB,
                    MAXSIZE = 100MB,
                    FILEGROWTH = 10MB
                )
                LOG ON
                (
                    NAME = '{databaseName}_Log',
                    FILENAME = '{logPath}\\{databaseName}_Log.ldf',
                    SIZE = 5MB,
                    MAXSIZE = 50MB,
                    FILEGROWTH = 5MB
                );

                --Configurar el modelo de recuperación
        ALTER DATABASE[{ databaseName}] SET RECOVERY { recoveryModel.ToUpper()}; ";

                // Ejecutar el comando en la capa DAL
                DatabaseDAL.ExecuteCommand(createDbCommand, _connectionStrategy, _instanceName);

                Console.WriteLine($"Base de datos '{databaseName}' creada exitosamente en la instancia {_instanceName}.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Toma un backup de la base de datos.
        /// </summary>
        /// <param name="databaseName">Nombre de la base de datos.</param>
        /// <param name="backupType">Tipo de backup (FULL, TLOG, DIFERENCIAL).</param>
        /// <param name="customBackupPath">Ruta personalizada para el backup (opcional).</param>
        public void TakeBackup(string databaseName, string backupType, string customBackupPath = null)
        {
            try
            {
                // Validar el tipo de backup
                string backupClause;
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
                }

                // Obtener la ruta de backup predeterminada de la instancia
                var instanceInfo = InstanceDAL.GetInstanceInfo(_instanceName, _connectionStrategy);
                string backupPath = customBackupPath ?? instanceInfo.BackupPath;

                // Construir el comando de backup
                string backupCommand = $@"
                BACKUP {backupClause} [{databaseName}]
                TO DISK = '{backupPath}\{databaseName}_{backupType}_{DateTime.Now:yyyyMMddHHmmss}.bak'
                WITH INIT;";

                // Ejecutar el comando en la capa DAL
                DatabaseDAL.ExecuteCommand(backupCommand, _connectionStrategy, _instanceName);

                Console.WriteLine($"Backup {backupType} de la base de datos '{databaseName}' creado exitosamente en '{backupPath}'.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al tomar el backup {backupType} de la base de datos '{databaseName}': {ex.Message}", ex);
            }
        }

        public List<DatabaseInfo> GetDatabases()
        {
            try
            {
                return DatabaseDAL.GetDatabasesInfo(_instanceName, _connectionStrategy);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener la lista de bases de datos: {ex.Message}", ex);
            }
        }
    }
}
