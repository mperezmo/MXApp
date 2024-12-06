using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SQLServer
{
    public class BackUpRepository : IBackupRepository
    {
        public void BackupDatabase(string connectionString, string backupPath)
        {
            // Obtener las rutas de backup desde el app.config
            string backupPathEstacionamiento = ConfigurationManager.AppSettings["BackupPath_Estacionamiento"];
            string backupPathLog = ConfigurationManager.AppSettings["BackupPath_Log"];
            string backupPathUser = ConfigurationManager.AppSettings["BackupPath_User"];

            // Asegurararme de que las rutas estén configuradas correctamente
            if (string.IsNullOrEmpty(backupPathEstacionamiento) || string.IsNullOrEmpty(backupPathLog) || string.IsNullOrEmpty(backupPathUser))
            {
                throw new Exception("Las rutas de backup no están correctamente configuradas en el app.config");
            }

            // Queries para hacer el backup
            string q1 = "BACKUP DATABASE [TC_Estacionamiento] TO DISK = @backupPath";
            string q2 = "BACKUP DATABASE [TC_User] TO DISK = @backupPath";
            string q3 = "BACKUP DATABASE [TC_Log] TO DISK = @backupPath";

            // Realizar el backup de cada base de datos

            // 1. Backup de TC_Estacionamiento
            SqlParameter[] parameters1 = new SqlParameter[]
            {
                new SqlParameter("@backupPath", backupPathEstacionamiento)
            };
            SqlHelper.ExecuteNonQuery(q1, CommandType.Text, parameters1);

            // 2. Backup de TC_Log
            SqlParameter[] parameters2 = new SqlParameter[]
            {
                new SqlParameter("@backupPath", backupPathUser)
            };
            SqlHelper.ExecuteNonQuery(q2, CommandType.Text, parameters2);

            // 3. Backup de TC_User
            SqlParameter[] parameters3 = new SqlParameter[]
            {
                new SqlParameter("@backupPath", backupPathLog)
            };
            SqlHelper.ExecuteNonQuery(q3, CommandType.Text, parameters3);

        }
    }
}
