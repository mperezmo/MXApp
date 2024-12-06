using BLL;
using DAL.Contracts;
using Domain;
using Services.DAL.Contracts;
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
    public partial class DBInformationForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private string _dataPath;
        private string _logPath;
        private string _backupPath;

        public DBInformationForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            InitializeComponent();

            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;

            // Cargar la información de la instancia al cargar el formulario
            LoadInstanceInfo();
            LoadDatabaseInfo();

            // Configurar el evento para cargar la información de las bases de datos al seleccionar la pestaña
            tabControl1.SelectedIndexChanged += new EventHandler(TabControl1_SelectedIndexChanged);
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text == "DB Information")
            {
                LoadDatabaseInfo();
            }
        }

        private void btnRefreshInstInfo_Click(object sender, EventArgs e)
        {
            LoadInstanceInfo();
        }

        private void LoadInstanceInfo()
        {
            try
            {
                // Obtener información de la instancia desde la capa de servicios
                var instanceInfo = InstanceService.TestInstance(_instanceName, _connectionStrategy);

                // Mostrar la información en los controles del formulario
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la información de la instancia: {ex.Message}\n Detalles: {ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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
    }
}
