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
    public static class InstanceDAL
    {
        public static InstanceInfo GetInstanceInfo(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            using (SqlConnection connection = connectionContext.GetConnection(instanceName))
            {
                try
                {
                    string query = @"
            select  
        SERVERPROPERTY ('Edition') as [Sql Edition],
        SERVERPROPERTY ('ProductVersion') as Build,
        SERVERPROPERTY('InstanceDefaultDataPath') AS 'Data Path',
        SERVERPROPERTY('InstanceDefaultLogPath') AS 'Log Path',
        SERVERPROPERTY('InstanceDefaultBackupPath') AS 'Backup Path',
        c.value_in_use AS 'MemoryMB',
        si.sqlserver_start_time AS [LastStartTime]
        FROM sys.configurations c, sys.dm_os_sys_info si
        WHERE c.name = 'max server memory (MB)';
    ";

                    // Abrir la conexión
                    connection.Open();

                    // Crear el objeto InstanceInfo
                    var instanceInfo = new InstanceInfo();

                    // Obtener información de la instancia
                    using (SqlCommand result = new SqlCommand(query, connection))
                    {
                        using (var reader = result.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                instanceInfo.LastStartTime = Convert.ToDateTime(reader["LastStartTime"]);
                                instanceInfo.SQLEdition = reader["SQL Edition"].ToString();
                                instanceInfo.SQLBuild = reader["Build"].ToString();
                                instanceInfo.SQLServerMemoryMB = Convert.ToInt32(reader["MemoryMB"]);
                                instanceInfo.DataPath = reader["Data Path"].ToString();
                                instanceInfo.LogPath = reader["Log Path"].ToString();
                                instanceInfo.BackupPath = reader["Backup Path"].ToString();
                            }
                            reader.Close();

                            string queryBackupHistory = @"
                SELECT 
                msdb.dbo.backupset.database_name as 'Database Name', 
                msdb.dbo.backupset.backup_start_date AS 'Start Date', 
                msdb.dbo.backupset.backup_finish_date AS 'End Date',
                CASE msdb..backupset.type 
                WHEN 'D' THEN 'Database' 
                WHEN 'L' THEN 'Log' 
                END AS 'Backup Type', 
                msdb.dbo.backupset.backup_size / 1048576 as 'Backup SizeMB',
                msdb.dbo.backupmediafamily.physical_device_name as 'File Location'
                FROM msdb.dbo.backupmediafamily 
                INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id
                ORDER BY 
                msdb.dbo.backupset.backup_finish_date desc";

                            SqlCommand cmdBackupHistory = new SqlCommand(queryBackupHistory, connection);
                            var readerBackupHistory = cmdBackupHistory.ExecuteReader();

                            List<BackupInfo> backupHistory = new List<BackupInfo>();

                            while (readerBackupHistory.Read())
                            {
                                BackupInfo backupInfo = new BackupInfo
                                {
                                    DatabaseName = readerBackupHistory["Database Name"].ToString(),
                                    BackupStartDate = Convert.ToDateTime(readerBackupHistory["Start Date"]),
                                    BackupFinishDate = Convert.ToDateTime(readerBackupHistory["End Date"]),
                                    BackupType = readerBackupHistory["Backup Type"].ToString(),
                                    BackupSizeMB = Convert.ToDecimal(readerBackupHistory["Backup SizeMB"]),
                                    BackupFileLocation = readerBackupHistory["File Location"].ToString()
                                };

                                backupHistory.Add(backupInfo);
                            }

                            readerBackupHistory.Close();

                            instanceInfo.BackupHistory = backupHistory;
                        }
                    }

                    return instanceInfo;
                }
                catch (Exception ex)
                {
                    throw new Exception($"No se pudo conectar a la instancia {instanceName}: {ex.Message}\n Detalles: {ex.StackTrace}");
                }
            }
        }
    }
}