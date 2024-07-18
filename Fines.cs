using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Cobrapp.Logic;

namespace Cobrapp
{
    public partial class Fines : Form
    {
        public Fines()
        {
            InitializeComponent();
            KeyPreview = true;
            txt_barcode.Focus();
        }

        private string receiptNumber = "";
        private string taxNumber = "";
        private string period = "";
        private string dueDate = "";

        private bool IsDueDateValid(string taxNumber, string dueDate)
        {
            
            if (taxNumber == "19" || taxNumber == "16")
            {
                // Convertir la fecha del código de barras (formato ddMMyy) a DateTime
                DateTime dueDateTime;
                if (DateTime.TryParseExact(dueDate, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateTime))
                {
                    // Comparar la fecha actual con la fecha del código de barras
                    if (dueDateTime < DateTime.Now)
                    {
                        // La fecha está vencida
                        return false;
                    }
                }
            }

            // El taxNumber no es "19" ni "16", o la fecha no está vencida
            return true;
        }

        // Luego, en tu evento txt_barcode_TextChanged, puedes llamar a esta función para verificar la validez de la fecha:
        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            int textLength = txt_barcode.Text.Length;
            if (textLength == 34)
            {
                receiptNumber = txt_barcode.Text.Substring(4, 8);
                taxNumber = txt_barcode.Text.Substring(12, 2);
                period = txt_barcode.Text.Substring(14, 6);
                string amount = txt_barcode.Text.Substring(20, 8).Insert(6,",");
                dueDate = txt_barcode.Text.Substring(28, 6);
                decimal amountDecimal = Decimal.Parse(amount);
                txt_barcode.Enabled = false;
                lbl_receipt.Text = receiptNumber.TrimStart('0');
                lbl_amount.Text = (Math.Round(amountDecimal, 2)).ToString();
                string fineName = ConfigurationLogic.Instance.GetConfigurationKey(taxNumber);
                if (fineName != null && fineName.Contains("fine_"))
                {
                    fineName = fineName.Split('_')[1];
                    lbl_show_tax.Text = fineName;
                }
                else
                {
                    MessageBox.Show("¡Advertencia! Código no reconocido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cleaner();
                }
            }
        }

        private void Collect(string receiptNumber, string code, string period, float total, string dueDate, string paymentDate, string paymentTime)
        {
            // Verificar si la fecha es válida
            if (!IsDueDateValid(taxNumber, dueDate))
            {
                MessageBox.Show("¡Advertencia! Las estadías no pueden pagarse una vez vencidas. Se debe generar una nueva boleta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                FineLogic.Instance.AddFine(receiptNumber, code, period, total, dueDate, paymentDate, paymentTime);
                Printer();
            }
            Cleaner();
        }

        private void Printer()
        {
            PrintDocument printReceipt = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = "tickera";
            printReceipt.PrinterSettings = ps;
            printReceipt.DefaultPageSettings.PaperSize = new PaperSize("Custom", 299, 842);
            printReceipt.PrintPage += (s, ev) => Print(s, ev);
            printReceipt.Print();
        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            string[] lines = File.ReadAllLines("models/ticket-multa.txt");
            string file = "";
            Font font = new Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point);
            foreach (string line in lines)
            {
                file = file + Environment.NewLine + line;
            }
            string receipt;
            receipt = Replacer(file);
            e.Graphics.DrawString(receipt, font, Brushes.Black, new RectangleF(0, 0, 220, 2000));
        }

        private string Replacer(string receipt)
        {
            string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
            receipt = receipt.Replace("BUSINESSNAME", ConfigurationLogic.Instance.GetConfigurationValue("BusinessName").ToUpper());
            receipt = receipt.Replace("ADDRESS", ConfigurationLogic.Instance.GetConfigurationValue("Address"));
            receipt = receipt.Replace("RECEIPTNUMBER", businessCode + lbl_receipt.Text);
            receipt = receipt.Replace("TICKETNUMBER", lbl_receipt.Text);
            receipt = receipt.Replace("DESCRIPTION", lbl_show_tax.Text);
            receipt = receipt.Replace("DATE", DateTime.Now.ToString("dd/MM/yy hh:mm:ss").ToString());
            receipt = receipt.Replace("TOTAL", lbl_amount.Text);
            return receipt;
        }

        private void Cleaner()
        {
            txt_barcode.Text = "";
            txt_barcode.Enabled = true;
            lbl_amount.Text = "";
            lbl_show_tax.Text = "";
            lbl_receipt.Text = "";
            receiptNumber = "";
            txt_barcode.Focus();
            taxNumber = "";
            period = "";
            dueDate = "";
    }

        private void Fines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                string payment_date = DateTime.Now.ToString("yyyy/MM/dd");
                string payment_time = DateTime.Now.ToString("hh:mm:ss");
                Collect(lbl_receipt.Text,taxNumber,period,float.Parse(lbl_amount.Text),dueDate,payment_date,payment_time);
            }
        }
    }
}
