using Cobrapp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cobrapp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Por favor, complete todos los campos.";
                return;
            }

            var (isAuthenticated, role) = ConfigurationLogic.Instance.Login(username, password);

            if (isAuthenticated)
            {
                lblError.Text = ""; // Limpiar mensaje de error
                MessageBox.Show($"Bienvenido, {username} (Rol: {role})", "Login Exitoso");

                // Lógica para redirigir a la interfaz principal
                this.Hide();
                Properties.Settings.Default.CurrentUser = username;
                main mainForm = new main(); // Pasar el rol al formulario principal
                mainForm.Show();
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            ConfigurationLogic.Instance.CreateDefaultRoles();
            ConfigurationLogic.Instance.EnsureDefaultAdminExists();
        }
    }
}
