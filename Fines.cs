using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Model;
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
            }
            Cleaner();
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
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
