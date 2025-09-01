using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using BLL;
using DAL.Contracts;
using Services.Logic;

namespace UI.Forms
{
    public partial class ShrinkDatabaseForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public ShrinkDatabaseForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
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
            
            radioButtonData.CheckedChanged += radioButton_CheckedChanged;
            radioButtonLog.CheckedChanged += radioButton_CheckedChanged;
            LoadDatabases();
        }

        private void LoadDatabases()
        {
            try
            {
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

        // Evento que se dispara cuando se cambia la selección de los radio buttons.
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Solo actualizamos si el radio button que se marcó es el que está activo
            if (radioButtonData.Checked || radioButtonLog.Checked)
            {
                LoadDatabaseFiles();
            }
        }

        // Carga los nombres de archivos según el tipo seleccionado
        private void LoadDatabaseFiles()
        {
            try
            {
                string databaseName = comboBoxdatabases.SelectedItem?.ToString();
                

                if (string.IsNullOrEmpty(databaseName))
                    return;

                string fileType = radioButtonData.Checked ? "Data" : "Log";
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                List<string> fileNames = databaseBLL.GetDatabaseFiles(databaseName, fileType);

                comboBoxDBFiles.Items.Clear();
                foreach (var file in fileNames)
                {
                    comboBoxDBFiles.Items.Add(file);
                }

                if (comboBoxDBFiles.Items.Count > 0)
                    comboBoxDBFiles.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos de la base de datos: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnStartShrink_Click(object sender, EventArgs e)
        {
            string databaseName = comboBoxdatabases.SelectedItem.ToString();
            string databaseFile = comboBoxDBFiles.SelectedItem?.ToString();
            int shrinkInt = (int)numericUpDownSize.Value;

            if (string.IsNullOrEmpty(databaseFile))
            {
                MessageBox.Show("Seleccione un archivo de la base de datos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var databaseBLL = new DatabaseBLL(_instanceName, _connectionStrategy);
                databaseBLL.ShrinkBaseDeDatos(databaseName, databaseFile, shrinkInt);
                MessageBox.Show("Accion finalizada correctamente.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido realizar la accion solicitada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
