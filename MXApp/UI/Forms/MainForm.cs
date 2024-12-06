using BLL;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;
using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class MainForm : Form
    {
        private List<InstanceInfo> instanceInfoList = new List<InstanceInfo>();
        IDatabaseConnectionStrategy connectionStrategy;

        public MainForm()
        {
            InitializeComponent();
            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            rdbIntegratedAuth.Checked = true;
            btnViewInstances.Enabled = false;

            rdbUserPassword.CheckedChanged += (sender, e) =>
            {
                if (rdbUserPassword.Checked)
                {
                    txtUsername.Enabled = true;
                    txtPassword.Enabled = true;
                }
            };

            dataGridViewDatabases.Columns.Add("InstanceName", "Nombre de la Instancia");
            dataGridViewDatabases.Columns.Add("LastStartTime", "Último Inicio");
            dataGridViewDatabases.Columns.Add("SQLEdition", "Edición de SQL Server");
            dataGridViewDatabases.Columns.Add("SQLBuild", "Build");
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {
            string instanceName = txtInstance.Text; // Campo de texto donde ingresas la instancia

            try
            {
                // Seleccionar la estrategia de conexión
                //IDatabaseConnectionStrategy connectionStrategy;

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

                dataGridViewDatabases.Rows.Add(instanceName,
                                               instanceInfo.LastStartTime,
                                               instanceInfo.SQLEdition,
                                               instanceInfo.SQLBuild);

                btnViewInstances.Enabled = true;
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error
                MessageBox.Show($"Error al conectar con la instancia {instanceName}:\n{ex.Message}\nDetalles: {ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnViewInstances_Click(object sender, EventArgs e)
        {
            this.Hide();
            string instanceName = txtInstance.Text.Trim();

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

            DBInformationForm dbInfo = new DBInformationForm(instanceName, connectionStrategy);
            dbInfo.Show();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm();
            addUserForm.Show();

            this.Hide();
        }

        private void configurarPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el usuario actual
                var currentUser = SessionService.UsuarioLogueado;

                if (currentUser == null)
                {
                    MessageBox.Show("No se ha iniciado sesión. No se puede configurar permisos.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // Crear el formulario con el usuario actual
                ConfigurePermissionsForm configurePermissionsForm = new ConfigurePermissionsForm(currentUser);
                configurePermissionsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al abrir la configuración de permisos: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void menuItemLogout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            SessionService.ClearSession(); // Limpiar la sesión
            this.Hide();               
            
        }
    }
}
