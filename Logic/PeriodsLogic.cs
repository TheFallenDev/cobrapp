using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cobrapp.Model;

namespace Cobrapp.Logic
{
    public class PeriodsLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static PeriodsLogic _instance = null;

        public PeriodsLogic()
        {

        }

        public static PeriodsLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PeriodsLogic();
                }
                return _instance;
            }
        }

        public bool DoesPeriodExist(string periodToSearch)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    // Definir la consulta SQL para buscar el período
                    cmd.CommandText = "SELECT COUNT(*) FROM Periods WHERE period = @periodToSearch";
                    cmd.Parameters.AddWithValue("@periodToSearch", periodToSearch);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        public bool SavePeriod(string period, string dueDate, string tax)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand cmd = connection.CreateCommand())
                    {
                        try
                        {
                            // Definir la consulta SQL para insertar el período
                            cmd.CommandText = "INSERT INTO Periods (period, due_date, tax) VALUES (@period, @dueDate, @tax)";
                            cmd.Parameters.AddWithValue("@period", period);
                            cmd.Parameters.AddWithValue("@dueDate", dueDate);
                            cmd.Parameters.AddWithValue("@tax", tax);

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit(); // Confirmar la transacción
                                return true;
                            }
                            else
                            {
                                transaction.Rollback(); // Revertir la transacción en caso de error
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            transaction.Rollback(); // Revertir la transacción en caso de excepción
                            throw;
                        }
                    }
                }
            }
        }

        public Period GetPeriod(string period, string tax)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    // Definir la consulta SQL para seleccionar el período por nombre
                    cmd.CommandText = "SELECT * FROM Periods WHERE period = @period AND tax = @tax";
                    cmd.Parameters.AddWithValue("@period", period);
                    cmd.Parameters.AddWithValue("@tax", tax);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Crear un objeto Period con los datos recuperados
                            return new Period
                            {
                                PeriodName = reader["period"].ToString(),
                                DueDate = reader["due_date"].ToString(),
                                Tax = reader["tax"].ToString()
                            };
                        }
                    }
                }
            }

            // Si no se encuentra el período, devolver null
            return null;
        }
    }
}
