using BLL;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;
using Services.DAL.Contracts;
using Services.DAL.Implementations.SQLServer;
using Services.Domain;
using Services.Facade;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace UI.Forms
{
    public partial class MainForm : Form
    {
        private List<InstanceInfo> instanceInfoList = new List<InstanceInfo>();
        IDatabaseConnectionStrategy connectionStrategy;
        private string roles = SessionService.ObtenerRolesUsuario();
        private bool isAdmin;
        private DatabaseStatusCheckerBLL _dbStatusChecker;
        private string _instanceSrvName;


        public MainForm()
        {
            InitializeComponent();

            // Cargar el idioma guardado (por defecto "es-ES" si no se ha guardado ninguno)
            string userLanguage = LanguageLogic.LoadUserLanguage();

            // Actualizar la cultura del hilo actual
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userLanguage);

            // Traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);


            txtUsername.Enabled = false;
            txtPassword.Enabled = false;
            rdbIntegratedAuth.Checked = true;
            btnViewInstance.Enabled = false;
            btnAddInstance.Enabled = false;

            // Verificar si el usuario es Admin (por ejemplo, que la cadena contenga "Admin")
            bool isAdmin = roles.ToLower().Contains("admin");

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
            foreach (DataGridViewColumn col in dataGridViewDatabases.Columns)
            {
                // Asigna la clave de traducción según el nombre o alguna convención que hayas definido
                // Por ejemplo, si el nombre de la columna es "InstanceName", asignar el Tag igual:
                col.Tag = col.Name;
            }
            TranslateDataGridViewColumns(dataGridViewDatabases);

            configurarPermisosToolStripMenuItem.Enabled = isAdmin;
            agregarUsuarioToolStripMenuItem.Enabled = isAdmin;

            _dbStatusChecker = new DatabaseStatusCheckerBLL(1);
            _dbStatusChecker.Start();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Detener el chequeo al cerrar la aplicación
            _dbStatusChecker.Stop();
            base.OnFormClosing(e);
        }

        private void btnLoadDatabases_Click(object sender, EventArgs e)
        {
            string instanceName = txtInstance.Text; // Campo de texto donde ingresas la instancia

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

                dataGridViewDatabases.Rows.Add(instanceInfo.ServerName,
                                               instanceInfo.LastStartTime,
                                               instanceInfo.SQLEdition,
                                               instanceInfo.SQLBuild);

                bool isAdmin = roles.ToLower().Contains("admin");
                btnAddInstance.Enabled = isAdmin;
                btnViewInstance.Enabled = true;

                // Verificar el rol del usuario solo después de una conexión exitosa
                //string roles = SessionService.ObtenerRolesUsuario();
                //bool isAdmin = roles.ToLower().Contains("admin");

                // Habilitar btnAddInstance solo si el usuario es Admin
                _instanceSrvName = instanceInfo.ServerName;

                LoggerService.WriteLog($"Conexión satisfactoria con la instancia: {instanceName}", TraceLevel.Info);
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

        private void btnViewInstances_Click(object sender, EventArgs e)
        {
            this.Hide();

            string instanceName = _instanceSrvName;

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

        private void btnExistingInstances_Click(object sender, EventArgs e)
        {
            ViewInstancesForm viewInstancesForm = new ViewInstancesForm();
            viewInstancesForm.Show();
        }

        private void btnAddInstance_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el nombre de la instancia ingresado por el usuario.
                string instanceName = txtInstance.Text.Trim();

                // Crear una instancia de la capa BLL.
                InstanceBLL instanceBLL = new InstanceBLL();

                // Llamar al método de la capa BLL para agregar la instancia.
                Instance nuevaInstancia = instanceBLL.AddInstance(instanceName);

                // Mostrar un mensaje de éxito con algunos detalles de la instancia agregada.
                MessageBox.Show($"Instancia '{nuevaInstancia.Name}' agregada correctamente.",
                                "Operación exitosa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Opcional: limpiar el TextBox después de la operación.
                txtInstance.Clear();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error en caso de que ocurra alguna excepción.
                MessageBox.Show("Error al agregar la instancia: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void inglesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Establece el idioma inglés
            string languageCode = "en-US";
            LanguageLogic.SaveUserLanguage(languageCode);

            // Actualiza la cultura actual para el hilo de la UI
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCode);

            // Vuelve a traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);
            TranslateDataGridViewColumns(dataGridViewDatabases);

            // Opcional: registrar la acción
            LoggerService.WriteLog("Language changed to English", System.Diagnostics.TraceLevel.Info);
        }

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Establece el idioma español
            string languageCode = "es-ES";
            LanguageLogic.SaveUserLanguage(languageCode);

            // Actualiza la cultura actual para el hilo de la UI
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCode);

            // Vuelve a traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);
            TranslateDataGridViewColumns(dataGridViewDatabases);

            // Opcional: registrar la acción
            LoggerService.WriteLog("Idioma cambiado a español", System.Diagnostics.TraceLevel.Info);


        }

        public static void TranslateDataGridViewColumns(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Tag != null && !string.IsNullOrEmpty(col.Tag.ToString()))
                {
                    col.HeaderText = LanguageLogic.Translate(col.Tag.ToString());
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            dataGridView1.DataSource = null;

            // Ejecutar la búsqueda en un hilo en background
            var instancias = await Task.Run(() =>
            {
                DataTable dt = SqlDataSourceEnumerator.Instance.GetDataSources();
                var lista = new List<dynamic>();
                foreach (DataRow row in dt.Rows)
                {
                    string server = row["ServerName"] as string;
                    string instance = row["InstanceName"] as string;
                    if (string.IsNullOrEmpty(instance))
                        instance = "MSSQLSERVER";
                    string version = row["Version"] as string;
                    string clustered = row["IsClustered"] as string;
                    lista.Add(new { ServerName = server, InstanceName = instance });
                }
                return lista;
            });

            dataGridView1.DataSource = instancias;
            Cursor = Cursors.Default;
        }

    }

}
