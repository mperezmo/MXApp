using Services.Domain;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    // Servicio para tomar el usuario logueado en el momento
    public static class SessionService
    {
        private static Usuario _usuarioLogueado;

        public static Usuario UsuarioLogueado
        {
            get { return _usuarioLogueado; }
            set { _usuarioLogueado = value; }
        }

        // Método para limpiar la sesión (logout)
        public static void ClearSession()
        {
            _usuarioLogueado = null;
        }

        // Método para obtener el nombre de los roles del usuario logueado
        public static string ObtenerRolesUsuario()
        {

            return SesionLogic.ObtenerRolesUsuario(_usuarioLogueado);
        }
    }
}
