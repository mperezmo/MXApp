using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Services.Facade;
using Domain;

namespace BLL
{
    public class DatabaseStatusCheckerBLL
    {
        private readonly Timer _timer;
        private readonly double _intervalMilliseconds;

        public DatabaseStatusCheckerBLL(int minutos)
        {
            _intervalMilliseconds = minutos * 60 * 1000;
            _timer = new Timer(_intervalMilliseconds);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
        }

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            try
            {
                CheckDatabaseStatuses();
@@ -37,56 +38,55 @@ namespace BLL
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);
            }
        }

        private void CheckDatabaseStatuses()
        {
            // Recuperar todas las instancias agregadas en el sistema
            InstanceBLL instanceBLL = new InstanceBLL();
            var instances = instanceBLL.GetInstances(); // Asumiendo que devuelve List<Instance>

            // Usaremos IntegratedAuthConnectionStrategy para el ejemplo
            IDatabaseConnectionStrategy connectionStrategy = new IntegratedAuthConnectionStrategy();

            foreach (var instance in instances)
            {
                try
                {
                    // Para cada instancia, obtenemos la lista de bases de datos usando DatabaseBLL
                    DatabaseBLL dbBLL = new DatabaseBLL(instance.Name, connectionStrategy);
                    var databases = dbBLL.GetDatabasesStatus();

                    // Buscar bases de datos en estado OFFLINE
                    var offlineDatabases = databases
                        .Where(db => db.State == DatabaseState.Offline)
                        .ToList();

                    if (offlineDatabases.Any())
                    {
                        // Obtener el número de alerta desde el App.config
                        string toPhoneNumber = ConfigurationManager.AppSettings["AlertPhoneNumber"];

                        if (!string.IsNullOrEmpty(toPhoneNumber))
                        {
                            // Construir mensaje de alerta
                            foreach (var db in offlineDatabases)
                            {
                                string alertMessage = $"Alerta: La base de datos '{db.DatabaseName}' en la instancia '{instance.Name}' se encuentra OFFLINE.";
                                // Enviar alerta SMS
                                SmsAlertService.SendAlert(toPhoneNumber, alertMessage);
                                LoggerService.WriteLog(alertMessage, System.Diagnostics.TraceLevel.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Registrar error en el chequeo para esta instancia
                    LoggerService.WriteLog($"Error al verificar la instancia '{instance.Name}': {ex.Message}", System.Diagnostics.TraceLevel.Error);
                }
            }
        }
    }
}
