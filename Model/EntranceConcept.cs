using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Model
{
    public class EntranceConcept
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        // Clave foranea
        public int TicketId { get; set; }
        public EntranceTicket EntranceTicket { get; set; }
        public string TicketTime { get; set; }
        public string Payment_method { get; set; }
    }
}
