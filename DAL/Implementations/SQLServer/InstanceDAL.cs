using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data.SqlClient;
using Services.DAL.Contracts;
using DAL.Contracts;
using System.Configuration;
using System.Data;


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
        @@SERVERNAME AS [Server Name],
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
                                instanceInfo.ServerName = reader["Server Name"].ToString();
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

        public static Instance AddInstance(string instanceName)
        {
            // Cadena de conexión a la base de datos central.
            string centralConnectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;


            // Crear el objeto Instance con sus propiedades.
            Instance instance = new Instance
            {
                Id = Guid.NewGuid(),
                Name = instanceName,
                // Se arma una cadena de conexión de ejemplo; deberás ajustar este valor según corresponda.
                ConnectionString = $"Server={instanceName};Database=master;Trusted_Connection=True;",
                DateAdded = DateTime.Now
            };

            try
            {
                using (SqlConnection connection = new SqlConnection(centralConnectionString))
                {
                    // Consulta SQL para insertar la nueva instancia en la tabla Instances.
                    string query = @"
                        INSERT INTO Instances (Id, Name, ConnectionString, DateAdded)
                        VALUES (@Id, @Name, @ConnectionString, @DateAdded)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Asignar parámetros
                        command.Parameters.AddWithValue("@Id", instance.Id);
                        command.Parameters.AddWithValue("@Name", instance.Name);
                        command.Parameters.AddWithValue("@ConnectionString", instance.ConnectionString);
                        command.Parameters.AddWithValue("@DateAdded", instance.DateAdded);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar la instancia en la base de datos central: {ex.Message}");
            }

            return instance;
        }
        
        public static List<Instance> GetInstances()
        {
            var instances = new List<Instance>();
            string centralConnectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(centralConnectionString))
            {
                conn.Open();
                string query = "SELECT Id, Name, ConnectionString, DateAdded FROM Instances ORDER BY DateAdded";
                SqlCommand cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    instances.Add(new Instance
                    {
                        Id = (Guid)reader["Id"],
                        Name = reader["Name"].ToString(),
                        ConnectionString = reader["ConnectionString"].ToString(),
                        DateAdded = (DateTime)reader["DateAdded"]
                    });
                }
            }

            return instances;
        }


    }
}