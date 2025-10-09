using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Model
{
    public class Tax
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public string TaxCode { get; set; }
        public string Receipt_number { get; set; }
        public string Payment_date { get; set; }
        public string Payment_time { get; set; }
        public string Due_date { get; set; }
        public decimal Total { get; set; }
        public decimal Additional { get; set; }
        public decimal Delay { get; set; }
        public decimal Partial { get; set; }
        public string Void { get; set; }
    }
}
