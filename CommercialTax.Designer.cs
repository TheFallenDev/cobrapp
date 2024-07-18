namespace Cobrapp
{
    partial class CommercialTax
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
            this.txt_barcode = new System.Windows.Forms.TextBox();
            this.txt_period = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_calculated_tax = new System.Windows.Forms.TextBox();
            this.lbl_calculated_tax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_due_date = new System.Windows.Forms.Label();
            this.txt_due_date = new System.Windows.Forms.TextBox();
            this.lbl_retentions = new System.Windows.Forms.Label();
            this.txt_retentions = new System.Windows.Forms.TextBox();
            this.lbl_additional_label = new System.Windows.Forms.Label();
            this.lbl_delay_label = new System.Windows.Forms.Label();
            this.lbl_total_label = new System.Windows.Forms.Label();
            this.lbl_additional = new System.Windows.Forms.Label();
            this.lbl_delay = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_penalty_percentage = new System.Windows.Forms.Label();
            this.lbl_show_due_days = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_overdue_period = new System.Windows.Forms.Label();
            this.lbl_unknown_period = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_barcode
            // 
            this.txt_barcode.Location = new System.Drawing.Point(101, 97);
            this.txt_barcode.Name = "txt_barcode";
            this.txt_barcode.Size = new System.Drawing.Size(281, 20);
            this.txt_barcode.TabIndex = 0;
            this.txt_barcode.TextChanged += new System.EventHandler(this.txt_barcode_TextChanged);
            this.txt_barcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_barcode_KeyDown);
            this.txt_barcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_barcode_KeyPress);
            // 
            // txt_period
            // 
            this.txt_period.Location = new System.Drawing.Point(191, 25);
            this.txt_period.Name = "txt_period";
            this.txt_period.Size = new System.Drawing.Size(129, 20);
            this.txt_period.TabIndex = 2;
            this.txt_period.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_period_KeyDown);
            this.txt_period.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_period_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(98, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Período a cobrar";
            // 
            // txt_calculated_tax
            // 
            this.txt_calculated_tax.Location = new System.Drawing.Point(191, 195);
            this.txt_calculated_tax.Name = "txt_calculated_tax";
            this.txt_calculated_tax.Size = new System.Drawing.Size(129, 20);
            this.txt_calculated_tax.TabIndex = 4;
            this.txt_calculated_tax.Visible = false;
            this.txt_calculated_tax.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_calculated_tax_KeyDown);
            this.txt_calculated_tax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_calculated_tax_KeyPress);
            // 
            // lbl_calculated_tax
            // 
            this.lbl_calculated_tax.AutoSize = true;
            this.lbl_calculated_tax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_calculated_tax.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_calculated_tax.Location = new System.Drawing.Point(98, 198);
            this.lbl_calculated_tax.Name = "lbl_calculated_tax";
            this.lbl_calculated_tax.Size = new System.Drawing.Size(80, 13);
            this.lbl_calculated_tax.TabIndex = 5;
            this.lbl_calculated_tax.Text = "Tasa calculada";
            this.lbl_calculated_tax.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(19, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cod. de barras";
            // 
            // lbl_due_date
            // 
            this.lbl_due_date.AutoSize = true;
            this.lbl_due_date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_due_date.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_due_date.Location = new System.Drawing.Point(98, 54);
            this.lbl_due_date.Name = "lbl_due_date";
            this.lbl_due_date.Size = new System.Drawing.Size(65, 13);
            this.lbl_due_date.TabIndex = 8;
            this.lbl_due_date.Text = "Vencimiento";
            // 
            // txt_due_date
            // 
            this.txt_due_date.Location = new System.Drawing.Point(191, 51);
            this.txt_due_date.Name = "txt_due_date";
            this.txt_due_date.Size = new System.Drawing.Size(129, 20);
            this.txt_due_date.TabIndex = 7;
            this.txt_due_date.Visible = false;
            this.txt_due_date.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_due_date_KeyDown);
            this.txt_due_date.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_due_date_KeyPress);
            // 
            // lbl_retentions
            // 
            this.lbl_retentions.AutoSize = true;
            this.lbl_retentions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_retentions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_retentions.Location = new System.Drawing.Point(98, 224);
            this.lbl_retentions.Name = "lbl_retentions";
            this.lbl_retentions.Size = new System.Drawing.Size(67, 13);
            this.lbl_retentions.TabIndex = 10;
            this.lbl_retentions.Text = "Retenciones";
            this.lbl_retentions.Visible = false;
            // 
            // txt_retentions
            // 
            this.txt_retentions.Location = new System.Drawing.Point(191, 221);
            this.txt_retentions.Name = "txt_retentions";
            this.txt_retentions.Size = new System.Drawing.Size(129, 20);
            this.txt_retentions.TabIndex = 9;
            this.txt_retentions.Visible = false;
            this.txt_retentions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_retentions_KeyDown);
            this.txt_retentions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_retentions_KeyPress);
            // 
            // lbl_additional_label
            // 
            this.lbl_additional_label.AutoSize = true;
            this.lbl_additional_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_additional_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_additional_label.Location = new System.Drawing.Point(98, 250);
            this.lbl_additional_label.Name = "lbl_additional_label";
            this.lbl_additional_label.Size = new System.Drawing.Size(48, 13);
            this.lbl_additional_label.TabIndex = 14;
            this.lbl_additional_label.Text = "Recargo";
            this.lbl_additional_label.Visible = false;
            // 
            // lbl_delay_label
            // 
            this.lbl_delay_label.AutoSize = true;
            this.lbl_delay_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_delay_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_delay_label.Location = new System.Drawing.Point(98, 276);
            this.lbl_delay_label.Name = "lbl_delay_label";
            this.lbl_delay_label.Size = new System.Drawing.Size(31, 13);
            this.lbl_delay_label.TabIndex = 16;
            this.lbl_delay_label.Text = "Mora";
            this.lbl_delay_label.Visible = false;
            // 
            // lbl_total_label
            // 
            this.lbl_total_label.AutoSize = true;
            this.lbl_total_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_total_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_total_label.Location = new System.Drawing.Point(135, 326);
            this.lbl_total_label.Name = "lbl_total_label";
            this.lbl_total_label.Size = new System.Drawing.Size(42, 13);
            this.lbl_total_label.TabIndex = 18;
            this.lbl_total_label.Text = "TOTAL";
            // 
            // lbl_additional
            // 
            this.lbl_additional.AutoSize = true;
            this.lbl_additional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_additional.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_additional.Location = new System.Drawing.Point(188, 250);
            this.lbl_additional.Name = "lbl_additional";
            this.lbl_additional.Size = new System.Drawing.Size(43, 13);
            this.lbl_additional.TabIndex = 19;
            this.lbl_additional.Text = "recargo";
            this.lbl_additional.Visible = false;
            // 
            // lbl_delay
            // 
            this.lbl_delay.AutoSize = true;
            this.lbl_delay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_delay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_delay.Location = new System.Drawing.Point(191, 276);
            this.lbl_delay.Name = "lbl_delay";
            this.lbl_delay.Size = new System.Drawing.Size(30, 13);
            this.lbl_delay.TabIndex = 20;
            this.lbl_delay.Text = "mora";
            this.lbl_delay.Visible = false;
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.lbl_total.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_total.Location = new System.Drawing.Point(184, 325);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(19, 13);
            this.lbl_total.TabIndex = 21;
            this.lbl_total.Text = "tot";
            this.lbl_total.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(450, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(102, 26);
            this.label13.TabIndex = 23;
            this.label13.Text = "TISHPyS";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cobrar (F12)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.lbl_penalty_percentage);
            this.panel1.Controls.Add(this.lbl_show_due_days);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl_overdue_period);
            this.panel1.Controls.Add(this.lbl_unknown_period);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lbl_due_date);
            this.panel1.Controls.Add(this.lbl_total);
            this.panel1.Controls.Add(this.txt_due_date);
            this.panel1.Controls.Add(this.txt_calculated_tax);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_period);
            this.panel1.Controls.Add(this.lbl_delay);
            this.panel1.Controls.Add(this.lbl_calculated_tax);
            this.panel1.Controls.Add(this.lbl_additional);
            this.panel1.Controls.Add(this.txt_barcode);
            this.panel1.Controls.Add(this.txt_retentions);
            this.panel1.Controls.Add(this.lbl_total_label);
            this.panel1.Controls.Add(this.lbl_retentions);
            this.panel1.Controls.Add(this.lbl_delay_label);
            this.panel1.Controls.Add(this.lbl_additional_label);
            this.panel1.Location = new System.Drawing.Point(268, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 417);
            this.panel1.TabIndex = 24;
            // 
            // lbl_penalty_percentage
            // 
            this.lbl_penalty_percentage.AutoSize = true;
            this.lbl_penalty_percentage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_penalty_percentage.Location = new System.Drawing.Point(326, 250);
            this.lbl_penalty_percentage.Name = "lbl_penalty_percentage";
            this.lbl_penalty_percentage.Size = new System.Drawing.Size(35, 13);
            this.lbl_penalty_percentage.TabIndex = 27;
            this.lbl_penalty_percentage.Text = "label2";
            this.lbl_penalty_percentage.Visible = false;
            // 
            // lbl_show_due_days
            // 
            this.lbl_show_due_days.AutoSize = true;
            this.lbl_show_due_days.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_show_due_days.Location = new System.Drawing.Point(98, 299);
            this.lbl_show_due_days.Name = "lbl_show_due_days";
            this.lbl_show_due_days.Size = new System.Drawing.Size(35, 13);
            this.lbl_show_due_days.TabIndex = 26;
            this.lbl_show_due_days.Text = "label2";
            this.lbl_show_due_days.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(326, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Ej. 202301";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(326, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "dd/mm/aaaa";
            // 
            // lbl_overdue_period
            // 
            this.lbl_overdue_period.AutoSize = true;
            this.lbl_overdue_period.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_overdue_period.Location = new System.Drawing.Point(71, 170);
            this.lbl_overdue_period.Name = "lbl_overdue_period";
            this.lbl_overdue_period.Size = new System.Drawing.Size(318, 13);
            this.lbl_overdue_period.TabIndex = 23;
            this.lbl_overdue_period.Text = "Período vencido. Deberá ingresar Tasa Calculada y Retenciones.";
            this.lbl_overdue_period.UseWaitCursor = true;
            this.lbl_overdue_period.Visible = false;
            // 
            // lbl_unknown_period
            // 
            this.lbl_unknown_period.AutoSize = true;
            this.lbl_unknown_period.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_unknown_period.Location = new System.Drawing.Point(93, 78);
            this.lbl_unknown_period.Name = "lbl_unknown_period";
            this.lbl_unknown_period.Size = new System.Drawing.Size(296, 13);
            this.lbl_unknown_period.TabIndex = 22;
            this.lbl_unknown_period.Text = "Período no cargado. Por favor ingrese fecha de vencimiento.";
            this.lbl_unknown_period.Visible = false;
            // 
            // CommercialTax
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(932, 628);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CommercialTax";
            this.Text = "TISHPyS";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommercialTax_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_barcode;
        private System.Windows.Forms.TextBox txt_period;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_calculated_tax;
        private System.Windows.Forms.Label lbl_calculated_tax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_due_date;
        private System.Windows.Forms.TextBox txt_due_date;
        private System.Windows.Forms.Label lbl_retentions;
        private System.Windows.Forms.TextBox txt_retentions;
        private System.Windows.Forms.Label lbl_additional_label;
        private System.Windows.Forms.Label lbl_delay_label;
        private System.Windows.Forms.Label lbl_total_label;
        private System.Windows.Forms.Label lbl_additional;
        private System.Windows.Forms.Label lbl_delay;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_overdue_period;
        private System.Windows.Forms.Label lbl_unknown_period;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_show_due_days;
        private System.Windows.Forms.Label lbl_penalty_percentage;
    }
}