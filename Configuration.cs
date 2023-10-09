using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cobrapp.Logic;

namespace Cobrapp
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();

            getConfigurations();
            getTaxConfigurations();

            CorrespondingComission.KeyPress += onlyNumbersAndComa_KeyPress;
            AdditionalPenalty.KeyPress += onlyNumbersAndComa_KeyPress;
            DelayPenalty.KeyPress += onlyNumbersAndComa_KeyPress;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(!CheckAllFields())
            {
                MessageBox.Show("Debe completar todos los campos", "Campos vacíos",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                Dictionary<string, string> textBoxValues = SaveTextBoxValues(tabControl);

                foreach (var kvp in textBoxValues)
                {
                    ConfigurationLogic.Instance.SaveConfiguration(kvp.Key,kvp.Value);
                }

                Dictionary<string, string> keyValueData = new Dictionary<string, string>();
                SaveDataGridViewToDictionary(dtgv_taxes, keyValueData);
                ConfigurationLogic.Instance.SaveOrUpdateTaxConfigurations(keyValueData);
            }
        }

        private bool CheckAllFields()
        {
            bool allFieldsValid = true;
            string emptyFields = "";

            // Itera a través de todos los controles dentro de todos los tabpages del TabControl.
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                foreach (Control control in tabPage.Controls)
                {
                    // Verifica si el control es un TextBox.
                    if (control is TextBox textBox)
                    {
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

        public Dictionary<string, string> SaveTextBoxValues(TabControl tabControl)
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
        }

        private void SaveDataGridViewToDictionary(DataGridView dataGridView, Dictionary<string, string> dictionary)
        {
            // Limpiar el diccionario existente antes de agregar nuevos datos.
            dictionary.Clear();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Cells.Count == 2 && row.Cells[0].Value != null && row.Cells[1].Value != null)
                {
                    string key = "tax" + row.Cells[0].Value.ToString();
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
    }
}
