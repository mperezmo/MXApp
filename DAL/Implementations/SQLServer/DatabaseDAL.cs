using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using Services.DAL.Contracts;
using DAL.Contracts;

namespace DAL.Implementations.SQLServer
{
    public static class DatabaseDAL
    {
        /// <summary>
        /// Construye y ejecuta el comando para crear una base de datos.
        /// </summary>
        public static void CrearBaseDeDatos(string databaseName, string dataPath, string logPath, string recoveryModel, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
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
ALTER DATABASE [{databaseName}] SET RECOVERY {recoveryModel.ToUpper()};";

            ExecuteCommand(createDbCommand, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Construye y ejecuta el comando para eliminar una base de datos.
        /// </summary>
        public static void EliminarBaseDeDatos(string databaseName, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            string deleteDbCommand = $@"
USE [master];
ALTER DATABASE [{databaseName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [{databaseName}];";

            ExecuteCommand(deleteDbCommand, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Construye y ejecuta el comando para realizar un backup de la base de datos.
        /// </summary>
        public static void TakeBackup(string databaseName, string backupType, string backupPath, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
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

            string backupCommand = $@"
BACKUP {backupClause} [{databaseName}]
TO DISK = '{backupPath}\\{databaseName}_{backupType}_{DateTime.Now:yyyyMMddHHmmss}.bak'
WITH INIT;";

            ExecuteCommand(backupCommand, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Recupera la lista de bases de datos (excluyendo las del sistema) de la instancia.
        /// </summary>
        public static List<DatabaseInfo> GetDatabasesInfo(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            using (var connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    connection.Open();

                    string query = @"
SELECT 
    name AS DatabaseName
FROM sys.databases
WHERE database_id > 4;"; // Excluye bases de datos del sistema

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        var databases = new List<DatabaseInfo>();

                        while (reader.Read())
                        {
                            databases.Add(new DatabaseInfo
                            {
                                DatabaseName = reader["DatabaseName"].ToString()
                            });
                        }

                        return databases;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener las bases de datos de la instancia '{instanceName}': {ex.Message}", ex);
                }
            }
        }

        /// <summary>
        /// Construye y ejecuta el comando para realizar un shrink (reducción de tamaño) en la base de datos.
        /// </summary>
        public static void ShrinkDatabase(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string databaseName, string databaseFile, int shrinkInt)
        {
            string shrinkCommand = $@"
USE [{databaseName}];
DBCC SHRINKFILE (N'{databaseFile}', {shrinkInt}, TRUNCATEONLY);";

            ExecuteCommand(shrinkCommand, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Método genérico que abre la conexión, ejecuta el comando SQL y lo cierra.
        /// </summary>
        public static void ExecuteCommand(string commandText, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            using (SqlConnection connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al ejecutar el comando SQL: {ex.Message}", ex);
                }
            }
        }

        public static List<DatabaseInfo> GetDatabaseInfo(string instanceName, DAL.Contracts.IDatabaseConnectionStrategy connectionStrategy)
        {
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);
            List<DatabaseInfo> databaseList = new List<DatabaseInfo>();

            using (SqlConnection connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    string query = @"
                SELECT 
                    db.name AS DatabaseName,
                    db.state_desc AS Status,
                    db.recovery_model_desc AS RecoveryModel,
                    SUM(mf.size * 8 / 1024) AS SizeMB,
                    mf.name AS FileName,
                    mf.physical_name AS FileLocation,
                    (SELECT MAX(backup_finish_date) 
                     FROM msdb.dbo.backupset 
                     WHERE backupset.database_name = db.name AND backupset.type = 'D') AS LastFullBackup,
                    (SELECT MAX(backup_finish_date) 
                     FROM msdb.dbo.backupset 
                     WHERE backupset.database_name = db.name AND backupset.type = 'L') AS LastLogBackup
                FROM 
                    sys.databases db
                LEFT JOIN 
                    sys.master_files mf ON db.database_id = mf.database_id
                WHERE db.database_id > 4
                GROUP BY 
                    db.name, db.state_desc, db.recovery_model_desc, mf.name, mf.physical_name
                ORDER BY 
                    db.name;
            ";

                    connection.Open();

                    using (SqlCommand result = new SqlCommand(query, connection))
                    {
                        using (var reader = result.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var databaseInfo = new DatabaseInfo
                                {
                                    DatabaseName = reader["DatabaseName"].ToString(),
                                    DatabaseStatus = reader["Status"].ToString(),
                                    RecoveryModel = reader["RecoveryModel"].ToString(),
                                    SizeMB = Convert.ToInt32(reader["SizeMB"]),
                                    FileName = reader["FileName"].ToString(),
                                    FileLocation = reader["FileLocation"].ToString(),
                                    LastFullBackup = reader["LastFullBackup"] != DBNull.Value ? reader["LastFullBackup"].ToString() : null,
                                    LastLogBackup = reader["LastLogBackup"] != DBNull.Value ? reader["LastLogBackup"].ToString() : null
                                };

                                databaseList.Add(databaseInfo);
                            }
                        }
                    }

                    return databaseList;
                }
                catch (Exception ex)
                {
                    throw new Exception($"No se pudo conectar a la instancia {instanceName}: {ex.Message}\n Detalles: {ex.StackTrace}");
                }

            }
        }

        /// <summary>
        /// Obtiene la lista de nombres de archivos de la base de datos, filtrando por tipo (Data o Log).
        /// </summary>
        /// <param name="instanceName">Nombre de la instancia.</param>
        /// <param name="connectionStrategy">Estrategia de conexión.</param>
        /// <param name="databaseName">Nombre de la base de datos.</param>
        /// <param name="fileType">Tipo de archivo: "Data" o "Log".</param>
        /// <returns>Lista de nombres de archivos.</returns>
        public static List<string> GetDatabaseFiles(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string databaseName, string fileType)
        {
            var fileList = new List<string>();
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            using (var connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    connection.Open();

                    // La columna type_desc de sys.master_files contiene "ROWS" para archivos de datos y "LOG" para archivos de log.
                    string fileTypeDesc = fileType.Equals("Data", StringComparison.OrdinalIgnoreCase) ? "ROWS" : "LOG";

                    string query = @"
                        SELECT mf.name AS FileName
                        FROM sys.master_files mf
                        WHERE mf.database_id = DB_ID(@databaseName)
                          AND mf.type_desc = @fileTypeDesc;";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@databaseName", databaseName);
                        command.Parameters.AddWithValue("@fileTypeDesc", fileTypeDesc);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                fileList.Add(reader["FileName"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener los archivos de la base de datos '{databaseName}': {ex.Message}", ex);
                }
            }

            return fileList;
        }

        public static void ToggleDatabaseState(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string databaseName, string targetState)
        {
            // targetState debe ser "ONLINE" o "OFFLINE"
            string commandText = $"ALTER DATABASE [{databaseName}] SET {targetState};";
            ExecuteCommand(commandText, connectionStrategy, instanceName);
        }

    }
}
