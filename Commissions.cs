using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            dtgv_commissions.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgv_commissions.Columns[1].DefaultCellStyle.Format = "N2";
            dtgv_commissions.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgv_commissions.Columns[2].DefaultCellStyle.Format = "N2";
            dtgv_commissions.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            decimal acc = 0;
            decimal collected = 0;
            foreach (var commission in commissionsList)
            {
                int n = dtgv_commissions.Rows.Add();
                dtgv_commissions.Rows[n].Cells[0].Value = MyUtils.DateFixer(commission.Day);
                dtgv_commissions.Rows[n].Cells[1].Value = commission.DailyTotal.ToString("N2");
                dtgv_commissions.Rows[n].Cells[2].Value = (commission.DailyTotal * CorrespondingComission).ToString("N2");
                dtgv_commissions.Rows[n].Cells[3].Value = commission.OpCounter;
                acc += decimal.Parse((commission.DailyTotal * CorrespondingComission).ToString());
                lbl_total_commission.Text = "$ " + acc.ToString("N2");
                collected += decimal.Parse(commission.DailyTotal.ToString());
                lbl_total_collected.Text = "$ " + collected.ToString("N2");
            }
            Console.WriteLine(acc);
            if (dtgv_commissions.Rows.Count > 0)
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
            List<string> days = new List<string>();
            List<string> totals = new List<string>();
            List<string> commissions = new List<string>();
            dtgv_commissions.Sort(dtgv_commissions.Columns[0], ListSortDirection.Ascending);

            foreach (DataGridViewRow row in dtgv_commissions.Rows)
            {
                days.Add(row.Cells[0].Value.ToString());
                totals.Add(row.Cells[1].Value.ToString());
                commissions.Add(row.Cells[2].Value.ToString());
            }

            Ticket myTicket = new Ticket
            {
                Total = lbl_total_collected.Text,
                Commission = lbl_total_commission.Text,
                FirstColumn = days.ToArray(),
                SecondColumn = totals.ToArray(),
                ThirdColumn = commissions.ToArray()
            };
            if (MyUtils.PrinterExists("tickerausb"))
            {
                myTicket.PrintTicket(Ticket.PrintType.CommissionsUSB);
            }
            else
            {
                myTicket.PrintTicket(Ticket.PrintType.Commissions);
            }

            dtgv_commissions.Sort(dtgv_commissions.Columns[0], ListSortDirection.Ascending);
        }

        private string Replacer(string model)
        {
            string linea = string.Empty; 

            foreach (DataGridViewRow row in dtgv_commissions.Rows)
            {
                DateTime day = DateTime.Parse(row.Cells[0].Value.ToString());
                linea = linea + Environment.NewLine + day.ToString("dd/MM/yy") + "\t" + row.Cells[1].Value.ToString() + "\t" + row.Cells[2].Value.ToString();
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
            if(e.KeyCode == Keys.Enter)
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
