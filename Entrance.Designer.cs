namespace Cobrapp
{
    partial class Entrance
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
            this.dtgv_entrances = new System.Windows.Forms.DataGridView();
            this.concept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_cash = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.btn_posnet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_entrances)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgv_entrances
            // 
            this.dtgv_entrances.AllowUserToAddRows = false;
            this.dtgv_entrances.AllowUserToDeleteRows = false;
            this.dtgv_entrances.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.dtgv_entrances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_entrances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.concept,
            this.value,
            this.cuantity,
            this.subtotal});
            this.dtgv_entrances.Location = new System.Drawing.Point(287, 53);
            this.dtgv_entrances.Name = "dtgv_entrances";
            this.dtgv_entrances.Size = new System.Drawing.Size(442, 255);
            this.dtgv_entrances.TabIndex = 0;
            this.dtgv_entrances.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgv_entrances_CellValidating);
            this.dtgv_entrances.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // concept
            // 
            this.concept.Frozen = true;
            this.concept.HeaderText = "Concepto";
            this.concept.Name = "concept";
            this.concept.ReadOnly = true;
            // 
            // value
            // 
            this.value.Frozen = true;
            this.value.HeaderText = "Valor";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            // 
            // cuantity
            // 
            this.cuantity.Frozen = true;
            this.cuantity.HeaderText = "Cantidad";
            this.cuantity.Name = "cuantity";
            // 
            // subtotal
            // 
            this.subtotal.Frozen = true;
            this.subtotal.HeaderText = "Subtotal";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // btn_cash
            // 
            this.btn_cash.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_cash.FlatAppearance.BorderSize = 0;
            this.btn_cash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cash.ForeColor = System.Drawing.Color.White;
            this.btn_cash.Location = new System.Drawing.Point(608, 475);
            this.btn_cash.Name = "btn_cash";
            this.btn_cash.Size = new System.Drawing.Size(159, 32);
            this.btn_cash.TabIndex = 34;
            this.btn_cash.Text = "Efectivo (F12)";
            this.btn_cash.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(147, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 26);
            this.label2.TabIndex = 35;
            this.label2.Text = "TOTAL A COBRAR";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_total.Location = new System.Drawing.Point(657, 379);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(72, 26);
            this.lbl_total.TabIndex = 36;
            this.lbl_total.Text = "$ 0.00";
            this.lbl_total.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btn_posnet
            // 
            this.btn_posnet.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_posnet.FlatAppearance.BorderSize = 0;
            this.btn_posnet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_posnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_posnet.ForeColor = System.Drawing.Color.White;
            this.btn_posnet.Location = new System.Drawing.Point(235, 475);
            this.btn_posnet.Name = "btn_posnet";
            this.btn_posnet.Size = new System.Drawing.Size(159, 32);
            this.btn_posnet.TabIndex = 37;
            this.btn_posnet.Text = "Posnet (F9)";
            this.btn_posnet.UseVisualStyleBackColor = false;
            // 
            // Entrance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(175)))), ((int)(((byte)(197)))));
            this.ClientSize = new System.Drawing.Size(916, 589);
            this.Controls.Add(this.btn_posnet);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cash);
            this.Controls.Add(this.dtgv_entrances);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Entrance";
            this.Text = "EntranceForm";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_entrances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgv_entrances;
        private System.Windows.Forms.DataGridViewTextBoxColumn concept;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Button btn_cash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Button btn_posnet;
    }
}