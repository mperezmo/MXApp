using Services.DAL.Contracts;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services.Facade
{
    public static class LanguageService
    {
        private static List<ILanguageObserver> observers = new List<ILanguageObserver>();

        // Método para agregar observadores
        public static void Subscribe(ILanguageObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
        }

        // Método para remover observadores
        public static void Unsubscribe(ILanguageObserver observer)
        {
            observers.Remove(observer);
        }

        // Método para notificar a todos los observadores cuando cambia el idioma
        private static void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.UpdateLanguage();  // Notificar al observador de la UI
            }
        }

        // Método para traducir una clave específica
        public static string Translate(string key)
        {
            return LanguageLogic.Translate(key);
        }

        // Guardar el idioma del usuario y notificar a los observadores
        public static void SaveUserLanguage(string languageCode)
        {
            LanguageLogic.SaveUserLanguage(languageCode);
            NotifyObservers();  // Notificar cuando cambia el idioma
        }

        // Cargar el idioma guardado
        public static string LoadUserLanguage()
        {
            return LanguageLogic.LoadUserLanguage();
        }

        // Traducir un formulario completo
        public static void TranslateForm(Control control)
        {
            LanguageLogic.TranslateForm(control);
        }
    }
}
