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
    public class DatabaseConnectionContext
    {
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public DatabaseConnectionContext(IDatabaseConnectionStrategy connectionStrategy)
        {
            _connectionStrategy = connectionStrategy;
        }

        public SqlConnection GetConnection(string instanceName)
        {
            return _connectionStrategy.GetConnection(instanceName);
        }
    }
}
