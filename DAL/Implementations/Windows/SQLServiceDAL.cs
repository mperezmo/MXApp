// Archivo: DAL/Implementations/SQLServer/SQLServiceDAL.cs
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Management;  // Asegúrate de tener referenciado System.Management
using Domain;

namespace DAL.Implementations.Windows
{
    public static class SQLServiceDAL
    {
        /// <summary>
        /// Obtiene una lista de servicios relacionados con SQL Server, incluyendo la cuenta de servicio.
        /// </summary>
        /// <returns>Lista de objetos SQLServiceInfo.</returns>
        /// 

        public static List<SQLServiceInfo> GetSQLServices()
        {
            List<SQLServiceInfo> sqlServices = new List<SQLServiceInfo>();

            // Consulta WMI para obtener servicios relacionados con SQL.
            // Se obtienen Name, DisplayName, State y StartName (cuenta del servicio)
            string query = "SELECT Name, DisplayName, State, StartName FROM Win32_Service " +
                           "WHERE Name LIKE '%SQL%' OR DisplayName LIKE '%SQL%'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject service in searcher.Get())
            {
                string name = service["Name"]?.ToString();
                string displayName = service["DisplayName"]?.ToString();
                string state = service["State"]?.ToString();
                string startName = service["StartName"]?.ToString();  // Cuenta de servicio

                sqlServices.Add(new SQLServiceInfo
                {
                    ServiceName = name,
                    DisplayName = displayName,
                    Status = state,
                    ServiceAccount = startName
                });
            }

            return sqlServices;
        }

        public static void SaveSQLServiceInfo(List<SQLServiceInfo> sqlServices)
        {
            // Obtener la cadena de conexión desde App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var service in sqlServices)
                {
                    // Convertir los valores de bytes a gigabytes
                    //double totalSizeGB = disk.TotalSize / (1024.0 * 1024.0 * 1024.0);
                    //double freeSpaceGB = disk.FreeSpace / (1024.0 * 1024.0 * 1024.0);

                    string commandText = @"
                        INSERT INTO SQLServicesInfo (ServiceName, DisplayName, Status, ServiceAccount, RecordDate)
                        VALUES (@ServiceName, @DisplayName, @Status, @ServiceAccount, @RecordDate)";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                        cmd.Parameters.AddWithValue("@DisplayName", service.DisplayName);
                        cmd.Parameters.AddWithValue("@Status", service.Status);
                        cmd.Parameters.AddWithValue("@ServiceAccount", service.ServiceAccount);
                        cmd.Parameters.AddWithValue("@RecordDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
