using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cobrapp.Logic;
using Cobrapp.Model;
using Cobrapp.Utils;

namespace Cobrapp
{
    public partial class VoidPayment : Form
    {
        public VoidPayment()
        {
            InitializeComponent();
        }

        private void btn_void_Click(object sender, EventArgs e)
        {

            if (TaxLogic.Instance.IsReceiptVoided(txt_receipt_number.Text))
            {
                // El recibo ya fue anulado previamente, muestra un mensaje de advertencia o toma la acción adecuada
                MessageBox.Show("Este recibo ya ha sido anulado previamente.", "Recibo Anulado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string description = Prompt.ShowDialog("Por favor, ingrese el motivo de la anulación:", "Motivo de Anulación");
                // Verificar si el usuario ingresó un motivo
                if (!string.IsNullOrEmpty(description))
                {
                    // Realizar la anulación con el motivo proporcionado
                    Voider(txt_receipt_number.Text, description);
                    txt_receipt_number.Text = "";
                }
                else
                {
                    MessageBox.Show("Debe proporcionar un motivo válido para la anulación.", "Motivo no válido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
        }

        private void Voider (string receipt, string description)
        {
            if (TaxLogic.Instance.SearchReceipt(receipt)) 
            {
                try
                {
                    TaxLogic.Instance.VoidTax(receipt, description);
                    MessageBox.Show("Comprobante anulado exitosamente", "Exito", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Se produjo una excepción: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Comprobante no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_receipt_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si no es un número ni una tecla de retroceso, se cancela la entrada
                e.Handled = true;
            }
        }
    }
}
