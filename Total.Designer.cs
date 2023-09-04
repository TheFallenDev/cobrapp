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
            this.txt_date = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgv_taxes = new System.Windows.Forms.DataGridView();
            this.Receipt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_date
            // 
            this.txt_date.Location = new System.Drawing.Point(355, 12);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(93, 20);
            this.txt_date.TabIndex = 0;
            this.txt_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_date_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(266, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese la fecha";
            // 
            // dtgv_taxes
            // 
            this.dtgv_taxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_taxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Receipt,
            this.Payment,
            this.DueDate,
            this.TaxName});
            this.dtgv_taxes.Location = new System.Drawing.Point(12, 38);
            this.dtgv_taxes.Name = "dtgv_taxes";
            this.dtgv_taxes.Size = new System.Drawing.Size(776, 329);
            this.dtgv_taxes.TabIndex = 2;
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
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_total.Location = new System.Drawing.Point(355, 394);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(187, 20);
            this.txt_total.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Total del día";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(645, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Total
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.dtgv_taxes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_date);
            this.Name = "Total";
            this.Text = "Total del día";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_taxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Receipt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxName;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}