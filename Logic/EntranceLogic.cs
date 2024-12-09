using Cobrapp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobrapp.Logic
{
    public class EntranceLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static EntranceLogic _instance = null;

        public EntranceLogic()
        {

        }

        public static EntranceLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EntranceLogic();
                }
                return _instance;
            }
        }

        public void AddEntranceTicket(EntranceTicket ticket)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "INSERT INTO EntranceTickets (Date, Time, Concepts, Total, Payment_method) " +
                               "VALUES (@Date, @Time, @Concepts, @Total, @Payment_method)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", ticket.Date);
                    command.Parameters.AddWithValue("@Time", ticket.Time);
                    command.Parameters.AddWithValue("@Concepts", ticket.Concepts);
                    command.Parameters.AddWithValue("@Total", ticket.Total);
                    command.Parameters.AddWithValue("@Payment_method", ticket.Payment_method);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddEntranceConcept(EntranceConcept concept)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "INSERT INTO EntranceConcepts (Name, Value, TicketId) " +
                               "VALUES (@Name, @Value, @TicketId)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", concept.Name);
                    command.Parameters.AddWithValue("@Value", concept.Value);
                    command.Parameters.AddWithValue("@TicketId", concept.TicketId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<EntranceConcept> GetEntranceConceptsByDate(string date)
        {
            List<EntranceConcept> concepts = new List<EntranceConcept>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                // Consulta SQL actualizada para incluir la hora del ticket
                string query = @"
            SELECT ec.Id, ec.Name, ec.Value, ec.TicketId, et.Time, et.Payment_method
            FROM EntranceConcepts ec
            INNER JOIN EntranceTickets et ON ec.TicketId = et.Id
            WHERE et.Date = @Date";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EntranceConcept concept = new EntranceConcept
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Value = Convert.ToDecimal(reader["Value"]),
                                TicketId = Convert.ToInt32(reader["TicketId"]),
                                TicketTime = reader["Time"].ToString(), // Obtiene la hora del ticket
                                Payment_method = reader["Payment_method"].ToString()
                            };

                            concepts.Add(concept);
                        }
                    }
                }
            }

            return concepts;
        }


        public int GetLastInsertedTicketId()
        {
            int lastId = 0;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT MAX(Id) FROM EntranceTickets";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        lastId = Convert.ToInt32(result);
                    }
                }
            }

            return lastId;
        }

    }
}
