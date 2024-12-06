using System;
using System.Windows.Forms;
using BLL; // Asegúrate de tener referencia a la capa BLL
using DAL.Contracts;
using Services.DAL.Contracts;

namespace UI.Forms
{
    public partial class BackupForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private readonly string _backupPath;

        public BackupForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string backupPath)
        {
            InitializeComponent();
            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;
            _backupPath = backupPath;

            // Cargar bases de datos en el ComboBox al cargar el formulario
            LoadDatabases();
            txtBackupPath.Text = _backupPath;
        }

        private void LoadDatabases()
        {
            try
            {
                // Obtener la lista de bases de datos desde la capa de servicios
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                var databases = databaseBLL.GetDatabases(); // Método para listar bases de datos

                comboBoxdatabases.Items.Clear();
                foreach (var db in databases)
                {
                    comboBoxdatabases.Items.Add(db.DatabaseName);
                }

                if (comboBoxdatabases.Items.Count > 0)
                {
                    comboBoxdatabases.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las bases de datos: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnStartBackup_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selección de base de datos
                if (comboBoxdatabases.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione una base de datos para el backup.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos del formulario
                string databaseName = comboBoxdatabases.SelectedItem.ToString();
                string backupPath = txtBackupPath.Text.Trim();

                if (string.IsNullOrWhiteSpace(backupPath))
                {
                    MessageBox.Show("Por favor, seleccione una ruta para el backup.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Determinar tipo de backup
                string backupType = radioButtonFull.Checked ? "FULL" :
                                    radioButtonTLog.Checked ? "TLOG" :
                                    throw new InvalidOperationException("Debe seleccionar un tipo de backup.");

                // Crear instancia del BLL
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);

                // Ejecutar el backup
                databaseBLL.TakeBackup(databaseName, backupType, backupPath);

                MessageBox.Show($"Backup {backupType} de la base de datos '{databaseName}' creado exitosamente en '{backupPath}'.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al tomar el backup: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtBackupPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario
        }
    }
}
