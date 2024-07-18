namespace Cobrapp
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
            this.ConfigurationPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_fines = new System.Windows.Forms.Label();
            this.txt_delay = new System.Windows.Forms.Label();
            this.txt_addtional = new System.Windows.Forms.Label();
            this.txt_comission = new System.Windows.Forms.Label();
            this.dtgv_fines = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditionalPenalty = new System.Windows.Forms.TextBox();
            this.DelayPenalty = new System.Windows.Forms.TextBox();
            this.CorrespondingComission = new System.Windows.Forms.TextBox();
            this.dtgv_taxes = new System.Windows.Forms.DataGridView();
            this.taxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taxCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ShortName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BusinessCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.toEmail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_extensionDecree = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_extensionDelay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_extensionAdditional = new System.Windows.Forms.TextBox();
            this.txt_extensionLastDate = new System.Windows.Forms.TextBox();
            this.txt_extensionEndDate = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_ShowPrinterName = new System.Windows.Forms.TextBox();
            this.btn_PrinterSelection = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ConfigurationPassword);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.lbl_fines);
            this.tabPage2.Controls.Add(this.txt_delay);
            this.tabPage2.Controls.Add(this.txt_addtional);
            this.tabPage2.Controls.Add(this.txt_comission);
            this.tabPage2.Controls.Add(this.dtgv_fines);
            this.tabPage2.Controls.Add(this.AdditionalPenalty);
            this.tabPage2.Controls.Add(this.DelayPenalty);
            this.tabPage2.Controls.Add(this.CorrespondingComission);
            this.tabPage2.Controls.Add(this.dtgv_taxes);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 356);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Constantes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ConfigurationPassword
            // 
            this.ConfigurationPassword.Location = new System.Drawing.Point(543, 322);
            this.ConfigurationPassword.Name = "ConfigurationPassword";
            this.ConfigurationPassword.Size = new System.Drawing.Size(219, 20);
            this.ConfigurationPassword.TabIndex = 25;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(394, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Contraseña de configuracion";
            // 
            // lbl_fines
            // 
            this.lbl_fines.AutoSize = true;
            this.lbl_fines.Location = new System.Drawing.Point(634, 17);
            this.lbl_fines.Name = "lbl_fines";
            this.lbl_fines.Size = new System.Drawing.Size(38, 13);
            this.lbl_fines.TabIndex = 21;
            this.lbl_fines.Text = "Multas";
            // 
            // txt_delay
            // 
            this.txt_delay.AutoSize = true;
            this.txt_delay.Location = new System.Drawing.Point(6, 325);
            this.txt_delay.Name = "txt_delay";
            this.txt_delay.Size = new System.Drawing.Size(31, 13);
            this.txt_delay.TabIndex = 20;
            this.txt_delay.Text = "Mora";
            // 
            // txt_addtional
            // 
            this.txt_addtional.AutoSize = true;
            this.txt_addtional.Location = new System.Drawing.Point(6, 299);
            this.txt_addtional.Name = "txt_addtional";
            this.txt_addtional.Size = new System.Drawing.Size(48, 13);
            this.txt_addtional.TabIndex = 19;
            this.txt_addtional.Text = "Recargo";
            // 
            // txt_comission
            // 
            this.txt_comission.AutoSize = true;
            this.txt_comission.Location = new System.Drawing.Point(6, 273);
            this.txt_comission.Name = "txt_comission";
            this.txt_comission.Size = new System.Drawing.Size(75, 13);
            this.txt_comission.TabIndex = 18;
            this.txt_comission.Text = "Comisión en %";
            // 
            // dtgv_fines
            // 
            this.dtgv_fines.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.dtgv_fines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_fines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dtgv_fines.Location = new System.Drawing.Point(522, 33);
            this.dtgv_fines.Name = "dtgv_fines";
            this.dtgv_fines.Size = new System.Drawing.Size(240, 231);
            this.dtgv_fines.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // AdditionalPenalty
            // 
            this.AdditionalPenalty.Location = new System.Drawing.Point(126, 296);
            this.AdditionalPenalty.Name = "AdditionalPenalty";
            this.AdditionalPenalty.Size = new System.Drawing.Size(117, 20);
            this.AdditionalPenalty.TabIndex = 17;
            // 
            // DelayPenalty
            // 
            this.DelayPenalty.Location = new System.Drawing.Point(126, 322);
            this.DelayPenalty.Name = "DelayPenalty";
            this.DelayPenalty.Size = new System.Drawing.Size(117, 20);
            this.DelayPenalty.TabIndex = 13;
            // 
            // CorrespondingComission
            // 
            this.CorrespondingComission.Location = new System.Drawing.Point(126, 270);
            this.CorrespondingComission.Name = "CorrespondingComission";
            this.CorrespondingComission.Size = new System.Drawing.Size(117, 20);
            this.CorrespondingComission.TabIndex = 11;
            // 
            // dtgv_taxes
            // 
            this.dtgv_taxes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(49)))), ((int)(((byte)(50)))));
            this.dtgv_taxes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv_taxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.taxName,
            this.taxCode});
            this.dtgv_taxes.Location = new System.Drawing.Point(3, 33);
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
            this.tabPage1.Controls.Add(this.btn_PrinterSelection);
            this.tabPage1.Controls.Add(this.txt_ShowPrinterName);
            this.tabPage1.Controls.Add(this.label18);
            this.tabPage1.Controls.Add(this.ShortName);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.BusinessCode);
            this.tabPage1.Controls.Add(this.label10);
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
            // ShortName
            // 
            this.ShortName.Location = new System.Drawing.Point(236, 56);
            this.ShortName.Name = "ShortName";
            this.ShortName.Size = new System.Drawing.Size(416, 20);
            this.ShortName.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Abreviación";
            // 
            // BusinessCode
            // 
            this.BusinessCode.Location = new System.Drawing.Point(236, 160);
            this.BusinessCode.Name = "BusinessCode";
            this.BusinessCode.Size = new System.Drawing.Size(416, 20);
            this.BusinessCode.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Codigo de cobranza";
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
            this.BusinessOwner.Location = new System.Drawing.Point(236, 134);
            this.BusinessOwner.Name = "BusinessOwner";
            this.BusinessOwner.Size = new System.Drawing.Size(416, 20);
            this.BusinessOwner.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Responsable";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(236, 108);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(416, 20);
            this.Phone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Teléfono";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(236, 82);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(416, 20);
            this.Address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
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
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 382);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.txt_extensionDecree);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.txt_extensionDelay);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.txt_extensionAdditional);
            this.tabPage3.Controls.Add(this.txt_extensionLastDate);
            this.tabPage3.Controls.Add(this.txt_extensionEndDate);
            this.tabPage3.Controls.Add(this.checkBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 356);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Moratoria";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(252, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Decreto";
            // 
            // txt_extensionDecree
            // 
            this.txt_extensionDecree.Location = new System.Drawing.Point(252, 96);
            this.txt_extensionDecree.Name = "txt_extensionDecree";
            this.txt_extensionDecree.Size = new System.Drawing.Size(196, 20);
            this.txt_extensionDecree.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(30, 251);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Mora";
            // 
            // txt_extensionDelay
            // 
            this.txt_extensionDelay.Location = new System.Drawing.Point(30, 270);
            this.txt_extensionDelay.Name = "txt_extensionDelay";
            this.txt_extensionDelay.Size = new System.Drawing.Size(100, 20);
            this.txt_extensionDelay.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(30, 192);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Recargo";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Ultimo vencimiento";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 77);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Fecha de finalización";
            // 
            // txt_extensionAdditional
            // 
            this.txt_extensionAdditional.Location = new System.Drawing.Point(30, 211);
            this.txt_extensionAdditional.Name = "txt_extensionAdditional";
            this.txt_extensionAdditional.Size = new System.Drawing.Size(100, 20);
            this.txt_extensionAdditional.TabIndex = 3;
            // 
            // txt_extensionLastDate
            // 
            this.txt_extensionLastDate.Location = new System.Drawing.Point(30, 154);
            this.txt_extensionLastDate.Name = "txt_extensionLastDate";
            this.txt_extensionLastDate.Size = new System.Drawing.Size(100, 20);
            this.txt_extensionLastDate.TabIndex = 2;
            // 
            // txt_extensionEndDate
            // 
            this.txt_extensionEndDate.Location = new System.Drawing.Point(30, 96);
            this.txt_extensionEndDate.Name = "txt_extensionEndDate";
            this.txt_extensionEndDate.Size = new System.Drawing.Size(100, 20);
            this.txt_extensionEndDate.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 31);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(110, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Habilitar moratoria";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(703, 415);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Guardar";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(392, 311);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Impresora";
            // 
            // txt_ShowPrinterName
            // 
            this.txt_ShowPrinterName.Location = new System.Drawing.Point(444, 308);
            this.txt_ShowPrinterName.Name = "txt_ShowPrinterName";
            this.txt_ShowPrinterName.Size = new System.Drawing.Size(219, 20);
            this.txt_ShowPrinterName.TabIndex = 23;
            // 
            // btn_PrinterSelection
            // 
            this.btn_PrinterSelection.Location = new System.Drawing.Point(669, 306);
            this.btn_PrinterSelection.Name = "btn_PrinterSelection";
            this.btn_PrinterSelection.Size = new System.Drawing.Size(75, 23);
            this.btn_PrinterSelection.TabIndex = 24;
            this.btn_PrinterSelection.Text = "Seleccionar";
            this.btn_PrinterSelection.UseVisualStyleBackColor = true;
            this.btn_PrinterSelection.Click += new System.EventHandler(this.btn_PrinterSelection_Click);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Configuration";
            this.Text = "Configuración";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_fines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv_taxes)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox BusinessCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ShortName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dtgv_fines;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TextBox AdditionalPenalty;
        private System.Windows.Forms.TextBox DelayPenalty;
        private System.Windows.Forms.TextBox CorrespondingComission;
        private System.Windows.Forms.Label lbl_fines;
        private System.Windows.Forms.Label txt_delay;
        private System.Windows.Forms.Label txt_addtional;
        private System.Windows.Forms.Label txt_comission;
        private System.Windows.Forms.TextBox ConfigurationPassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox txt_extensionEndDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_extensionAdditional;
        private System.Windows.Forms.TextBox txt_extensionLastDate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_extensionDelay;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_extensionDecree;
        private System.Windows.Forms.Button btn_PrinterSelection;
        private System.Windows.Forms.TextBox txt_ShowPrinterName;
        private System.Windows.Forms.Label label18;
    }
}