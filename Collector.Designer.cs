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
            this.lbl_due_date = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_penalty = new System.Windows.Forms.Label();
            this.lbl_tax_total = new System.Windows.Forms.Label();
            this.btn_add_tax = new System.Windows.Forms.Button();
            this.btn_collect_taxes = new System.Windows.Forms.Button();
            this.dtgv_taxes_list = new System.Windows.Forms.DataGridView();
            this.receiptNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.due_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.penalty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extra_penalty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.partial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_remove_tax = new System.Windows.Forms.Button();
            this.lbl_show_tax = new System.Windows.Forms.Label();
            this.lbl_show_due_date = new System.Windows.Forms.Label();
            this.lbl_show_penalty = new System.Windows.Forms.Label();
            this.lbl_amount = new System.Windows.Forms.Label();
            this.txt_amount = new System.Windows.Forms.TextBox();
            this.txt_penalty = new System.Windows.Forms.TextBox();
            this.btn_cleaner = new System.Windows.Forms.Button();
            this.txt_tax_total = new System.Windows.Forms.TextBox();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.txt_extra_penalty = new System.Windows.Forms.TextBox();
            this.lbl_extra_penalty = new System.Windows.Forms.Label();
            this.txt_penalty_percentage = new System.Windows.Forms.TextBox();
            this.lbl_show_due_days = new System.Windows.Forms.Label();
            this.printTicket = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes_list)).BeginInit();
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
            this.txt_barcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_barcode.TextChanged += new System.EventHandler(this.txt_barcode_TextChanged);
            this.txt_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_barcode_KeyPress);
            // 
            // lbl_tax_name
            // 
            this.lbl_tax_name.AutoSize = true;
            this.lbl_tax_name.Location = new System.Drawing.Point(13, 93);
            this.lbl_tax_name.Name = "lbl_tax_name";
            this.lbl_tax_name.Size = new System.Drawing.Size(31, 13);
            this.lbl_tax_name.TabIndex = 2;
            this.lbl_tax_name.Text = "Tasa";
            // 
            // lbl_due_date
            // 
            this.lbl_due_date.AutoSize = true;
            this.lbl_due_date.Location = new System.Drawing.Point(140, 93);
            this.lbl_due_date.Name = "lbl_due_date";
            this.lbl_due_date.Size = new System.Drawing.Size(112, 13);
            this.lbl_due_date.TabIndex = 4;
            this.lbl_due_date.Text = "Fecha de vencimiento";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(850, 515);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(73, 13);
            this.lbl_total.TabIndex = 5;
            this.lbl_total.Text = "Total a cobrar";
            // 
            // lbl_penalty
            // 
            this.lbl_penalty.AutoSize = true;
            this.lbl_penalty.Location = new System.Drawing.Point(224, 123);
            this.lbl_penalty.Name = "lbl_penalty";
            this.lbl_penalty.Size = new System.Drawing.Size(48, 13);
            this.lbl_penalty.TabIndex = 6;
            this.lbl_penalty.Text = "Recargo";
            // 
            // lbl_tax_total
            // 
            this.lbl_tax_total.AutoSize = true;
            this.lbl_tax_total.Location = new System.Drawing.Point(73, 198);
            this.lbl_tax_total.Name = "lbl_tax_total";
            this.lbl_tax_total.Size = new System.Drawing.Size(63, 13);
            this.lbl_tax_total.TabIndex = 7;
            this.lbl_tax_total.Text = "Total boleta";
            // 
            // btn_add_tax
            // 
            this.btn_add_tax.Enabled = false;
            this.btn_add_tax.Location = new System.Drawing.Point(136, 277);
            this.btn_add_tax.Name = "btn_add_tax";
            this.btn_add_tax.Size = new System.Drawing.Size(75, 23);
            this.btn_add_tax.TabIndex = 9;
            this.btn_add_tax.Text = "Agregar (F9)";
            this.btn_add_tax.UseVisualStyleBackColor = true;
            this.btn_add_tax.Click += new System.EventHandler(this.btn_add_tax_Click);
            // 
            // btn_collect_taxes
            // 
            this.btn_collect_taxes.Enabled = false;
            this.btn_collect_taxes.Location = new System.Drawing.Point(963, 561);
            this.btn_collect_taxes.Name = "btn_collect_taxes";
            this.btn_collect_taxes.Size = new System.Drawing.Size(75, 23);
            this.btn_collect_taxes.TabIndex = 12;
            this.btn_collect_taxes.Text = "Cobrar (F12)";
            this.btn_collect_taxes.UseVisualStyleBackColor = true;
            this.btn_collect_taxes.Click += new System.EventHandler(this.btn_collect_taxes_Click);
            this.btn_collect_taxes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btn_collect_taxes_KeyPress);
            // 
            // dtgv_taxes_list
            // 
            this.dtgv_taxes_list.AllowUserToAddRows = false;
            this.dtgv_taxes_list.AllowUserToDeleteRows = false;
            this.dtgv_taxes_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_taxes_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receiptNum,
            this.tax,
            this.due_date,
            this.penalty,
            this.extra_penalty,
            this.partial,
            this.amount});
            this.dtgv_taxes_list.Location = new System.Drawing.Point(497, 24);
            this.dtgv_taxes_list.Name = "dtgv_taxes_list";
            this.dtgv_taxes_list.Size = new System.Drawing.Size(599, 474);
            this.dtgv_taxes_list.TabIndex = 14;
            this.dtgv_taxes_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgv_taxes_list_CellClick);
            // 
            // receiptNum
            // 
            this.receiptNum.HeaderText = "N° comprobante";
            this.receiptNum.Name = "receiptNum";
            this.receiptNum.ReadOnly = true;
            // 
            // tax
            // 
            this.tax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tax.HeaderText = "Tasa";
            this.tax.Name = "tax";
            this.tax.ReadOnly = true;
            this.tax.Width = 56;
            // 
            // due_date
            // 
            this.due_date.HeaderText = "Vencimiento";
            this.due_date.Name = "due_date";
            this.due_date.ReadOnly = true;
            // 
            // penalty
            // 
            this.penalty.HeaderText = "Recargo";
            this.penalty.Name = "penalty";
            this.penalty.ReadOnly = true;
            // 
            // extra_penalty
            // 
            this.extra_penalty.HeaderText = "Mora";
            this.extra_penalty.Name = "extra_penalty";
            this.extra_penalty.ReadOnly = true;
            // 
            // partial
            // 
            this.partial.HeaderText = "A pagar";
            this.partial.Name = "partial";
            this.partial.ReadOnly = true;
            // 
            // amount
            // 
            this.amount.HeaderText = "Monto";
            this.amount.Name = "amount";
            this.amount.Visible = false;
            // 
            // btn_remove_tax
            // 
            this.btn_remove_tax.Location = new System.Drawing.Point(261, 277);
            this.btn_remove_tax.Name = "btn_remove_tax";
            this.btn_remove_tax.Size = new System.Drawing.Size(75, 23);
            this.btn_remove_tax.TabIndex = 15;
            this.btn_remove_tax.Text = "Quitar";
            this.btn_remove_tax.UseVisualStyleBackColor = true;
            this.btn_remove_tax.Click += new System.EventHandler(this.btn_remove_tax_Click);
            // 
            // lbl_show_tax
            // 
            this.lbl_show_tax.AutoSize = true;
            this.lbl_show_tax.Location = new System.Drawing.Point(51, 93);
            this.lbl_show_tax.Name = "lbl_show_tax";
            this.lbl_show_tax.Size = new System.Drawing.Size(0, 13);
            this.lbl_show_tax.TabIndex = 16;
            // 
            // lbl_show_due_date
            // 
            this.lbl_show_due_date.AutoSize = true;
            this.lbl_show_due_date.Location = new System.Drawing.Point(259, 93);
            this.lbl_show_due_date.Name = "lbl_show_due_date";
            this.lbl_show_due_date.Size = new System.Drawing.Size(0, 13);
            this.lbl_show_due_date.TabIndex = 19;
            // 
            // lbl_show_penalty
            // 
            this.lbl_show_penalty.AutoSize = true;
            this.lbl_show_penalty.Location = new System.Drawing.Point(281, 123);
            this.lbl_show_penalty.Name = "lbl_show_penalty";
            this.lbl_show_penalty.Size = new System.Drawing.Size(0, 13);
            this.lbl_show_penalty.TabIndex = 20;
            // 
            // lbl_amount
            // 
            this.lbl_amount.AutoSize = true;
            this.lbl_amount.Location = new System.Drawing.Point(13, 123);
            this.lbl_amount.Name = "lbl_amount";
            this.lbl_amount.Size = new System.Drawing.Size(37, 13);
            this.lbl_amount.TabIndex = 22;
            this.lbl_amount.Text = "Monto";
            // 
            // txt_amount
            // 
            this.txt_amount.Enabled = false;
            this.txt_amount.Location = new System.Drawing.Point(56, 120);
            this.txt_amount.Name = "txt_amount";
            this.txt_amount.Size = new System.Drawing.Size(93, 20);
            this.txt_amount.TabIndex = 24;
            this.txt_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_penalty
            // 
            this.txt_penalty.Enabled = false;
            this.txt_penalty.Location = new System.Drawing.Point(361, 120);
            this.txt_penalty.Name = "txt_penalty";
            this.txt_penalty.Size = new System.Drawing.Size(68, 20);
            this.txt_penalty.TabIndex = 25;
            this.txt_penalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_cleaner
            // 
            this.btn_cleaner.Location = new System.Drawing.Point(402, 51);
            this.btn_cleaner.Name = "btn_cleaner";
            this.btn_cleaner.Size = new System.Drawing.Size(75, 23);
            this.btn_cleaner.TabIndex = 26;
            this.btn_cleaner.Text = "Limpiar";
            this.btn_cleaner.UseVisualStyleBackColor = true;
            this.btn_cleaner.Click += new System.EventHandler(this.btn_cleaner_Click);
            // 
            // txt_tax_total
            // 
            this.txt_tax_total.Enabled = false;
            this.txt_tax_total.Location = new System.Drawing.Point(143, 198);
            this.txt_tax_total.Name = "txt_tax_total";
            this.txt_tax_total.Size = new System.Drawing.Size(126, 20);
            this.txt_tax_total.TabIndex = 27;
            // 
            // txt_total
            // 
            this.txt_total.Enabled = false;
            this.txt_total.Location = new System.Drawing.Point(929, 512);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(167, 20);
            this.txt_total.TabIndex = 28;
            // 
            // txt_extra_penalty
            // 
            this.txt_extra_penalty.Enabled = false;
            this.txt_extra_penalty.Location = new System.Drawing.Point(361, 146);
            this.txt_extra_penalty.Name = "txt_extra_penalty";
            this.txt_extra_penalty.Size = new System.Drawing.Size(68, 20);
            this.txt_extra_penalty.TabIndex = 29;
            // 
            // lbl_extra_penalty
            // 
            this.lbl_extra_penalty.AutoSize = true;
            this.lbl_extra_penalty.Location = new System.Drawing.Point(224, 150);
            this.lbl_extra_penalty.Name = "lbl_extra_penalty";
            this.lbl_extra_penalty.Size = new System.Drawing.Size(60, 13);
            this.lbl_extra_penalty.TabIndex = 30;
            this.lbl_extra_penalty.Text = "Mora (10%)";
            // 
            // txt_penalty_percentage
            // 
            this.txt_penalty_percentage.Enabled = false;
            this.txt_penalty_percentage.Location = new System.Drawing.Point(287, 120);
            this.txt_penalty_percentage.Name = "txt_penalty_percentage";
            this.txt_penalty_percentage.Size = new System.Drawing.Size(68, 20);
            this.txt_penalty_percentage.TabIndex = 31;
            this.txt_penalty_percentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_show_due_days
            // 
            this.lbl_show_due_days.AutoSize = true;
            this.lbl_show_due_days.Location = new System.Drawing.Point(358, 93);
            this.lbl_show_due_days.Name = "lbl_show_due_days";
            this.lbl_show_due_days.Size = new System.Drawing.Size(0, 13);
            this.lbl_show_due_days.TabIndex = 32;
            // 
            // Collector
            // 
            this.AcceptButton = this.btn_add_tax;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 617);
            this.Controls.Add(this.lbl_show_due_days);
            this.Controls.Add(this.txt_penalty_percentage);
            this.Controls.Add(this.lbl_extra_penalty);
            this.Controls.Add(this.txt_extra_penalty);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.txt_tax_total);
            this.Controls.Add(this.btn_cleaner);
            this.Controls.Add(this.txt_penalty);
            this.Controls.Add(this.txt_amount);
            this.Controls.Add(this.lbl_amount);
            this.Controls.Add(this.lbl_show_penalty);
            this.Controls.Add(this.lbl_show_due_date);
            this.Controls.Add(this.lbl_show_tax);
            this.Controls.Add(this.btn_remove_tax);
            this.Controls.Add(this.dtgv_taxes_list);
            this.Controls.Add(this.btn_collect_taxes);
            this.Controls.Add(this.btn_add_tax);
            this.Controls.Add(this.lbl_tax_total);
            this.Controls.Add(this.lbl_penalty);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_due_date);
            this.Controls.Add(this.lbl_tax_name);
            this.Controls.Add(this.txt_barcode);
            this.Controls.Add(this.lbl_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Collector";
            this.Text = "Cobrapp";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Collector_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes_list)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_barcode;
        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.Label lbl_tax_name;
        private System.Windows.Forms.Label lbl_due_date;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lbl_penalty;
        private System.Windows.Forms.Label lbl_tax_total;
        private System.Windows.Forms.Button btn_add_tax;
        private System.Windows.Forms.Button btn_collect_taxes;
        private System.Windows.Forms.DataGridView dtgv_taxes_list;
        private System.Windows.Forms.Button btn_remove_tax;
        private System.Windows.Forms.Label lbl_show_tax;
        private System.Windows.Forms.Label lbl_show_due_date;
        private System.Windows.Forms.Label lbl_show_penalty;
        private System.Windows.Forms.Label lbl_amount;
        private System.Windows.Forms.TextBox txt_amount;
        private System.Windows.Forms.TextBox txt_penalty;
        private System.Windows.Forms.Button btn_cleaner;
        private System.Windows.Forms.TextBox txt_tax_total;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.TextBox txt_extra_penalty;
        private System.Windows.Forms.Label lbl_extra_penalty;
        private System.Windows.Forms.TextBox txt_penalty_percentage;
        private System.Windows.Forms.Label lbl_show_due_days;
        private System.Drawing.Printing.PrintDocument printTicket;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn due_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn penalty;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra_penalty;
        private System.Windows.Forms.DataGridViewTextBoxColumn partial;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
    }
}