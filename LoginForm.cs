﻿using Cobrapp.Logic;
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
            string userPassword = txtPassword.Text;
            string configuredPassword = ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationPassword");
            if (userPassword == configuredPassword)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
            }
        }
    }

}
