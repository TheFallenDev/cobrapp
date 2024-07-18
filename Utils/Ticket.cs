using System;
using System.Drawing;
using System.Drawing.Printing;

namespace Cobrapp.Utils
{
    public class Ticket
    {
        public string Header { get; set; }
        public string Title { get; set; }
        public string Separator { get; set; }
        public string Date { get; set; }
        public string Total { get; set; }
        public string Commission { get; set; }
        public string[] FirstColumn { get; set; }
        public string[] SecondColumn { get; set; }
        public string[] ThirdColumn { get; set; }


        public Ticket()
        {
            Header = "Municipalidad de Diamante";
            Title = "Total diario";
        }

        public enum PrintType
        {
            Total,
            Commissions,
            TotalUSB,
            CommissionsUSB
        }

        public void PrintTicket(PrintType printType)
        {
            PrintDocument pd = new PrintDocument();
            if (MyUtils.PrinterExists("tickeraUSB"))
            {
                pd.PrinterSettings.PrinterName = "tickeraUSB";
            }
            else
            {
                pd.PrinterSettings.PrinterName = "tickera";
            }
            pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            switch (printType)
            {
                case PrintType.Total:
                    pd.PrintPage += PrintTotalPageHandler;
                    break;

                case PrintType.Commissions:
                    pd.PrintPage += PrintCommissionsPageHandler;
                    break;

                case PrintType.TotalUSB:
                    pd.PrintPage += PrintTotalUSBPageHandler;
                    break;

                case PrintType.CommissionsUSB:
                    pd.PrintPage += PrintCommissionsUSBPageHandler;
                    break;

                default:
                    throw new ArgumentException("Tipo de impresión no válido.");
            }
            pd.Print();
        }

        private void PrintTotalPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font font = new Font("Consolas", 10);
            Font separatorFont = new Font("Consolas", 10);
            // Ajusta el ancho del Separador
            float separatorWidth = e.MarginBounds.Right - leftMargin - 3;

            string[] type = FirstColumn;
            string[] receipt = SecondColumn;
            string[] total = ThirdColumn;

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Header del ticket

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Header;
            g.DrawString(line, new Font("Consolas", 11), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Título del ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Title;
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + Date;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Cabeceras de las columnas
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Tipo Recibo          Total";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos en tres columnas
            for (int i = 0; i < receipt.Length; i++)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                // Ajusta el espaciado para acercar más la columna "Elemento"
                line = $"{type[i].PadRight(5)}{receipt[i].PadRight(9)}{total[i].PadLeft(12)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "A depositar:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Comision
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Comision:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Commission).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
        }

        private void PrintCommissionsPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font font = new Font("Consolas", 10);
            Font separatorFont = new Font("Consolas", 10);
            Font linesFont = new Font("Consolas", 9);
            // Ajusta el ancho del Separador
            float separatorWidth = e.MarginBounds.Right - leftMargin - 3;

            string[] day = FirstColumn;
            string[] total = SecondColumn;
            string[] commission = ThirdColumn;

            Title = "Comisiones";

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Header del ticket

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Header;
            g.DrawString(line, new Font("Consolas", 11), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Título del ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Title;
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Cabeceras de las columnas
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Dia        Total    Comision";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos en tres columnas
            for (int i = 0; i < day.Length; i++)
            {
                DateTime aux = DateTime.Parse(day[i]);
                string fixedDay = aux.ToString("dd/MM/yy");
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                // Ajusta el espaciado para acercar más la columna "Elemento"
                line = $"{fixedDay.PadRight(9)}{total[i].PadLeft(12)}{commission[i].PadLeft(10)}";
                g.DrawString(line, linesFont, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total recaudado:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = (Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Comision
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Comision:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = (Commission).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
        }

        private void PrintTotalUSBPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font font = new Font("Consolas", 10);
            Font separatorFont = new Font("Consolas", 10);
            // Ajusta el ancho del Separador
            float separatorWidth = e.MarginBounds.Right - leftMargin - 3;

            string[] type = FirstColumn;
            string[] receipt = SecondColumn;
            string[] total = ThirdColumn;

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Header del ticket

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Header;
            g.DrawString(line, new Font("Consolas", 11), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Título del ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Title;
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + Date;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Cabeceras de las columnas
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Tipo  Recibo                  Total";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos en tres columnas
            for (int i = 0; i < receipt.Length; i++)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                // Ajusta el espaciado para acercar más la columna "Elemento"
                line = $"{type[i].PadRight(5)}{receipt[i].PadRight(12)}{total[i].PadLeft(18)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "A depositar:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Comision
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Comision:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Commission).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
        }

        private void PrintCommissionsUSBPageHandler(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            float yPos = 0;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font font = new Font("Consolas", 10);
            Font separatorFont = new Font("Consolas", 10);
            Font linesFont = new Font("Consolas", 9);
            // Ajusta el ancho del Separador
            float separatorWidth = e.MarginBounds.Right - leftMargin - 3;

            string[] day = FirstColumn;
            string[] total = SecondColumn;
            string[] commission = ThirdColumn;

            Title = "Comisiones";

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Header del ticket

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Header;
            g.DrawString(line, new Font("Consolas", 11), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Título del ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Title;
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Cabeceras de las columnas
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Dia               Total    Comision";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos en tres columnas
            for (int i = 0; i < day.Length; i++)
            {
                DateTime aux = DateTime.Parse(day[i]);
                string fixedDay = aux.ToString("dd/MM/yy");
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                // Ajusta el espaciado para acercar más la columna "Elemento"
                line = $"{fixedDay.PadRight(9)}{total[i].PadLeft(17)}{commission[i].PadLeft(13)}";
                g.DrawString(line, linesFont, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total recaudado:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = (Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Comision
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Comision:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = (Commission).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
        }
    }
}
