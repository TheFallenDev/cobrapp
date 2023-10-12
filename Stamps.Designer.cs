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
            this.txt_stamp_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Valor del sellado $";
            // 
            // btn_print
            // 
            this.btn_print.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_print.FlatAppearance.BorderSize = 0;
            this.btn_print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_print.ForeColor = System.Drawing.Color.White;
            this.btn_print.Location = new System.Drawing.Point(382, 237);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(159, 32);
            this.btn_print.TabIndex = 3;
            this.btn_print.Text = "Cobrar (F12)";
            this.btn_print.UseVisualStyleBackColor = false;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // txt_stamp_value
            // 
            this.txt_stamp_value.Location = new System.Drawing.Point(448, 135);
            this.txt_stamp_value.Name = "txt_stamp_value";
            this.txt_stamp_value.Size = new System.Drawing.Size(109, 20);
            this.txt_stamp_value.TabIndex = 4;
            this.txt_stamp_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(393, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "SELLADOS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(0, 615);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(770, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "El cobro de un sellado no puede ser anulado. Antes de presionar el boton de COBRA" +
    "R asegurese de haber recibido el total del dinero.";
            // 
            // Stamps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(932, 628);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_stamp_value);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stamps";
            this.Text = "Sellados";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stamps_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.TextBox txt_stamp_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}