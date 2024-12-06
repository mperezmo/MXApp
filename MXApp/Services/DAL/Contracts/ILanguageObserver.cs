using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Contracts
{
    /// <summary>
    /// Interfaz para los observadores de idioma en el patrón Observer.
    /// </summary>
    //Creo la interfaz observador de idioma (patron observer)
    public interface ILanguageObserver
    {
        /// <summary>
        /// Actualiza el idioma del observador.
        /// Este método es llamado cuando ocurre un cambio en el idioma, notificando al observador para actualizarse.
        /// </summary>
        void UpdateLanguage();
    }
}
