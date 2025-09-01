using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using DAL.Contracts;
using DAL.Implementations.SQLServer;
using Domain;
using Services.DAL.Contracts; // Para IDatabaseConnectionStrategy
// using TuProyecto.ConnectionStrategies; // Descomenta y ajusta el namespace de tu estrategia

namespace UI.Forms
{
    public partial class ViewInstancesForm : Form
    {
        // Instancia de la capa BLL para interactuar con la lógica de negocio.
        InstanceBLL instanceBLL = new InstanceBLL();

        public ViewInstancesForm()
        {
            InitializeComponent();
            LoadInstances();
        }

        /// <summary>
        /// Carga las instancias registradas y las asigna al DataGridView.
        /// </summary>
        private void LoadInstances()
        {
            try
            {
                List<Instance> instances = instanceBLL.GetInstances();
                dataGridViewInstances.DataSource = instances;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las instancias: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en el botón "More Info".  
        /// Se obtiene la instancia seleccionada y se muestra su información detallada en DBInformationForm.
        /// </summary>
        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que exista una fila seleccionada.
                if (dataGridViewInstances.CurrentRow == null)
                {
                    MessageBox.Show("Por favor, seleccione una instancia de la lista.", "Advertencia",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el objeto Instance asociado a la fila seleccionada.
                Instance selectedInstance = dataGridViewInstances.CurrentRow.DataBoundItem as Instance;
                if (selectedInstance == null)
                {
                    MessageBox.Show("No se pudo determinar la instancia seleccionada.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear o recuperar una estrategia de conexión válida.
                // Reemplaza 'DefaultDatabaseConnectionStrategy' por tu implementación real de IDatabaseConnectionStrategy.
                IDatabaseConnectionStrategy connectionStrategy = new IntegratedAuthConnectionStrategy();

                // Recuperar la información detallada de la instancia usando la capa BLL.
                InstanceInfo instanceInfo = instanceBLL.GetInstanceInfo(selectedInstance.Name, connectionStrategy);

                // Crear y mostrar el formulario DBInformationForm, pasándole la información de la instancia.
                DBInformationForm dbInfo = new DBInformationForm(selectedInstance.Name, connectionStrategy);
                dbInfo.ShowDialog(); // Se muestra de forma modal
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener información de la instancia: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
