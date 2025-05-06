using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cobrapp.Logic;
using Cobrapp.Model;
using Cobrapp.Utils;

namespace Cobrapp
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();

            getConfigurations();
            getTaxConfigurations();
            getFineConfigurations();
            GetEntranceConcepts();
            LoadUsers();
            ToggleExtensionFields();
            CorrespondingComission.KeyPress += onlyNumbersAndComa_KeyPress;
            AdditionalPenalty.KeyPress += onlyNumbersAndComa_KeyPress;
            DelayPenalty.KeyPress += onlyNumbersAndComa_KeyPress;
            ExtensionAdditional.KeyPress += onlyNumbersAndComa_KeyPress;
            ExtensionDelay.KeyPress += onlyNumbersAndComa_KeyPress;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(!CheckAllFields())
            {
                MessageBox.Show("Debe completar todos los campos", "Campos vacíos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {

                Properties.Settings.Default.ShortName = ShortName.Text;
                Properties.Settings.Default.BusinessName = BusinessName.Text;
                Properties.Settings.Default.Address = Address.Text;
                Properties.Settings.Default.Phone = Phone.Text;
                Properties.Settings.Default.BusinessOwner = BusinessOwner.Text;
                Properties.Settings.Default.BusinessCode = BusinessCode.Text;
                Properties.Settings.Default.EmailUser = EmailUser.Text;
                Properties.Settings.Default.EmailPassword = EmailPassword.Text;
                Properties.Settings.Default.EmailPort = EmailPort.Text;
                Properties.Settings.Default.Emailserver = EmailServer.Text;
                Properties.Settings.Default.EmailReceiver = toEmail.Text;
                Properties.Settings.Default.DefaultPrinter = DefaultPrinter.Text;

                Properties.Settings.Default.CorrespondingComission = CorrespondingComission.Text;
                Properties.Settings.Default.AdditionalPenalty = decimal.Parse(AdditionalPenalty.Text);
                Properties.Settings.Default.DelayPenalty = decimal.Parse(DelayPenalty.Text);
                Properties.Settings.Default.ConfigurationPassword = ConfigurationPassword.Text;

                Properties.Settings.Default.ExtensionActive = ExtensionActive.Checked;
                Properties.Settings.Default.ExtensionEndDate = ExtensionEndDate.Text;
                Properties.Settings.Default.ExtensionLastDate = ExtensionLastDate.Text;
                Properties.Settings.Default.ExtensionAdditional = int.Parse(ExtensionAdditional.Text);
                Properties.Settings.Default.ExtensionDelay = int.Parse(ExtensionDelay.Text);
                Properties.Settings.Default.ExtensionDecree = ExtensionDecree.Text;
                Properties.Settings.Default.ConfigurationOK = "OK";

                Properties.Settings.Default.EntranceMode = EntranceMode.Checked;

                Properties.Settings.Default.Save();

                /*Dictionary<string, string> textBoxValues = SaveTextBoxValues(tabControl);

                foreach (var kvp in textBoxValues)
                {
                    ConfigurationLogic.Instance.SaveConfiguration(kvp.Key,kvp.Value);
                }*/

                Dictionary<string, string> keyValueTaxes = new Dictionary<string, string>();
                Dictionary<string, string> keyValueFines = new Dictionary<string, string>();
                Dictionary<string, string> keyValueEntranceConcepts = new Dictionary<string, string>();
                SaveDataGridViewToDictionary(dtgv_taxes, keyValueTaxes, "tax");
                SaveDataGridViewToDictionary(dtgv_fines, keyValueFines, "fine_");
                SaveDataGridViewToDictionary(dtgv_entranceConcepts, keyValueEntranceConcepts, "entranceConcept");
                ConfigurationLogic.Instance.SaveOrUpdateTaxConfigurations(keyValueTaxes);
                ConfigurationLogic.Instance.SaveOrUpdateFineConfigurations(keyValueFines);
                ConfigurationLogic.Instance.SaveOrUpdateEntranceConcepts(keyValueEntranceConcepts);

                MessageBox.Show("La aplicación se reiniciará para aplicar los cambios.", "Configuración guardada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reiniciar la aplicación
                Application.Restart();
            }
        }
        private void LoadUsers()
        {
            // Obtener los usuarios desde la base de datos
            List<User> users = ConfigurationLogic.Instance.GetAllUsers();

            // Limpiar filas existentes
            dtgv_users.Rows.Clear();

            // Agregar filas al DataGridView
            foreach (var user in users)
            {
                dtgv_users.Rows.Add(user.Username, user.RoleId, user.IsActive ? true : false);
            }
        }

        private bool CheckAllFields()
        {
            bool allFieldsValid = true;
            string emptyFields = "";

            // Lista de campos a ignorar si ExtensionActive es False
            List<string> fieldsToIgnore = new List<string>
            {
                "ExtensionEndDate",
                "ExtensionLastDate",
                "ExtensionAdditional",
                "ExtensionDelay",
                "ExtensionDecree"
            };

            // Itera a través de todos los controles dentro de todos los tabpages del TabControl.
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    // Verifica si el control es un TextBox.
                    if (control is TextBox textBox)
                    {
                        // Si ExtensionActive es False, ignora los campos especificados
                        if (!ExtensionActive.Checked && fieldsToIgnore.Contains(textBox.Name))
                        {
                            continue;
                        }

                        // Verifica si el TextBox está vacío o contiene un valor no válido.
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            // El campo no es válido, marca la bandera como falsa.
                            allFieldsValid = false;
                            // Agrega el nombre del campo vacío a la lista de campos vacíos.
                            emptyFields += $"{textBox.Name}, ";
                        }
                    }
                }
            }

            // Elimina la última coma y el espacio de la lista de campos vacíos.
            emptyFields = emptyFields.TrimEnd(',', ' ');

            if (!allFieldsValid)
            {
                // Muestra un MessageBox con la lista de campos vacíos.
                MessageBox.Show($"Los siguientes campos están vacíos o contienen valores no válidos: {emptyFields}", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return allFieldsValid;
        }


        /*public Dictionary<string, string> SaveTextBoxValues(TabControl tabControl)
        {
            Dictionary<string, string> textBoxValues = new Dictionary<string, string>();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    if (control is TextBox textBox)
                    {
                        // Guarda el valor del TextBox utilizando el nombre del control como clave.
                        textBoxValues[textBox.Name] = textBox.Text;
                    }
                }
            }

            return textBoxValues;
        }*/

        private void SaveDataGridViewToDictionary(DataGridView dataGridView, Dictionary<string, string> dictionary, string prefix)
        {
            // Limpiar el diccionario existente antes de agregar nuevos datos.
            dictionary.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells.Count == 2 && row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string key = prefix + row.Cells[0].Value.ToString();
                    string value = row.Cells[1].Value.ToString();

                    // Verificar si la clave ya existe en el diccionario antes de agregarla.
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, value);
                    }
                }
            }
        }

        private void getConfigurations()
        {

            ShortName.Text = Properties.Settings.Default.ShortName;
            BusinessName.Text = Properties.Settings.Default.BusinessName;
            Address.Text = Properties.Settings.Default.Address;
            Phone.Text = Properties.Settings.Default.Phone;
            BusinessOwner.Text = Properties.Settings.Default.BusinessOwner;
            BusinessCode.Text = Properties.Settings.Default.BusinessCode;
            EmailUser.Text = Properties.Settings.Default.EmailUser;
            EmailPassword.Text = Properties.Settings.Default.EmailPassword;
            EmailPort.Text = Properties.Settings.Default.EmailPort;
            EmailServer.Text = Properties.Settings.Default.Emailserver;
            toEmail.Text = Properties.Settings.Default.EmailReceiver;
            DefaultPrinter.Text = Properties.Settings.Default.DefaultPrinter;

            CorrespondingComission.Text = Properties.Settings.Default.CorrespondingComission;
            AdditionalPenalty.Text = Properties.Settings.Default.AdditionalPenalty.ToString();
            DelayPenalty.Text = Properties.Settings.Default.DelayPenalty.ToString();
            ConfigurationPassword.Text = Properties.Settings.Default.ConfigurationPassword;

            ExtensionActive.Checked = Properties.Settings.Default.ExtensionActive;
            ExtensionEndDate.Text = Properties.Settings.Default.ExtensionEndDate;
            ExtensionLastDate.Text = Properties.Settings.Default.ExtensionLastDate;
            ExtensionAdditional.Text = Properties.Settings.Default.ExtensionAdditional.ToString();
            ExtensionDelay.Text = Properties.Settings.Default.ExtensionDelay.ToString();
            ExtensionDecree.Text = Properties.Settings.Default.ExtensionDecree;

            EntranceMode.Checked = Properties.Settings.Default.EntranceMode;

            /*
            Dictionary<string, string> config = ConfigurationLogic.Instance.GetAllConfigurations();

            if (config.Count != 0)
            {
                foreach (TabPage tabPage in tabControl.TabPages)
                {
                    foreach (Control control in tabPage.Controls)
                    {
                        if (control is TextBox textBox)
                        {
                            // Verificar si la clave del diccionario coincide con el nombre del TextBox.
                            if (config.ContainsKey(textBox.Name))
                            {
                                // Asignar el valor del diccionario al TextBox.
                                textBox.Text = config[textBox.Name];
                            }
                        }
                    }
                }
            }
            DefaultPrinter.Text = ConfigurationLogic.GetDefaultPrinter();
            */
        }

        private void getTaxConfigurations()
        {
            Dictionary<string, string> taxConfigurations = ConfigurationLogic.Instance.GetTaxConfigurations();

            dtgv_taxes.Rows.Clear();

            foreach (var kvp in taxConfigurations)
            {
                // Elimina el prefijo "tax" de la clave
                string keyWithoutTax = kvp.Key.Substring(3);
                dtgv_taxes.Rows.Add(keyWithoutTax, kvp.Value);
            }
        }

        private void getFineConfigurations()
        {
            Dictionary<string, string> fineConfigurations = ConfigurationLogic.Instance.GetFineConfigurations();

            dtgv_fines.Rows.Clear();

            foreach (var kvp in fineConfigurations)
            {
                // Elimina el prefijo "fine_" de la clave
                string keyWithoutFine = kvp.Key.Substring(5);
                dtgv_fines.Rows.Add(keyWithoutFine, kvp.Value);
            }
        }

        private void GetEntranceConcepts()
        {
            Dictionary<string, string> entranceConcepts = ConfigurationLogic.Instance.GetEntranceConcepts();

            // Limpia el DataGridView antes de llenarlo
            dtgv_entranceConcepts.Rows.Clear();

            foreach (var kvp in entranceConcepts)
            {
                // Elimina el prefijo "entranceConcept" de la clave
                string keyWithoutPrefix = kvp.Key.Substring(15); // "entranceConcept" tiene 15 caracteres
                dtgv_entranceConcepts.Rows.Add(keyWithoutPrefix, kvp.Value);
            }
        }


        private void onlyNumbersAndComa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si la tecla presionada no es un número ni una coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                // Cancelar la entrada del caracter
                e.Handled = true;
            }

            // Permitir solo una coma en el TextBox
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(','))
            {
                e.Handled = true;
            }
        }

        private void ToggleExtensionFields()
        {
            bool enableFields = ExtensionActive.Checked;

            ExtensionEndDate.Enabled = enableFields;
            ExtensionLastDate.Enabled = enableFields;
            ExtensionAdditional.Enabled = enableFields;
            ExtensionDelay.Enabled = enableFields;
            ExtensionDecree.Enabled = enableFields;
        }

        private void btn_PrinterSelection_Click(object sender, EventArgs e)
        {
            ConfigurationLogic.SelectDefaultPrinter();
            DefaultPrinter.Text = ConfigurationLogic.GetDefaultPrinter();
        }

        private void ExtensionActive_CheckedChanged(object sender, EventArgs e)
        {
            ToggleExtensionFields();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPassword.Text.Trim();
            int roleId = Convert.ToInt32(txtRole.Text);
            if (ConfigurationLogic.Instance.UserExists(username))
            {
                ConfigurationLogic.Instance.ChangePassword(username,password);
            }
            else
            {
                ConfigurationLogic.Instance.RegisterUser(username,password,roleId);
            }
        }
    }
}
