using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Services.DAL.Implementations.SQLServer.Helper
{
    internal static class SecuritySqlHelper
    {
        public readonly static string conString;

        static SecuritySqlHelper()
        {
            conString = ConfigurationManager
                .ConnectionStrings["SecurityConString"].ConnectionString;
        }

        public static int ExecuteNonQuery(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            CheckNullables(parameters);
            using (var conn = new SqlConnection(conString))
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object ExecuteScalar(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(conString))
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static SqlDataReader ExecuteReader(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            var conn = new SqlConnection(conString);
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        public static DataTable ExecuteDataTable(string commandText,
            CommandType commandType, params SqlParameter[] parameters)
        {
            using (var conn = new SqlConnection(conString))
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private static void CheckNullables(SqlParameter[] parameters)
        {
            foreach (var p in parameters)
                if (p.SqlValue == null) p.SqlValue = DBNull.Value;
        }
    }
}
