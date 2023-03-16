using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Cobrapp
{
    public partial class Collector : Form
    {
        public Collector()
        {
            InitializeComponent();
        }

        private void Cleaner ()
        {
            txt_barcode.Text = "";
            txt_barcode.Enabled = true;
            lbl_show_account.Text = "";
            lbl_show_penalty.Text = "";
            lbl_show_period.Text = "";
            lbl_show_tax.Text = "";
            lbl_show_due_date.Text = "";
            txt_amount.Text = "";
        }

        private string TaxCheck (string taxNumber)
        {
            switch (taxNumber)
            {
                case "06":
                    return "TGI";
                case "13":
                    return "OSM";
                case "39":
                    return "COM";
                default:
                    return "ERROR EN LA BARRA";
            }
        }

        

        private string AmountFixer(string amount)
        {
            amount = amount.Insert(8, ".");
            amount = string.Format("{0:0.00}", amount);
            amount = amount.TrimStart('0');
            return amount;
        }

        private string DateCheck(string dueDateStr,string amount)
        {
            DateTime todayDate = DateTime.Today;
            var cultureInfo = new CultureInfo("es-AR");
            DateTime dueDate = DateTime.ParseExact(dueDateStr, "ddMMyy", cultureInfo);
            if (DateTime.Compare(todayDate, dueDate) > 0)
            {
                lbl_show_due_date.ForeColor = Color.Red;
                PenaltiesCalculator(amount, todayDate, dueDate);
                return dueDate.ToString("dd/MM/yy");
            }
            lbl_show_due_date.ForeColor = Color.Black;
            return dueDate.ToString("dd/MM/yy");
        }

        private decimal PenaltiesCalculator(string amount, DateTime todayDate, DateTime date)
        {
            txt_penalty.Text = "30.46";
            return 30.46m;
        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            int textLength = txt_barcode.Text.Length;
            if (textLength == 31)
            {
                string taxNumber = txt_barcode.Text.Substring(4, 2);
                string dueDate = txt_barcode.Text.Substring(14, 6);
                string amount = txt_barcode.Text.Substring(20, 10);
                string checkDigit = txt_barcode.Text.Substring(30);
                string fixedAmount = AmountFixer(amount);
                txt_barcode.Enabled = false;
                lbl_show_tax.Text = TaxCheck(taxNumber);
                txt_penalty.Text = "0.00";
                lbl_show_due_date.Text = DateCheck(dueDate, fixedAmount);
                txt_amount.Text = fixedAmount;
            }
        }

        private void btn_add_tax_Click(object sender, EventArgs e)
        {
            int n = dtgv_taxes_list.Rows.Add();

            dtgv_taxes_list.Rows[n].Cells[1].Value = lbl_show_tax.Text;
            dtgv_taxes_list.Rows[n].Cells[3].Value = lbl_show_due_date.Text;
            dtgv_taxes_list.Rows[n].Cells[5].Value = txt_tax_total.Text;

            Cleaner();
        }

        private void btn_cleaner_Click(object sender, EventArgs e)
        {
            Cleaner();
        }
    }
}
