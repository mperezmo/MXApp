using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    /// <summary>
    /// Servicio para exponer la lógica de verificación.
    /// </summary>
    public static class VerificacionService
    {
        /// <summary>
        /// Calcula el código verificador basado en un número base.
        /// </summary>
        /// <param name="numeroBase">Número base como string.</param>
        /// <returns>Código verificador calculado.</returns>
        public static int CalcularCodigoVerificador(string numeroBase)
        {
            return VerificacionLogic.CalcularCodigoVerificador(numeroBase);
        }
    }
}
