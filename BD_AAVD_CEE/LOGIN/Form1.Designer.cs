namespace BD_MAD_CEE
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CMBL_TIPO = new System.Windows.Forms.ComboBox();
            this.TEXTL_USUARIO = new System.Windows.Forms.TextBox();
            this.TEXTL_CLAVE = new System.Windows.Forms.TextBox();
            this.DTPL_FECHA = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.CBL_RECORDAR = new System.Windows.Forms.CheckBox();
            this.BTNL_INGRESAR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "SISTEMA DE CONSUMO ELECTRICO A.C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clave";
            // 
            // CMBL_TIPO
            // 
            this.CMBL_TIPO.FormattingEnabled = true;
            this.CMBL_TIPO.Items.AddRange(new object[] {
            "Administrador",
            "Empleado",
            "Cliente"});
            this.CMBL_TIPO.Location = new System.Drawing.Point(69, 81);
            this.CMBL_TIPO.Name = "CMBL_TIPO";
            this.CMBL_TIPO.Size = new System.Drawing.Size(140, 21);
            this.CMBL_TIPO.TabIndex = 4;
            // 
            // TEXTL_USUARIO
            // 
            this.TEXTL_USUARIO.Location = new System.Drawing.Point(69, 137);
            this.TEXTL_USUARIO.Name = "TEXTL_USUARIO";
            this.TEXTL_USUARIO.Size = new System.Drawing.Size(140, 20);
            this.TEXTL_USUARIO.TabIndex = 5;
            // 
            // TEXTL_CLAVE
            // 
            this.TEXTL_CLAVE.Location = new System.Drawing.Point(69, 180);
            this.TEXTL_CLAVE.Name = "TEXTL_CLAVE";
            this.TEXTL_CLAVE.Size = new System.Drawing.Size(140, 20);
            this.TEXTL_CLAVE.TabIndex = 6;
            // 
            // DTPL_FECHA
            // 
            this.DTPL_FECHA.Location = new System.Drawing.Point(43, 350);
            this.DTPL_FECHA.Name = "DTPL_FECHA";
            this.DTPL_FECHA.Size = new System.Drawing.Size(200, 20);
            this.DTPL_FECHA.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha";
            // 
            // CBL_RECORDAR
            // 
            this.CBL_RECORDAR.AutoSize = true;
            this.CBL_RECORDAR.Location = new System.Drawing.Point(69, 295);
            this.CBL_RECORDAR.Name = "CBL_RECORDAR";
            this.CBL_RECORDAR.Size = new System.Drawing.Size(126, 17);
            this.CBL_RECORDAR.TabIndex = 9;
            this.CBL_RECORDAR.Text = "Recordar contraseña";
            this.CBL_RECORDAR.UseVisualStyleBackColor = true;
            this.CBL_RECORDAR.CheckedChanged += new System.EventHandler(this.CBL_RECORDAR_CheckedChanged);
            // 
            // BTNL_INGRESAR
            // 
            this.BTNL_INGRESAR.Location = new System.Drawing.Point(55, 235);
            this.BTNL_INGRESAR.Name = "BTNL_INGRESAR";
            this.BTNL_INGRESAR.Size = new System.Drawing.Size(152, 40);
            this.BTNL_INGRESAR.TabIndex = 10;
            this.BTNL_INGRESAR.Text = "Ingresar";
            this.BTNL_INGRESAR.UseVisualStyleBackColor = true;
            this.BTNL_INGRESAR.Click += new System.EventHandler(this.BTNL_INGRESAR_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 382);
            this.Controls.Add(this.BTNL_INGRESAR);
            this.Controls.Add(this.CBL_RECORDAR);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DTPL_FECHA);
            this.Controls.Add(this.TEXTL_CLAVE);
            this.Controls.Add(this.TEXTL_USUARIO);
            this.Controls.Add(this.CMBL_TIPO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CMBL_TIPO;
        private System.Windows.Forms.TextBox TEXTL_USUARIO;
        private System.Windows.Forms.TextBox TEXTL_CLAVE;
        private System.Windows.Forms.DateTimePicker DTPL_FECHA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CBL_RECORDAR;
        private System.Windows.Forms.Button BTNL_INGRESAR;
    }
}

