using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;
using Services.DAL.Contracts;
using DAL.Contracts;

namespace DAL.Implementations.SQLServer
{
    public static class DatabaseDAL
    {
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
    }
}
