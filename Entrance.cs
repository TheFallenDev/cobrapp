using Cobrapp.Logic;
using Cobrapp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Utils;

namespace Cobrapp
{
    public partial class Entrance : Form
    {
        public Entrance()
        {
            InitializeComponent();

            dtgv_entrances.Rows.Clear();
            dtgv_entrances.Columns[1].DefaultCellStyle.Format = "C";
            dtgv_entrances.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgv_entrances.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgv_entrances.Columns[3].DefaultCellStyle.Format = "C";
            dtgv_entrances.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgv_entrances.EditingControlShowing += dtgv_entrances_EditingControlShowing;
            dtgv_entrances.CellValueChanged += dtgv_entrances_CellValueChanged;
            dtgv_entrances.CellEndEdit += dtgv_entranceConcepts_CellEndEdit;

            GetEntranceConcepts();
        }

        private void GetEntranceConcepts()
        {
            Dictionary<string, string> entranceConcepts = ConfigurationLogic.Instance.GetEntranceConcepts();

            // Limpia el DataGridView antes de llenarlo
            dtgv_entrances.Rows.Clear();

            foreach (var kvp in entranceConcepts)
            {
                // Elimina el prefijo "entranceConcept" de la clave
                string keyWithoutPrefix = kvp.Key.Substring(15); // "entranceConcept" tiene 15 caracteres
                dtgv_entrances.Rows.Add(keyWithoutPrefix, kvp.Value);
            }
        }

        private void dtgv_entrances_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Verifica si la columna que se está editando es la de números
            if (dtgv_entrances.CurrentCell.ColumnIndex == 2)
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    // Elimina cualquier handler previo para evitar múltiples suscripciones
                    textBox.KeyPress -= TextBox_KeyPressOnlyNumbers;

