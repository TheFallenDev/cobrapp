using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Model;
using Cobrapp.Logic;
using System.IO;

namespace Cobrapp
{
    public partial class Stamps : Form
    {
        public Stamps()
        {
            InitializeComponent();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument printReceipt = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printReceipt.PrinterSettings = ps;
            //printReceipt.DefaultPageSettings.PaperSize = new PaperSize("Receipt",500,1500);
            printReceipt.PrintPage += (s, ev) => Print(s, ev);
            printReceipt.Print();

            Stamp obj = new Stamp()
            {
                Receipt_number = Constant.Default.ToString(),
                Payment_date = DateTime.Now.ToString("dd/MM/yy hh:mm:ss"),
                Total = float.Parse(txt_stamp.Text),
            };

            bool response = StampLogic.Instance.Save(obj);

        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            string[] lines = File.ReadAllLines("models/ticket-sellado.txt");
            string file = "";
            Font font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            foreach (string line in lines)
            {
                file = file + Environment.NewLine + line;
            }
            string receipt;
            string escapeSequence = "\x1B" + "m" + "\x1B\x6D";
            receipt = Replacer(file);
            receipt = receipt + escapeSequence;
            e.Graphics.DrawString(receipt, font, Brushes.Black, new RectangleF(0, 0, 220, 2000));


        }

        private string Replacer(string receipt)
        {
            receipt = receipt.Replace("RECEIPTNUMBER", Constant.Default.ToString());
            receipt = receipt.Replace("DATE", DateTime.Now.ToString("dd/MM/yy hh:mm:ss").ToString());
            receipt = receipt.Replace("TOTAL", txt_stamp.Text.ToString());
            return receipt;
        }
    }
    static class Constant
    {
        public const int Default = 53000000;
    }
}
