using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Services.Facade;

namespace UI.Forms
{
    public partial class AppConfigurationForm: Form
    {
        IDatabaseConnectionStrategy connectionStrategy;

        public AppConfigurationForm()
        {
            InitializeComponent();
            txtUsernameApp.Enabled = false;
            txtPasswordApp.Enabled = false;
            btnConfigApp.Enabled = false;
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {

            string instanceName = txtInstanceName.Text; // Campo de texto donde ingresas la instancia

            try
            {
                // Seleccionar la estrategia de conexión
                if (rdbIntegratedAuth.Checked) // Si seleccionó autenticación integrada
                {
                    connectionStrategy = new IntegratedAuthConnectionStrategy();
                }
                else if (rdbUserPassword.Checked) // Si seleccionó usuario/contraseña
                {
                    string username = txtUsername.Text; // Campo de texto para el usuario
                    string password = txtPassword.Text; // Campo de texto para la contraseña
                    connectionStrategy = new UserPasswordConnectionStrategy(username, password);
                }
                else
                {
                    throw new Exception("Debe seleccionar un método de autenticación.");
                }

                // Llamar al servicio para testear la instancia
                var instanceInfo = InstanceService.TestInstance(instanceName, connectionStrategy);
                if (instanceInfo != null)
                {
                    txtUsernameApp.Enabled = true;
                    txtPasswordApp.Enabled = true;
                    btnConfigApp.Enabled=true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la instancia {instanceName}.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                LoggerService.WriteLog($"Error al conectarse a la instancia: {instanceName}.\nDetalles: {ex.Message}", TraceLevel.Error);
            }

        }

        private void btnConfigApp_Click(object sender, EventArgs e)
        {
            try
            {
                string instanceName = txtInstanceName.Text.Trim();
                string adminUsername = txtUsernameApp.Text.Trim();
                string adminPassword = txtPasswordApp.Text.Trim();

                // Crear la configuración de la aplicación
                AppConfigBLL appConfigBLL = new AppConfigBLL();
                appConfigBLL.DeployConfiguration(instanceName);
                //appConfigBLL.UpdateMainConnectionString(instanceName);
                //appConfigBLL.UpdateSecondConnectionString(instanceName);

                // Crear el usuario Admin en la aplicación usando los datos ingresados en los txt de Admin.
                // El método Register de UserService espera el nombre, la contraseña y el teléfono (puedes pasar cadena vacía si no es obligatorio).
                UserService.Register(txtUsernameApp.Text, txtPasswordApp.Text);

                MessageBox.Show("La configuración de la aplicación se completó correctamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al configurar la aplicación: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                LoggerService.WriteLog("Error en configuración de la App: " + ex.Message + "-"+ ex.StackTrace, TraceLevel.Error);
            }
        }

    }
}
