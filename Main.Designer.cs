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
            this.btn_daily_total = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_stamps = new System.Windows.Forms.Button();
            this.btn_payments_list = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.Location = new System.Drawing.Point(208, 116);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(162, 35);
            this.btn_collect_taxes.TabIndex = 0;
            this.btn_collect_taxes.Text = "Cobrar tasas";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            this.btn_collect_taxes.Click += new System.EventHandler(this.btn_collect_taxes_Click);
            // 
            // btn_void_payment
            // 
            this.btn_void_payment.Location = new System.Drawing.Point(312, 170);
            this.btn_void_payment.Name = "btn_void_payment";
            this.btn_void_payment.Size = new System.Drawing.Size(162, 35);
            this.btn_void_payment.TabIndex = 1;
            this.btn_void_payment.Text = "Anular pago";
            this.btn_void_payment.UseVisualStyleBackColor = true;
            // 
            // lbl_select_message
            // 
            this.lbl_select_message.AutoSize = true;
            this.lbl_select_message.Location = new System.Drawing.Point(331, 45);
            this.lbl_select_message.Name = "lbl_select_message";
            this.lbl_select_message.Size = new System.Drawing.Size(116, 13);
            this.lbl_select_message.TabIndex = 2;
            this.lbl_select_message.Text = "Seleccione una opción";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(312, 381);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(162, 29);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "Enviar archivo de recaudación";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // btn_daily_total
            // 
            this.btn_daily_total.Location = new System.Drawing.Point(312, 255);
            this.btn_daily_total.Name = "btn_daily_total";
            this.btn_daily_total.Size = new System.Drawing.Size(162, 35);
            this.btn_daily_total.TabIndex = 4;
            this.btn_daily_total.Text = "Totales";
            this.btn_daily_total.UseVisualStyleBackColor = true;
            this.btn_daily_total.Click += new System.EventHandler(this.btn_daily_total_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 255);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Comisión";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_stamps
            // 
            this.btn_stamps.Location = new System.Drawing.Point(409, 116);
            this.btn_stamps.Name = "btn_stamps";
            this.btn_stamps.Size = new System.Drawing.Size(162, 35);
            this.btn_stamps.TabIndex = 6;
            this.btn_stamps.Text = "Sellados";
            this.btn_stamps.UseVisualStyleBackColor = true;
            this.btn_stamps.Click += new System.EventHandler(this.btn_stamps_Click);
            // 
            // btn_payments_list
            // 
            this.btn_payments_list.Location = new System.Drawing.Point(144, 255);
            this.btn_payments_list.Name = "btn_payments_list";
            this.btn_payments_list.Size = new System.Drawing.Size(162, 35);
            this.btn_payments_list.TabIndex = 7;
            this.btn_payments_list.Text = "Listado de cobros";
            this.btn_payments_list.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_payments_list);
            this.Controls.Add(this.btn_stamps);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_daily_total);
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
        private System.Windows.Forms.Button btn_daily_total;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_stamps;
        private System.Windows.Forms.Button btn_payments_list;
    }
}

