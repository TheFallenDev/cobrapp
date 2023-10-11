using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Cobrapp.Logic;

namespace Cobrapp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void btn_collect_taxes_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new Collector());
            }
        }

        private void btn_daily_total_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new Total());
            }
        }

        private void btn_stamps_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new Stamps());
            }
        }

        private void btn_commissions_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new Commissions());
            }
        }

        private void btn_void_payment_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new VoidPayment());
            }
        }

        private void btn_fines_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new Fines());
            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Realiza la acción correspondiente al botón F1
                btn_collect_taxes.PerformClick(); // Esto simula un clic en el botón 1
            }
            else if (e.KeyCode == Keys.F2)
            {
                // Realiza la acción correspondiente al botón F2
                btn_stamps.PerformClick(); // Esto simula un clic en el botón 2
            }
            else if (e.KeyCode == Keys.F3)
            {
                btn_fines.PerformClick();
                // Realiza la acción correspondiente al botón F3
                
            }
            else if (e.KeyCode == Keys.F4)
            {
                // Realiza la acción correspondiente al botón F4
                btn_void_payment.PerformClick(); // Esto simula un clic en el botón 2
            }
            else if (e.KeyCode == Keys.F5)
            {
                // Realiza la acción correspondiente al botón F5
                btn_daily_total.PerformClick(); // Esto simula un clic en el botón 2
            }
            else if (e.KeyCode == Keys.F6)
            {
                // Realiza la acción correspondiente al botón F6
                btn_commissions.PerformClick(); // Esto simula un clic en el botón 2
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btn_maximize.Visible = false;
            btn_restore.Visible = true;
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            WindowState=FormWindowState.Normal;
            btn_restore.Visible = false;
            btn_maximize.Visible= true;
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void UpperBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        public void OpenNewForm(object newForm)
        {
            if(panelContainer.Controls.Count > 0)
                panelContainer.Controls.RemoveAt(0);
            Form nf = newForm as Form;

            if(nf != null)
            {
                nf.TopLevel = false;
                nf.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(nf);
                panelContainer.Tag = nf;
                nf.Show();
                nf.Focus();
            }
        }

        private void btn_Configuration_Click(object sender, EventArgs e)
        {
            OpenNewForm(new Configuration());
        }

        private void main_Load(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                OpenNewForm(new Configuration());
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PasswordCheck()
        {

        }
    }
}
