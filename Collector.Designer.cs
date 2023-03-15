namespace Cobrapp
{
    partial class Collector
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
            this.lbl_barcode = new System.Windows.Forms.Label();
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.lbl_tax_name = new System.Windows.Forms.Label();
            this.lbl_account_number = new System.Windows.Forms.Label();
            this.lbl_due_date = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_interest = new System.Windows.Forms.Label();
            this.lbl_tax_total = new System.Windows.Forms.Label();
            this.btn_add_tax = new System.Windows.Forms.Button();
            this.lbl_period = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_collect_taxes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_barcode
            // 
            this.lbl_barcode.AutoSize = true;
            this.lbl_barcode.Location = new System.Drawing.Point(12, 27);
            this.lbl_barcode.Name = "lbl_barcode";
            this.lbl_barcode.Size = new System.Drawing.Size(76, 13);
            this.lbl_barcode.TabIndex = 0;
            this.lbl_barcode.Text = "Cod. de barras";
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(112, 24);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(366, 20);
            this.txt_barcode.TabIndex = 1;
            // 
            // lbl_tax_name
            // 
            this.lbl_tax_name.AutoSize = true;
            this.lbl_tax_name.Location = new System.Drawing.Point(15, 93);
            this.lbl_tax_name.Name = "lbl_tax_name";
            this.lbl_tax_name.Size = new System.Drawing.Size(31, 13);
            this.lbl_tax_name.TabIndex = 2;
            this.lbl_tax_name.Text = "Tasa";
            // 
            // lbl_account_number
            // 
            this.lbl_account_number.AutoSize = true;
            this.lbl_account_number.Location = new System.Drawing.Point(15, 128);
            this.lbl_account_number.Name = "lbl_account_number";
            this.lbl_account_number.Size = new System.Drawing.Size(71, 13);
            this.lbl_account_number.TabIndex = 3;
            this.lbl_account_number.Text = "Cta. Corriente";
            // 
            // lbl_due_date
            // 
            this.lbl_due_date.AutoSize = true;
            this.lbl_due_date.Location = new System.Drawing.Point(226, 128);
            this.lbl_due_date.Name = "lbl_due_date";
            this.lbl_due_date.Size = new System.Drawing.Size(112, 13);
            this.lbl_due_date.TabIndex = 4;
            this.lbl_due_date.Text = "Fecha de vencimiento";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(801, 523);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(73, 13);
            this.lbl_total.TabIndex = 5;
            this.lbl_total.Text = "Total a cobrar";
            // 
            // lbl_interest
            // 
            this.lbl_interest.AutoSize = true;
            this.lbl_interest.Location = new System.Drawing.Point(226, 165);
            this.lbl_interest.Name = "lbl_interest";
            this.lbl_interest.Size = new System.Drawing.Size(50, 13);
            this.lbl_interest.TabIndex = 6;
            this.lbl_interest.Text = "Intereses";
            // 
            // lbl_tax_total
            // 
            this.lbl_tax_total.AutoSize = true;
            this.lbl_tax_total.Location = new System.Drawing.Point(75, 240);
            this.lbl_tax_total.Name = "lbl_tax_total";
            this.lbl_tax_total.Size = new System.Drawing.Size(63, 13);
            this.lbl_tax_total.TabIndex = 7;
            this.lbl_tax_total.Text = "Total boleta";
            // 
            // btn_add_tax
            // 
            this.btn_add_tax.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_add_tax.Location = new System.Drawing.Point(138, 319);
            this.btn_add_tax.Name = "btn_add_tax";
            this.btn_add_tax.Size = new System.Drawing.Size(75, 23);
            this.btn_add_tax.TabIndex = 9;
            this.btn_add_tax.Text = "Agregar tasa";
            this.btn_add_tax.UseVisualStyleBackColor = true;
            // 
            // lbl_period
            // 
            this.lbl_period.AutoSize = true;
            this.lbl_period.Location = new System.Drawing.Point(226, 93);
            this.lbl_period.Name = "lbl_period";
            this.lbl_period.Size = new System.Drawing.Size(45, 13);
            this.lbl_period.TabIndex = 10;
            this.lbl_period.Text = "Período";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.57471F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.42529F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 161F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(505, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.929515F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.07049F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(575, 473);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_collect_taxes.Location = new System.Drawing.Point(804, 557);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(75, 23);
            this.btn_collect_taxes.TabIndex = 12;
            this.btn_collect_taxes.Text = "Cobrar";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            // 
            // Collector
            // 
            this.AcceptButton = this.btn_add_tax;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 617);
            this.Controls.Add(this.btn_collect_taxes);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lbl_period);
            this.Controls.Add(this.btn_add_tax);
            this.Controls.Add(this.lbl_tax_total);
            this.Controls.Add(this.lbl_interest);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_due_date);
            this.Controls.Add(this.lbl_account_number);
            this.Controls.Add(this.lbl_tax_name);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.lbl_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Collector";
            this.Text = "Cobrapp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_barcode;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label lbl_tax_name;
        private System.Windows.Forms.Label lbl_account_number;
        private System.Windows.Forms.Label lbl_due_date;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_interest;
        private System.Windows.Forms.Label lbl_tax_total;
        private System.Windows.Forms.Button btn_add_tax;
        private System.Windows.Forms.Label lbl_period;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_collect_taxes;
    }
}