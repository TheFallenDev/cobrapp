namespace Cobrapp
{
    partial class VoidPayment
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
            this.txt_receipt_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_void = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(356, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ANULAR PAGOS";
            // 
            // txt_receipt_number
            // 
            this.txt_receipt_number.Location = new System.Drawing.Point(420, 166);
            this.txt_receipt_number.Name = "txt_receipt_number";
            this.txt_receipt_number.Size = new System.Drawing.Size(100, 20);
            this.txt_receipt_number.TabIndex = 1;
            this.txt_receipt_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_receipt_number_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese el N° de comprobante";
            // 
            // btn_void
            // 
            this.btn_void.Location = new System.Drawing.Point(359, 246);
            this.btn_void.Name = "btn_void";
            this.btn_void.Size = new System.Drawing.Size(75, 23);
            this.btn_void.TabIndex = 3;
            this.btn_void.Text = "Anular";
            this.btn_void.UseVisualStyleBackColor = true;
            this.btn_void.Click += new System.EventHandler(this.btn_void_Click);
            // 
            // VoidPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_void);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_receipt_number);
            this.Controls.Add(this.label1);
            this.Name = "VoidPayment";
            this.Text = "VoidPayment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_receipt_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_void;
    }
}