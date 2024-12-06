using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;
using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class DatabaseService
    {
        public static List<DatabaseInfo> TestDatabase(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            if (string.IsNullOrEmpty(instanceName))
                throw new ArgumentException("El nombre de la instancia no puede estar vacío.");

            // Ahora GetDatabaseInfo devuelve una lista
            return DatabaseDAL.GetDatabaseInfo(instanceName, connectionStrategy);
        }
    }
}
