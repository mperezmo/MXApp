using Services.DAL.Implementations.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Facade
{
    public class ManualService
    {
        private ManualRepository manualRepository;
        private string languageCode;

        /// <summary>
        /// Constructor que inicializa el repositorio de manuales y carga el idioma del usuario.
        /// </summary>
        public ManualService()
        {
            // Cargar el idioma del usuario desde el servicio de idioma
            languageCode = LanguageService.LoadUserLanguage();
            manualRepository = new ManualRepository(languageCode);
        }

        /// <summary>
        /// Abre la ayuda para el módulo actual en el idioma del usuario.
        /// </summary>
        /// <param name="currentModule">El identificador del módulo actual.</param>
        public void AbrirAyuda(string currentModule)
        {
            manualRepository.AbrirAyuda(currentModule, languageCode);
        }

        /// <summary>
        /// Cambia el idioma del usuario y actualiza el repositorio para reflejar el cambio.
        /// </summary>
        /// <param name="newLanguage">El nuevo idioma seleccionado (ejemplo: "es", "en").</param>
        public void CambiarIdioma(string newLanguage)
        {
            languageCode = newLanguage;
            manualRepository = new ManualRepository(languageCode);
        }
    }
}
