using Services.DAL.Contracts;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Logic
{
    /// <summary>
    /// Clase estática que encapsula la lógica para habilitar o deshabilitar controles y elementos de menú según las patentes del usuario.
    /// </summary>
    public static class AccesoLogic
    {
        //El decorador encapsula la lógica para habilitar o deshabilitar según las patentes del usuario, agrra la interfaz IControlAcces y la implementa en la clase Decorador
        /* ControlDecorator puede manejar cualquier control que herede de Control (por ejemplo, Button, CheckBox, TextBox, etc.).
        El método SetAccess habilita o deshabilita el control dependiendo de si el usuario tiene la patente requerida.*/

        //Decorador para los controles

        /// <summary>
        /// Decorador para habilitar o deshabilitar un control de interfaz de usuario basado en las patentes del usuario.
        /// </summary>
        public class ControlDecorator : IControlAccess
        {
            private readonly Control _control;
            private readonly string _requiredPatente;
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="ControlDecorator"/>.
            /// </summary>
            /// <param name="control">El control a decorar y gestionar el acceso.</param>
            /// <param name="requiredPatente">La patente requerida para habilitar el control.</param>
            public ControlDecorator(Control control, string requiredPatente)
            {
                _control = control;
                _requiredPatente = requiredPatente;
            }
            /// <summary>
            /// Establece el acceso al control basado en las patentes del usuario.
            /// </summary>
            /// <param name="patentesUsuario">Lista de patentes que el usuario posee.</param>
            public void SetAccess(List<Patente> patentesUsuario)
            {
                // Habilitar o deshabilitar el control dependiendo de las patentes del usuario
                _control.Enabled = patentesUsuario.Any(p => p.Nombre == _requiredPatente);
            }
        }
        /// <summary>
        /// Decorador para habilitar o deshabilitar un elemento de menú basado en las patentes del usuario.
        /// </summary>

        public class MenuItemDecorator : IControlAccess
        {
            private readonly ToolStripMenuItem _menuItem;
            private readonly string _requiredPatente;
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="MenuItemDecorator"/>.
            /// </summary>
            /// <param name="menuItem">El elemento de menú a decorar y gestionar el acceso.</param>
            /// <param name="requiredPatente">La patente requerida para habilitar el elemento de menú.</param>
            public MenuItemDecorator(ToolStripMenuItem menuItem, string requiredPatente)
            {
                _menuItem = menuItem;
                _requiredPatente = requiredPatente;
            }
            /// <summary>
            /// Establece el acceso al elemento de menú basado en las patentes del usuario.
            /// </summary>
            /// <param name="patentesUsuario">Lista de patentes que el usuario posee.</param>
            public void SetAccess(List<Patente> patentesUsuario)
            {
                _menuItem.Enabled = patentesUsuario.Any(p => p.Nombre == _requiredPatente);
            }
        }
    }
}
