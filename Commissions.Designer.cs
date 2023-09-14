namespace Cobrapp
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dailyTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_from_date = new System.Windows.Forms.Label();
            this.lbl_to_date = new System.Windows.Forms.Label();
            this.txt_total_commission = new System.Windows.Forms.TextBox();
            this.lbl_total_commission = new System.Windows.Forms.Label();
            this.dtp_from_date = new System.Windows.Forms.DateTimePicker();
            this.dtp_to_date = new System.Windows.Forms.DateTimePicker();
            this.btn_calculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.dailyTotal,
            this.commission});
            this.dataGridView1.Location = new System.Drawing.Point(227, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(344, 323);
            this.dataGridView1.TabIndex = 0;
            // 
            // date
            // 
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            // 
            // dailyTotal
            // 
            this.dailyTotal.HeaderText = "Total del día";
            this.dailyTotal.Name = "dailyTotal";
            // 
            // commission
            // 
            this.commission.HeaderText = "Comisión";
            this.commission.Name = "commission";
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
            // txt_total_commission
            // 
            this.txt_total_commission.Location = new System.Drawing.Point(471, 405);
            this.txt_total_commission.Name = "txt_total_commission";
            this.txt_total_commission.Size = new System.Drawing.Size(100, 20);
            this.txt_total_commission.TabIndex = 5;
            // 
            // lbl_total_commission
            // 
            this.lbl_total_commission.AutoSize = true;
            this.lbl_total_commission.Location = new System.Drawing.Point(364, 408);
            this.lbl_total_commission.Name = "lbl_total_commission";
            this.lbl_total_commission.Size = new System.Drawing.Size(101, 13);
            this.lbl_total_commission.TabIndex = 6;
            this.lbl_total_commission.Text = "Total de comisiones";
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
            this.dtp_to_date.Value = new System.DateTime(2023, 9, 13, 0, 0, 0, 0);
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
            // Commissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_calculate);
            this.Controls.Add(this.dtp_to_date);
            this.Controls.Add(this.dtp_from_date);
            this.Controls.Add(this.lbl_total_commission);
            this.Controls.Add(this.txt_total_commission);
            this.Controls.Add(this.lbl_to_date);
            this.Controls.Add(this.lbl_from_date);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Commissions";
            this.Text = "Comisiones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_from_date;
        private System.Windows.Forms.Label lbl_to_date;
        private System.Windows.Forms.TextBox txt_total_commission;
        private System.Windows.Forms.Label lbl_total_commission;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dailyTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn commission;
        private System.Windows.Forms.DateTimePicker dtp_from_date;
        private System.Windows.Forms.DateTimePicker dtp_to_date;
        private System.Windows.Forms.Button btn_calculate;
    }
}