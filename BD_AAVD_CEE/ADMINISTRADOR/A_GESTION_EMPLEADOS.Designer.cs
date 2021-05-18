namespace BD_MAD_CEE.ADMINISTRADOR
{
    partial class A_GESTION_EMPLEADOS
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
            this.CMBA_EMPLEADOS = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TEXTA_NOMBRES = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TEXTA_AP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TEXTA_AM = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DTP_FNAC = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.TEXTA_RFC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TEXTA_CURP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TEXTA_USUARIO = new System.Windows.Forms.TextBox();
            this.TEXTA_CLAVE = new System.Windows.Forms.TextBox();
            this.BTNA_GUARDAR = new System.Windows.Forms.Button();
            this.BTNA_BORRAR = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTNA_REESTABLECER = new System.Windows.Forms.Button();
            this.ID_AUX = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleados";
            // 
            // CMBA_EMPLEADOS
            // 
            this.CMBA_EMPLEADOS.FormattingEnabled = true;
            this.CMBA_EMPLEADOS.Items.AddRange(new object[] {
            "Ingrese nuevo empleado"});
            this.CMBA_EMPLEADOS.Location = new System.Drawing.Point(21, 55);
            this.CMBA_EMPLEADOS.Name = "CMBA_EMPLEADOS";
            this.CMBA_EMPLEADOS.Size = new System.Drawing.Size(149, 21);
            this.CMBA_EMPLEADOS.TabIndex = 1;
            this.CMBA_EMPLEADOS.SelectedIndexChanged += new System.EventHandler(this.CMBA_EMPLEADOS_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre(s)";
            // 
            // TEXTA_NOMBRES
            // 
            this.TEXTA_NOMBRES.Location = new System.Drawing.Point(125, 40);
            this.TEXTA_NOMBRES.Name = "TEXTA_NOMBRES";
            this.TEXTA_NOMBRES.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_NOMBRES.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Apellido Paterno";
            // 
            // TEXTA_AP
            // 
            this.TEXTA_AP.Location = new System.Drawing.Point(125, 77);
            this.TEXTA_AP.Name = "TEXTA_AP";
            this.TEXTA_AP.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_AP.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Apellido Materno";
            // 
            // TEXTA_AM
            // 
            this.TEXTA_AM.Location = new System.Drawing.Point(125, 111);
            this.TEXTA_AM.Name = "TEXTA_AM";
            this.TEXTA_AM.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_AM.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Fecha de nacimiento";
            // 
            // DTP_FNAC
            // 
            this.DTP_FNAC.Location = new System.Drawing.Point(125, 217);
            this.DTP_FNAC.Name = "DTP_FNAC";
            this.DTP_FNAC.Size = new System.Drawing.Size(217, 20);
            this.DTP_FNAC.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "RFC";
            // 
            // TEXTA_RFC
            // 
            this.TEXTA_RFC.Location = new System.Drawing.Point(125, 145);
            this.TEXTA_RFC.Name = "TEXTA_RFC";
            this.TEXTA_RFC.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_RFC.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "CURP";
            // 
            // TEXTA_CURP
            // 
            this.TEXTA_CURP.Location = new System.Drawing.Point(125, 176);
            this.TEXTA_CURP.Name = "TEXTA_CURP";
            this.TEXTA_CURP.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_CURP.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Usuario";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Clave";
            // 
            // TEXTA_USUARIO
            // 
            this.TEXTA_USUARIO.Location = new System.Drawing.Point(125, 35);
            this.TEXTA_USUARIO.Name = "TEXTA_USUARIO";
            this.TEXTA_USUARIO.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_USUARIO.TabIndex = 19;
            // 
            // TEXTA_CLAVE
            // 
            this.TEXTA_CLAVE.Location = new System.Drawing.Point(125, 75);
            this.TEXTA_CLAVE.Name = "TEXTA_CLAVE";
            this.TEXTA_CLAVE.Size = new System.Drawing.Size(217, 20);
            this.TEXTA_CLAVE.TabIndex = 20;
            // 
            // BTNA_GUARDAR
            // 
            this.BTNA_GUARDAR.Location = new System.Drawing.Point(618, 32);
            this.BTNA_GUARDAR.Name = "BTNA_GUARDAR";
            this.BTNA_GUARDAR.Size = new System.Drawing.Size(131, 51);
            this.BTNA_GUARDAR.TabIndex = 22;
            this.BTNA_GUARDAR.Text = "Guardar";
            this.BTNA_GUARDAR.UseVisualStyleBackColor = true;
            this.BTNA_GUARDAR.Click += new System.EventHandler(this.BTNA_GUARDAR_Click);
            // 
            // BTNA_BORRAR
            // 
            this.BTNA_BORRAR.Location = new System.Drawing.Point(618, 99);
            this.BTNA_BORRAR.Name = "BTNA_BORRAR";
            this.BTNA_BORRAR.Size = new System.Drawing.Size(131, 51);
            this.BTNA_BORRAR.TabIndex = 23;
            this.BTNA_BORRAR.Text = "Borrar";
            this.BTNA_BORRAR.UseVisualStyleBackColor = true;
            this.BTNA_BORRAR.Click += new System.EventHandler(this.BTNA_BORRAR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TEXTA_RFC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TEXTA_NOMBRES);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TEXTA_AP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TEXTA_AM);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DTP_FNAC);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.TEXTA_CURP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(201, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 270);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BTNA_REESTABLECER);
            this.groupBox2.Controls.Add(this.TEXTA_USUARIO);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TEXTA_CLAVE);
            this.groupBox2.Location = new System.Drawing.Point(201, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 130);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de usuario";
            // 
            // BTNA_REESTABLECER
            // 
            this.BTNA_REESTABLECER.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNA_REESTABLECER.Location = new System.Drawing.Point(396, 37);
            this.BTNA_REESTABLECER.Name = "BTNA_REESTABLECER";
            this.BTNA_REESTABLECER.Size = new System.Drawing.Size(131, 51);
            this.BTNA_REESTABLECER.TabIndex = 26;
            this.BTNA_REESTABLECER.Text = "RESTABLECER USUARIO";
            this.BTNA_REESTABLECER.UseVisualStyleBackColor = false;
            this.BTNA_REESTABLECER.Click += new System.EventHandler(this.BTNA_REESTABLECER_Click);
            // 
            // ID_AUX
            // 
            this.ID_AUX.Enabled = false;
            this.ID_AUX.Location = new System.Drawing.Point(21, 202);
            this.ID_AUX.Name = "ID_AUX";
            this.ID_AUX.Size = new System.Drawing.Size(149, 20);
            this.ID_AUX.TabIndex = 26;
            this.ID_AUX.Visible = false;
            // 
            // A_GESTION_EMPLEADOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ID_AUX);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BTNA_BORRAR);
            this.Controls.Add(this.BTNA_GUARDAR);
            this.Controls.Add(this.CMBA_EMPLEADOS);
            this.Controls.Add(this.label1);
            this.Name = "A_GESTION_EMPLEADOS";
            this.Text = "Gestion de Empleados";
            this.Load += new System.EventHandler(this.A_GESTION_EMPLEADOS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CMBA_EMPLEADOS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TEXTA_NOMBRES;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TEXTA_AP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TEXTA_AM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTP_FNAC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TEXTA_RFC;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TEXTA_CURP;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TEXTA_USUARIO;
        private System.Windows.Forms.TextBox TEXTA_CLAVE;
        private System.Windows.Forms.Button BTNA_GUARDAR;
        private System.Windows.Forms.Button BTNA_BORRAR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTNA_REESTABLECER;
        private System.Windows.Forms.TextBox ID_AUX;
    }
}