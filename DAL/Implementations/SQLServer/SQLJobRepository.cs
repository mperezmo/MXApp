// Archivo: DAL/Implementations/SQLServer/SQLJobRepository.cs
using System;
using System.Data.SqlClient;
using System.Data;
using Domain;
using DAL.Contracts;
using System.Collections.Generic;

namespace DAL.Implementations.SQLServer
{
    public class SQLJobRepository
    {
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public SQLJobRepository(IDatabaseConnectionStrategy connectionStrategy)
        {
            _connectionStrategy = connectionStrategy;
        }

        public List<SQLJob> GetSQLJobs(IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            List<SQLJob> jobs = new List<SQLJob>();
            string query = "SELECT job_id, name, enabled FROM msdb.dbo.sysjobs ORDER BY name;";
            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            // Aquí usamos la estrategia para obtener la conexión apuntando a msdb.
            using (var connection = connectionContext.GetConnection(instanceName))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        jobs.Add(new SQLJob
                        {
                            JobId = (Guid)reader["job_id"],
                            Name = reader["name"].ToString(),
                            Enabled = Convert.ToBoolean(reader["enabled"])
                        });
                    }
                }
            }
            return jobs;
        }

        public List<SQLJobStep> GetJobSteps(Guid jobId, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            List<SQLJobStep> steps = new List<SQLJobStep>();
            string query = $@"
                SELECT step_id, step_name, subsystem, command, database_name
                FROM msdb.dbo.sysjobsteps
                WHERE job_id = '{jobId}'
                ORDER BY step_id;";

            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            // Aquí usamos la estrategia para obtener la conexión apuntando a msdb.
            using (var connection = connectionContext.GetConnection(instanceName))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    //cmd.Parameters.AddWithValue("@jobId", jobId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            steps.Add(new SQLJobStep
                            {
                                StepId = Convert.ToInt32(reader["step_id"]),
                                StepName = reader["step_name"].ToString(),
                                Subsystem = reader["subsystem"].ToString(),
                                Command = reader["command"].ToString(),
                                DatabaseName = reader["database_name"].ToString()
                            });
                        }
                    }
                }
            }
            return steps;
        }

        /// <summary>
        /// Obtiene la información del schedule del job en formato string.
        /// Retorna un string con la fecha y hora de inicio activa, o null si no existe.
        /// </summary>
        public List<SQLJobSchedule> GetJobScheduleInfo(Guid jobId, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            List<SQLJobSchedule> jobschedules = new List<SQLJobSchedule>();
            string query = $@"
                SELECT 
    s.name AS ScheduleName,
    CASE s.enabled 
        WHEN 1 THEN 'Habilitado' 
        ELSE 'Deshabilitado' 
    END AS EstadoSchedule,
    -- Traduce el tipo de frecuencia (freq_type) a un texto entendible:
    CASE s.freq_type 
        WHEN 1 THEN 'Ejecutar una sola vez'
        WHEN 4 THEN 'Diario'
        WHEN 8 THEN 'Semanal'
        WHEN 16 THEN 'Mensual'
        WHEN 32 THEN 'Mensual Relativo'
        WHEN 64 THEN 'Al iniciar SQL Agent'
        WHEN 128 THEN 'En inactividad'
        ELSE 'Desconocido'
    END AS Frecuencia,
    -- Traduce el intervalo de frecuencia:
    CASE s.freq_type 
        WHEN 8 THEN 
            RTRIM(
                CASE WHEN (s.freq_interval & 1) = 1 THEN 'Domingo ' ELSE '' END +
                CASE WHEN (s.freq_interval & 2) = 2 THEN 'Lunes ' ELSE '' END +
                CASE WHEN (s.freq_interval & 4) = 4 THEN 'Martes ' ELSE '' END +
                CASE WHEN (s.freq_interval & 8) = 8 THEN 'Miércoles ' ELSE '' END +
                CASE WHEN (s.freq_interval & 16) = 16 THEN 'Jueves ' ELSE '' END +
                CASE WHEN (s.freq_interval & 32) = 32 THEN 'Viernes ' ELSE '' END +
                CASE WHEN (s.freq_interval & 64) = 64 THEN 'Sábado ' ELSE '' END
            )
        WHEN 4 THEN -- Diario: freq_interval indica cada cuantos días se repite
            'Cada ' + CAST(s.freq_interval AS VARCHAR(10)) + ' día(s)'
        WHEN 16 THEN -- Mensual: freq_interval indica el día del mes
            'Día ' + CAST(s.freq_interval AS VARCHAR(10)) + ' del mes'
        WHEN 32 THEN -- Mensual relativo: se muestra el valor numérico
            'Programación mensual relativa (freq_interval=' + CAST(s.freq_interval AS VARCHAR(10)) + ')'
        ELSE 
            CAST(s.freq_interval AS VARCHAR(10))
    END AS IntervaloFrecuencia,
    -- Traduce el tipo de subdía:
    CASE s.freq_subday_type 
        WHEN 1 THEN 'A una hora específica'
        WHEN 2 THEN 'Segundos'
        WHEN 4 THEN 'Minutos'
        WHEN 8 THEN 'Horas'
        ELSE 'Desconocido'
    END AS TipoSubdia,
    -- Este campo indica el intervalo en la unidad especificada (en este caso, horas si TipoSubdia es 'Horas')
    s.freq_subday_interval AS IntervaloSubdia,
    -- Convierte el tiempo (almacenado como hhmmss) a formato hh:mm:ss
    STUFF(STUFF(RIGHT('000000' + CAST(s.active_start_time AS VARCHAR(6)),6),3,0,':'),6,0,':') AS HoraInicio,
    STUFF(STUFF(RIGHT('000000' + CAST(s.active_end_time AS VARCHAR(6)),6),3,0,':'),6,0,':') AS HoraFin
FROM msdb.dbo.sysjobs j
INNER JOIN msdb.dbo.sysjobschedules js ON j.job_id = js.job_id
INNER JOIN msdb.dbo.sysschedules s ON js.schedule_id = s.schedule_id
WHERE j.job_id = '{jobId}'
ORDER BY j.name;";

            var connectionContext = new DatabaseConnectionContext(connectionStrategy);

            // Aquí usamos la estrategia para obtener la conexión apuntando a msdb.
            using (var connection = connectionContext.GetConnection(instanceName))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    //cmd.Parameters.AddWithValue("@jobId", jobId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            jobschedules.Add(new SQLJobSchedule
                            {
                                ScheduleName = reader["ScheduleName"].ToString(),
                                EstadoSchedule = reader["EstadoSchedule"].ToString(),
                                Frecuencia = reader["Frecuencia"].ToString(),
                                IntervaloFrecuencia = reader["IntervaloFrecuencia"].ToString(),
                                TipoSubdia = reader["TipoSubdia"].ToString(),
                                IntervaloSubdia = Convert.ToInt32(reader["IntervaloSubdia"].ToString()),
                                HoraInicio = Convert.ToString(reader["HoraInicio"]),
                                HoraFin = Convert.ToString(reader["HoraFin"])
                            });
                        }
                    }
                }
            }
            return jobschedules;
        }
    }
}
