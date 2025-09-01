using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using BLL; // Asegúrate de tener la referencia a tu capa BLL
using DAL.Contracts;
using Services.DAL.Contracts;
using Services.Logic;

namespace UI.Forms
{
    public partial class CreateDatabaseForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;
        private readonly string _dataPath;
        private readonly string _logPath;

        public CreateDatabaseForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy, string dataPath, string logPath)
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
            _dataPath = dataPath;
            _logPath = logPath;

            txtLogPath.Text = logPath;
            txtDataPath.Text = dataPath;
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya ingresado un nombre para la base de datos
                if (string.IsNullOrWhiteSpace(txtDatabaseName.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la base de datos.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                string databaseName = txtDatabaseName.Text.Trim();
                //string customDataPath = string.IsNullOrWhiteSpace(txtDataPath.Text) ? null : txtDataPath.Text.Trim();
                string customDataPath = txtDataPath.Text.Trim();
                //string customLogPath = string.IsNullOrWhiteSpace(txtLogPath.Text) ? null : txtLogPath.Text.Trim();
                string customLogPath = txtLogPath.Text.Trim();
                string recoveryModel = comboBoxRecoveryModel.Text.Trim();

                // Crear instancia del BLL
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);

                // Llamar al método para crear la base de datos
                databaseBLL.CrearBaseDeDatos(databaseName, customDataPath, customLogPath, recoveryModel);

                MessageBox.Show($"La base de datos '{databaseName}' se creó exitosamente.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Limpiar los campos después de crear la base de datos
                txtDatabaseName.Clear();
                txtDataPath.Clear();
                txtLogPath.Clear();

                var result = MessageBox.Show("¿Desea crear otra base de datos?",
                                     "Confirmación",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Limpiar los campos si el usuario desea crear otra base de datos
                    txtDatabaseName.Clear();
                    txtDataPath.Clear();
                    txtLogPath.Clear();
                    comboBoxRecoveryModel.SelectedIndex = 0; // Restablecer a FULL
                }
                else
                {
                    // Cerrar el formulario si el usuario no desea crear otra base de datos
                    this.Close(); 
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la base de datos: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }


        }

        private void btnBrowseData_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDataPath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void btnBrowseLog_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Seleccione la carpeta";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtDataPath.Text = folderDialog.SelectedPath;
                }
            }
        }
    }
}
