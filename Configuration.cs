using System;
using System.Collections.Generic;
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
            getFineConfigurations();
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

                Dictionary<string, string> keyValueTaxes = new Dictionary<string, string>();
                Dictionary<string, string> keyValueFines = new Dictionary<string, string>();
                SaveDataGridViewToDictionary(dtgv_taxes, keyValueTaxes, "tax");
                SaveDataGridViewToDictionary(dtgv_fines, keyValueFines, "fine_");
                ConfigurationLogic.Instance.SaveOrUpdateTaxConfigurations(keyValueTaxes);
                ConfigurationLogic.Instance.SaveOrUpdateFineConfigurations(keyValueFines);
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
    }
}
