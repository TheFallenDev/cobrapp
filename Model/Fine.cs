using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Model
{
    public class Fine
    {
        public int Id { get; set; }
        public string Receipt_number { get; set; }
        public string Code { get; set; }
        public string Period { get; set; }
        public float Total { get; set; }
        public string Due_date  { get; set; }
        public string Payment_date { get; set; }
        public string Payment_time { get; set; }
    }
}
