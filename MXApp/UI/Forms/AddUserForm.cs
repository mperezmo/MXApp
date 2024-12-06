using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class AddUserForm : Form
    {
        private List<Familia> availableFamilies;

        public AddUserForm()
        {
            InitializeComponent();
            LoadRoles();
        }

        /// <summary>
        /// Carga los roles disponibles en el CheckedListBox.
        /// </summary>
        private void LoadRoles()
        {
            try
            {
                // Obtener las familias disponibles desde el servicio
                availableFamilies = FamiliaService.GetAllFamilias();

                // Agregar las familias al CheckedListBox
                checkedListBoxRoles.Items.Clear();
                foreach (var familia in availableFamilies)
                {
                    checkedListBoxRoles.Items.Add(familia.Nombre, false); // Mostrar el nombre de la familia
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los roles: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento del botón "Guardar".
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar datos del formulario
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    MessageBox.Show("Por favor, ingrese un nombre de usuario.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Por favor, ingrese una contraseña.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("La contraseña y la confirmación no coinciden.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Crear el nuevo usuario
                var newUser = new Usuario
                {
                    UserName = txtUsername.Text.Trim(),
                    Password = CryptographyService.HashMd5(txtPassword.Text.Trim()), // Hashear la contraseña
                };

                // Registrar el usuario
                UserService.Register(newUser.UserName, txtPassword.Text.Trim(), null);

                // Obtener las familias seleccionadas en el CheckedListBox
                var selectedFamilies = new List<Familia>();
                foreach (var item in checkedListBoxRoles.CheckedItems)
                {
                    // Buscar la familia correspondiente en la lista de disponibles
                    var roleName = item.ToString();
                    var familia = availableFamilies.Find(f => f.Nombre == roleName);

                    if (familia != null)
                    {
                        selectedFamilies.Add(familia);
                    }
                }

                if (selectedFamilies.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar al menos una familia para el usuario.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // Asignar las familias al usuario
                foreach (var familia in selectedFamilies)
                {
                    FamiliaService.AsignarFamiliaAUsuario(newUser.IdUsuario, familia);
                }

                MessageBox.Show($"Usuario '{newUser.UserName}' creado exitosamente con las familias seleccionadas.",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Limpiar el formulario
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}\n Detalles: {ex.StackTrace}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia los campos del formulario.
        /// </summary>
        private void ClearForm()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();

            for (int i = 0; i < checkedListBoxRoles.Items.Count; i++)
            {
                checkedListBoxRoles.SetItemChecked(i, false);
            }
        }

        /// <summary>
        /// Maneja el evento del botón "Cancelar".
        /// </summary>

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close(); // Cerrar el formulario
        }
    }
}
