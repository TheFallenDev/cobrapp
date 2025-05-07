using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Model
{
    public class EntranceTicket
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Concepts { get; set; }
        public decimal Total { get; set; }
        public string Payment_method { get; set; }
        public string Username { get; set; }
        // Relación uno a muchos
        public List<EntranceConcept> EntranceConcepts { get; set; }
    }
}
