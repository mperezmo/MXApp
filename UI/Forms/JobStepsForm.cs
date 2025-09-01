using System;
using System.Windows.Forms;
using BLL;
using Domain;
using DAL.Contracts;

namespace UI.Forms
{
    public partial class JobStepsForm : Form
    {
        private readonly SQLJob _job;
        private readonly SQLJobBLL _jobBLL;
        private readonly string _instanceName;

        public JobStepsForm(SQLJob job, IDatabaseConnectionStrategy connectionStrategy, string instanceName)
        {
            InitializeComponent();
            _instanceName = instanceName;
            _job = job;
            _jobBLL = new SQLJobBLL(connectionStrategy, _instanceName);
            this.Text = "Job Steps for: " + _job.Name;
            LoadJobSteps();
            LoadJobScheduleInfo();
        }

        private void LoadJobSteps()
        {
            try
            {
                var steps = _jobBLL.GetJobSteps(_job.JobId);
                dataGridViewJobSteps.DataSource = steps;
                dataGridViewJobSteps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los pasos del job: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadJobScheduleInfo()
        {
            try
            {
                var scheduleInfo = _jobBLL.GetJobScheduleInfo(_job.JobId);
                dataGridSchedule.DataSource = scheduleInfo;
                dataGridSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el schedule del job: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JobStepsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
