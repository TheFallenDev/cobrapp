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

        public CommissionsLogic()
        {

        }

        public static CommissionsLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommissionsLogic();
                }
                return _instance;
            }
        }

        public List<Commission> ListFromToDate(String fromDate, String toDate)
        {
            List<Commission> listFromToDate = new List<Commission>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = @"SELECT total, payment_date, receipt_number FROM (
                                    SELECT total, payment_date, receipt_number FROM Taxes 
                                    WHERE payment_date >= @fromDate AND payment_date <= @toDate
                                    AND void IS NULL
                                    UNION ALL
                                    SELECT total, payment_date, receipt_number FROM Stamps
                                    WHERE payment_date >= @fromDate AND payment_date <= @toDate
                                    UNION ALL
                                    SELECT total, payment_date, receipt_number FROM Fines
                                    WHERE payment_date >= @fromDate AND payment_date <= @toDate
                                ) AS CombinedResults
                                ORDER BY payment_date";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.CommandType = System.Data.CommandType.Text;
                command.Parameters.AddWithValue("@fromDate", fromDate);
                command.Parameters.AddWithValue("@toDate", toDate);
                string previousDate = "";
                string newDate = "";
                int counter = 0;
                double dailyTotal;
                double accumulator = 0;

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["payment_date"].ToString() != newDate)
                        {
                            previousDate = newDate;
                            newDate = reader["payment_date"].ToString();
                            if (accumulator == 0)
                            {
                                previousDate = reader["payment_date"].ToString();
                                dailyTotal = double.Parse(reader["total"].ToString());
                            }
                            else
                            {
                                dailyTotal = accumulator;
                                listFromToDate.Add(new Commission
                                {
                                    Day = previousDate,
                                    DailyTotal = dailyTotal,
                                    OpCounter = counter
                                });
                            }
                            accumulator = double.Parse(reader["total"].ToString());
                            counter = 1;
                        }
                        else
                        {
                            accumulator += double.Parse(reader["total"].ToString());
                            counter++;
                        }
                    }
                }
                if (accumulator != 0)
                {
                    listFromToDate.Add(new Commission
                    {
                        Day = newDate,
                        DailyTotal = accumulator,
                        OpCounter = counter
                    });
                }
            }

            return listFromToDate;
        }
    }
}
