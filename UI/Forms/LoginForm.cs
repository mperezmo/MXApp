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
using Services.DAL.Contracts;
using Services.DAL.Strategy;
using Services.Logic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using System.Threading;

namespace UI.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            // Cargar el idioma guardado (por defecto "es-ES" si no se ha guardado ninguno)
            string userLanguage = LanguageLogic.LoadUserLanguage();

            // Actualizar la cultura del hilo actual
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(userLanguage);

            // Traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);
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

        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Establece el idioma español
            string languageCode = "es-ES";
            LanguageLogic.SaveUserLanguage(languageCode);

            // Actualiza la cultura actual para el hilo de la UI
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCode);

            // Vuelve a traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);

            // Opcional: registrar la acción
            LoggerService.WriteLog("Idioma cambiado a español", System.Diagnostics.TraceLevel.Info);
        }

        private void inglesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Establece el idioma inglés
            string languageCode = "en-US";
            LanguageLogic.SaveUserLanguage(languageCode);

            // Actualiza la cultura actual para el hilo de la UI
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCode);

            // Vuelve a traducir todos los controles del formulario
            LanguageLogic.TranslateForm(this);

            // Opcional: registrar la acción
            LoggerService.WriteLog("Language changed to English", System.Diagnostics.TraceLevel.Info);
        }

        private void checkBoxShowPWD_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPWD.Checked) { txtPassword.UseSystemPasswordChar = false; }
            if (!(checkBoxShowPWD.Checked)) { txtPassword.UseSystemPasswordChar = true; }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
               $"¿Quieres configurar la aplicacion por primera vez?", "",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AppConfigurationForm appConfigurationForm = new AppConfigurationForm();
                appConfigurationForm.Show();
                this.Hide();
            }
        }
    }
}
