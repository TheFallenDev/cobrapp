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
            this.btn_fees = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.credencialesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreLaAplicaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.Location = new System.Drawing.Point(312, 97);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(162, 35);
            this.btn_collect_taxes.TabIndex = 0;
            this.btn_collect_taxes.Text = "Cobrar tasas (F1)";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            this.btn_collect_taxes.Click += new System.EventHandler(this.btn_collect_taxes_Click);
            // 
            // btn_void_payment
            // 
            this.btn_void_payment.Location = new System.Drawing.Point(312, 240);
            this.btn_void_payment.Name = "btn_void_payment";
            this.btn_void_payment.Size = new System.Drawing.Size(162, 35);
            this.btn_void_payment.TabIndex = 1;
            this.btn_void_payment.Text = "Anular pago (F4)";
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
            this.btn_daily_total.Text = "Totales diarios (F5)";
            this.btn_daily_total.UseVisualStyleBackColor = true;
            this.btn_daily_total.Click += new System.EventHandler(this.btn_daily_total_Click);
            // 
            // btn_commissions
            // 
            this.btn_commissions.Location = new System.Drawing.Point(409, 322);
            this.btn_commissions.Name = "btn_commissions";
            this.btn_commissions.Size = new System.Drawing.Size(162, 35);
            this.btn_commissions.TabIndex = 5;
            this.btn_commissions.Text = "Comisiones (F6)";
            this.btn_commissions.UseVisualStyleBackColor = true;
            this.btn_commissions.Click += new System.EventHandler(this.btn_commissions_Click);
            // 
            // btn_stamps
            // 
            this.btn_stamps.Location = new System.Drawing.Point(208, 172);
            this.btn_stamps.Name = "btn_stamps";
            this.btn_stamps.Size = new System.Drawing.Size(162, 35);
            this.btn_stamps.TabIndex = 6;
            this.btn_stamps.Text = "Sellados (F2)";
            this.btn_stamps.UseVisualStyleBackColor = true;
            this.btn_stamps.Click += new System.EventHandler(this.btn_stamps_Click);
            // 
            // btn_fees
            // 
            this.btn_fees.Location = new System.Drawing.Point(408, 172);
            this.btn_fees.Name = "btn_fees";
            this.btn_fees.Size = new System.Drawing.Size(162, 35);
            this.btn_fees.TabIndex = 7;
            this.btn_fees.Text = "Multas y estadías (F3)";
            this.btn_fees.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraciónToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuraciónToolStripMenuItem
            // 
            this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.credencialesToolStripMenuItem});
            this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
            this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.configuraciónToolStripMenuItem.Text = "Configuración";
            // 
            // credencialesToolStripMenuItem
            // 
            this.credencialesToolStripMenuItem.Name = "credencialesToolStripMenuItem";
            this.credencialesToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.credencialesToolStripMenuItem.Text = "Credenciales";
            this.credencialesToolStripMenuItem.Click += new System.EventHandler(this.credencialesToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreLaAplicaciónToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // sobreLaAplicaciónToolStripMenuItem
            // 
            this.sobreLaAplicaciónToolStripMenuItem.Name = "sobreLaAplicaciónToolStripMenuItem";
            this.sobreLaAplicaciónToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.sobreLaAplicaciónToolStripMenuItem.Text = "Sobre la aplicación";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_fees);
            this.Controls.Add(this.btn_stamps);
            this.Controls.Add(this.btn_commissions);
            this.Controls.Add(this.btn_daily_total);
            this.Controls.Add(this.lbl_select_message);
            this.Controls.Add(this.btn_void_payment);
            this.Controls.Add(this.btn_collect_taxes);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main";
            this.Text = "Cobrapp";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.main_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btn_fees;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem credencialesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreLaAplicaciónToolStripMenuItem;
    }
}

