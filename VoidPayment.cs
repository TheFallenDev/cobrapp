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
            // Mostrar un cuadro de diálogo de confirmación
            string message = "¿Está seguro de que desea anular el comprobante " + txt_receipt_number.Text + "?" + Environment.NewLine + "Esta acción no se puede revertir.";
            DialogResult result = MessageBox.Show(message, "Confirmación de Anulación de Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Verificar la respuesta del usuario
            if (result == DialogResult.Yes)
            {
                Voider(txt_receipt_number.Text);
                txt_receipt_number.Text = "";
            }
            else
            {
                txt_receipt_number.Text = "";
            }
        }

        private void Voider (string receipt)
        {
            if (TaxLogic.Instance.SearchReceipt(receipt)) 
            {
                try
                {
                    TaxLogic.Instance.VoidTax(receipt);
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
