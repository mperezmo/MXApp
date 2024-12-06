using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Define los métodos para realizar operaciones de respaldo en la base de datos.
    /// </summary>
    public interface IBackupRepository
    {
        /// <summary>
        /// Realiza una copia de seguridad de la base de datos en la ruta especificada.
        /// </summary>
        /// <param name="connectionString">La cadena de conexión de la base de datos.</param>
        /// <param name="backupPath">La ruta donde se almacenará el archivo de respaldo.</param>
        void BackupDatabase(string connectionString, string backupPath);
    }
}
