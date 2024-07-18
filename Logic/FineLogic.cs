using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using Cobrapp.Model;

namespace Cobrapp.Logic
{
    public class FineLogic
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static FineLogic _instance = null;

        public FineLogic()
        {

        }

        public static FineLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FineLogic();
                }
                return _instance;
            }
        }

        public Fine GetFineValue(string receipt_number)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Fines WHERE receipt_number = @receipt_number";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@receipt_number", receipt_number);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Fine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Receipt_number = reader["Receipt_number"].ToString(),
                                Code = reader["Code"].ToString(),
                                Period = reader["Period"].ToString(),
                                Total = decimal.Parse(reader["Total"].ToString()),
                                Due_date = reader["Due_date"].ToString(),
                                Payment_date = reader["Payment_date"].ToString(),
                                Payment_time = reader["Payment_time"].ToString()
                            };
                        }
                    }
                }
            }
            return null; // Retorna null si no se encuentra la multa con el ID especificado
        }

        public bool AddFine(string receiptNumber, string code, string period, float total, string dueDate, string paymentDate, string paymentTime)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Fines (Receipt_number, Code, Period, Total, Due_date, Payment_date, Payment_time) " +
                               "VALUES (@ReceiptNumber, @Code, @Period, @Total, @DueDate, @PaymentDate, @PaymentTime)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ReceiptNumber", receiptNumber);
                    command.Parameters.AddWithValue("@Code", code);
                    command.Parameters.AddWithValue("@Period", period);
                    command.Parameters.AddWithValue("@Total", total);
                    command.Parameters.AddWithValue("@DueDate", dueDate);
                    command.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    command.Parameters.AddWithValue("@PaymentTime", paymentTime);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0; // Retorna true si se insertó al menos una fila
                }
            }
        }

        public List<Fine> GetAllFines()
        {
            List<Fine> fines = new List<Fine>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Fines";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fine fine = new Fine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Receipt_number = reader["Receipt_number"].ToString(),
                                Code = reader["Code"].ToString(),
                                Period = reader["Period"].ToString(),
                                Total = decimal.Parse(reader["Total"].ToString()),
                                Due_date = reader["Due_date"].ToString(),
                                Payment_date = reader["Payment_date"].ToString(),
                                Payment_time = reader["Payment_time"].ToString()
                            };
                            fines.Add(fine);
                        }
                    }
                }
            }
            return fines;
        }

        public List<Fine> GetFinesByDate(string date)
        {
            List<Fine> fines = new List<Fine>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Fines WHERE Payment_date = @Date";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Date", date);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fine fine = new Fine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Receipt_number = reader["Receipt_number"].ToString(),
                                Code = reader["Code"].ToString(),
                                Period = reader["Period"].ToString(),
                                Total = decimal.Parse(reader["Total"].ToString()),
                                Due_date = reader["Due_date"].ToString(),
                                Payment_date = reader["Payment_date"].ToString(),
                                Payment_time = reader["Payment_time"].ToString()
                            };
                            fines.Add(fine);
                        }
                    }
                }
            }

            return fines;
        }

        public List<Fine> GetFinesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Fine> fines = new List<Fine>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Fines WHERE Payment_date BETWEEN @StartDate AND @EndDate";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate.Date);
                    command.Parameters.AddWithValue("@EndDate", endDate.Date);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Fine fine = new Fine
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Receipt_number = reader["Receipt_number"].ToString(),
                                Code = reader["Code"].ToString(),
                                Period = reader["Period"].ToString(),
                                Total = decimal.Parse(reader["Total"].ToString()),
                                Due_date = reader["Due_date"].ToString(),
                                Payment_date = reader["Payment_date"].ToString(),
                                Payment_time = reader["Payment_time"].ToString()
                            };
                            fines.Add(fine);
                        }
                    }
                }
            }
            return fines;
        }
    }
}
