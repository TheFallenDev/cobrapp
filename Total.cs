using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Cobrapp.Model;
using Cobrapp.Logic;
using Cobrapp.Utils;
using System.Drawing.Printing;
using System.IO;
using System.Threading.Tasks;


namespace Cobrapp
{
    public partial class Total : Form
    {
        public Total()
        {
            InitializeComponent();
            dtp_date.Value = DateTime.Now;
            dtp_date.Focus();
            KeyPreview = true;
        }

        private void dtp_date_KeyDown(object sender, KeyEventArgs e)
        {
            float acc = 0;
            if (e.KeyCode == Keys.Enter)
            {
                dtgv_taxes.Rows.Clear();

                List<Tax> taxList = TaxLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var tax in taxList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = tax.Payment_time;
                    dtgv_taxes.Rows[n].Cells[1].Value = tax.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[2].Value = tax.Total.ToString("0.00");
                    dtgv_taxes.Rows[n].Cells[3].Value = tax.Due_date;
                    dtgv_taxes.Rows[n].Cells[4].Value = tax.TaxName;
                    dtgv_taxes.Rows[n].Cells[5].Value = tax.Void;
                    if (dtgv_taxes.Rows[n].Cells[5].Value == null || string.IsNullOrEmpty(dtgv_taxes.Rows[n].Cells[5].Value.ToString()))
                    {
                        acc += tax.Total;
                        lbl_total.Text = acc.ToString();
                    }
                }

                List<Stamp> stampList = StampLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var stamp in stampList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = stamp.Payment_time;
                    dtgv_taxes.Rows[n].Cells[1].Value = stamp.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[2].Value = stamp.Total.ToString("0.00");
                    dtgv_taxes.Rows[n].Cells[4].Value = "Sellado";
                    acc += stamp.Total;
                    lbl_total.Text = acc.ToString("0.00");
                }
                dtgv_taxes.Sort(dtgv_taxes.Columns[0], ListSortDirection.Ascending);
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument printReceipt = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printReceipt.PrinterSettings = ps;
            printReceipt.PrintPage += (s, ev) => Print(s, ev);
            printReceipt.Print();
        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            string Model = File.ReadAllText("models/ticket-totales.txt");
            int yPos = 100;

            e.Graphics.DrawString(Replacer(Model), new Font("Arial", 8), Brushes.Black, 50, yPos);
        }

        private string Replacer(string model)
        {
            string linea = string.Empty;
            dtgv_taxes.Sort(dtgv_taxes.Columns[1], ListSortDirection.Ascending);
            dtgv_taxes.Sort(dtgv_taxes.Columns[4], ListSortDirection.Ascending);
            foreach (DataGridViewRow row in dtgv_taxes.Rows)
            {
                if (row.Cells[5].Value == null || string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    linea = linea + Environment.NewLine + row.Cells[4].Value.ToString() + "\t\t" + row.Cells[1].Value.ToString() + "\t" + row.Cells[2].Value.ToString();
                }
            }
            dtgv_taxes.Sort(dtgv_taxes.Columns[0], ListSortDirection.Ascending);
            model = model.Replace("PERCENT", ConfigurationLogic.Instance.GetConfigurationValue("CorrespondingComission"));
            model = model.Replace("BUSINESSNAME", ConfigurationLogic.Instance.GetConfigurationValue("BusinessName").ToUpper());
            model = model.Replace("ADDRESS", ConfigurationLogic.Instance.GetConfigurationValue("Address"));
            model = model.Replace("LINE", linea);
            model = model.Replace("TOTAL", "$" + lbl_total.Text);
            float commission = (float.Parse(lbl_total.Text) * float.Parse(ConfigurationLogic.Instance.GetConfigurationValue("CorrespondingComission"))) / 100;
            model = model.Replace("TOTCOM", " $" + commission.ToString("0.00"));

            return model;
        }

        private async void btn_generate_file_Click(object sender, EventArgs e)
        {
            string baseFileName = ConfigurationLogic.Instance.GetConfigurationValue("ShortName").ToUpper() + MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
            string fileName = baseFileName + ".dat";
            int version = 1;

            while (File.Exists(fileName))
            {
                version++;
                fileName = $"{baseFileName}_v{version}.dat";
            }
            try
            {
                // Crea un StreamWriter para escribir en el archivo (esto creará o sobrescribirá el archivo)
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    // Escribe contenido en el archivo
                    List<Tax> taxList = TaxLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                    foreach (var tax in taxList)
                    {
                        if (tax.Void == null)
                        {
                            string receipt = tax.Receipt_number.PadLeft(8, '0');
                            string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                            string amount = tax.Partial.ToString().Replace(",", "").PadLeft(10, '0');
                            string additional = tax.Additional.ToString().Replace(",", "").PadLeft(8, '0');
                            string delay = tax.Delay.ToString().Replace(",", "").PadLeft(8, '0');

                            string line = "53" + "0285" + "06" + receipt + date + amount + "0" + additional + delay;
                            writer.WriteLine(line);
                        }
                    }

                    List<Stamp> stampList = StampLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                    foreach (var stamp in stampList)
                    {
                        string receipt = stamp.Receipt_number.PadLeft(6, '0');
                        string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                        string amount = stamp.Total.ToString().Replace(",", "").PadLeft(10, '0');
                        string additional = "00000000";
                        string delay = "00000000";
                        string line = "53" + "0285" + "00" + receipt + date + amount + "0" + additional + delay;
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine("Archivo creado con éxito: " + fileName + " " + lbl_total.Text);
                 
                DialogResult result = MessageBox.Show("¿Desea enviar el archivo por correo electrónico?", "Enviar Correo Electrónico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string toEmail = ConfigurationLogic.Instance.GetConfigurationValue("toEmail");
                    string subject = baseFileName + " - $" + lbl_total.Text;
                    string body = "";
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string attachmentFilePath = Path.Combine(currentDirectory, fileName);
                    EmailSender emailSender = new EmailSender();
                    await Task.Run(() => emailSender.SendEmailWithAttachment(toEmail, subject, body, attachmentFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el archivo: " + ex.Message);
            }
        }

        private void chkShowVoid_CheckedChanged(object sender, EventArgs e)
        {
            bool showVoidRows = chkShowVoid.Checked;

            foreach (DataGridViewRow row in dtgv_taxes.Rows)
            {
                int columnIndex = 5;
                bool isVoided = row.Cells[columnIndex].Value != null && !string.IsNullOrEmpty(row.Cells[columnIndex].Value.ToString());

                // Mostrar u ocultar la fila según el estado del CheckBox y si la fila está anulada
                row.Visible = showVoidRows || !isVoided;
            }
        }

        private void Total_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                btn_print.PerformClick();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                dtp_date_KeyDown(dtp_date,e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
