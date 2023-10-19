using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Cobrapp.Utils
{
    public class Ticket
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Total { get; set; }
        public string[] ItemNames { get; set; } // Nombres de los elementos o productos
        public string[] ItemPrices { get; set; } // Precios de los elementos

        public Ticket()
        {
            Title = "Total diario";
        }

        public void PrintTicket()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pd.PrintPage += PrintPageHandler;
            pd.Print();
        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font font = new Font("Courier New", 10);

            // Título del ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Title;
            g.DrawString(line, new Font("Arial", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + Date.ToString("dd/MM/yyyy");
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos
            for (int i = 0; i < ItemNames.Length; i++)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
                line = $"{ItemNames[i]} - {ItemPrices[i]}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total: " + Total;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
        }
    }
}
