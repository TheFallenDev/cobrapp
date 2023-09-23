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
            this.btn_daily_total = new System.Windows.Forms.Button();
            this.btn_commissions = new System.Windows.Forms.Button();
            this.btn_stamps = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.Location = new System.Drawing.Point(312, 97);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(162, 35);
            this.btn_collect_taxes.TabIndex = 0;
            this.btn_collect_taxes.Text = "Cobrar tasas";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            this.btn_collect_taxes.Click += new System.EventHandler(this.btn_collect_taxes_Click);
            // 
            // btn_void_payment
            // 
            this.btn_void_payment.Location = new System.Drawing.Point(312, 240);
            this.btn_void_payment.Name = "btn_void_payment";
            this.btn_void_payment.Size = new System.Drawing.Size(162, 35);
            this.btn_void_payment.TabIndex = 1;
            this.btn_void_payment.Text = "Anular pago";
            this.btn_void_payment.UseVisualStyleBackColor = true;
            this.btn_void_payment.Click += new System.EventHandler(this.btn_void_payment_Click);
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
            // btn_daily_total
            // 
            this.btn_daily_total.Location = new System.Drawing.Point(208, 322);
            this.btn_daily_total.Name = "btn_daily_total";
            this.btn_daily_total.Size = new System.Drawing.Size(162, 35);
            this.btn_daily_total.TabIndex = 4;
            this.btn_daily_total.Text = "Totales diarios";
            this.btn_daily_total.UseVisualStyleBackColor = true;
            this.btn_daily_total.Click += new System.EventHandler(this.btn_daily_total_Click);
            // 
            // btn_commissions
            // 
            this.btn_commissions.Location = new System.Drawing.Point(409, 322);
            this.btn_commissions.Name = "btn_commissions";
            this.btn_commissions.Size = new System.Drawing.Size(162, 35);
            this.btn_commissions.TabIndex = 5;
            this.btn_commissions.Text = "Comisiones";
            this.btn_commissions.UseVisualStyleBackColor = true;
            this.btn_commissions.Click += new System.EventHandler(this.btn_commissions_Click);
            // 
            // btn_stamps
            // 
            this.btn_stamps.Location = new System.Drawing.Point(208, 172);
            this.btn_stamps.Name = "btn_stamps";
            this.btn_stamps.Size = new System.Drawing.Size(162, 35);
            this.btn_stamps.TabIndex = 6;
            this.btn_stamps.Text = "Sellados";
            this.btn_stamps.UseVisualStyleBackColor = true;
            this.btn_stamps.Click += new System.EventHandler(this.btn_stamps_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 172);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "Multas y estadías";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_stamps);
            this.Controls.Add(this.btn_commissions);
            this.Controls.Add(this.btn_daily_total);
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
        private System.Windows.Forms.Button btn_daily_total;
        private System.Windows.Forms.Button btn_commissions;
        private System.Windows.Forms.Button btn_stamps;
        private System.Windows.Forms.Button button2;
    }
}

