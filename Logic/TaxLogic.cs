using System;
using System.Collections.Generic;

using System.Configuration;
using Cobrapp.Model;
using System.Data.SQLite;

namespace Cobrapp.Logic
{
    public class TaxLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static TaxLogic _instance = null;

        public TaxLogic()
        {

        }

        public static TaxLogic Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new TaxLogic();
                }
                return _instance;
            }
        }

        public bool Save(Tax obj)
        {
            bool response = true;

            using (SQLiteConnection connection = new SQLiteConnection(conn) )
            {
                connection.Open();
                string query = "insert into Taxes(Tax,Receipt_number,Payment_date,Payment_time,Due_date,Total,Additional,Delay,Partial) values (@tax,@receipt_number,@payment_date,@payment_time,@due_date,@total,@additional,@delay,@partial)";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@tax", obj.TaxName));
                command.Parameters.Add(new SQLiteParameter("@receipt_number", obj.Receipt_number));
                command.Parameters.Add(new SQLiteParameter("@payment_date", obj.Payment_date));
                command.Parameters.Add(new SQLiteParameter("@payment_time", obj.Payment_time));
                command.Parameters.Add(new SQLiteParameter("@due_date", obj.Due_date));
                command.Parameters.Add(new SQLiteParameter("@total", obj.Total));
                command.Parameters.Add(new SQLiteParameter("@additional", obj.Additional));
                command.Parameters.Add(new SQLiteParameter("@delay", obj.Delay));
                command.Parameters.Add(new SQLiteParameter("@partial", obj.Partial));
                command.CommandType = System.Data.CommandType.Text;

                if (command.ExecuteNonQuery() < 1)
                {
                    response = false;
                }
            }
            return response;
        }

        public List<Tax> List()
        {
            List<Tax> list = new List<Tax>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "select id,tax,receipt_number,payment_date,due_date,total from Taxes";
                SQLiteCommand command = new SQLiteCommand(query,connection);
                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Tax()
                        {
                            Receipt_number = reader["receipt_number"].ToString(),
                            Total = float.Parse(reader["total"].ToString()),
                            Due_date = reader["due_date"].ToString(),
                            TaxName = reader["tax"].ToString(),
                        });
                    }
                }
            }

            return list;
        }

        public List<Tax> ListByDate(String date)
        {
            List<Tax> listByDate = new List<Tax>();
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "select receipt_number,total,additional,delay,partial,due_date,tax,payment_date,payment_time,void from Taxes where payment_date='" + date + "'" ;
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listByDate.Add(new Tax()
                        {
                            Receipt_number = reader["receipt_number"].ToString(),
                            Total = float.Parse(reader["total"].ToString()),
                            Additional = float.Parse(reader["additional"].ToString()),
                            Delay = float.Parse(reader["delay"].ToString()),
                            Partial = reader["partial"].ToString(),
                            Due_date = reader["due_date"].ToString(),
                            TaxName = reader["tax"].ToString(),
                            Payment_time = reader["payment_time"].ToString(),
                            Void = reader["void"].ToString()
                        });
                    }
                }
            }

            return listByDate;
        }

        public bool SearchReceipt(string newReceipt)
        {
            bool response = false;

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "select receipt_number from Taxes where receipt_number = '" + newReceipt + "'";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Verifica si hay resultados
                    {
                        response = true;
                    }
                }
            }
            return response;
        }
    }
}
