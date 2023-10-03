﻿namespace Cobrapp
{
    partial class Configuration
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgv_taxes = new System.Windows.Forms.DataGridView();
            this.taxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.EmailPort = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EmailServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EmailPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.EmailUser = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BusinessOwner = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BusinessName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.btn_save = new System.Windows.Forms.Button();
            this.toEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgv_taxes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Constantes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dtgv_taxes
            // 
            this.dtgv_taxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_taxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taxName,
            this.taxCode});
            this.dtgv_taxes.Location = new System.Drawing.Point(522, 6);
            this.dtgv_taxes.Name = "dtgv_taxes";
            this.dtgv_taxes.Size = new System.Drawing.Size(240, 231);
            this.dtgv_taxes.TabIndex = 0;
            // 
            // taxName
            // 
            this.taxName.Frozen = true;
            this.taxName.HeaderText = "Tasa";
            this.taxName.Name = "taxName";
            // 
            // taxCode
            // 
            this.taxCode.Frozen = true;
            this.taxCode.HeaderText = "Código";
            this.taxCode.Name = "taxCode";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toEmail);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.EmailPort);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.EmailServer);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.EmailPassword);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.EmailUser);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.BusinessOwner);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.Phone);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.Address);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.BusinessName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lugar de cobro";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // EmailPort
            // 
            this.EmailPort.Location = new System.Drawing.Point(444, 282);
            this.EmailPort.Name = "EmailPort";
            this.EmailPort.Size = new System.Drawing.Size(219, 20);
            this.EmailPort.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(392, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Port";
            // 
            // EmailServer
            // 
            this.EmailServer.Location = new System.Drawing.Point(444, 256);
            this.EmailServer.Name = "EmailServer";
            this.EmailServer.Size = new System.Drawing.Size(219, 20);
            this.EmailServer.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Server";
            // 
            // EmailPassword
            // 
            this.EmailPassword.Location = new System.Drawing.Point(78, 282);
            this.EmailPassword.Name = "EmailPassword";
            this.EmailPassword.Size = new System.Drawing.Size(219, 20);
            this.EmailPassword.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Pass";
            // 
            // EmailUser
            // 
            this.EmailUser.Location = new System.Drawing.Point(78, 256);
            this.EmailUser.Name = "EmailUser";
            this.EmailUser.Size = new System.Drawing.Size(219, 20);
            this.EmailUser.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "User";
            // 
            // BusinessOwner
            // 
            this.BusinessOwner.Location = new System.Drawing.Point(236, 108);
            this.BusinessOwner.Name = "BusinessOwner";
            this.BusinessOwner.Size = new System.Drawing.Size(416, 20);
            this.BusinessOwner.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Responsable";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(236, 82);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(416, 20);
            this.Phone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Teléfono";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(236, 56);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(416, 20);
            this.Address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dirección";
            // 
            // BusinessName
            // 
            this.BusinessName.Location = new System.Drawing.Point(236, 30);
            this.BusinessName.Name = "BusinessName";
            this.BusinessName.Size = new System.Drawing.Size(416, 20);
            this.BusinessName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del lugar de cobro";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 382);
            this.tabControl.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(363, 415);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // toEmail
            // 
            this.toEmail.Location = new System.Drawing.Point(78, 308);
            this.toEmail.Name = "toEmail";
            this.toEmail.Size = new System.Drawing.Size(219, 20);
            this.toEmail.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 311);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Destinatario";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tabControl);
            this.Name = "Configuration";
            this.Text = "Configuración";
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BusinessName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgv_taxes;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn taxCode;
        private System.Windows.Forms.TextBox EmailPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EmailUser;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BusinessOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox EmailPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EmailServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox toEmail;
        private System.Windows.Forms.Label label9;
    }
}