using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Printing;
using Cobrapp.Model;
using Cobrapp.Logic;

namespace Cobrapp
{
    public partial class Collector : Form
    {
        public Collector()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private int n = 0;
        private string receiptNumber = "";
        private int page = 0;

        private bool CheckDigit (string barcode)
        {
            int acc = 0;
            int checker = Int32.Parse(barcode[30].ToString());
            for (int i = 0; i < barcode.Length - 1; i++)
            {
                acc += Int32.Parse(barcode[i].ToString());
            }
            if (acc % 10 != checker)
            {
                MessageBox.Show("Código de barras incorrecto");
                Cleaner();
                return false;
            }
            return true;    
        }

        private void Cleaner ()
        {
            txt_barcode.Text = "";
            txt_barcode.Enabled = true;
            lbl_show_penalty.Text = "";
            lbl_show_tax.Text = "";
            lbl_show_due_date.Text = "";
            txt_amount.Text = "";
            txt_penalty_percentage.Text = "";
            txt_penalty.Text = "";
            txt_extra_penalty.Text = "";
            txt_tax_total.Text = "";
            lbl_show_due_days.Text = "";
            btn_add_tax.Enabled = false;
            receiptNumber = "";
        }

        private string TaxCheck (string taxNumber)
        {
            switch (taxNumber)
            {
                case "06":
                    return "TGI";
                case "13":
                    return "OSM";
                default:
                    return "ERROR EN LA BARRA";
            }
        }
         
        private string DateCheck(string dueDateStr,decimal amountDecimal)
        {
            DateTime todayDate = DateTime.Today;
            var cultureInfo = new CultureInfo("es-AR");
            DateTime dueDate = DateTime.ParseExact(dueDateStr, "ddMMyy", cultureInfo);
            if (DateTime.Compare(todayDate, dueDate) > 0)
            {
                lbl_show_due_date.ForeColor = Color.Red;
                PenaltiesCalculator(amountDecimal, todayDate, dueDate);
                return dueDate.ToString("dd/MM/yy");
            }
            lbl_show_due_date.ForeColor = Color.Black;
            txt_tax_total.Text = (Math.Round(amountDecimal, 2)).ToString();
            return dueDate.ToString("dd/MM/yy");
        }

        private void PenaltiesCalculator(decimal amountDecimal, DateTime todayDate, DateTime dueDate)
        {
            int differenceInDays = (todayDate - dueDate).Days;
            decimal calc = differenceInDays * Constants.Interest;
            decimal penalty = amountDecimal * (calc / 100);
            decimal totalWithPenalties = amountDecimal + penalty;
            if (differenceInDays > 60) {
                decimal extraPenalty = (Decimal.Multiply(amountDecimal, Constants.ExtraPenalty));
                totalWithPenalties += extraPenalty;
                txt_extra_penalty.Text = (Math.Round(extraPenalty, 2)).ToString();
            }
            lbl_show_due_days.Text = "Días de atraso: " + differenceInDays.ToString();
            txt_penalty_percentage.Text = (Math.Round(calc,2)).ToString() + " %";
            txt_penalty.Text = (Math.Round(penalty, 2)).ToString();
            txt_tax_total.Text = (Math.Round(totalWithPenalties, 2)).ToString();
        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            int textLength = txt_barcode.Text.Length;
            if (textLength == 31 && CheckDigit(txt_barcode.Text))
            {
                string taxNumber = txt_barcode.Text.Substring(4, 2);
                receiptNumber = txt_barcode.Text.Substring(6, 8);
                string dueDate = txt_barcode.Text.Substring(14, 6);
                string amount = txt_barcode.Text.Substring(20, 10);
                decimal amountDecimal = Decimal.Parse(amount) / 100;
                txt_barcode.Enabled = false;
                txt_amount.Text = (Math.Round(amountDecimal, 2)).ToString();
                lbl_show_tax.Text = TaxCheck(taxNumber);
                lbl_show_due_date.Text = DateCheck(dueDate, amountDecimal);
                if (!btn_add_tax.Enabled) btn_add_tax.Enabled = true;
            }
        }


