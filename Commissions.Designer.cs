﻿namespace Cobrapp
{
    partial class Commissions
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
            this.dtgv_commissions = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dailyTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op_counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_from_date = new System.Windows.Forms.Label();
            this.lbl_to_date = new System.Windows.Forms.Label();
            this.lbl_commission = new System.Windows.Forms.Label();
            this.dtp_from_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_to_date = new System.Windows.Forms.DateTimePicker();
            this.btn_calculate = new System.Windows.Forms.Button();
            this.btn_print = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_total_collected = new System.Windows.Forms.Label();
            this.lbl_total_commission = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_commissions)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_commissions
            // 
            this.dtgv_commissions.AllowUserToAddRows = false;
            this.dtgv_commissions.AllowUserToDeleteRows = false;
            this.dtgv_commissions.AllowUserToResizeColumns = false;
            this.dtgv_commissions.AllowUserToResizeRows = false;
            this.dtgv_commissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_commissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.dailyTotal,
            this.commission,
            this.op_counter});
            this.dtgv_commissions.Location = new System.Drawing.Point(227, 52);
            this.dtgv_commissions.Name = "dtgv_commissions";
            this.dtgv_commissions.Size = new System.Drawing.Size(443, 323);
            this.dtgv_commissions.TabIndex = 0;
            // 
            // date
            // 
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // dailyTotal
            // 
            this.dailyTotal.HeaderText = "Total del día";
            this.dailyTotal.Name = "dailyTotal";
            this.dailyTotal.ReadOnly = true;
            // 
            // commission
            // 
            this.commission.HeaderText = "Comisión";
            this.commission.Name = "commission";
            this.commission.ReadOnly = true;
            // 
            // op_counter
            // 
            this.op_counter.HeaderText = "Operaciones";
            this.op_counter.Name = "op_counter";
            this.op_counter.ReadOnly = true;
            // 
            // lbl_from_date
            // 
            this.lbl_from_date.AutoSize = true;
            this.lbl_from_date.Location = new System.Drawing.Point(250, 29);
            this.lbl_from_date.Name = "lbl_from_date";
            this.lbl_from_date.Size = new System.Drawing.Size(38, 13);
            this.lbl_from_date.TabIndex = 3;
            this.lbl_from_date.Text = "Desde";
            // 
            // lbl_to_date
            // 
            this.lbl_to_date.AutoSize = true;
            this.lbl_to_date.Location = new System.Drawing.Point(397, 29);
            this.lbl_to_date.Name = "lbl_to_date";
            this.lbl_to_date.Size = new System.Drawing.Size(35, 13);
            this.lbl_to_date.TabIndex = 4;
            this.lbl_to_date.Text = "Hasta";
            // 
            // lbl_commission
            // 
            this.lbl_commission.AutoSize = true;
            this.lbl_commission.Location = new System.Drawing.Point(225, 421);
            this.lbl_commission.Name = "lbl_commission";
            this.lbl_commission.Size = new System.Drawing.Size(101, 13);
            this.lbl_commission.TabIndex = 6;
            this.lbl_commission.Text = "Total de comisiones";
            // 
            // dtp_from_date
            // 
            this.dtp_from_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_from_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_from_date.Location = new System.Drawing.Point(294, 26);
            this.dtp_from_date.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtp_from_date.Name = "dtp_from_date";
            this.dtp_from_date.Size = new System.Drawing.Size(100, 20);
            this.dtp_from_date.TabIndex = 7;
            this.dtp_from_date.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // dtp_to_date
            // 
            this.dtp_to_date.CustomFormat = "dd/MM/yyyy";
            this.dtp_to_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_to_date.Location = new System.Drawing.Point(438, 26);
            this.dtp_to_date.Name = "dtp_to_date";
            this.dtp_to_date.Size = new System.Drawing.Size(100, 20);
            this.dtp_to_date.TabIndex = 8;
            this.dtp_to_date.Value = new System.DateTime(2023, 9, 15, 0, 0, 0, 0);
            // 
            // btn_calculate
            // 
            this.btn_calculate.Location = new System.Drawing.Point(577, 26);
            this.btn_calculate.Name = "btn_calculate";
            this.btn_calculate.Size = new System.Drawing.Size(75, 23);
            this.btn_calculate.TabIndex = 9;
            this.btn_calculate.Text = "Calcular";
            this.btn_calculate.UseVisualStyleBackColor = true;
            this.btn_calculate.Click += new System.EventHandler(this.btn_calculate_Click);
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(595, 403);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 10;
            this.btn_print.Text = "Imprimir";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 393);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Total recaudado";
            // 
            // lbl_total_collected
            // 
            this.lbl_total_collected.AutoSize = true;
            this.lbl_total_collected.Location = new System.Drawing.Point(309, 393);
            this.lbl_total_collected.Name = "lbl_total_collected";
            this.lbl_total_collected.Size = new System.Drawing.Size(0, 13);
            this.lbl_total_collected.TabIndex = 12;
            // 
            // lbl_total_commission
            // 
            this.lbl_total_commission.AutoSize = true;
            this.lbl_total_commission.Location = new System.Drawing.Point(332, 421);
            this.lbl_total_commission.Name = "lbl_total_commission";
            this.lbl_total_commission.Size = new System.Drawing.Size(0, 13);
            this.lbl_total_commission.TabIndex = 13;
            // 
            // Commissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_total_commission);
            this.Controls.Add(this.lbl_total_collected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.dtp_to_date);
            this.Controls.Add(this.dtp_from_date);
            this.Controls.Add(this.lbl_commission);
            this.Controls.Add(this.lbl_to_date);
            this.Controls.Add(this.lbl_from_date);
            this.Controls.Add(this.dtgv_commissions);
            this.Name = "Commissions";
            this.Text = "Comisiones";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_commissions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_commissions;
        private System.Windows.Forms.Label lbl_from_date;
        private System.Windows.Forms.Label lbl_to_date;
        private System.Windows.Forms.Label lbl_commission;
        private System.Windows.Forms.DateTimePicker dtp_from_date;
        private System.Windows.Forms.DateTimePicker dtp_to_date;
        private System.Windows.Forms.Button btn_calculate;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dailyTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn commission;
        private System.Windows.Forms.DataGridViewTextBoxColumn op_counter;
        private System.Windows.Forms.Button btn_print;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_total_collected;
        private System.Windows.Forms.Label lbl_total_commission;
    }
}