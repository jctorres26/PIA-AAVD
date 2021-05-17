using BD_AAVD_CEE.DataBaseConnections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNL_INGRESAR_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //BD_MAD_CEE.ADMINISTRADOR.A_GESTION_EMPLEADOS fmr = new ADMINISTRADOR.A_GESTION_EMPLEADOS();
            // BD_MAD_CEE.EMPLEADO.E_PANTALLA_PRINCIPAL fmr = new EMPLEADO.E_PANTALLA_PRINCIPAL();
            //fmr.Show();
            var log = 0;
            DataBaseManager dbm = DataBaseManager.getInstance();
            log=dbm.PROGRAM_LOGIN(CMBL_TIPO.Text, TEXTL_USUARIO.Text, TEXTL_CLAVE.Text);
            if (log == 1) //ADMINISTRADOR
            {
                this.Hide();
                Form form = new ADMINISTRADOR.A_GESTION_EMPLEADOS();
                form.ShowDialog();
            }
            else if (log == 2) //EMPLEADO
            {
                Program.usuarioIng = TEXTL_USUARIO.Text;
                Program.ContraIng = TEXTL_CLAVE.Text;
                this.Hide();
                Form form = new EMPLEADO.E_PANTALLA_PRINCIPAL();
                form.ShowDialog();
            }
            else if (log == 3) //CLIENTE
            {
                Program.usuarioIng = TEXTL_USUARIO.Text;
                this.Hide();
                Form form = new CLIENTE.C_CLIENTES();
                form.ShowDialog();
            }
            else
            {
                //HACER FUNCION DE CONTEO POR SI HAY MAS DE 3 ERRORES !!!
                MessageBox.Show("Error al ingresar datos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                CMBL_TIPO.SelectedIndex = -1;
                TEXTL_USUARIO.Text = "";
                TEXTL_CLAVE.Text = "";
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
