using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Strategy
{
    // Defino estrategia para escribir logs en un file.
    public class FileLoggerStrategy : ILoggerStrategy
    {
        public void WriteLog(Log log, Exception ex = null)
        {
            LoggerRepository.WriteLogToFile(log, ex);
        }
    }
}
