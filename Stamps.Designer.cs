namespace Cobrapp
{
    partial class Stamps
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
            this.btn_print = new System.Windows.Forms.Button();
            this.nud_stamp_value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_stamp_value)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor del sellado $";
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(283, 146);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "Imprimir";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // nud_stamp_value
            // 
            this.nud_stamp_value.Location = new System.Drawing.Point(272, 97);
            this.nud_stamp_value.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.nud_stamp_value.Name = "nud_stamp_value";
            this.nud_stamp_value.Size = new System.Drawing.Size(120, 20);
            this.nud_stamp_value.TabIndex = 4;
            this.nud_stamp_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nud_stamp_value.ThousandsSeparator = true;
            // 
            // Stamps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 281);
            this.Controls.Add(this.nud_stamp_value);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label1);
            this.Name = "Stamps";
            this.Text = "Sellados";
            ((System.ComponentModel.ISupportInitialize)(this.nud_stamp_value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.NumericUpDown nud_stamp_value;
    }
}