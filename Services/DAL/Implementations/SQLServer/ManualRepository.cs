using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Implementations.SQLServer
{
    public class ManualRepository
    {
        private string helpFilePath;

        /// <summary>
        /// Constructor que inicializa el repositorio con el idioma especificado.
        /// </summary>
        /// <param name="languageCode">El código de idioma (ejemplo: "es" o "en").</param>
        public ManualRepository(string languageCode)
        {
            // Inicializa la ruta del archivo CHM basado en el idioma
            helpFilePath = GetHelpFilePath(languageCode);
        }

        /// <summary>
        /// Obtiene la ruta del archivo CHM basada en el idioma.
        /// </summary>
        /// <param name="languageCode">El código de idioma (ejemplo: "es" o "en").</param>
        /// <returns>La ruta del archivo CHM.</returns>
        private string GetHelpFilePath(string languageCode)
        {
            string key = $"HelpFilePath_{languageCode}";
            string path = ConfigurationManager.AppSettings[key];

            // Si no hay una clave para el idioma especificado, usa la ruta por defecto
            if (string.IsNullOrEmpty(path))
            {
                path = ConfigurationManager.AppSettings["HelpFilePath_Default"];
            }

            return path;
        }

        /// <summary>
        /// Abre una sección específica del archivo CHM basado en el módulo y el idioma.
        /// </summary>
        /// <param name="topicKey">El identificador del módulo actual.</param>
        /// <param name="languageCode">El código de idioma (ejemplo: "es" o "en").</param>
        public void AbrirAyuda(string topicKey, string languageCode)
        {
            // Obtén el Context ID desde App.config
            string mapId = ConfigurationManager.AppSettings[$"HelpMap_{topicKey}"];
            string filePath = ConfigurationManager.AppSettings["HelpFilePath_es"];

            if (!string.IsNullOrEmpty(mapId) && !string.IsNullOrEmpty(filePath))
            {
                // Usa el Context ID para abrir el tema específico
                string command = $"-mapid {mapId} \"{filePath}\"";

                // Configurar el proceso para ejecutar hh.exe sin mostrar cmd
                var processInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "hh.exe",
                    Arguments = command,
                    UseShellExecute = false,
                    CreateNoWindow = true, // No muestra ventana de consola
                };

                // Iniciar el proceso
                System.Diagnostics.Process.Start(processInfo);
            }
            else
            {
                throw new InvalidOperationException("No se pudo encontrar el Map ID o la ruta del archivo de ayuda.");
            }
        }
    }
}
