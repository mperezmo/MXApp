using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Services.DAL.Contracts;
using DAL.Contracts;

namespace DAL.Implementations.SQLServer
{
    public class IntegratedAuthConnectionStrategy : IDatabaseConnectionStrategy
    {
        public SqlConnection GetConnection(string instanceName)
        {
            // Construir cadena de conexión para autenticación integrada
            string connectionString = $"Server={instanceName};Integrated Security=True;";
            return new SqlConnection(connectionString);
        }
    }
}
