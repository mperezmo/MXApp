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
    public class UserPasswordConnectionStrategy : IDatabaseConnectionStrategy
    {
        private readonly string _username;
        private readonly string _password;

        public UserPasswordConnectionStrategy(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public SqlConnection GetConnection(string instanceName)
        {
            // Construir cadena de conexión para usuario/contraseña
            string connectionString = $"Server={instanceName};User ID={_username};Password={_password};";
            return new SqlConnection(connectionString);
        }
    }
}
