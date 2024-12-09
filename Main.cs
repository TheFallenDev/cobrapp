using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Cobrapp.Logic;
using Cobrapp.Utils;

namespace Cobrapp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void entranceMode()
        {
            bool entranceActive = Properties.Settings.Default.EntranceMode;
            if ( entranceActive )
            {
                btn_collect_taxes.Text = "Cobrar entradas - F1";
                btn_daily_total.Location = new Point(0, 172);
                btn_CommercialTax.Visible = false;
                btn_stamps.Visible = false;
                btn_void_payment.Visible = false;
                btn_commissions.Visible = false;
                btn_fines.Visible = false;
                panel2.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
            }
            else
            {
                btn_collect_taxes.Text = "Cobrar tasas - F1";
                btn_daily_total.Location = new Point(0, 323);
                btn_CommercialTax.Visible = true;
                btn_stamps.Visible = true;
                btn_void_payment.Visible = true;
                btn_commissions.Visible = true;
                btn_fines.Visible= true;
                panel2.Visible = true;
                panel5.Visible = true;
                panel6.Visible = true;
                panel7.Visible = true;
                panel8.Visible = true;
            }
        }

        private void btn_collect_taxes_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else if (Properties.Settings.Default.EntranceMode)
            {
                OpenNewForm(new Entrance());
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

        private void btn_Main_Click(object sender, EventArgs e)
        {
            OpenNewForm(new MainChild());
        }

        private void btn_CommercialTax_Click(object sender, EventArgs e)
        {
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenNewForm(new Configuration());
            }
            else
            {
                OpenNewForm(new CommercialTax());
            }
        }

        private void main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btn_collect_taxes.PerformClick();
            }
            else if (e.KeyCode == Keys.F2 && !Properties.Settings.Default.EntranceMode)
            {
                btn_stamps.PerformClick();
            }
            else if (e.KeyCode == Keys.F3 && !Properties.Settings.Default.EntranceMode)
            {
                btn_fines.PerformClick();
            }
            else if (e.KeyCode == Keys.F4 && !Properties.Settings.Default.EntranceMode)
            {
                btn_CommercialTax.PerformClick();
            }
            else if (e.KeyCode == Keys.F5 && !Properties.Settings.Default.EntranceMode)
            {
                btn_void_payment.PerformClick();
            }
            else if (e.KeyCode == Keys.F6)
            {
                btn_daily_total.PerformClick();
            }
            else if (e.KeyCode == Keys.F7 && !Properties.Settings.Default.EntranceMode)
            {
                btn_commissions.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btn_Main_Click(null, e);
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

        private void OpenProtectedArea()
        {
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    OpenNewForm(new Configuration());
                }
            }
        }

        private void btn_Configuration_Click(object sender, EventArgs e)
        {
            OpenProtectedArea();
        }
        private void main_Load(object sender, EventArgs e)
        {
            entranceMode();
            if (ConfigurationLogic.Instance.GetConfigurationValue("ConfigurationOK") != "OK")
            {
                OpenNewForm(new Configuration());
                MessageBox.Show("Antes de continuar debe rellenar las configuraciones para que el programa funcione correctamente.", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btn_Main_Click(null, e);
            }

            if (!MyUtils.PrinterExists("tickera") && !MyUtils.PrinterExists("tickerausb"))
            {
                MessageBox.Show("Se requiere tener una impresora instalada con el nombre 'tickera' o 'tickeraUSB'.");
            }
        }
    }
}
