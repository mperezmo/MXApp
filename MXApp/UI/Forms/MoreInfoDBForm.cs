using BLL;
using DAL.Contracts;
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
    public partial class MoreInfoDBForm : Form
    {
        private readonly string _instanceName;
        private readonly IDatabaseConnectionStrategy _connectionStrategy;

        public MoreInfoDBForm(string instanceName, IDatabaseConnectionStrategy connectionStrategy)
        {
            InitializeComponent();
            _instanceName = instanceName;
            _connectionStrategy = connectionStrategy;

            // Cargar datos iniciales
            LoadExpensiveQueries();
        }
        private void LoadExpensiveQueries()
        {
            try
            {
                // Llamar al servicio para obtener las consultas más costosas
                var expensiveQueries = PerformanceService.GetTopExpensiveQueries(_instanceName, _connectionStrategy);

                // Asignar los datos al DataGridView
                dataGridViewExpensiveQueries.DataSource = null;
                dataGridViewExpensiveQueries.DataSource = expensiveQueries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las consultas más costosas: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadExpensiveQueries();
        }
    }
}
