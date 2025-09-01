using BLL;
using DAL.Contracts;
using Domain;
using Services.DAL.Contracts;
using Services.Facade;
using Services.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class DBInformationForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private string _dataPath;
        private string _logPath;
        private string _backupPath;
        private DatabaseStatusCheckerBLL _dbStatusChecker;

        public DBInformationForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            InitializeComponent();

            // Cargar el idioma guardado (por defecto "es-ES" si no se ha guardado ninguno)
            string userLanguage = LanguageLogic.LoadUserLanguage();

            // Actualizar la cultura del hilo actual
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userLanguage);

            // Traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);

            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;

            var instanceInfo = InstanceService.TestInstance(_instanceName, _connectionStrategy);
            // Cargar la información de la instancia al cargar el formulario
            LoadInstanceInfo();
            LoadDatabaseInfo();
            LoadSQLService();
            ConfigureAccessControls();

            // Configurar el evento para cargar la información de las bases de datos al seleccionar la pestaña
            tabControl1.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged);


            label8.Text = instanceInfo.ServerName.ToString(); //cambiar a SELECT @@SERVERNAME

            _dbStatusChecker = new DatabaseStatusCheckerBLL(1);
            _dbStatusChecker.Start();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si la pestaña seleccionada es "DB Information", se carga la información de las bases de datos.
            if (tabControl1.SelectedTab.Text == "DB Information")
            {
                LoadDatabaseInfo();
            }
            // Si la pestaña seleccionada es "SQL Services", se carga la información de los servicios de SQL.
            else if (tabControl1.SelectedTab.Text == "Server Information")
            {
                LoadSQLService();
                LoadDiskInfo();
            }
        }

        private void btnRefreshInstInfo_Click(object sender, EventArgs e)
        {
            LoadInstanceInfo();
        }

        private void btnRefreshInstInfoDB_Click(object sender, EventArgs e)
        {
            LoadDatabaseInfo();
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            CreateDatabaseForm createDatabaseForm = new CreateDatabaseForm(_instanceName, _connectionStrategy, _dataPath, _logPath);
            createDatabaseForm.Show();
            
        }

        private void btnTakeBackup_Click(object sender, EventArgs e)
        {
            BackupForm backupForm = new BackupForm(_instanceName,_connectionStrategy, _backupPath);
            backupForm.Show();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"];
            mainForm.Show();
            this.Close();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["MainForm"];
            mainForm.Show();
            this.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir el formulario MoreInfoDBForm
                var moreInfoForm = new MoreInfoDBForm(_instanceName, _connectionStrategy);
                moreInfoForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el formulario de consultas más costosas: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDatabase_Click(object sender, EventArgs e)
        {
            DeleteDatabaseForm deleteDatabaseForm = new DeleteDatabaseForm(_instanceName, _connectionStrategy);
            deleteDatabaseForm.Show();
        }

        private void btnShrinkDatabase_Click(object sender, EventArgs e)
        {
            ShrinkDatabaseForm shrinkDatabaseForm = new ShrinkDatabaseForm(_instanceName, _connectionStrategy);
            shrinkDatabaseForm.Show();
        }

        private void btnViewJobs_Click(object sender, EventArgs e)
        {
            SQLJobsForm sqlJobsForm = new SQLJobsForm(_connectionStrategy, _instanceName);
            sqlJobsForm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadSQLService();
            LoadDiskInfo();
        }

        private void LoadInstanceInfo()
        {
            try
            {
                // Obtener información de la instancia desde la capa de servicios
                var instanceInfo = InstanceService.TestInstance(_instanceName, _connectionStrategy);

                // Mostrar la información en los controles del formulario
                //label8.Text = instanceInfo.ServerName.ToString();
                txtLastStartTime.Text = instanceInfo.LastStartTime.ToString();
                txtSQLEdition.Text = instanceInfo.SQLEdition.ToString();
                txtSQLBuild.Text = instanceInfo.SQLBuild.ToString();
                txtDataPath.Text = instanceInfo.DataPath.ToString();
                txtLogPath.Text = instanceInfo.LogPath.ToString();
                txtBackupPath.Text = instanceInfo.BackupPath.ToString();
                txtConfiguredMemory.Text = instanceInfo.SQLServerMemoryMB.ToString();


                _dataPath = txtDataPath.Text;
                _logPath = txtLogPath.Text;
                _backupPath = txtBackupPath.Text;

                // Mostrar el historial de backups en un DataGridView
                dataGridViewBackupHistory.DataSource = instanceInfo.BackupHistory;
                dataGridViewBackupHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                foreach (DataGridViewColumn col in dataGridViewBackupHistory.Columns)
                {
                    // Asigna la clave de traducción según el nombre o alguna convención que hayas definido
                    // Por ejemplo, si el nombre de la columna es "InstanceName", asignar el Tag igual:
                    col.Tag = col.Name;
                }
                TranslateDataGridViewColumns(dataGridViewBackupHistory);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la información de la instancia: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadDatabaseInfo()
        {
            try
            {
                // Permitir generación automática de columnas
                dataGridViewDatabases.AutoGenerateColumns = true;

                // Obtener la información de la base de datos desde el servicio (ahora es una lista)
                var dbinfoList = DatabaseService.TestDatabase(_instanceName, _connectionStrategy);

                // Asignar la lista como fuente de datos del DataGridView
                dataGridViewDatabases.DataSource = dbinfoList;

                foreach (DataGridViewColumn col in dataGridViewDatabases.Columns)
                {
                    // Asigna la clave de traducción según el nombre o alguna convención que hayas definido
                    // Por ejemplo, si el nombre de la columna es "InstanceName", asignar el Tag igual:
                    col.Tag = col.Name;
                }
                TranslateDataGridViewColumns(dataGridViewDatabases);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la información de la instancia: {ex.Message}\n Detalles: {ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadSQLService()
        {
            try
            {
                var _serviceBLL = new SQLServiceBLL();
                // Usar la instancia de SQLServiceBLL que ya fue creada en el constructor (_serviceBLL)
                List<SQLServiceInfo> services = _serviceBLL.GetSQLServices();
                dataGridViewServices.DataSource = services;
                // Opcional: ajustar el modo de autoajuste de columnas
                dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                foreach (DataGridViewColumn col in dataGridViewServices.Columns)
                {
                    // Asigna la clave de traducción según el nombre o alguna convención que hayas definido
                    // Por ejemplo, si el nombre de la columna es "InstanceName", asignar el Tag igual:
                    col.Tag = col.Name;
                }
                TranslateDataGridViewColumns(dataGridViewServices);

                _serviceBLL.SaveSQLServiceInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los servicios: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadDiskInfo()
        {
            try
            {
                var _diskBLL = new DiskInfoBLL();

                List<DiskInfo> diskInfos = _diskBLL.GetDiskInfos(_instanceName);
                dataGridViewDisks.DataSource = diskInfos;
                dataGridViewDisks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Ocultar las columnas de TotalSize y FreeSpace
                if (dataGridViewDisks.Columns["TotalSize"] != null)
                    dataGridViewDisks.Columns["TotalSize"].Visible = false;

                if (dataGridViewDisks.Columns["FreeSpace"] != null)
                    dataGridViewDisks.Columns["FreeSpace"].Visible = false;

                foreach (DataGridViewColumn col in dataGridViewDisks.Columns)
                {
                    // Asigna la clave de traducción según el nombre o alguna convención que hayas definido
                    // Por ejemplo, si el nombre de la columna es "InstanceName", asignar el Tag igual:
                    col.Tag = col.Name;
                }
                TranslateDataGridViewColumns(dataGridViewDisks);

                _diskBLL.SaveDiskInfos(_instanceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la información de los discos: " + ex.Message,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ConfigureAccessControls()
        {
            // Obtener la cadena con los roles del usuario logueado
            string roles = SessionService.ObtenerRolesUsuario();

            // Verificar si el usuario es Admin (por ejemplo, que la cadena contenga "Admin")
            bool isAdmin = roles.ToLower().Contains("admin");

            // Habilitar o deshabilitar controles según el rol
            btnCreateDatabase.Enabled = isAdmin;
            btnDeleteDatabase.Enabled = isAdmin;
            btnShrinkDatabase.Enabled = isAdmin;
            btnTakeBackup.Enabled = isAdmin;
        }

        private void btnDBStatus_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado al menos una fila
            if (dataGridViewDatabases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una base de datos.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Suponemos que el DataGridView tiene columnas "DatabaseName" y "DatabaseStatus"
            var selectedRow = dataGridViewDatabases.SelectedRows[0];
            if (selectedRow.Cells["DatabaseName"].Value == null ||
                selectedRow.Cells["DatabaseStatus"].Value == null)
            {
                MessageBox.Show("La fila seleccionada no contiene información de estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string databaseName = selectedRow.Cells["DatabaseName"].Value.ToString();
            string currentState = selectedRow.Cells["DatabaseStatus"].Value.ToString();

            // Determinar el estado opuesto
            string targetState = currentState.ToLower().Contains("offline") ? "ONLINE" : "OFFLINE";

            // Mostrar popup de confirmación
            DialogResult result = MessageBox.Show(
                $"¿Estás seguro que deseas cambiar el estado de la base de datos '{databaseName}' a {targetState}?",
                "Confirmar cambio de estado",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Suponiendo que _instanceName y _connectionStrategy están disponibles en el formulario
                    DatabaseBLL dbBLL = new DatabaseBLL(_instanceName, _connectionStrategy);

                    // Se llama a un método para cambiar el estado; este método debe implementarse en la capa BLL/DAL.
                    dbBLL.ToggleDatabaseState(databaseName, targetState);

                    MessageBox.Show($"El estado de la base de datos '{databaseName}' ha sido cambiado a {targetState}.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Actualizar la información de la base de datos en el DataGridView
                    LoadDatabaseInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cambiar el estado de la base de datos: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
    }
}
