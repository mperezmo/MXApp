// Archivo: DAL/Implementations/SQLServer/PerformanceRepository.cs
using Domain;
using DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.Implementations.SQLServer
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
                SELECT 
    qs.total_logical_reads,
    qs.total_worker_time,
    qs.execution_count,
    st.text AS QueryText,
    CASE 
        WHEN CHARINDEX('FROM', st.text COLLATE Latin1_General_CI_AS) > 0 THEN 
            LTRIM(RTRIM(
                SUBSTRING(
                    st.text,
                    CHARINDEX('FROM', st.text COLLATE Latin1_General_CI_AS) + 5,
                    CHARINDEX(' ', st.text + ' ', CHARINDEX('FROM', st.text COLLATE Latin1_General_CI_AS) + 5) 
                      - (CHARINDEX('FROM', st.text COLLATE Latin1_General_CI_AS) + 5)
                )
            ))
        ELSE 'No se encontró FROM'
    END AS TableUsed
FROM sys.dm_exec_query_stats qs
CROSS APPLY sys.dm_exec_sql_text(qs.sql_handle) st
WHERE st.text NOT LIKE '%OBJECTS%'
AND st.text NOT LIKE '%PRINCIPAL%'
AND st.text NOT LIKE '%SYS%'
AND st.text NOT LIKE '%The%'
ORDER BY qs.total_logical_reads DESC;
            ";

            using (SqlConnection connection = _connectionStrategy.GetConnection(instanceName))
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
                                CPUTime = Convert.ToDecimal(reader["total_worker_time"]),
                                LogicalReads = Convert.ToDecimal(reader["total_logical_reads"]),
                                ExecutionCount = Convert.ToDecimal(reader["execution_count"]),
                                QueryText = reader["QueryText"].ToString(),
                                TableUsed = reader["TableUsed"].ToString()
                                // Nota: No se asigna DatabaseName aquí
                            });
                        }
                    }
                }
            }

            return expensiveQueries;
        }
    }
}