                    // Agrega el evento para permitir solo números
                    textBox.KeyPress += TextBox_KeyPressOnlyNumbers;
                }
            }
        }

        // Evento KeyPress para validar que solo se ingresen números
        private void TextBox_KeyPressOnlyNumbers(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, tecla de retroceso y punto decimal (si aplica)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Bloquea la entrada si no es un número
            }
        }

        private void dtgv_entrances_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // Cambia "1" al índice de la columna deseada
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out _))
                {
                    MessageBox.Show("Por favor, ingresa solo números.");
                    e.Cancel = true; // Cancela la edición si el valor no es numérico
                }
            }
        }

        private void dtgv_entrances_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si la celda editada pertenece a la columna de Cantidad (1) o Precio Unitario (2)
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                try
                {
                    // Obtiene la fila correspondiente
                    DataGridViewRow row = dtgv_entrances.Rows[e.RowIndex];

                    // Obtiene los valores de Cantidad y Precio Unitario
                    object quantityObj = row.Cells[2].Value;
                    object priceObj = row.Cells[1].Value;

                    // Intenta convertirlos a valores numéricos
                    if (decimal.TryParse(Convert.ToString(quantityObj), out decimal quantity) &&
                        decimal.TryParse(Convert.ToString(priceObj), out decimal price))
                    {
                        // Calcula el subtotal
                        decimal subtotal = quantity * price;

                        // Asigna el subtotal a la celda correspondiente
                        row.Cells[3].Value = subtotal;
                    }
                    else
                    {
                        // Si los valores no son válidos, pone 0 en el subtotal
                        row.Cells[3].Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al calcular el subtotal: {ex.Message}");
                }
            }
        }

        private void dtgv_entranceConcepts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Fuerza el evento CellValueChanged
            dtgv_entrances.CommitEdit(DataGridViewDataErrorContexts.Commit);
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                if (row.Cells[3].Value != null && decimal.TryParse(row.Cells[3].Value.ToString(), out decimal subtotal))
                {
                    total += subtotal;
                }
            }

            lbl_total.Text = total.ToString("C"); // Muestra el total en un Label
        }

        private void btnCobrar_KeyDown(object sender, KeyEventArgs e)
        {
            // Validar los datos del DataGridView
            int quant = 0;
            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                quant += Convert.ToInt32(row.Cells[2].Value); // Columna 3: Subtotal
            }
            if (dtgv_entrances.Rows.Count == 0 || quant == 0)
            {
                MessageBox.Show("No hay conceptos para cobrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular el total
            decimal total = 0;
            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                total += Convert.ToDecimal(row.Cells[3].Value); // Columna 3: Subtotal
            }

            List<string> concepts = new List<string>();
            List<decimal> values = new List<decimal>();
            List<string> quantitys = new List<string>();

            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                {
                    MessageBox.Show("Asegúrese de que todas las filas tengan conceptos y valores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (row.Cells[2].Value != null && Convert.ToInt32(row.Cells[2].Value) > 0)
                {
                    concepts.Add(row.Cells[0].Value.ToString());
                    values.Add(Convert.ToDecimal(row.Cells[3].Value));
                    quantitys.Add(row.Cells[2].Value.ToString());
                }
            }

            int ticketId = EntranceLogic.Instance.GetLastInsertedTicketId();

            Ticket myticket = new Ticket
            {
                Date = DateTime.Now.ToString(),
                TotalPrice = total,
                FirstColumn = concepts.ToArray(),
                SecondColumn = quantitys.ToArray(),
                PriceColumn = values.ToArray(),
                TicketNumber = ticketId + 1
            };

            myticket.PrintTicket(Ticket.PrintType.EntranceTicket);

            // Crear el ticket
            string payment_method = "";
            if (e.KeyCode == Keys.F9) payment_method = "Posnet";
            if (e.KeyCode == Keys.F12) payment_method = "Efectivo";
            EntranceTicket ticket = new EntranceTicket
            {
                Date = DateTime.Now.ToString("yyyy-MM-dd"),
                Time = DateTime.Now.ToString("HH:mm:ss"),
                Concepts = GetDetailedConcepts(),
                Total = total,
                Payment_method = payment_method // Cambia según sea necesario
            };

            try
            {
                // Guardar el ticket
                EntranceLogic.Instance.AddEntranceTicket(ticket);

                // Obtener el ID del ticket generado
                ticketId = EntranceLogic.Instance.GetLastInsertedTicketId();
                // Guardar los conceptos como entradas individuales
                foreach (DataGridViewRow row in dtgv_entrances.Rows)
                {
                    string conceptName = row.Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells[2].Value);
                    decimal value = Convert.ToDecimal(row.Cells[1].Value);

                    for (int i = 0; i < quantity; i++)
                    {
                        EntranceConcept concept = new EntranceConcept
                        {
                            Name = conceptName,
                            Value = value,
                            TicketId = ticketId
                        };
                        EntranceLogic.Instance.AddEntranceConcept(concept);
                    }
                }

                // Confirmar éxito
                MessageBox.Show("Cobro realizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cleaner();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar el cobro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cleaner()
        {
            // Limpiar el DataGridView
            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                row.Cells[2].Value = 0;
                CalculateTotal(); // Columna 3: Subtotal
            }
        }

        // Método auxiliar para obtener los conceptos detallados
        private string GetDetailedConcepts()
        {
            List<string> concepts = new List<string>();
            foreach (DataGridViewRow row in dtgv_entrances.Rows)
            {
                if (row.Cells[2].Value != null)
                {
                    string name = row.Cells[0].Value.ToString();
                    int quantity = Convert.ToInt32(row.Cells[2].Value);
                    decimal value = Convert.ToDecimal(row.Cells[1].Value);
                    concepts.Add($"{quantity}x {name} ({value:C})");
                }
            }
            return string.Join(", ", concepts);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            // Asegúrate de que el DataGridView esté correctamente poblado antes de intentar seleccionar la celda.
            if (dtgv_entrances.Rows.Count > 0)
            {
                // Seleccionar la celda de la fila 0 y la columna 1.
                dtgv_entrances.CurrentCell = dtgv_entrances[2, 0];  // [columna, fila]
            }
            Cleaner();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9 || e.KeyCode == Keys.F12) btnCobrar_KeyDown(sender, e);
        }
    }
}
