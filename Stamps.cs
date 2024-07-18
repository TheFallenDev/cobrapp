using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Cobrapp.Model;
using Cobrapp.Logic;
using Cobrapp.Utils;
using System.IO;

namespace Cobrapp
{
    public partial class Stamps : Form
    {
        public Stamps()
        {
            InitializeComponent();
            KeyPreview = true;
            txt_stamp_value.Text = "";
            txt_stamp_value.Focus();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_stamp_value.Text))
            {
                string value = MyUtils.Formatter(txt_stamp_value.Text);
                PrintDocument printReceipt = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = "tickera";
                printReceipt.PrinterSettings = ps;
                printReceipt.PrintPage += (s, ev) => Print(s, ev);
                printReceipt.Print();

                int newId = StampLogic.Instance.GetLastItemID() + 1;
                string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
                Stamp obj = new Stamp()
                {
                    Receipt_number = businessCode + newId.ToString().PadLeft(6, '0'),
                    Payment_date = DateTime.Now.ToString("yyyy/MM/dd"),
                    Payment_time = DateTime.Now.ToString("HH:mm:ss"),
                    Total = decimal.Parse(value)
                };
                bool response = StampLogic.Instance.Save(obj);
            }
            else
            {
                MessageBox.Show("Debe ingresar un valor.","¡Advertencia!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            string[] lines = File.ReadAllLines("models/ticket-sellado.txt");
            string file = "";
            Font font = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Point);
            foreach (string line in lines)
            {
                file = file + Environment.NewLine + line;
            }
            string receipt;
            receipt = Replacer(file);
            e.Graphics.DrawString(receipt, font, Brushes.Black, new RectangleF(0, 0, 220, 2000));
            txt_stamp_value.Text = "";
            txt_stamp_value.Focus();
        }

        private string Replacer(string receipt)
        {
            string businessCode = ConfigurationLogic.Instance.GetConfigurationValue("BusinessCode");
            int newId = StampLogic.Instance.GetLastItemID() + 1;
            receipt = receipt.Replace("BUSINESSNAME", ConfigurationLogic.Instance.GetConfigurationValue("BusinessName").ToUpper());
            receipt = receipt.Replace("ADDRESS", ConfigurationLogic.Instance.GetConfigurationValue("Address"));
            receipt = receipt.Replace("RECEIPTNUMBER", businessCode + newId.ToString().PadLeft(6, '0'));
            receipt = receipt.Replace("DATE", DateTime.Now.ToString("dd/MM/yy hh:mm:ss").ToString());
            receipt = receipt.Replace("TOTAL", MyUtils.Formatter(txt_stamp_value.Text));
            return receipt;
        }

        private void Stamps_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F12)
            {
                btn_print.PerformClick();
            }
        }
    }
}
