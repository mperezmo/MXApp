using Services.Domain;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services.Facade;

namespace UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            try
            {
                if (UserService.Login(username, password))
                {
                    Usuario user = UserService.GetUsuarioByUsername(username);
                    SessionService.UsuarioLogueado = user;

                    // Ocultar el formulario de login
                    this.Hide();

                    // Obtener MainFrm desde el contenedor de dependencias
                    MainForm mainForm = new MainForm();
                    mainForm.Show();

                    // Suscribirse al evento FormClosed para cerrar el formulario de login después
                    mainForm.FormClosed += (s, args) => this.Close();

                    LoggerService.WriteLog($"El usuario {username} inició sesión correctamente.", TraceLevel.Info);

                }
                else
                {
                    LoggerService.WriteLog($"Intento fallido de inicio de sesión por el usuario {username}.", TraceLevel.Warning);
                    MessageBox.Show("Inicio de sesión fallido. Verifique su nombre de usuario y contraseña.");
                }
            }
            catch (Exception ex)
            {
                LoggerService.WriteException(ex);

                MessageBox.Show($"Ocurrió un error durante el inicio de sesión. Detalles: {ex.Message}");
            }
        }
    }
}
