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
            this.KeyPreview = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            Console.WriteLine(string.IsNullOrWhiteSpace(txtUsername.Text));
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Por favor, complete todos los campos.";
                lblError.Visible = true;
                return;
            }

            try
            {
                var (isAuthenticated, role) = ConfigurationLogic.Instance.Login(username, password);
                
                if (isAuthenticated)
                {
                    lblError.Visible = false;
                    MessageBox.Show($"Bienvenido, {username} (Rol: {role})", "Login Exitoso");
                    this.Hide();
                    Properties.Settings.Default.CurrentUser = username;
                    main mainForm = new main();
                    mainForm.Show();
                }
                else
                {
                    lblError.Text = "Usuario o contraseña incorrectos.";
                    txtPassword.Clear();
                    txtPassword.Focus();
                    lblError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar iniciar sesión.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Load");
            ConfigurationLogic.Instance.CreateDefaultRoles();
            ConfigurationLogic.Instance.EnsureDefaultAdminExists();
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
                Console.WriteLine("Enter");
            }
        }
    }
}