        private void btn_add_tax_Click(object sender, EventArgs e)
        {
            string newReceiptNumber = receiptNumber.TrimStart('0'); // Obtén el valor actual de receiptNumber

            // Verifica si el receiptNumber ya existe en dtgv_taxes_list
            bool receiptNumberExists = false;
            foreach (DataGridViewRow row in dtgv_taxes_list.Rows)
            {
                string existingReceiptNumber = row.Cells[0].Value as string;
                if (existingReceiptNumber != null && existingReceiptNumber.Equals(newReceiptNumber))
                {
                    receiptNumberExists = true;
                    break;
                }
            }

            if (receiptNumberExists)
            {
                MessageBox.Show("¡Advertencia! Este número de recibo ya está en la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cleaner();
                txt_barcode.Focus();
            }
            else if (TaxLogic.Instance.SearchReceipt(newReceiptNumber))
            {
                MessageBox.Show("¡Advertencia! Este número de recibo ya ha sido cobrado previamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Cleaner(); // Ejecuta Cleaner() cuando SearchReceipt es verdadero
                txt_barcode.Focus();
            }
            else
            {
                int n = dtgv_taxes_list.Rows.Add();
                dtgv_taxes_list.Rows[n].Cells[0].Value = newReceiptNumber;
                dtgv_taxes_list.Rows[n].Cells[1].Value = lbl_show_tax.Text;
                dtgv_taxes_list.Rows[n].Cells[2].Value = lbl_show_due_date.Text;
                dtgv_taxes_list.Rows[n].Cells[3].Value = string.IsNullOrEmpty(txt_penalty.Text) ? "0" : txt_penalty.Text;
                dtgv_taxes_list.Rows[n].Cells[4].Value = string.IsNullOrEmpty(txt_extra_penalty.Text) ? "0" : txt_extra_penalty.Text;
                dtgv_taxes_list.Rows[n].Cells[5].Value = Decimal.Parse(txt_tax_total.Text);
                dtgv_taxes_list.Rows[n].Cells["amount"].Value = txt_amount.Text;


                if (string.IsNullOrEmpty(txt_penalty.Text))
                {
                    dtgv_taxes_list.Rows[n].Cells[3].Value = 0;
                    dtgv_taxes_list.Rows[n].Cells[4].Value = 0;
                }

                UpdateTotal();
                Cleaner();
                txt_barcode.Focus();
                if (!btn_collect_taxes.Enabled) btn_collect_taxes.Enabled = true;
            }
        }


        private void btn_cleaner_Click(object sender, EventArgs e)
        {
            Cleaner();
        }

        private void dtgv_taxes_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = e.RowIndex;
        }

        private void btn_remove_tax_Click(object sender, EventArgs e)
        {
            if (n != -1 && n < dtgv_taxes_list.Rows.Count)
            {
                dtgv_taxes_list.Rows.RemoveAt(n);
                UpdateTotal();
                txt_barcode.Focus();
            }
        }

        private void UpdateTotal()
        {
            decimal total = 0;
            foreach(DataGridViewRow row in dtgv_taxes_list.Rows)
            {
                if(row.Cells["partial"] != null)
                {
                    total += (Decimal)row.Cells["partial"].Value;
                }
            }
            txt_total.Text = total.ToString();
        }

        private void btn_collect_taxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (dtgv_taxes_list.Rows.Count > 0)
                {
                    PrintDocument printReceipt = new PrintDocument();
                    PrinterSettings ps = new PrinterSettings();
                    printReceipt.PrinterSettings = ps;
                    //printReceipt.DefaultPageSettings.PaperSize = new PaperSize("Receipt",500,1500);
                    printReceipt.PrintPage += (s, ev) => Print(s, ev);
                    printReceipt.Print();

                    foreach (DataGridViewRow row in dtgv_taxes_list.Rows)
                    {

                        Tax obj = new Tax()
                        {
                            TaxName = row.Cells["tax"].Value.ToString(),
                            Receipt_number = row.Cells["receiptNum"].Value.ToString(),
                            Due_date = row.Cells["due_date"].Value.ToString(),
                            Partial = row.Cells["amount"].Value.ToString(),
                            Additional = float.Parse(row.Cells["penalty"].Value.ToString()),
                            Delay = float.Parse(row.Cells["extra_penalty"].Value.ToString()),
                            Total = float.Parse(row.Cells["partial"].Value.ToString()),
                            Payment_date = DateTime.Now.ToString("yyyy/MM/dd"),
                            Payment_time = DateTime.Now.ToString("HH:mm:ss")
                        };

                        bool response = TaxLogic.Instance.Save(obj);
                    }

                    dtgv_taxes_list.Rows.Clear();
                    txt_total.Text = "";
                    btn_collect_taxes.Enabled = false;
                }
            }
        }

        private void Print (object sender, PrintPageEventArgs e)
        {
            string[] lines = File.ReadAllLines("models/ticket.txt");
            string file = "";
            Font font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            foreach (string line in lines)
            {
                file = file + Environment.NewLine + line;
            }
            int pages = dtgv_taxes_list.Rows.Count;
            string receipt;
            receipt = Replacer(file, dtgv_taxes_list.Rows[page]);
            e.Graphics.DrawString(receipt, font, Brushes.Black, new RectangleF(0,0,220,2000));
            page++;
            if(page < pages)
            {
            e.HasMorePages = true;
            }
            else 
            { 
                e.HasMorePages = false;
                page = 0;
            }
        }

        private string Replacer (string receipt, DataGridViewRow row)
        {
            receipt = receipt.Replace("BUSINESSNAME", ConfigurationLogic.Instance.GetConfigurationValue("BusinessName").ToUpper());
            receipt = receipt.Replace("ADDRESS", ConfigurationLogic.Instance.GetConfigurationValue("Address"));
            receipt = receipt.Replace("RECEIPTNUMBER", row.Cells["receiptNum"].Value.ToString());
            receipt = receipt.Replace("DATE", DateTime.Now.ToString());
            receipt = receipt.Replace("AMOUNT", row.Cells["amount"].Value.ToString());
            receipt = receipt.Replace("PENALTIES", row.Cells["penalty"].Value.ToString());
            receipt = receipt.Replace("EXTRAPENALTY", row.Cells["extra_penalty"].Value.ToString());
            receipt = receipt.Replace("TOTAL", row.Cells["partial"].Value.ToString());
            return receipt;
        }

        private void Collector_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                btn_add_tax.PerformClick();
            }
            else if(e.KeyCode == Keys.F12)
            {
                btn_collect_taxes_KeyDown(btn_collect_taxes,e);
            }
            else if(e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
    static class Constants
    {
        public const decimal Interest = 0.0667m;
        public const decimal ExtraPenalty = 0.1m;
    }
}
