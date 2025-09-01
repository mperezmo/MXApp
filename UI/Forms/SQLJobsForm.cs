using System;
using System.Windows.Forms;
using BLL;
using Domain;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using System.Collections.Generic;

namespace UI.Forms
{
    public partial class SQLJobsForm : Form
    {
        // private readonly SQLJobBLL _jobBLL;
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public SQLJobsForm(IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            InitializeComponent();
            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;
            
            LoadSQLJobs();
        }

        private void LoadSQLJobs()
        {
            try
            {
                SQLJobBLL _sqlJobBLL = new SQLJobBLL(_connectionStrategy, _instanceName);

                List<SQLJob> sqlJob = _sqlJobBLL.GetSQLJobs();
                //var jobs = _jobBLL.GetSQLJobs();
                dataGridViewJobs.DataSource = sqlJob;
                dataGridViewJobs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los SQL Jobs: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnViewJobSteps_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewJobs.SelectedRows.Count > 0)
            {
                // Se asume que el DataGridView tiene SelectionMode = FullRowSelect.
                var selectedJob = dataGridViewJobs.SelectedRows[0].DataBoundItem as SQLJob;
                if (selectedJob != null)
                {
                    // Abrir el formulario JobStepsForm pasando el job seleccionado y la estrategia de conexión.
                    JobStepsForm jobStepsForm = new JobStepsForm(selectedJob, _connectionStrategy, _instanceName);
                    jobStepsForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione un job válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un job.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
