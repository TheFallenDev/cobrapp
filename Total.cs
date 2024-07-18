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
            dtgv_taxes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgv_taxes.Columns[2].DefaultCellStyle.Format = "N2";
            dtgv_taxes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            KeyPreview = true;
            btn_print.Enabled = false;
            btn_generate_file.Enabled = false;
        }

        private void dtp_date_KeyDown(object sender, KeyEventArgs e)
        {
            decimal acc = 0;
            if (e.KeyCode == Keys.Enter)
            {
                dtgv_taxes.Rows.Clear();

                List<Tax> taxList = TaxLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var tax in taxList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = tax.Payment_time;
                    dtgv_taxes.Rows[n].Cells[1].Value = tax.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[2].Value = tax.Total.ToString("N2");
                    dtgv_taxes.Rows[n].Cells[3].Value = tax.Due_date;
                    dtgv_taxes.Rows[n].Cells[4].Value = tax.TaxName;
                    dtgv_taxes.Rows[n].Cells[5].Value = tax.Void;
                    if (dtgv_taxes.Rows[n].Cells[5].Value == null || string.IsNullOrEmpty(dtgv_taxes.Rows[n].Cells[5].Value.ToString()))
                    {
                        acc += tax.Total;
                        lbl_total.Text = acc.ToString("N2");
                    }
                }

                List<Fine> fineList = FineLogic.Instance.GetFinesByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var fine in fineList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = fine.Payment_time;
                    dtgv_taxes.Rows[n].Cells[1].Value = fine.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[2].Value = fine.Total.ToString("N2");
                    dtgv_taxes.Rows[n].Cells[3].Value = fine.Due_date;
                    string fineName = ConfigurationLogic.Instance.GetConfigurationKey(fine.Code).Split('_')[1];
                    dtgv_taxes.Rows[n].Cells[4].Value = fineName.Substring(0,4).ToUpper();
                    acc += fine.Total;
                    lbl_total.Text = "$ " + acc.ToString("N2");
                }

                List<Stamp> stampList = StampLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var stamp in stampList)
                {
                    int n = dtgv_taxes.Rows.Add();
                    dtgv_taxes.Rows[n].Cells[0].Value = stamp.Payment_time;
                    dtgv_taxes.Rows[n].Cells[1].Value = stamp.Receipt_number;
                    dtgv_taxes.Rows[n].Cells[2].Value = stamp.Total.ToString("N2");
                    dtgv_taxes.Rows[n].Cells[4].Value = "Sellado";
                    acc += stamp.Total;
                    lbl_total.Text = acc.ToString("N2");
                }
                dtgv_taxes.Sort(dtgv_taxes.Columns[0], ListSortDirection.Ascending);
                if (dtgv_taxes.Rows.Count > 0)
                {
                    btn_print.Enabled = true;
                    btn_generate_file.Enabled = true;
                }
                else
                {
                    btn_print.Enabled = false;
                    btn_generate_file.Enabled = false;
                }
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            List<string> types = new List<string>();
            List<string> receipts = new List<string>();
            List<string> totals = new List<string>();
            dtgv_taxes.Sort(dtgv_taxes.Columns[1], ListSortDirection.Ascending);
            dtgv_taxes.Sort(dtgv_taxes.Columns[4], ListSortDirection.Ascending);
            foreach (DataGridViewRow row in dtgv_taxes.Rows)
            {
                if (row.Cells[5].Value == null || string.IsNullOrEmpty(row.Cells[5].Value.ToString()))
                {
                    types.Add(row.Cells[4].Value.ToString().Substring(0, 3).ToUpper());
                    receipts.Add(row.Cells[1].Value.ToString());
                    totals.Add(row.Cells[2].Value.ToString());
                }
            }
            decimal commission = (decimal.Parse(lbl_total.Text) * decimal.Parse(ConfigurationLogic.Instance.GetConfigurationValue("CorrespondingComission"))) / 100;
            Ticket myTicket = new Ticket
            {
                Date = dtp_date.Text,
                Total = lbl_total.Text,
                Commission = commission.ToString("N2"),
                FirstColumn = types.ToArray(),
                SecondColumn = receipts.ToArray(),
                ThirdColumn = totals.ToArray()
            };
            if (MyUtils.PrinterExists("brother"))
            {
                myTicket.PrintTicket(Ticket.PrintType.TotalUSB);
            }
            else
            {
                myTicket.PrintTicket(Ticket.PrintType.Total);
            }
            dtgv_taxes.Sort(dtgv_taxes.Columns[0], ListSortDirection.Ascending);
        }

        private async void btn_generate_file_Click(object sender, EventArgs e)
        {
            string baseFileName = ConfigurationLogic.Instance.GetConfigurationValue("ShortName").ToUpper() + MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
            string fileName = "arch/" + baseFileName + ".dat";
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
                        if (String.IsNullOrEmpty(tax.Void))
                        {
                            string taxCode = tax.TaxCode.ToString().PadLeft(2, '0');
                            string receipt = tax.Receipt_number.PadLeft(8, '0');
                            string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                            string amount = tax.Partial.ToString().Replace(",", "").PadLeft(10, '0');
                            string additional = tax.Additional.ToString().Replace(",", "").PadLeft(8, '0');
                            string delay = tax.Delay.ToString().Replace(",", "").PadLeft(8, '0');
                            string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
                            string line = businessCode + "0285" + taxCode + receipt + date + amount + "0" + additional + delay;
                            writer.WriteLine(line);
                        }
                    }

                    List<Fine> fineList = FineLogic.Instance.GetFinesByDate(MyUtils.DateFixer(dtp_date.Text));
                    foreach (var fine in fineList)
                    {
                        string receipt = fine.Receipt_number.PadLeft(8, '0');
                        string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                        string amount = fine.Total.ToString("0.00").Replace(",", "").PadLeft(10, '0');
                        string additional = "00000000";
                        string delay = "00000000";
                        string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
                        string line = businessCode + "0285" + "00" + receipt + date + amount + "0" + additional + delay;
                        writer.WriteLine(line);
                    }

                        List<Stamp> stampList = StampLogic.Instance.ListByDate(MyUtils.DateFixer(dtp_date.Text));
                    foreach (var stamp in stampList)
                    {
                        string receipt = stamp.Receipt_number.PadLeft(8, '0');
                        string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                        string amount = stamp.Total.ToString("0.00").Replace(",", "").PadLeft(10, '0');
                        string additional = "00000000";
                        string delay = "00000000";
                        string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
                        string line = businessCode + "0285" + "00" + receipt + date + amount + "0" + additional + delay;
                        writer.WriteLine(line);
                    }
                }
                 
                DialogResult result = MessageBox.Show("¿Desea enviar el archivo por correo electrónico?", "Enviar Correo Electrónico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string toEmail = ConfigurationLogic.Instance.GetConfigurationValue("toEmail");
                    string subject = baseFileName + " - $" + lbl_total.Text;
                    string body = "";
                    string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string attachmentFilePath = Path.Combine(currentDirectory, fileName);
                    EmailSender emailSender = new EmailSender();
                    try
                    {
                        await Task.Run(() => emailSender.SendEmailWithAttachment(toEmail, subject, body, attachmentFilePath));
                        // La tarea se completó con éxito, muestra un MessageBox
                        MessageBox.Show("El correo se envió con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Manejo de errores si la tarea falla
                        MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear el archivo: " + ex.Message);
            }
        }

        private void FinesFileGenerator(string fileName)
        {
            fileName = "Fines" + fileName; 
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                // Escribe contenido en el archivo
                List<Fine> fineList = FineLogic.Instance.GetFinesByDate(MyUtils.DateFixer(dtp_date.Text));
                foreach (var fine in fineList)
                {
                    string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
                    string receipt = fine.Receipt_number.PadLeft(8, '0');
                    string date = MyUtils.DateFixer(dtp_date.Text).Replace("/", "");
                    string amount = fine.Total.ToString("0.00").Replace(",", "").PadLeft(10, '0');
                    string code = fine.Code;
                    string line = businessCode + receipt + date + amount + code;
                    writer.WriteLine(line);
                }
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
        }
    }
}
