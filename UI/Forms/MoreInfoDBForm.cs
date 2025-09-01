using BLL;
using DAL.Contracts;
using Domain;
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

        // Dentro de MoreInfoDBForm.cs
        // Dentro de MoreInfoDBForm.cs
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewExpensiveQueries.SelectedRows.Count > 0)
            {
                var selectedQuery = dataGridViewExpensiveQueries.SelectedRows[0].DataBoundItem as ExpensiveQuery;
                if (selectedQuery != null)
                {
                    string tableUsed = selectedQuery.TableUsed;
                    // Validar que se tenga un valor válido
                    if (string.IsNullOrWhiteSpace(tableUsed) || tableUsed.Equals("No se encontró FROM", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("La consulta seleccionada no contiene una tabla válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Crear instancia del BLL para índices
                    IndexBLL indexBLL = new IndexBLL(_connectionStrategy);
                    List<IndexInfo> indexes = indexBLL.GetIndexes(_instanceName, tableUsed);

                    // Abrir el formulario IndexForm pasando la lista de índices y el nombre de la tabla
                    IndexForm indexForm = new IndexForm(indexes, tableUsed);
                    indexForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione una consulta válida.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una consulta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
