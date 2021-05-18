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
            Program.Contador = dbm.PROGRAM_CHECK(CMBL_TIPO.Text, TEXTL_USUARIO.Text, TEXTL_CLAVE.Text);
            if ( Program.Contador != 1 )
            {
                Program.cont2 = Program.cont2 + 1;
            }
            if ( Program.cont2 >= 3)
            {
                //CAMBIARA EL VALOR DE ACTIVO EN EL SELECT Y NO DEJARA ENTRAR
                if (CMBL_TIPO.Text == "Empleado")
                {
                    string id = dbm.IDEMPLEADOL('E',TEXTL_USUARIO.Text);
                    if (id == "")
                    {
                        MessageBox.Show("No existe el usuario", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        Guid g = new Guid(id);
                        dbm.EMPLEADOUL('E',g, TEXTL_USUARIO.Text, 0);

                        MessageBox.Show("Usuario bloqueado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    
                }
                if (CMBL_TIPO.Text == "Cliente")
                {
                    string id = dbm.IDEMPLEADOL('C', TEXTL_USUARIO.Text);
                    if (id == "")
                    {
                        MessageBox.Show("No existe el usuario", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        var guid = Guid.NewGuid();
                        int g = Convert.ToInt32(id);
                        dbm.EMPLEADOUL('C', guid, TEXTL_USUARIO.Text, g);

                        MessageBox.Show("Usuario bloqueado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                Program.Contador = 0;
                Program.cont2 = 0;
            }
            
            log=dbm.PROGRAM_LOGIN(CMBL_TIPO.Text, TEXTL_USUARIO.Text, TEXTL_CLAVE.Text);
            if (log == 1) //ADMINISTRADOR
            {
                if (CBL_RECORDAR.Checked)
                {
                    //Guardar en la tabla de login el usuario y la clave
                    
                    dbm.INSERTLOGIN_INGRESO(TEXTL_USUARIO.Text, TEXTL_CLAVE.Text, CMBL_TIPO.Text);
                }
                else
                {
                    //Se va a poner el recordar en false 
                    dbm.UPDATELOGIN_INGRESO();
                }
                this.Hide();
                Form form = new ADMINISTRADOR.A_GESTION_EMPLEADOS();
                form.ShowDialog();
            }
            else if (log == 2) //EMPLEADO
            {
                if (CBL_RECORDAR.Checked)
                {
                    //Guardar en la tabla de login el usuario y la clave
                   
                    dbm.INSERTLOGIN_INGRESO(TEXTL_USUARIO.Text, TEXTL_CLAVE.Text, CMBL_TIPO.Text);
                }
                else
                {
                    dbm.UPDATELOGIN_INGRESO();
                }
                Program.usuarioIng = TEXTL_USUARIO.Text;
                Program.ContraIng = TEXTL_CLAVE.Text;
                this.Hide();
                Form form = new EMPLEADO.E_PANTALLA_PRINCIPAL();
                form.ShowDialog();
            }
            else if (log == 3) //CLIENTE
            {
                if (CBL_RECORDAR.Checked)
                {
                    //Guardar en la tabla de login el usuario y la clave
                 
                    dbm.INSERTLOGIN_INGRESO(TEXTL_USUARIO.Text, TEXTL_CLAVE.Text, CMBL_TIPO.Text);
                }
                else
                {
                    dbm.UPDATELOGIN_INGRESO();
                }
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
            DataBaseManager dbm = DataBaseManager.getInstance();
            //checar si se dejo en true el check 
            //HACER UN SELECT DEL USUARIO Y CONTRA SI EN LA TABLA LOGIN HAY TRUE
            TEXTL_USUARIO.Text = dbm.USUARIOLOGIN();
            TEXTL_CLAVE.Text = dbm.CLAVELOGIN();
            CMBL_TIPO.Text = dbm.TIPOLOGIN();

        }


       

        private void CBL_RECORDAR_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}
