namespace BD_MAD_CEE.CLIENTE
{
    partial class C_CLIENTES
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mesCC = new System.Windows.Forms.DateTimePicker();
            this.anioCC = new System.Windows.Forms.DateTimePicker();
            this.BTNC_PDF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CMBC_SERVICIOS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.mesPR = new System.Windows.Forms.DateTimePicker();
            this.anioPR = new System.Windows.Forms.DateTimePicker();
            this.TEXTC_ESTATUS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TEXTC_CANTP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BTN_MASIVO = new System.Windows.Forms.Button();
            this.BTNC_PAGAR = new System.Windows.Forms.Button();
            this.TEXTC_TOTAL = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CMBC_FORMA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CMBC_PSERVICIOS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.anioCHH = new System.Windows.Forms.DateTimePicker();
            this.BTNC_CSV = new System.Windows.Forms.Button();
            this.BTNC_CHPDF = new System.Windows.Forms.Button();
            this.DTG_CONSUMOH = new System.Windows.Forms.DataGridView();
            this.CMBC_CHVISUAL = new System.Windows.Forms.Button();
            this.CMBC_CHSERVICIO = new System.Windows.Forms.TextBox();
            this.CMBC_CHMEDIDOR = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_CONSUMOH)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 341);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.mesCC);
            this.tabPage1.Controls.Add(this.anioCC);
            this.tabPage1.Controls.Add(this.BTNC_PDF);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CMBC_SERVICIOS);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(717, 315);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultar recibo";
            // 
            // mesCC
            // 
            this.mesCC.Location = new System.Drawing.Point(352, 30);
            this.mesCC.Name = "mesCC";
            this.mesCC.Size = new System.Drawing.Size(98, 20);
            this.mesCC.TabIndex = 11;
            // 
            // anioCC
            // 
            this.anioCC.Location = new System.Drawing.Point(199, 34);
            this.anioCC.Name = "anioCC";
            this.anioCC.Size = new System.Drawing.Size(101, 20);
            this.anioCC.TabIndex = 10;
            // 
            // BTNC_PDF
            // 
            this.BTNC_PDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNC_PDF.Location = new System.Drawing.Point(482, 160);
            this.BTNC_PDF.Name = "BTNC_PDF";
            this.BTNC_PDF.Size = new System.Drawing.Size(215, 131);
            this.BTNC_PDF.TabIndex = 9;
            this.BTNC_PDF.Text = "Generar recibo PDF";
            this.BTNC_PDF.UseVisualStyleBackColor = false;
            this.BTNC_PDF.Click += new System.EventHandler(this.BTNC_PDF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año";
            // 
            // CMBC_SERVICIOS
            // 
            this.CMBC_SERVICIOS.FormattingEnabled = true;
            this.CMBC_SERVICIOS.Location = new System.Drawing.Point(21, 33);
            this.CMBC_SERVICIOS.Name = "CMBC_SERVICIOS";
            this.CMBC_SERVICIOS.Size = new System.Drawing.Size(125, 21);
            this.CMBC_SERVICIOS.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicios contratados";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.mesPR);
            this.tabPage2.Controls.Add(this.anioPR);
            this.tabPage2.Controls.Add(this.TEXTC_ESTATUS);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.TEXTC_CANTP);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.BTN_MASIVO);
            this.tabPage2.Controls.Add(this.BTNC_PAGAR);
            this.tabPage2.Controls.Add(this.TEXTC_TOTAL);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.CMBC_FORMA);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.CMBC_PSERVICIOS);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(717, 315);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pagar recibo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(525, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 47);
            this.button1.TabIndex = 26;
            this.button1.Text = "Checar recibo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // mesPR
            // 
            this.mesPR.Location = new System.Drawing.Point(326, 35);
            this.mesPR.Name = "mesPR";
            this.mesPR.Size = new System.Drawing.Size(100, 20);
            this.mesPR.TabIndex = 25;
            // 
            // anioPR
            // 
            this.anioPR.Location = new System.Drawing.Point(173, 35);
            this.anioPR.Name = "anioPR";
            this.anioPR.Size = new System.Drawing.Size(111, 20);
            this.anioPR.TabIndex = 24;
            // 
            // TEXTC_ESTATUS
            // 
            this.TEXTC_ESTATUS.Enabled = false;
            this.TEXTC_ESTATUS.Location = new System.Drawing.Point(177, 241);
            this.TEXTC_ESTATUS.Name = "TEXTC_ESTATUS";
            this.TEXTC_ESTATUS.Size = new System.Drawing.Size(107, 20);
            this.TEXTC_ESTATUS.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(181, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Estatus del pago";
            // 
            // TEXTC_CANTP
            // 
            this.TEXTC_CANTP.Location = new System.Drawing.Point(326, 130);
            this.TEXTC_CANTP.Name = "TEXTC_CANTP";
            this.TEXTC_CANTP.Size = new System.Drawing.Size(100, 20);
            this.TEXTC_CANTP.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Total a pagar";
            // 
            // BTN_MASIVO
            // 
            this.BTN_MASIVO.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTN_MASIVO.Location = new System.Drawing.Point(525, 212);
            this.BTN_MASIVO.Name = "BTN_MASIVO";
            this.BTN_MASIVO.Size = new System.Drawing.Size(128, 76);
            this.BTN_MASIVO.TabIndex = 19;
            this.BTN_MASIVO.Text = "Pago masivo de los servicios";
            this.BTN_MASIVO.UseVisualStyleBackColor = false;
            this.BTN_MASIVO.Click += new System.EventHandler(this.BTN_MASIVO_Click);
            // 
            // BTNC_PAGAR
            // 
            this.BTNC_PAGAR.Enabled = false;
            this.BTNC_PAGAR.Location = new System.Drawing.Point(525, 101);
            this.BTNC_PAGAR.Name = "BTNC_PAGAR";
            this.BTNC_PAGAR.Size = new System.Drawing.Size(128, 76);
            this.BTNC_PAGAR.TabIndex = 18;
            this.BTNC_PAGAR.Text = "Pagar";
            this.BTNC_PAGAR.UseVisualStyleBackColor = true;
            this.BTNC_PAGAR.Click += new System.EventHandler(this.BTNC_PAGAR_Click);
            // 
            // TEXTC_TOTAL
            // 
            this.TEXTC_TOTAL.Enabled = false;
            this.TEXTC_TOTAL.Location = new System.Drawing.Point(184, 130);
            this.TEXTC_TOTAL.Name = "TEXTC_TOTAL";
            this.TEXTC_TOTAL.Size = new System.Drawing.Size(100, 20);
            this.TEXTC_TOTAL.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(323, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cantidad pagada";
            // 
            // CMBC_FORMA
            // 
            this.CMBC_FORMA.FormattingEnabled = true;
            this.CMBC_FORMA.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta debito",
            "Tarjeta credito",
            "Transferencia bancaria"});
            this.CMBC_FORMA.Location = new System.Drawing.Point(19, 129);
            this.CMBC_FORMA.Name = "CMBC_FORMA";
            this.CMBC_FORMA.Size = new System.Drawing.Size(125, 21);
            this.CMBC_FORMA.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Forma de pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(323, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Año";
            // 
            // CMBC_PSERVICIOS
            // 
            this.CMBC_PSERVICIOS.FormattingEnabled = true;
            this.CMBC_PSERVICIOS.Location = new System.Drawing.Point(19, 34);
            this.CMBC_PSERVICIOS.Name = "CMBC_PSERVICIOS";
            this.CMBC_PSERVICIOS.Size = new System.Drawing.Size(125, 21);
            this.CMBC_PSERVICIOS.TabIndex = 3;
            this.CMBC_PSERVICIOS.SelectedIndexChanged += new System.EventHandler(this.CMBC_PSERVICIOS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Servicios contratados";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.anioCHH);
            this.tabPage3.Controls.Add(this.BTNC_CSV);
            this.tabPage3.Controls.Add(this.BTNC_CHPDF);
            this.tabPage3.Controls.Add(this.DTG_CONSUMOH);
            this.tabPage3.Controls.Add(this.CMBC_CHVISUAL);
            this.tabPage3.Controls.Add(this.CMBC_CHSERVICIO);
            this.tabPage3.Controls.Add(this.CMBC_CHMEDIDOR);
            this.tabPage3.Controls.Add(this.label37);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(717, 315);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Consumo historico";
            // 
            // anioCHH
            // 
            this.anioCHH.Location = new System.Drawing.Point(18, 32);
            this.anioCHH.Name = "anioCHH";
            this.anioCHH.Size = new System.Drawing.Size(115, 20);
            this.anioCHH.TabIndex = 18;
            // 
            // BTNC_CSV
            // 
            this.BTNC_CSV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNC_CSV.Location = new System.Drawing.Point(567, 196);
            this.BTNC_CSV.Name = "BTNC_CSV";
            this.BTNC_CSV.Size = new System.Drawing.Size(142, 67);
            this.BTNC_CSV.TabIndex = 17;
            this.BTNC_CSV.Text = "Generar CSV";
            this.BTNC_CSV.UseVisualStyleBackColor = false;
            // 
            // BTNC_CHPDF
            // 
            this.BTNC_CHPDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNC_CHPDF.Location = new System.Drawing.Point(567, 95);
            this.BTNC_CHPDF.Name = "BTNC_CHPDF";
            this.BTNC_CHPDF.Size = new System.Drawing.Size(142, 67);
            this.BTNC_CHPDF.TabIndex = 16;
            this.BTNC_CHPDF.Text = "Generar PDF";
            this.BTNC_CHPDF.UseVisualStyleBackColor = false;
            // 
            // DTG_CONSUMOH
            // 
            this.DTG_CONSUMOH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG_CONSUMOH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.DTG_CONSUMOH.Location = new System.Drawing.Point(18, 80);
            this.DTG_CONSUMOH.Name = "DTG_CONSUMOH";
            this.DTG_CONSUMOH.Size = new System.Drawing.Size(541, 206);
            this.DTG_CONSUMOH.TabIndex = 15;
            // 
            // CMBC_CHVISUAL
            // 
            this.CMBC_CHVISUAL.Location = new System.Drawing.Point(445, 15);
            this.CMBC_CHVISUAL.Name = "CMBC_CHVISUAL";
            this.CMBC_CHVISUAL.Size = new System.Drawing.Size(114, 44);
            this.CMBC_CHVISUAL.TabIndex = 14;
            this.CMBC_CHVISUAL.Text = "Visualizar";
            this.CMBC_CHVISUAL.UseVisualStyleBackColor = true;
            this.CMBC_CHVISUAL.Click += new System.EventHandler(this.CMBC_CHVISUAL_Click);
            // 
            // CMBC_CHSERVICIO
            // 
            this.CMBC_CHSERVICIO.Location = new System.Drawing.Point(304, 32);
            this.CMBC_CHSERVICIO.Name = "CMBC_CHSERVICIO";
            this.CMBC_CHSERVICIO.Size = new System.Drawing.Size(126, 20);
            this.CMBC_CHSERVICIO.TabIndex = 13;
            // 
            // CMBC_CHMEDIDOR
            // 
            this.CMBC_CHMEDIDOR.Location = new System.Drawing.Point(160, 31);
            this.CMBC_CHMEDIDOR.Name = "CMBC_CHMEDIDOR";
            this.CMBC_CHMEDIDOR.Size = new System.Drawing.Size(126, 20);
            this.CMBC_CHMEDIDOR.TabIndex = 12;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(301, 15);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(66, 13);
            this.label37.TabIndex = 10;
            this.label37.Text = "Nro. servicio";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(157, 15);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 13);
            this.label36.TabIndex = 9;
            this.label36.Text = "Nro. medidor";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(15, 15);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(26, 13);
            this.label35.TabIndex = 8;
            this.label35.Text = "Año";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FechaF";
            this.Column2.HeaderText = "Periodo de facturacion";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Consumo";
            this.Column3.HeaderText = "Consumo kWh";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Importe_IVA";
            this.Column4.HeaderText = "Importe";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Cantidad_Pagada";
            this.Column5.HeaderText = "Pago";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Cantidad_Pendiente";
            this.Column6.HeaderText = "Pendiente de pago";
            this.Column6.Name = "Column6";
            // 
            // C_CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 341);
            this.Controls.Add(this.tabControl1);
            this.Name = "C_CLIENTES";
            this.Text = "CLIENTE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.C_CLIENTES_FormClosed);
            this.Load += new System.EventHandler(this.C_CLIENTES_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_CONSUMOH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMBC_SERVICIOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNC_PDF;
        private System.Windows.Forms.Button BTNC_PAGAR;
        private System.Windows.Forms.TextBox TEXTC_TOTAL;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CMBC_FORMA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CMBC_PSERVICIOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BTN_MASIVO;
        private System.Windows.Forms.TextBox TEXTC_CANTP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TEXTC_ESTATUS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button CMBC_CHVISUAL;
        private System.Windows.Forms.TextBox CMBC_CHSERVICIO;
        private System.Windows.Forms.TextBox CMBC_CHMEDIDOR;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DataGridView DTG_CONSUMOH;
        private System.Windows.Forms.Button BTNC_CSV;
        private System.Windows.Forms.Button BTNC_CHPDF;
        private System.Windows.Forms.DateTimePicker mesCC;
        private System.Windows.Forms.DateTimePicker anioCC;
        private System.Windows.Forms.DateTimePicker anioCHH;
        private System.Windows.Forms.DateTimePicker mesPR;
        private System.Windows.Forms.DateTimePicker anioPR;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}