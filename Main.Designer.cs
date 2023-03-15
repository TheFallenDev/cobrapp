namespace Cobrapp
{
    partial class main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_collect_taxes = new System.Windows.Forms.Button();
            this.btn_void_payment = new System.Windows.Forms.Button();
            this.lbl_select_message = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.Location = new System.Drawing.Point(347, 162);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(94, 35);
            this.btn_collect_taxes.TabIndex = 0;
            this.btn_collect_taxes.Text = "Cobrar tasas";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            this.btn_collect_taxes.Click += new System.EventHandler(this.btn_collect_taxes_Click);
            // 
            // btn_void_payment
            // 
            this.btn_void_payment.Location = new System.Drawing.Point(347, 215);
            this.btn_void_payment.Name = "btn_void_payment";
            this.btn_void_payment.Size = new System.Drawing.Size(94, 35);
            this.btn_void_payment.TabIndex = 1;
            this.btn_void_payment.Text = "Anular pago";
            this.btn_void_payment.UseVisualStyleBackColor = true;
            // 
            // lbl_select_message
            // 
            this.lbl_select_message.AutoSize = true;
            this.lbl_select_message.Location = new System.Drawing.Point(335, 90);
            this.lbl_select_message.Name = "lbl_select_message";
            this.lbl_select_message.Size = new System.Drawing.Size(116, 13);
            this.lbl_select_message.TabIndex = 2;
            this.lbl_select_message.Text = "Seleccione una opción";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(316, 385);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(162, 29);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Enviar archivo de recaudación";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbl_select_message);
            this.Controls.Add(this.btn_void_payment);
            this.Controls.Add(this.btn_collect_taxes);
            this.Name = "main";
            this.Text = "Cobrapp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_collect_taxes;
        private System.Windows.Forms.Button btn_void_payment;
        private System.Windows.Forms.Label lbl_select_message;
        private System.Windows.Forms.Button btn_send;
    }
}

