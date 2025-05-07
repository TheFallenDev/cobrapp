using Cobrapp.Model;
using Cobrapp.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Drawing.Printing;
using System.Windows.Forms;

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
        public void CreateDefaultRoles()
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "INSERT OR IGNORE INTO Roles (Name) VALUES ('Admin'), ('User'), ('Guest')";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        public void EnsureDefaultAdminExists()
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                // Verifica si la tabla Users está vacía
                string query = "SELECT COUNT(*) FROM Users";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    long userCount = (long)command.ExecuteScalar();
                    if (userCount == 0)
                    {
                        // Inserta el rol Admin si no existe
                        string insertRole = "INSERT OR IGNORE INTO Roles (Name) VALUES ('Admin')";
                        using (SQLiteCommand roleCommand = new SQLiteCommand(insertRole, connection))
                        {
                            roleCommand.ExecuteNonQuery();
                        }

                        // Crea el usuario Admin
                        string insertAdmin = @"
                    INSERT INTO Users (Username, PasswordHash, RoleId, IsActive)
                    VALUES ('admin', @PasswordHash, 
                            (SELECT Id FROM Roles WHERE Name = 'Admin'), 1)";
                        using (SQLiteCommand adminCommand = new SQLiteCommand(insertAdmin, connection))
                        {
                            string hashedPassword = MyUtils.HashPassword("admin123"); // Implementa tu función de hashing
                            adminCommand.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                            adminCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public bool UserExists(string username)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Devuelve true si el usuario existe, de lo contrario false
                }
            }
        }

        public void RegisterUser(string username, string password, int roleId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string hashedPassword = MyUtils.HashPassword(password);

                string query = @"
            INSERT INTO Users (Username, PasswordHash, RoleId, IsActive)
            VALUES (@Username, @PasswordHash, @RoleId, 1)";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@RoleId", roleId);
                    command.ExecuteNonQuery();
                }
            }
        }
        public (bool, string) Login(string username, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = @"
            SELECT PasswordHash, 
                   (SELECT Name FROM Roles WHERE Roles.Id = Users.RoleId) AS Role
            FROM Users
            WHERE Username = @Username AND IsActive = 1";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["PasswordHash"].ToString();
                            string role = reader["Role"].ToString();

                            bool isAuthenticated = MyUtils.VerifyPassword(password, storedHash);
                            return (isAuthenticated, isAuthenticated ? role : string.Empty);
                        }
                    }
                }
            }

            return (false, string.Empty); // Usuario no encontrado o contraseña incorrecta
        }

        public void ChangePassword(string username, string newPassword)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string hashedPassword = MyUtils.HashPassword(newPassword);

                string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE Username = @Username";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateUserRole(string username, int newRoleId)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "UPDATE Users SET RoleId = @RoleId WHERE Username = @Username";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoleId", newRoleId);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void SetUserActiveState(string username, bool isActive)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "UPDATE Users SET IsActive = @IsActive WHERE Username = @Username";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IsActive", isActive ? 1 : 0);
                    command.Parameters.AddWithValue("@Username", username);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                string query = "SELECT u.Id, u.Username, r.Id AS RoleId, u.IsActive FROM Users u " +
                               "INNER JOIN Roles r ON u.RoleId = r.Id";
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                RoleId = reader.GetInt32(2),
                                IsActive = reader.GetBoolean(3)
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public bool AddOrUpdateConfiguration(string key, string value)
        {
            try
            {
                if (Properties.Settings.Default.Properties[key] == null)
                {
                    // Crear nueva propiedad dinámica
                    SettingsProperty property = new SettingsProperty(key)
                    {
                        PropertyType = typeof(string),
                        IsReadOnly = false,
                        DefaultValue = value,
                        Provider = Properties.Settings.Default.Providers["LocalFileSettingsProvider"]
                    };
                    Properties.Settings.Default.Properties.Add(property);
                }

                Properties.Settings.Default[key] = value;
                Properties.Settings.Default.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar configuración: {ex.Message}");
                return false;
            }
        }
        /*
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
        */

        public string GetConfigurationValue(string key)
        {
            try
            {
                if (Properties.Settings.Default.Properties[key] != null)
                {
                    return Properties.Settings.Default[key]?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener configuración: {ex.Message}");
            }

            return null;
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

        public void SaveOrUpdateFineConfigurations(Dictionary<string, string> fineConfigurations)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener los datos actuales de la base de datos para las claves con prefijo "fine_"
                        Dictionary<string, string> dbFineConfigurations = GetFineConfigurations();

                        // 2. Eliminar las entradas en la base de datos que no existen en el Dictionary
                        foreach (var kvp in dbFineConfigurations)
                        {
                            if (!fineConfigurations.ContainsKey(kvp.Key))
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
                        foreach (var kvp in fineConfigurations)
                        {
                            if (dbFineConfigurations.ContainsKey(kvp.Key) && dbFineConfigurations[kvp.Key] != kvp.Value)
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
                        foreach (var kvp in fineConfigurations)
                        {
                            if (!dbFineConfigurations.ContainsKey(kvp.Key))
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

        public Dictionary<string, string> GetEntranceConcepts()
        {
            Dictionary<string, string> entranceConcepts = new Dictionary<string, string>();

            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Key, Value FROM Configurations WHERE Key LIKE '%entranceConcept%'";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string key = reader["Key"].ToString();
                        string value = reader["Value"].ToString();
                        entranceConcepts[key] = value;
                    }
                }
            }

            return entranceConcepts;
        }

        public void SaveOrUpdateEntranceConcepts(Dictionary<string, string> entranceConcepts)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obtener los datos actuales de la base de datos para las claves con prefijo "entranceConcept"
                        Dictionary<string, string> dbEntranceConcepts = GetEntranceConcepts();

                        // 2. Eliminar las entradas en la base de datos que no existen en el Dictionary
                        foreach (var kvp in dbEntranceConcepts)
                        {
                            if (!entranceConcepts.ContainsKey(kvp.Key))
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
                        foreach (var kvp in entranceConcepts)
                        {
                            if (dbEntranceConcepts.ContainsKey(kvp.Key) && dbEntranceConcepts[kvp.Key] != kvp.Value)
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
                        foreach (var kvp in entranceConcepts)
                        {
                            if (!dbEntranceConcepts.ContainsKey(kvp.Key))
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

        /*
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
        */
        public string GetConfigurationKey(string value)
        {
            using (SQLiteConnection connection = new SQLiteConnection(conn))
            {
                connection.Open();

                string query = "SELECT Key FROM Configurations WHERE Value = @Value";

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["Key"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        public Dictionary<string, string> GetAllConfigurations()
        {
            Dictionary<string, string> configurations = new Dictionary<string, string>();

            foreach (SettingsProperty property in Properties.Settings.Default.Properties)
            {
                configurations[property.Name] = Properties.Settings.Default[property.Name]?.ToString();
            }

            return configurations;
        }

        public bool ConfigurationExists(string key)
        {
            return Properties.Settings.Default.Properties[key] != null;
        }

        public static void SelectDefaultPrinter()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrinterSettings = new PrinterSettings();

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPrinter = printDialog.PrinterSettings.PrinterName;
                Properties.Settings.Default.DefaultPrinter = selectedPrinter;
                Properties.Settings.Default.Save();
                MessageBox.Show($"Impresora seleccionada: {selectedPrinter}");
            }
        }

        public static string GetDefaultPrinter()
        {
            return Properties.Settings.Default.DefaultPrinter;
        }
        /*
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
        */
    }
}
