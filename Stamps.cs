﻿using System;
using System.Drawing;
using System.Drawing.Printing;
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
            nud_stamp_value.DecimalPlaces = 2; // Dos decimales
            nud_stamp_value.Increment = 1; // Incremento de 1
            nud_stamp_value.Minimum = 0.00m; // Valor mínimo
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument printReceipt = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            printReceipt.PrinterSettings = ps;
            //printReceipt.DefaultPageSettings.PaperSize = new PaperSize("Receipt",500,1500);
            printReceipt.PrintPage += (s, ev) => Print(s, ev);
            printReceipt.Print();

            int newId = StampLogic.Instance.GetLastItemID() + 1;

            Stamp obj = new Stamp()
            {
                Receipt_number = "53" + newId.ToString().PadLeft(6,'0'),
                Payment_date = DateTime.Now.ToString("yyyy/MM/dd"),
                Payment_time = DateTime.Now.ToString("HH:mm:ss"),
                Total = float.Parse(nud_stamp_value.Value.ToString("0.00"))
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
            receipt = Replacer(file);
            e.Graphics.DrawString(receipt, font, Brushes.Black, new RectangleF(0, 0, 220, 2000));
        }

        private string Replacer(string receipt)
        {
            int newId = StampLogic.Instance.GetLastItemID() + 1;
            receipt = receipt.Replace("RECEIPTNUMBER", "53" + newId.ToString().PadLeft(6, '0'));
            receipt = receipt.Replace("DATE", DateTime.Now.ToString("dd/MM/yy hh:mm:ss").ToString());
            receipt = receipt.Replace("TOTAL", nud_stamp_value.Value.ToString("0.00"));
            return receipt;
        }

    }
    static class Constant
    {
        public const int Default = 53000000;
    }
}