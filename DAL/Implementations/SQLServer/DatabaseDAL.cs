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
            string commandText = string.Format(@"CREATE DATABASE [{0}]
ON PRIMARY
(
    NAME = @DataName,
    FILENAME = @DataPath,
    SIZE = 10MB,
    MAXSIZE = 100MB,
    FILEGROWTH = 10MB
)
LOG ON
(
    NAME = @LogName,
    FILENAME = @LogPath,
    SIZE = 5MB,
    MAXSIZE = 50MB,
    FILEGROWTH = 5MB
);
ALTER DATABASE [{0}] SET RECOVERY {1};", databaseName, recoveryModel.ToUpper());

            var command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@DataName", databaseName + "_Data");
            command.Parameters.AddWithValue("@DataPath", dataPath + "\\" + databaseName + "_Data.mdf");
            command.Parameters.AddWithValue("@LogName", databaseName + "_Log");
            command.Parameters.AddWithValue("@LogPath", logPath + "\\" + databaseName + "_Log.ldf");

            ExecuteCommand(command, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Construye y ejecuta el comando para eliminar una base de datos.
        /// </summary>
        public static void EliminarBaseDeDatos(string databaseName, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            string commandText = string.Format(@"USE [master];
ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE [{0}];", databaseName);

            var command = new SqlCommand(commandText);
            ExecuteCommand(command, connectionStrategy, instanceName);
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

            string commandText = string.Format("BACKUP {0} [{1}] TO DISK = @BackupPath WITH INIT;", backupClause, databaseName);
            var command = new SqlCommand(commandText);
            string fileName = backupPath + "\\" + databaseName + "_" + backupType + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
            command.Parameters.AddWithValue("@BackupPath", fileName);

            ExecuteCommand(command, connectionStrategy, instanceName);
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
            string commandText = string.Format("USE [{0}]; DBCC SHRINKFILE (@DatabaseFile, @ShrinkInt, TRUNCATEONLY);", databaseName);
            var command = new SqlCommand(commandText);
            command.Parameters.AddWithValue("@DatabaseFile", databaseFile);
            command.Parameters.AddWithValue("@ShrinkInt", shrinkInt);

            ExecuteCommand(command, connectionStrategy, instanceName);
        }

        /// <summary>
        /// Método genérico que abre la conexión, ejecuta el comando SQL y lo cierra.
        /// </summary>
        public static void ExecuteCommand(SqlCommand command, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            using (SqlConnection connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    connection.Open();
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el comando SQL: " + ex.Message, ex);
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
@@ -257,32 +261,32 @@ DBCC SHRINKFILE (N'{databaseFile}', {shrinkInt}, TRUNCATEONLY);";
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
            string commandText = string.Format("ALTER DATABASE [{0}] SET {1};", databaseName, targetState);
            var command = new SqlCommand(commandText);
            ExecuteCommand(command, connectionStrategy, instanceName);
        }

    }
}
