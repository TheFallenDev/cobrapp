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
    }
}
