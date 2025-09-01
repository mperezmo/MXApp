using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Domain;

namespace DAL.Implementations.Windows
{
    public static class DiskInfoDAL
    {
        /// <summary>
        /// Obtiene la información de las unidades disponibles que estén listas.
        /// </summary>
        /// <returns>Lista de objetos DiskInfo con la información de cada unidad.</returns>
        public static List<DiskInfo> GetDiskInfos()
        {
            List<DiskInfo> disks = new List<DiskInfo>();

            // Obtiene todas las unidades lógicas del sistema.
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                // Solo se procesan las unidades que están listas (por ejemplo, descarta unidades extraíbles sin medios)
                if (drive.IsReady)
                {
                    disks.Add(new DiskInfo
                    {
                        DriveName = drive.Name,
                        TotalSize = drive.TotalSize,
                        FreeSpace = drive.TotalFreeSpace
                    });
                }
            }

            return disks;
        }

        /// <summary>
        /// Guarda la información de los discos en la tabla DiskInfoHistory junto con la fecha de registro.
        /// Los valores de TotalSize y FreeSpace se almacenan en gigabytes.
        /// </summary>
        /// <param name="diskInfos">Lista de objetos DiskInfo.</param>
        public static void SaveDiskInfos(List<DiskInfo> diskInfos)
        {
            // Obtener la cadena de conexión desde App.config
            string connectionString = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (var disk in diskInfos)
                {
                    // Convertir los valores de bytes a gigabytes
                    double totalSizeGB = disk.TotalSize / (1024.0 * 1024.0 * 1024.0);
                    double freeSpaceGB = disk.FreeSpace / (1024.0 * 1024.0 * 1024.0);

                    string commandText = @"
                        INSERT INTO DiskInfoHistory (ServerName, DriveName, TotalSize, FreeSpace, RecordDate)
                        VALUES (@ServerName, @DriveName, @TotalSize, @FreeSpace, @RecordDate)";

                    using (SqlCommand cmd = new SqlCommand(commandText, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ServerName", disk.ServerName);
                        cmd.Parameters.AddWithValue("@DriveName", disk.DriveName);
                        cmd.Parameters.AddWithValue("@TotalSize", totalSizeGB);
                        cmd.Parameters.AddWithValue("@FreeSpace", freeSpaceGB);
                        cmd.Parameters.AddWithValue("@RecordDate", DateTime.Now);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
