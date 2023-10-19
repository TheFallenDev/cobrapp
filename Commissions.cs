using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using Cobrapp.Logic;
using Cobrapp.Model;
using Cobrapp.Utils;

namespace Cobrapp
{
    public partial class Commissions : Form
    {
        public Commissions()
        {
            InitializeComponent();

            DateTime today = DateTime.Now;
            DateTime previousMonth = today.AddMonths(-1);
            dtp_to_date.Value = new DateTime(previousMonth.Year,previousMonth.Month, DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month));
            dtp_from_date.Value = new DateTime(dtp_to_date.Value.Year,dtp_to_date.Value.Month,1);
            KeyPreview = true;
            btn_print.Enabled = false;
        }

        private float CorrespondingComission = float.Parse(ConfigurationLogic.Instance.GetConfigurationValue("CorrespondingComission")) / 100;

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            dtgv_commissions.Rows.Clear();
            lbl_total_commission.Text = "";
            lbl_total_collected.Text = "";
            List<Commission> commissionsList = CommissionsLogic.Instance.ListFromToDate(MyUtils.DateFixer(dtp_from_date.Text), MyUtils.DateFixer(dtp_to_date.Text));
            Decimal acc = 0;
            Decimal collected = 0;
            foreach (var commission in commissionsList)
            {
                int n = dtgv_commissions.Rows.Add();
                dtgv_commissions.Rows[n].Cells[0].Value = MyUtils.DateFixer(commission.Day);
                dtgv_commissions.Rows[n].Cells[1].Value = "$ " + commission.DailyTotal.ToString("0.00");
                dtgv_commissions.Rows[n].Cells[2].Value = "$ " + (commission.DailyTotal * CorrespondingComission).ToString("0.00");
                dtgv_commissions.Rows[n].Cells[3].Value = commission.OpCounter.ToString();
                acc += Decimal.Parse((commission.DailyTotal * CorrespondingComission).ToString());
                lbl_total_commission.Text = "$ " + acc.ToString("0.00");
                collected += Decimal.Parse(commission.DailyTotal.ToString());
                lbl_total_collected.Text = "$ " + collected.ToString("0.00");
            }
            if(dtgv_commissions.Rows.Count > 0)
            {
                btn_print.Enabled = true;
            }
            else
            {
                btn_print.Enabled = false;
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument printReceipt = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printReceipt.PrinterSettings = ps;
            printReceipt.DefaultPageSettings.PaperSize = new PaperSize("Custom", 299, 842);
            printReceipt.PrintPage += (s, ev) => Print(s, ev);
            printReceipt.Print();
        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Courier New", 10, FontStyle.Regular, GraphicsUnit.Point);
            string Model = File.ReadAllText("models/ticket-comisiones.txt");
            int yPos = 100;
            
            e.Graphics.DrawString(Replacer(Model), font, Brushes.Black, 50, yPos);
        }

        private string Replacer(string model)
        {
            string linea = string.Empty; 

            foreach (DataGridViewRow row in dtgv_commissions.Rows)
            {
                linea = linea + Environment.NewLine + row.Cells[0].Value.ToString() + "\t" + row.Cells[1].Value.ToString() + "\t" + row.Cells[2].Value.ToString();
            }

            model = model.Replace("PERCENT", ConfigurationLogic.Instance.GetConfigurationValue("CorrespondingComission"));
            model = model.Replace("BUSINESSNAME", ConfigurationLogic.Instance.GetConfigurationValue("BusinessName").ToUpper());
            model = model.Replace("ADDRESS", ConfigurationLogic.Instance.GetConfigurationValue("Address"));
            model = model.Replace("LINE", linea);
            model = model.Replace("TOTAL", lbl_total_collected.Text);
            model = model.Replace("TOTCOM", "\t" + lbl_total_commission.Text);

            return model;
        }

        private void Commissions_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F9)
            {
                btn_calculate.PerformClick();
            }
            else if (e.KeyCode == Keys.F12)
            {
                btn_print.PerformClick();
            }
        }
    }
}
