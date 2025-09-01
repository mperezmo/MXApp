using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
/// <summary>
 /// Define el contrato para las diferentes estrategias de logging.
 /// Cualquier clase que implemente esta interfaz debe proporcionar una implementación
 /// del método <see cref="WriteLog"/>, que puede ser utilizado para escribir logs de diferentes maneras.
 /// </summary>
    public interface ILoggerStrategy
    {
        /// <summary>
        /// Escribe un log utilizando la estrategia de logging definida.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que contiene los detalles del registro.</param>
        /// <param name="ex">La excepción opcional asociada al log, si corresponde.</param>
        void WriteLog(Log log, Exception ex = null);
    }
}
