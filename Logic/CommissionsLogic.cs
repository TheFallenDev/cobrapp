using System;
using System.Collections.Generic;

using System.Configuration;
using Cobrapp.Model;
using System.Data.SQLite;

namespace Cobrapp.Logic
{
    public class CommissionsLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static CommissionsLogic _instance = null;

        public List<Tax> ListFromToDate(String fromDate, String toDate)
        {
            List<Tax> listFromToDate = new List<Tax>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "select total,payment_date from Taxes where payment_date>='" + fromDate + "' and payment_date<='" + toDate + "'";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    string previousDate = "";
                    while (reader.Read())
                    {
                        if (reader["payment_date"].ToString() != previousDate)
                        {
                            previousDate = reader["payment_date"].ToString();
                        }
                        listFromToDate.Add(new Tax()
                        {
                            Total = float.Parse(reader["total"].ToString()),
                        });
                    }
                }
            }

            return listFromToDate;
        }
    }
}
