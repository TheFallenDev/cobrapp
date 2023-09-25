namespace Cobrapp
{
    partial class Total
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_taxes = new System.Windows.Forms.DataGridView();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.voided = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_print = new System.Windows.Forms.Button();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.lbl_total = new System.Windows.Forms.Label();
            this.btn_generate_file = new System.Windows.Forms.Button();
            this.chkShowVoid = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Día";
            // 
            // dtgv_taxes
            // 
            this.dtgv_taxes.AllowUserToAddRows = false;
            this.dtgv_taxes.AllowUserToDeleteRows = false;
            this.dtgv_taxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_taxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.time,
            this.Receipt,
            this.Payment,
            this.DueDate,
            this.TaxName,
            this.voided});
            this.dtgv_taxes.Location = new System.Drawing.Point(12, 38);
            this.dtgv_taxes.Name = "dtgv_taxes";
            this.dtgv_taxes.Size = new System.Drawing.Size(776, 329);
            this.dtgv_taxes.TabIndex = 2;
            // 
            // time
            // 
            this.time.HeaderText = "Hora";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // Receipt
            // 
            this.Receipt.HeaderText = "Comprobante";
            this.Receipt.Name = "Receipt";
            this.Receipt.ReadOnly = true;
            // 
            // Payment
            // 
            this.Payment.HeaderText = "Pago";
            this.Payment.Name = "Payment";
            this.Payment.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Vencimiento";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            // 
            // TaxName
            // 
            this.TaxName.HeaderText = "Tasa";
            this.TaxName.Name = "TaxName";
            this.TaxName.ReadOnly = true;
            // 
            // voided
            // 
            this.voided.HeaderText = "Anulado";
            this.voided.Name = "voided";
            this.voided.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total del día";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(374, 392);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 5;
            this.btn_print.Text = "Imprimir";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // dtp_date
            // 
            this.dtp_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(297, 12);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(100, 20);
            this.dtp_date.TabIndex = 9;
            this.dtp_date.Value = new System.DateTime(2023, 9, 15, 0, 0, 0, 0);
            this.dtp_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp_date_KeyDown);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(150, 397);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(0, 13);
            this.lbl_total.TabIndex = 10;
            // 
            // btn_generate_file
            // 
            this.btn_generate_file.Location = new System.Drawing.Point(608, 392);
            this.btn_generate_file.Name = "btn_generate_file";
            this.btn_generate_file.Size = new System.Drawing.Size(180, 23);
            this.btn_generate_file.TabIndex = 11;
            this.btn_generate_file.Text = "Generar archivo de recaudación";
            this.btn_generate_file.UseVisualStyleBackColor = true;
            this.btn_generate_file.Click += new System.EventHandler(this.btn_generate_file_Click);
            // 
            // chkShowVoid
            // 
            this.chkShowVoid.AutoSize = true;
            this.chkShowVoid.Checked = true;
            this.chkShowVoid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowVoid.Location = new System.Drawing.Point(462, 12);
            this.chkShowVoid.Name = "chkShowVoid";
            this.chkShowVoid.Size = new System.Drawing.Size(102, 17);
            this.chkShowVoid.TabIndex = 12;
            this.chkShowVoid.Text = "Incluír anulados";
            this.chkShowVoid.UseVisualStyleBackColor = true;
            this.chkShowVoid.CheckedChanged += new System.EventHandler(this.chkShowVoid_CheckedChanged);
            // 
            // Total
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkShowVoid);
            this.Controls.Add(this.btn_generate_file);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgv_taxes);
            this.Controls.Add(this.label1);
            this.Name = "Total";
            this.Text = "Total del día";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_taxes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn voided;
        private System.Windows.Forms.Button btn_generate_file;
        private System.Windows.Forms.CheckBox chkShowVoid;
    }
}