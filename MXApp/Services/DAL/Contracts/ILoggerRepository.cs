using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Interfaz para definir los métodos de registro de logs en el sistema.
    /// </summary>
    internal interface ILoggerRepository
    {
        /// <summary>
        /// Escribe un log en el sistema.
        /// </summary>
        /// <param name="log">El objeto <see cref="Log"/> que contiene los detalles del registro.</param>
        /// <param name="ex">La excepción opcional asociada al log, si corresponde.</param>

        void WriteLog(Log log, Exception ex = null);


    }
}
