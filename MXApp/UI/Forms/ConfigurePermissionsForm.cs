using Services.Domain;
using Services.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace UI.Forms
{
    public partial class ConfigurePermissionsForm : Form
    {
        private List<Usuario> users;
        private readonly Usuario currentUser;
        private List<Patente> availablePatentes;

        public ConfigurePermissionsForm(Usuario currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            LoadUsers();
            LoadRoles();

            // Evento para actualizar roles cuando cambia el usuario seleccionado
            comboBoxUsers.SelectedIndexChanged += comboBoxUsers_SelectedIndexChanged;
        }

        private void LoadUsers()
        {
            try
            {
                users = UserService.GetAllUsuarios();

                // Excluir al usuario actual si existe
                if (currentUser != null)
                {
                    users = users.Where(u => u.IdUsuario != currentUser.IdUsuario).ToList();
                }

                comboBoxUsers.Items.Clear();
                foreach (var user in users)
                {
                    comboBoxUsers.Items.Add(user.UserName);
                }

                if (comboBoxUsers.Items.Count > 0)
                {
                    comboBoxUsers.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void comboBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUsers.SelectedItem != null)
            {
                string selectedUserName = comboBoxUsers.SelectedItem.ToString();
                var selectedUser = users.Find(u => u.UserName == selectedUserName);

                Usuario usuario = UserService.GetUsuarioByUsername(selectedUserName);

                // Llamamos al método que obtiene todas las patentes (permisos)
                availablePatentes = FamiliaService.GetAllPatentes();

                checkedListBoxRoles.Items.Clear();

                foreach (var role in availablePatentes)
                {
                    int index = checkedListBoxRoles.Items.Add(role.Nombre);
                    bool isAssigned = selectedUser.Accesos.Any(r => r.Id == role.Id);
                    checkedListBoxRoles.SetItemChecked(index, isAssigned);
                }


                /*if (selectedUser != null)
                {
                    UpdateCheckedRoles(selectedUser);
                }*/
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUsers.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un usuario.",
                                    "Validación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                var selectedUserName = comboBoxUsers.SelectedItem.ToString();
                var selectedUser = users.FirstOrDefault(u => u.UserName == selectedUserName);

                if (selectedUser == null)
                {
                    MessageBox.Show("Usuario seleccionado no encontrado.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                var confirmResult = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al usuario '{selectedUser.UserName}'?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    UserService.RemoveUser(selectedUser.IdUsuario);

                    MessageBox.Show("Usuario eliminado correctamente.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadRoles()
        {
            try
            {
                availablePatentes = FamiliaService.GetAllPatentes();

                checkedListBoxRoles.Items.Clear();
                foreach (var patente in availablePatentes)
                {
                    checkedListBoxRoles.Items.Add(patente.Nombre, false);
                }

                // Si ya hay un usuario seleccionado, actualizar roles
                if (comboBoxUsers.SelectedItem != null)
                {
                    string selectedUserName = comboBoxUsers.SelectedItem.ToString();
                    var selectedUser = users.FirstOrDefault(u => u.UserName == selectedUserName);

                    if (selectedUser != null)
                    {
                        UpdateCheckedRoles(selectedUser);
                    }
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

        private void UpdateCheckedRoles(Usuario selectedUser)
        {
            // Desmarcar todo
            for (int i = 0; i < checkedListBoxRoles.Items.Count; i++)
            {
                checkedListBoxRoles.SetItemChecked(i, false);
            }

            // Marcar roles que el usuario ya tiene según sus accesos actuales
            for (int i = 0; i < checkedListBoxRoles.Items.Count; i++)
            {
                string roleName = checkedListBoxRoles.Items[i].ToString();
                bool userHasRole = selectedUser.Accesos
                                               .OfType<Familia>()
                                               .Any(f => f.Nombre == roleName);

                if (userHasRole)
                {
                    checkedListBoxRoles.SetItemChecked(i, true);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUsers.SelectedItem is string selectedUserName)
                {
                    var selectedUser = users.FirstOrDefault(u => u.UserName == selectedUserName);

                    if (selectedUser != null)
                    {
                        var selectedPatentes = new List<Patente>();
                        foreach (var item in checkedListBoxRoles.CheckedItems)
                        {
                            var roleName = item.ToString();
                            var patente = availablePatentes.FirstOrDefault(f => f.Nombre == roleName);
                            if (patente != null)
                            {
                                selectedPatentes.Add(patente);
                            }
                        }

                        if (selectedPatentes.Count == 0)
                        {
                            MessageBox.Show("Debe seleccionar al menos un rol para el usuario.",
                                            "Validación",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Warning);
                            return;
                        }

                        UserService.UpdateUserAccesos(selectedUser.IdUsuario, selectedPatentes.Cast<Acceso>().ToList());

                        MessageBox.Show("Permisos actualizados correctamente.",
                                        "Éxito",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para guardar los cambios.",
                                    "Advertencia",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ConfigurePermissionsForm_Load(object sender, EventArgs e)
        {
            // Acción opcional al cargar el formulario
        }
    }
}
