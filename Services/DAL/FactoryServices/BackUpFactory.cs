using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.FactoryServices
{
    /// <summary>
    /// Fábrica para crear instancias de <see cref="IBackupRepository"/>.
    /// </summary>
    public static class BackUpFactory
    {
        /// <summary>
        /// Crea una instancia de <see cref="IBackupRepository"/> para manejar las operaciones de respaldo.
        /// </summary>
        /// <returns>Una nueva instancia de <see cref="BackUpRepository"/>.</returns>
        public static IBackupRepository CreateBackupRepository()
        {


            return new BackUpRepository();
        }
    }
}
