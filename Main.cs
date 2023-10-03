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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void btn_collect_taxes_Click(object sender, EventArgs e)
        {
            using (Collector taxCollector = new Collector()) 
                taxCollector.ShowDialog();    
        }

        private void btn_daily_total_Click(object sender, EventArgs e)
        {
            using (Total dailyTotal = new Total())
                dailyTotal.ShowDialog();
        }

        private void btn_stamps_Click(object sender, EventArgs e)
        {
            using (Stamps stamps = new Stamps())
                stamps.ShowDialog();
        }

        private void btn_commissions_Click(object sender, EventArgs e)
        {
            using (Commissions commissions = new Commissions())
                commissions.ShowDialog();
        }

        private void btn_void_payment_Click(object sender, EventArgs e)
        {
            using (VoidPayment payment = new VoidPayment())
                payment.ShowDialog();
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
                // Realiza la acción correspondiente al botón F2
            }
            else if (e.KeyCode == Keys.F4)
            {
                // Realiza la acción correspondiente al botón F2
                btn_void_payment.PerformClick(); // Esto simula un clic en el botón 2
            }
            else if (e.KeyCode == Keys.F5)
            {
                // Realiza la acción correspondiente al botón F2
                btn_daily_total.PerformClick(); // Esto simula un clic en el botón 2
            }
            else if (e.KeyCode == Keys.F6)
            {
                // Realiza la acción correspondiente al botón F2
                btn_commissions.PerformClick(); // Esto simula un clic en el botón 2
            }
        }

        private void credencialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Configuration configuration = new Configuration())
                configuration.ShowDialog();
        }
    }
}
