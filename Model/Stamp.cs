using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Model
{
    public class Stamp
    {
        public int Id { get; set; }
        public string Receipt_number { get; set; }
        public string Payment_date { get; set; }
        public float Total { get; set; }
    }
}
