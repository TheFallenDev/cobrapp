using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Cobrapp.Model;
using System.Data.SQLite;

namespace Cobrapp.Logic
{
    public class StampLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static StampLogic _instance = null;

        public StampLogic()
        {

        }

        public static StampLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StampLogic();
                }
                return _instance;
            }
        }

        public bool Save(Stamp obj)
        {
            bool response = true;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "insert into Stamps(Receipt_number,Payment_date,Payment_time,Total) values (@receipt_number,@payment_date,@payment_time,@total)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@receipt_number", obj.Receipt_number));
                command.Parameters.Add(new SQLiteParameter("@payment_date", obj.Payment_date));
                command.Parameters.Add(new SQLiteParameter("@payment_time", obj.Payment_time));
                command.Parameters.Add(new SQLiteParameter("@total", obj.Total));
                command.CommandType = System.Data.CommandType.Text;

                if (command.ExecuteNonQuery() < 1)
                {
                    response = false;
                }
            }
            return response;
        }

        public List<Stamp> ListByDate(String date)
        {
            List<Stamp> listByDate = new List<Stamp>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "select receipt_number,total,payment_date from Stamps where payment_date='" + date + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listByDate.Add(new Stamp()
                        {
                            Receipt_number = reader["receipt_number"].ToString(),
                            Total = float.Parse(reader["total"].ToString()),
                        });
                    }
                }
            }

            return listByDate;
        }
    }
}
