using BLL;
using DAL.Contracts;
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
    public partial class DeleteDatabaseForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public DeleteDatabaseForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
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

            LoadDatabases();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre para la base de datos.",
                                      "Validación",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    return;
                }

                if (radioBtnLastBackup.Checked)
                {
                    string databaseName = comboBox1.Text;
                    string backupType = "FULL";
                    var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                    databaseBLL.TakeBackup(databaseName,backupType);

                    databaseBLL.EliminarBaseDeDatos(databaseName);
                    MessageBox.Show($"Backup de la base de datos tomado exitosamente. Base de datos '{databaseName}' se eliminó correctamente.",
                                   "Éxito",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    string databaseName = comboBox1.Text;
                    var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                                        databaseBLL.EliminarBaseDeDatos(databaseName);
                    MessageBox.Show($"Base de datos '{databaseName}' se eliminó correctamente.",
                                   "Éxito",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la base de datos: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LoadDatabases()
        {
            try
            {
                // Obtener la lista de bases de datos desde la capa de servicios
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                var databases = databaseBLL.GetDatabases(); // Método para listar bases de datos

                comboBox1.Items.Clear();
                foreach (var db in databases)
                {
                    comboBox1.Items.Add(db.DatabaseName);
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0; // Seleccionar el primer elemento por defecto
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
    }
}
