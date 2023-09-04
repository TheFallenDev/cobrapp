using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Model;
using Cobrapp.Logic;

namespace Cobrapp
{
    public partial class Total : Form
    {
        public Total()
        {
            InitializeComponent();
        }

        private void txt_date_KeyDown(object sender, KeyEventArgs e)
        {
            float acc = 0;
            if(e.KeyCode == Keys.Enter)
            {
                dtgv_taxes.DataSource = null;
                
                List<Tax> taxList = TaxLogic.Instance.ListByDate(txt_date.Text);
                foreach (var tax in taxList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = tax.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[1].Value = tax.Total;
                    dtgv_taxes.Rows[n].Cells[2].Value = tax.Due_date;
                    dtgv_taxes.Rows[n].Cells[3].Value = tax.TaxName;
                    acc += tax.Total;
                    txt_total.Text = acc.ToString();
                }

                List<Stamp> stampList = StampLogic.Instance.ListByDate(txt_date.Text);
                foreach (var stamp in stampList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = stamp.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[1].Value = stamp.Total;
                    dtgv_taxes.Rows[n].Cells[3].Value = "Sellado";
                    acc += stamp.Total;
                    txt_total.Text = acc.ToString();
                }
            }
        }
    }
}
