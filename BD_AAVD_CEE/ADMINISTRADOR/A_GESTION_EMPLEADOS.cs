using BD_AAVD_CEE;
using BD_AAVD_CEE.DataBaseConnections;
using BD_AAVD_CEE.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE.ADMINISTRADOR
{
    public partial class A_GESTION_EMPLEADOS : Form
    {
        public A_GESTION_EMPLEADOS()
        {
            InitializeComponent();
        }

        private void BTNA_GUARDAR_Click(object sender, EventArgs e)
        {
            //ALTA DE EMPLEADOS HECHA POR EL ADMINISTRADOR 
            if (string.IsNullOrEmpty(TEXTA_NOMBRES.Text) || string.IsNullOrEmpty(TEXTA_AP.Text) || string.IsNullOrEmpty(TEXTA_AM.Text) ||
               string.IsNullOrEmpty(TEXTA_RFC.Text) || string.IsNullOrEmpty(TEXTA_CURP.Text) || string.IsNullOrEmpty(TEXTA_CLAVE.Text) ||
               string.IsNullOrEmpty(TEXTA_USUARIO.Text))
            {
                MessageBox.Show("Debe completar toda la informacion");
            }
            else
            {
                //SI SE VA A GUARDAR UN NUEVO EMPLEADO
                if (CMBA_EMPLEADOS.SelectedIndex == 0)
                {

                    //LLENAR CAMPOS 
                    #region Llenar Campos
                    BD_AAVD_CEE.ENTIDADES.Empleado_por_Id_Empleado vEmpleado = new Empleado_por_Id_Empleado();
                    vEmpleado.Nombre = TEXTA_NOMBRES.Text;
                    vEmpleado.Apellido_Paterno = TEXTA_AP.Text;
                    vEmpleado.Apellido_Materno = TEXTA_AM.Text;
                    vEmpleado.RFC = TEXTA_RFC.Text;
                    vEmpleado.CURP = TEXTA_CURP.Text;
                    vEmpleado.Fecha_Nacimiento = DTP_FNAC.Value;
                    vEmpleado.Nombre_Usuario = TEXTA_USUARIO.Text;
                    vEmpleado.Contrasenia = TEXTA_CLAVE.Text;
                    #endregion

                    //VALIDAR CAMPOS
                    #region Validar Campos

                    #endregion


                    //AQUI ESTA EL LLENADO 
                    vEmpleado.Id_Empleado = Guid.NewGuid();
                    DataBaseManager dbm = DataBaseManager.getInstance();
                    dbm.InsertUpdateDeleteEmpleado('I', vEmpleado);
                    string a = "";
                    a = Program.usuarioIng;
                    dbm.InsertAdmin('U', a, TEXTA_USUARIO.Text);

                    ActualizarDatosEmpleado();
                    MostrarDatosEMPLEADO();

                }
                //SI SE VA A EDITAR 
                else if (CMBA_EMPLEADOS.SelectedIndex >0)
                {
                    BD_AAVD_CEE.ENTIDADES.Empleado_por_Id_Empleado vEmpleado = new Empleado_por_Id_Empleado();
                    //aqui se editara, no se hara un duplicado 
                    //en este caso en vez de un insert es un update 
                 
                    vEmpleado.RFC = TEXTA_RFC.Text;
                    vEmpleado.CURP = TEXTA_CURP.Text;
                    vEmpleado.Nombre = TEXTA_NOMBRES.Text;
                    vEmpleado.Apellido_Paterno = TEXTA_AP.Text;
                    vEmpleado.Apellido_Materno = TEXTA_AM.Text;
                    vEmpleado.Fecha_Nacimiento = DTP_FNAC.Value;
                    vEmpleado.Nombre_Usuario = TEXTA_USUARIO.Text;
                    vEmpleado.Contrasenia = TEXTA_CLAVE.Text;
                    //aqui obtengo cual es el id del textbox
                    Guid g= new Guid(ID_AUX.Text);
                    vEmpleado.Id_Empleado = g;
                   
                    DataBaseManager dbm = DataBaseManager.getInstance();
                    dbm.InsertUpdateDeleteEmpleado('U', vEmpleado);

                    ActualizarDatosEmpleado();
                    MostrarDatosEMPLEADO();
                }

               

            }

        }


        //ACTUALIZARDATOS
         public void ActualizarDatosEmpleado()
        {
            //Aqui se actualiza el combo 
            DataBaseManager dbm = DataBaseManager.getInstance();
            List<Empleado_por_Id_Empleado> listaEmpleados = dbm.ObtenerEmpleado('X', null).ToList();
            CLASEGENERAL.ActualizarCombo(CMBA_EMPLEADOS, listaEmpleados, "Ingrese nuevo empleado");
            setPONERCOMBO0(0);
 
        }


        //MOSTRAR DATOS 
        #region MOSTRAR DATOS
        private void MostrarDatosEMPLEADO()
        {
            if (CMBA_EMPLEADOS.SelectedIndex == 0)
            {
                //vaciar campos para permitir que el usuario pueda ingresar un nuevo empleado
                TEXTA_NOMBRES.Text = "";
                TEXTA_AP.Text="";
                TEXTA_AM.Text = "";
                TEXTA_RFC.Text = "";
                TEXTA_CURP.Text = "";
                TEXTA_USUARIO.Text = "";
                TEXTA_CLAVE.Text = "";

            }
            else if (CMBA_EMPLEADOS.SelectedIndex > 0)
            {
                DataBaseManager dbm = DataBaseManager.getInstance();
                Empleado_por_Id_Empleado vEmpleadoElegido = (Empleado_por_Id_Empleado)CMBA_EMPLEADOS.SelectedItem;
               
                List<Empleado_por_Id_Empleado> empleadoElegido = dbm.ObtenerEmpleado('S', vEmpleadoElegido).ToList();
                TEXTA_NOMBRES.Text = empleadoElegido[0].Nombre;
                TEXTA_AP.Text = empleadoElegido[0].Apellido_Paterno;
                TEXTA_AM.Text = empleadoElegido[0].Apellido_Materno;
                TEXTA_RFC.Text = empleadoElegido[0].RFC;
                TEXTA_CURP.Text = empleadoElegido[0].CURP;
                TEXTA_USUARIO.Text = empleadoElegido[0].Nombre_Usuario;
                TEXTA_CLAVE.Text = empleadoElegido[0].Contrasenia;
                DTP_FNAC.Value = empleadoElegido[0].Fecha_Nacimiento;
                ID_AUX.Text = empleadoElegido[0].Id_Empleado.ToString();
            }
        }
        #endregion

        private void setPONERCOMBO0(int index)
        {
            if (index>=-1)
            {
                try
                {
                    CMBA_EMPLEADOS.SelectedIndex = index;
                }
                catch (Exception)
                {

                }
                
            }

        }

        private void CMBA_EMPLEADOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarDatosEMPLEADO();
        }

        private void A_GESTION_EMPLEADOS_Load(object sender, EventArgs e)
        {
            DataBaseManager dbm = DataBaseManager.getInstance();
            List<Empleado_por_Id_Empleado> listaEmpleados = dbm.ObtenerEmpleado('X', null).ToList();
            CLASEGENERAL.ActualizarCombo(CMBA_EMPLEADOS, listaEmpleados, "Ingrese nuevo empleado");

        }

        private void BTNA_BORRAR_Click(object sender, EventArgs e)
        {
            //checar que este seleccionado algo para borrar, sino mostar advertencia 
            if (CMBA_EMPLEADOS.SelectedIndex == -1 || CMBA_EMPLEADOS.SelectedIndex ==0)
            {
                //  que no este seleccionado nada o que este seleccionado el de ingresar nuevo empleado
                MessageBox.Show("Debe seleccionar el empleado a borrar");
            }
            else
            {
                //PROCESO DE BORRADO
                //variable para poder obtener el id y de ahi hacer el update del activo o no 
                BD_AAVD_CEE.ENTIDADES.Empleado_por_Id_Empleado vEmpleado = new Empleado_por_Id_Empleado();
                Guid g = new Guid(ID_AUX.Text);
                vEmpleado.Id_Empleado = g;

                DataBaseManager dbm = DataBaseManager.getInstance();
                dbm.InsertUpdateDeleteEmpleado('D', vEmpleado);
                ActualizarDatosEmpleado();
                MostrarDatosEMPLEADO();

            }
        }
    }
}
