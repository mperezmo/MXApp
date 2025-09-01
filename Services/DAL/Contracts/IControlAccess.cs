using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Define el método para establecer restricciones de acceso basadas en las patentes del usuario.
    /// Implementa el patrón Decorador para personalizar el acceso según las patentes asignadas.
    /// </summary>
    public interface IControlAccess
    {
        /// <summary>
        /// Aplica las restricciones de acceso en función de las patentes proporcionadas.
        /// </summary>
        /// <param name="patentesUsuario">Lista de patentes asociadas al usuario.</param>
        void SetAccess(List<Patente> patentesUsuario);
    }
}
