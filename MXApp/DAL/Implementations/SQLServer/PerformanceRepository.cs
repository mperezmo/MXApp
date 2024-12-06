using Domain;
using DAL.Contracts;
using Services.DAL.Implementations.SQLServer.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PerformanceRepository
    {
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public PerformanceRepository(IDatabaseConnectionStrategy connectionStrategy)
        {
            _connectionStrategy = connectionStrategy;
        }

        public List<ExpensiveQuery> GetTopExpensiveQueries(string instanceName)
        {
            var expensiveQueries = new List<ExpensiveQuery>();

            string query = @"
                SELECT TOP 5
                    qs.total_worker_time / qs.execution_count AS AverageCPUTime,
                    qs.total_logical_reads / qs.execution_count AS AverageLogicalReads,
                    qs.execution_count AS ExecutionCount,
                    st.text AS QueryText,
                    qp.query_plan AS ExecutionPlan,
                    OBJECT_NAME(st.objectid) AS AffectedTables
                FROM 
                    sys.dm_exec_query_stats qs
                CROSS APPLY 
                    sys.dm_exec_sql_text(qs.sql_handle) st
                CROSS APPLY 
                    sys.dm_exec_query_plan(qs.plan_handle) qp
                ORDER BY 
                    AverageCPUTime DESC";

            using (SqlConnection connection = _connectionStrategy.GetConnection(instanceName)) // Usar la estrategia de conexión
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            expensiveQueries.Add(new ExpensiveQuery
                            {
                                CPUTime = Convert.ToDecimal(reader["AverageCPUTime"]),
                                LogicalReads = Convert.ToDecimal(reader["AverageLogicalReads"]),
                                ExecutionCount = Convert.ToDecimal(reader["ExecutionCount"]),
                                QueryText = reader["QueryText"].ToString(),
                                ExecutionPlan = reader["ExecutionPlan"].ToString(),
                                AffectedTables = reader["AffectedTables"]?.ToString()
                            });
                        }
                    }
                }
            }

            return expensiveQueries;
        }
    }
}
