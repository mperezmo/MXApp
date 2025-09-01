using Services.DAL.Contracts;
using Services.DAL.Strategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.FactoryServices
{
    /// <summary>
    /// Fábrica estática para crear instancias de estrategias de logging de acuerdo con el tipo configurado.
    /// </summary>
    public static class LoggerFactory
    {
        /// <summary>
        /// Crea y devuelve una instancia de la estrategia de logging especificada en la configuración de la aplicación.
        /// </summary>
        /// <returns>Instancia de <see cref="ILoggerStrategy"/> que corresponde al tipo de logger configurado.</returns>
        /// <exception cref="NotSupportedException">Se lanza si el tipo de logger no está implementado.</exception>
        public static ILoggerStrategy CreateLogger()
        {
            string loggerType = ConfigurationManager.AppSettings["LoggerType"]; // "file" o "database"

            switch (loggerType.ToLower())
            {
                case "file":
                    return new FileLoggerStrategy();
                case "database":
                    return new DatabaseLoggerStrategy();
                default:
                    throw new NotSupportedException("base de datos no implementada ");
            }
        }
    }
}
