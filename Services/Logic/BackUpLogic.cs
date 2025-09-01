using Services.DAL.Contracts;
using Services.DAL.FactoryServices;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logic
{
    /// <summary>
    /// Clase para manejar la lógica de respaldo de bases de datos.
    /// </summary>
    public class BackUpLogic
    {
        private readonly IBackupRepository _backupRepository;
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BackUpLogic"/>.
        /// </summary>
        public BackUpLogic()
        {
            _backupRepository = BackUpFactory.CreateBackupRepository();
        }
        /// <summary>
        /// Realiza el respaldo de todas las bases de datos especificadas en el archivo de configuración.
        /// </summary>
        public void RealizarBackupDeTodasLasBases()
        {
            // Obtener las rutas y cadenas de conexión desde app.config
            string backupPath1 = ConfigurationManager.AppSettings["BackupPath1"];
            string backupPath2 = ConfigurationManager.AppSettings["BackupPath2"];
            string backupPath3 = ConfigurationManager.AppSettings["BackupPath3"];

            string connectionString1 = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            string connectionString2 = ConfigurationManager.ConnectionStrings["SecondConString"].ConnectionString;
            string connectionString3 = ConfigurationManager.ConnectionStrings["LogDatabase"].ConnectionString;

            // Realizar backup de cada base de datos
            _backupRepository.BackupDatabase(connectionString1, backupPath1);
            _backupRepository.BackupDatabase(connectionString2, backupPath2);
            _backupRepository.BackupDatabase(connectionString3, backupPath3);
        }
    }
}
