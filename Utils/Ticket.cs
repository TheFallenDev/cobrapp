using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using static Cobrapp.Total;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cobrapp.Utils
{
    public class Ticket
    {
        public string Header { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Separator { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Total { get; set; }
        public int TicketNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalCash { get; set; }
        public decimal TotalPos {  get; set; }
        public string Commission { get; set; }
        public string[] FirstColumn { get; set; }
        public string[] SecondColumn { get; set; }
        public string[] ThirdColumn { get; set; }
        public decimal[] PriceColumn { get; set; }
        public Dictionary<string, ConceptSummary> SummaryDict { get; set; }

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
            CommissionsUSB,
            EntranceTicket,
            TotalEntrance
        }

        public void PrintTicket(PrintType printType)
        {
            PrintDocument pd = new PrintDocument();
            /*if (MyUtils.PrinterExists("tickeraUSB"))
            {
                pd.PrinterSettings.PrinterName = "tickeraUSB";
            }
            else if (MyUtils.PrinterExists("tickera"))
            {
                pd.PrinterSettings.PrinterName = "tickera";
            }
            else
            {
                pd.PrinterSettings.PrinterName = Properties.Settings.Default.DefaultPrinter;
            }*/
            pd.PrinterSettings.PrinterName = Properties.Settings.Default.DefaultPrinter;
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

                case PrintType.EntranceTicket:
                    pd.PrintPage += PrintEntranceTicketPageHandler;
                    break;

                case PrintType.TotalEntrance:
                    pd.PrintPage += PrintTotalEntrancePageHandler;
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
        
        private void PrintEntranceTicketPageHandler(object sender, PrintPageEventArgs e)
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

            string[] concept = FirstColumn;
            string[] quantity = SecondColumn;
            decimal[] total = PriceColumn;

            Title = "Ingreso al complejo";
            Name = Properties.Settings.Default.BusinessName;

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
            
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = Name;
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Fecha
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Fecha: " + Date;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Ticket
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Ticket Nro." + TicketNumber.ToString().PadLeft(10);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Cabeceras de las columnas
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Detalle       Cant.         Subtotal";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            // Detalles de los elementos en tres columnas
            for (int i = 0; i < quantity.Length; i++)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                // Ajusta el espaciado para acercar más la columna "Elemento"
                line = $"{concept[i].PadRight(16)}{quantity[i].PadRight(2)}{total[i].ToString("F2").PadLeft(18)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total ";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + TotalPrice.ToString("F2")).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            // Información
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Este ticket es válido como\ncomprobante de pago de ingreso.\n" +
                "Sólo válido para el día de la fecha\nindicado en la parte superior.";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
        }
        private void PrintTotalEntrancePageHandler(object sender, PrintPageEventArgs e)
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
            decimal[] total = PriceColumn;

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
            line = "Tipo     Ticket               Total";
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);


            // Detalles de los elementos en tres columnas
            for (int i = 0; i < receipt.Length; i++)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
                line = $"{type[i].PadRight(10)}{receipt[i].PadRight(7)}{total[i].ToString("N2").PadLeft(18)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            //RESUMEN FINAL
            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "RESUMEN DEL DÍA " + Date;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            foreach (var summary in SummaryDict.Values)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
                // Ajusta el espaciado para las columnas
                line = $"{summary.Name.PadRight(19)}{summary.Count.ToString().PadRight(7)}{summary.Total.ToString("N2").PadLeft(9)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('-', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Efectivo: " + ("$ " + TotalCash.ToString("N2")).PadLeft(25);
            g.DrawString(line, new Font("Consolas", 10), Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Posnet: " + ("$ " + TotalPos.ToString("N2")).PadLeft(27);
            g.DrawString(line, new Font("Consolas", 10), Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total del día:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
        }
        /*private void PrintTotalEntrancePageHandler(object sender, PrintPageEventArgs e)
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
            decimal[] total = PriceColumn;

            int linesPerPage = 60; // Máximo de líneas por página
            int totalLines = receipt.Length; // Total de líneas a imprimir
            int pages = (totalLines / linesPerPage) + 1;
            Console.WriteLine("Total lineas: " + receipt.Length);
            Console.WriteLine("Paginas " + pages);
            Console.WriteLine(isPrintingSummary);
            if (!isPrintingSummary)
            {
                if (currentLine == 0)
                {
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
                    line = "Tipo     Ticket               Total";
                    g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
                }

                for (int i = currentLine; i < receipt.Length; i++)
                {
                    Console.WriteLine(i);
                    if (currentLine % 60 != 0 || currentLine == 0)
                    {
                        yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;

                        // Ajusta el espaciado para las columnas
                        line = $"{type[i].PadRight(10)}{receipt[i].PadRight(7)}{total[i].ToString("N2").PadLeft(18)}";
                        g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

                        currentLine++; // Incrementa la línea actual procesada
                        Console.WriteLine("Linea " + currentLine);
                    }

                    // Si se alcanza el límite de líneas por página
                    if (currentLine % 60 == 0 && currentLine != 0)
                    {
                        page++; // Incrementa la página actual
                        Console.WriteLine("Página nueva: " + page);

                        e.HasMorePages = true; // Indica que hay más páginas
                        Console.WriteLine("Valor de currentline: " + currentLine);
                        currentLine = i + 2;   // Guarda el índice de inicio para la próxima página
                        Console.WriteLine("Nuevo valor de currentline: " + currentLine);

                        return;                // Finaliza la impresión de la página actual
                    }
                }
            }
            if(currentLine == totalLines && !isPrintingSummary)
            {
                Console.WriteLine("Entro para cambiar isPrintingSummary");
                isPrintingSummary = true;
                e.HasMorePages = true;
                return;
            }
            // Si se completan todas las líneas, finaliza la impresión
            currentLine = 0; // Reinicia para futuras impresiones
            page = 0;

            //RESUMEN FINAL
            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "RESUMEN DEL DÍA " + Date;
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            foreach (var summary in SummaryDict.Values)
            {
                yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
                // Ajusta el espaciado para las columnas
                line = $"{summary.Name.PadRight(19)}{summary.Count.ToString().PadRight(7)}{summary.Total.ToString("N2").PadLeft(9)}";
                g.DrawString(line, font, Brushes.Black, leftMargin, yPos);
            }

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Efectivo: " + ("$ " + TotalCash).PadLeft(13);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Posnet: " + ("$ " + TotalPos).PadLeft(15);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Total
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = "Total del día:".PadLeft(28);
            g.DrawString(line, font, Brushes.Black, leftMargin, yPos);

            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = ("$ " + Total).PadLeft(23);
            g.DrawString(line, new Font("Consolas", 12), Brushes.Black, leftMargin, yPos);

            // Separador
            yPos = topMargin + (count++) * g.MeasureString("Text", font).Height;
            line = new string('*', (int)separatorWidth);
            g.DrawString(line, separatorFont, Brushes.Black, leftMargin, yPos);
            isPrintingSummary = false;
            e.HasMorePages = false;
        }*/
    }
}
