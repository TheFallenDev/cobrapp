namespace Cobrapp
{
    partial class MainChild
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
            this.lbl_Muni = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Muni
            // 
            this.lbl_Muni.AutoSize = true;
            this.lbl_Muni.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Muni.Font = new System.Drawing.Font("Segoe UI Black", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Muni.Location = new System.Drawing.Point(236, 276);
            this.lbl_Muni.Name = "lbl_Muni";
            this.lbl_Muni.Size = new System.Drawing.Size(444, 37);
            this.lbl_Muni.TabIndex = 1;
            this.lbl_Muni.Text = "MUNICIPALIDAD DE DIAMANTE";
            // 
            // MainChild
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(916, 589);
            this.Controls.Add(this.lbl_Muni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainChild";
            this.Text = "MainChild";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Muni;
    }
}