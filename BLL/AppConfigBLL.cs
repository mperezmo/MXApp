using System;
using DAL.Implementations.SQLServer.AppConfiguration;

namespace BLL
{
    public class AppConfigBLL
    {
        /// <summary>
        /// Despliega la configuración completa de la aplicación:
        /// 1. Actualiza las cadenas de conexión en el App.config (MainConString y SecondConString)
        ///    usando el servidor declarado.
        /// 2. Ejecuta el script T-SQL para crear la base de datos MonitorXpressApp, las tablas necesarias
        ///    e insertar los datos iniciales, utilizando el nombre y contraseña proporcionados para el usuario Admin.
        /// </summary>
        /// <param name="adminUsername">Nombre del usuario Admin.</param>
        /// <param name="adminPassword">Contraseña para el usuario Admin (ya hasheada si es necesario).</param>
        /// <param name="instanceName">Nombre del servidor SQL ingresado en el formulario.</param>
        public void DeployConfiguration(string instanceName)
        {
            try
            {
                // Actualizar las cadenas de conexión en el App.config
                AppConfigDAL.UpdateConnectionString("MainConString", BuildConnectionString(instanceName));
                AppConfigDAL.UpdateConnectionString("SecondConString", BuildConnectionString(instanceName));

                // Ejecutar el script de configuración
                AppConfigDAL.DeployConfiguration(instanceName);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desplegar la configuración de la aplicación: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza únicamente la cadena de conexión MainConString.
        /// </summary>
        public void UpdateMainConnectionString(string instanceName)
        {
            try
            {
                AppConfigDAL.UpdateConnectionString("MainConString", BuildConnectionString(instanceName));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar MainConString: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Actualiza únicamente la cadena de conexión SecondConString.
        /// </summary>
        public void UpdateSecondConnectionString(string instanceName)
        {
            try
            {
                AppConfigDAL.UpdateConnectionString("SecondConString", BuildConnectionString(instanceName));
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar SecondConString: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Construye la cadena de conexión usando el nombre del servidor.
        /// Se utiliza la base de datos "master" para ejecutar el script inicial.
        /// </summary>
        /// <param name="instanceName">Nombre del servidor SQL.</param>
        /// <returns>Nueva cadena de conexión.</returns>
        private string BuildConnectionString(string instanceName)
        {
            // Puedes ajustar la cadena según tus necesidades (por ejemplo, tiempo de espera, encriptación, etc.)
            return $"Server={instanceName};Database=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        }
    }
}
