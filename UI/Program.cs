using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Forms;
using Microsoft.Extensions.DependencyInjection;
using Services.Domain;
using Services.Facade;
using System.Diagnostics;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Registro la clave de licencia de Syncfusion
            //SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXZfeXVTQmddUENyWkY=");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Configurar los servicios de inyección de dependencias
            var services = new ServiceCollection();
            //ConfigureServices(services);

            // Construir el contenedor de dependencias
            var serviceProvider = services.BuildServiceProvider();

            // Iniciar la aplicación con el formulario de inicio de sesión
            //var loginForm = serviceProvider.GetRequiredService<LoginForm>();
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);


            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);*/
            Application.Run(new LoginForm());
        }
        

    }
}
