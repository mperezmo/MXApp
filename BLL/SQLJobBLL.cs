// Archivo: BLL/SQLJobBLL.cs
using System;
using System.Collections.Generic;
using Domain;
using DAL.Implementations.SQLServer;
using DAL.Contracts;

namespace BLL
{
    public class SQLJobBLL
    {
        private readonly SQLJobRepository _jobRepository;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private readonly string _instanceName;

        public SQLJobBLL(IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            _jobRepository = new SQLJobRepository(connectionStrategy);
            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;
        }

        public List<SQLJob> GetSQLJobs()
        {
            try
            {
                return _jobRepository.GetSQLJobs(_connectionStrategy, _instanceName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los SQL Jobs: " + ex.Message, ex);
            }
        }

        public List<SQLJobStep> GetJobSteps(Guid jobId)
        {
            try
            {
                return _jobRepository.GetJobSteps(jobId, _connectionStrategy, _instanceName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pasos del job: " + ex.Message, ex);
            }
        }

        public List<SQLJobSchedule> GetJobScheduleInfo(Guid jobId)
        {
            try
            {
                return _jobRepository.GetJobScheduleInfo(jobId, _connectionStrategy, _instanceName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el schedule del job: " + ex.Message, ex);
            }
        }
    }
}
