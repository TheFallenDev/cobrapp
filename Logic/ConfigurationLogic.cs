using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace Cobrapp.Logic
{
    public class ConfigurationLogic
    {
        private static string conn = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        private static ConfigurationLogic _instance = null;

        public ConfigurationLogic()
        {

        }

        public static ConfigurationLogic Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationLogic();
                }
                return _instance;
            }
        }

        public bool AddConfiguration(string key, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "INSERT INTO Configurations (Key, Value) VALUES (@Key, @Value)";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    command.Parameters.AddWithValue("@Value", value);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Si se insertó una nueva fila, se considera que la adición fue exitosa
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateConfigurationValue(string key, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "UPDATE Configurations SET Value = @Value WHERE Key = @Key";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);
                    command.Parameters.AddWithValue("@Value", value);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Si se actualizó al menos una fila, se considera que la actualización fue exitosa
                    return rowsAffected > 0;
                }
            }
        }

        public bool SaveConfiguration(string key, string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                // Verificar si la clave ya existe en la base de datos.
                string queryCheckExistence = "SELECT COUNT(*) FROM Configurations WHERE Key = @Key";

                using (SQLiteCommand checkCommand = new SQLiteCommand(queryCheckExistence, connection))
                {
                    checkCommand.Parameters.AddWithValue("@Key", key);

                    int existingCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (existingCount > 0)
                    {
                        // La clave ya existe, actualizar el valor.
                        return UpdateConfigurationValue(key, value);
                    }
                    else
                    {
                        // La clave no existe, agregar una nueva configuración.
                        return AddConfiguration(key, value);
                    }
                }
            }
        }

        public Dictionary<string, string> GetAllConfigurations()
        {
            Dictionary<string, string> configurations = new Dictionary<string, string>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Key, Value FROM Configurations";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["Key"].ToString();
                        string value = reader["Value"].ToString();
                        configurations[key] = value;
                    }
                }
            }

            return configurations;
        }

        public Dictionary<string, string> GetTaxConfigurations()
        {
            Dictionary<string, string> taxConfigurations = new Dictionary<string, string>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Key, Value FROM Configurations WHERE Key LIKE '%tax%'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["Key"].ToString();
                        string value = reader["Value"].ToString();
                        taxConfigurations[key] = value;
                    }
                }
            }

            return taxConfigurations;
        }

        public void SaveOrUpdateTaxConfigurations(Dictionary<string, string> taxConfigurations)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener los datos actuales de la base de datos para las claves con prefijo "tax"
                        Dictionary<string, string> dbTaxConfigurations = GetTaxConfigurations();

                        // 2. Eliminar las entradas en la base de datos que no existen en el Dictionary
                        foreach (var kvp in dbTaxConfigurations)
                        {
                            if (!taxConfigurations.ContainsKey(kvp.Key))
                            {
                                string deleteQuery = "DELETE FROM Configurations WHERE Key = @Key";
                                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 3. Actualizar las entradas en la base de datos que ya existen y tienen valores diferentes en el Dictionary
                        foreach (var kvp in taxConfigurations)
                        {
                            if (dbTaxConfigurations.ContainsKey(kvp.Key) && dbTaxConfigurations[kvp.Key] != kvp.Value)
                            {
                                string updateQuery = "UPDATE Configurations SET Value = @Value WHERE Key = @Key";
                                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    updateCommand.Parameters.AddWithValue("@Value", kvp.Value);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 4. Agregar nuevas entradas a la base de datos que están en el Dictionary pero no en la base de datos
                        foreach (var kvp in taxConfigurations)
                        {
                            if (!dbTaxConfigurations.ContainsKey(kvp.Key))
                            {
                                string insertQuery = "INSERT INTO Configurations (Key, Value) VALUES (@Key, @Value)";
                                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    insertCommand.Parameters.AddWithValue("@Value", kvp.Value);
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Manejar cualquier excepción que pueda ocurrir durante la transacción.
                        Console.WriteLine("Error al guardar/actualizar configuraciones: " + ex.Message);
                    }
                }
            }
        }

        public Dictionary<string, string> GetFineConfigurations()
        {
            Dictionary<string, string> fineConfigurations = new Dictionary<string, string>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Key, Value FROM Configurations WHERE Key LIKE '%fine_%'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["Key"].ToString();
                        string value = reader["Value"].ToString();
                        fineConfigurations[key] = value;
                    }
                }
            }

            return fineConfigurations;
        }

        public void SaveOrUpdateFineConfigurations(Dictionary<string, string> taxConfigurations)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener los datos actuales de la base de datos para las claves con prefijo "fine_"
                        Dictionary<string, string> dbTaxConfigurations = GetTaxConfigurations();

                        // 2. Eliminar las entradas en la base de datos que no existen en el Dictionary
                        foreach (var kvp in dbTaxConfigurations)
                        {
                            if (!taxConfigurations.ContainsKey(kvp.Key))
                            {
                                string deleteQuery = "DELETE FROM Configurations WHERE Key = @Key";
                                using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                                {
                                    deleteCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    deleteCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 3. Actualizar las entradas en la base de datos que ya existen y tienen valores diferentes en el Dictionary
                        foreach (var kvp in taxConfigurations)
                        {
                            if (dbTaxConfigurations.ContainsKey(kvp.Key) && dbTaxConfigurations[kvp.Key] != kvp.Value)
                            {
                                string updateQuery = "UPDATE Configurations SET Value = @Value WHERE Key = @Key";
                                using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    updateCommand.Parameters.AddWithValue("@Value", kvp.Value);
                                    updateCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        // 4. Agregar nuevas entradas a la base de datos que están en el Dictionary pero no en la base de datos
                        foreach (var kvp in taxConfigurations)
                        {
                            if (!dbTaxConfigurations.ContainsKey(kvp.Key))
                            {
                                string insertQuery = "INSERT INTO Configurations (Key, Value) VALUES (@Key, @Value)";
                                using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                                {
                                    insertCommand.Parameters.AddWithValue("@Key", kvp.Key);
                                    insertCommand.Parameters.AddWithValue("@Value", kvp.Value);
                                    insertCommand.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Manejar cualquier excepción que pueda ocurrir durante la transacción.
                        Console.WriteLine("Error al guardar/actualizar configuraciones: " + ex.Message);
                    }
                }
            }
        }

        public string GetConfigurationValue(string key)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Value FROM Configurations WHERE Key = @Key";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Value"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        public bool ConfigurationExists(string key)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Configurations WHERE Key = @Key";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Key", key);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Si el recuento es mayor que cero, la configuración existe
                    return count > 0;
                }
            }
        }
    }
}
