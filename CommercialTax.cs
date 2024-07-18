using System;
using System.Globalization;
using System.Windows.Forms;
using Cobrapp.Logic;
using Cobrapp.Model;

namespace Cobrapp
{
    public partial class CommercialTax : Form
    {
        public CommercialTax()
        {
            InitializeComponent();
        }

        private string receiptNumber;
        private string taxNumber;
        private string receiptDueDate;
        private string amount;
        private decimal calculatedTaxWithCommon;
        private readonly CultureInfo cultureInfo = new CultureInfo("es-AR");

        private void txt_period_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (PeriodsLogic.Instance.DoesPeriodExist(txt_period.Text))
                {
                    Period period = PeriodsLogic.Instance.GetPeriod(txt_period.Text, "COM");
                    txt_due_date.Text = period.DueDate;
                    txt_due_date.Enabled = false;
                    txt_due_date.Visible = true;
                    lbl_unknown_period.Visible = false;
                    txt_barcode.Focus();
                    IsOverdue(txt_due_date.Text);
                }
                else if (string.IsNullOrEmpty(txt_period.Text))
                {
                    MessageBox.Show("Debe completar todos los campos correctamente.");
                }
                else
                {
                    txt_due_date.Visible = true;
                    txt_due_date.Text = "";
                    txt_due_date.Enabled = true;
                    txt_due_date.Focus();
                    lbl_unknown_period.Visible = true;
                }
            }
        }

        private void txt_due_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txt_period.Text))
                {
                    txt_barcode.Focus();
                    txt_barcode.Enabled = true;
                    IsOverdue(txt_due_date.Text);
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos correctamente.");
                }
            }
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int textLength = txt_barcode.Text.Length;
                if (textLength != 31)
                {
                    MessageBox.Show("Código incompleto o erróneo.");
                }
                txt_calculated_tax.Focus();
            }
        }

        private void IsOverdue(string dueDate)
        {
            DateTime parsedDueDate = DateTime.ParseExact(dueDate, "dd/MM/yyyy", cultureInfo);
            if (parsedDueDate < DateTime.Today)
            {
                lbl_overdue_period.Visible = true;
                lbl_calculated_tax.Visible = true;
                lbl_retentions.Visible = true;
                txt_calculated_tax.Visible = true;
                txt_retentions.Visible = true;
                lbl_additional_label.Visible = true;
                lbl_delay_label.Visible = true;
            }
            else
            {
                lbl_overdue_period.Visible = false;
                lbl_calculated_tax.Visible = false;
                lbl_retentions.Visible = false;
                txt_calculated_tax.Visible = false;
                txt_retentions.Visible = false;
                lbl_additional_label.Visible = false;
                lbl_delay_label.Visible = false;
            }
        }
        
        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            int textLength = txt_barcode.Text.Length;
            if (textLength == 31 && CheckDigit(txt_barcode.Text))
            {
                taxNumber = txt_barcode.Text.Substring(4, 2);
                receiptNumber = txt_barcode.Text.Substring(6, 8);
                receiptDueDate = txt_barcode.Text.Substring(14, 6);
                amount = txt_barcode.Text.Substring(20, 10);
                decimal amountDecimal = Decimal.Parse(amount) / 100;
                txt_barcode.Enabled = false;
            }
        }

        private void DateCheck(string dueDateStr)
        {
            DateTime todayDate = DateTime.Today;
            DateTime dueDate = DateTime.ParseExact(dueDateStr, "dd/MM/yyyy", cultureInfo);
            if (DateTime.Compare(todayDate, dueDate) > 0)
            {
                decimal calculatedTax = Convert.ToDecimal(txt_calculated_tax.Text);
                decimal retentions = Convert.ToDecimal(txt_retentions.Text);
                PenaltiesCalculator(calculatedTax, retentions, todayDate, dueDate);
            }
        }

        private void PenaltiesCalculator(decimal calculatedTax, decimal retentions, DateTime todayDate, DateTime dueDate)
        {
            decimal extraPenalty;
            calculatedTaxWithCommon = (calculatedTax + (calculatedTax * 12) / 100) - Convert.ToDecimal(txt_retentions.Text);
            decimal additionalPenalty = decimal.Parse(ConfigurationLogic.Instance.GetConfigurationValue("AdditionalPenalty"));
            decimal delayPenalty = decimal.Parse(ConfigurationLogic.Instance.GetConfigurationValue("DelayPenalty"));
            int differenceInDays = (todayDate - dueDate).Days;
            decimal calc = differenceInDays * additionalPenalty;
            decimal penalty = calculatedTaxWithCommon * (calc / 100);
            decimal totalWithPenalties = calculatedTaxWithCommon + penalty;
            if (differenceInDays > 60)
            {
                extraPenalty = (calculatedTaxWithCommon * delayPenalty) / 100;
                totalWithPenalties += extraPenalty;
                lbl_delay.Text = extraPenalty.ToString("N2");
                lbl_delay.Visible = true;
            }
            lbl_show_due_days.Text = "Días de atraso: " + differenceInDays.ToString();
            lbl_show_due_days.Visible = true;
            lbl_penalty_percentage.Text = calc.ToString("N2") + " %";
            lbl_penalty_percentage.Visible = true;
            lbl_additional.Text = penalty.ToString("N2");
            lbl_additional.Visible = true;
            lbl_total.Text = (totalWithPenalties + 50).ToString("N2");
            lbl_total.Visible = true;
        }

        private bool CheckDigit(string barcode)
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
                txt_barcode.Text = "";
                return false;
            }
            return true;
        }

        private void txt_calculated_tax_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_calculated_tax.Text))
                {
                    MessageBox.Show("Debe completar todos los campos correctamente.");
                }
                else
                {
                    txt_calculated_tax.Text = txt_calculated_tax.Text.Replace(".", ",");
                    txt_retentions.Focus();
                }
            }
        }

        private void txt_retentions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt_calculated_tax.Text) && string.IsNullOrEmpty(txt_retentions.Text))
                {
                    MessageBox.Show("Debe completar todos los campos correctamente.");
                }
                else
                {
                    txt_retentions.Text = txt_retentions.Text.Replace(".", ",");
                    DateCheck(txt_due_date.Text);
                }
            }
        }

        private void txt_period_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito numérico, suprimir el caracter
                e.Handled = true;
            }
        }

        private void txt_due_date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '/' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número ni el carácter '/', o no es una tecla de retroceso (Backspace),
                // entonces se ignora la pulsación de tecla
                e.Handled = true;
            }
        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un dígito numérico, suprimir el caracter
                e.Handled = true;
            }
        }

        private void txt_calculated_tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número ni el carácter '.', o no es una tecla de retroceso (Backspace),
                // entonces se ignora la pulsación de tecla
                e.Handled = true;
            }
        }

        private void txt_retentions_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número ni el carácter '.', o no es una tecla de retroceso (Backspace),
                // entonces se ignora la pulsación de tecla
                e.Handled = true;
            }
        }

        private void Cleaner()
        {
            txt_retentions.Text = "";
            txt_period.Text = "";
            txt_due_date.Text = "";
            txt_calculated_tax.Text = "";
            txt_barcode.Text = "";
            lbl_penalty_percentage.Visible = false;
            lbl_unknown_period.Visible = false;
            lbl_overdue_period.Visible = false;
            lbl_show_due_days.Visible = false;
            lbl_overdue_period.Visible = false;
            lbl_calculated_tax.Visible = false;
            lbl_retentions.Visible = false;
            txt_calculated_tax.Visible = false;
            txt_retentions.Visible = false;
            lbl_additional_label.Visible = false;
            lbl_delay_label.Visible = false;
            lbl_total.Visible = false;
        }

        private void Collect()
        {
            try
            {
                Save();
                //Print();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Save()
        {
            DateTime parsedDueDate = DateTime.ParseExact(txt_due_date.Text, "dd/MM/yyyy", cultureInfo);
            string partial;
            float additional;
            float delay;
            if (parsedDueDate < DateTime.Today)
            {
                partial = (calculatedTaxWithCommon + 50).ToString();
                additional = float.Parse(lbl_additional.Text);
                delay = float.Parse(lbl_delay.Text);
            }
            else
            {
                partial = lbl_total.Text;
                additional = 0;
                delay = 0;
            }
            Tax tax = new Tax()
            {
                TaxName = "COM",
                Receipt_number = receiptNumber,
                Due_date = txt_due_date.Text,
                Partial = partial,
                Additional = additional,
                Delay = delay,
                Total = decimal.Parse(lbl_total.Text),
                Payment_date = DateTime.Now.ToString("yyyy/MM/dd"),
                Payment_time = DateTime.Now.ToString("HH:mm:ss")
            };

            bool response = TaxLogic.Instance.Save(tax);
            if (!response)
            {
                throw new Exception("Error al guardar");
            }
        }

        private void CommercialTax_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F12)
            {
                Collect();
            }
        }
    }
}
