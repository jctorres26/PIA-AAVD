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

namespace BD_MAD_CEE.EMPLEADO
{
    public partial class E_PANTALLA_PRINCIPAL : Form
    {
        public E_PANTALLA_PRINCIPAL()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void BTNE_RCONTRATO_Click(object sender, EventArgs e)
        {
            //primero se debe registrar a un cliente por primera vez junto con su primer contrato
            //despues se debe poder tambien registrar un nuevo contrato con ese mismo cliente u otro cliente

            //primero checar que esten llenos todos los espacios sino no puede guardar nada
            if (string.IsNullOrEmpty(TXTE_NOMBRES.Text) || string.IsNullOrEmpty(TXTE_AP.Text) || string.IsNullOrEmpty(TXTE_AM.Text) ||
                string.IsNullOrEmpty(TXTE_CURP.Text)  || string.IsNullOrEmpty(CMBE_GENERO.Text) || string.IsNullOrEmpty(TXTE_USUARIO.Text) ||
                string.IsNullOrEmpty(TXTE_CLAVE.Text) || string.IsNullOrEmpty(CMBE_TIPOS.Text) || string.IsNullOrEmpty(TXTE_CIUDAD.Text) ||
                string.IsNullOrEmpty(TXTE_COLONIA.Text) || string.IsNullOrEmpty(TXTE_ESTADO.Text) || string.IsNullOrEmpty(TXTE_CALLE.Text) ||
                string.IsNullOrEmpty(TXTE_NUMCASA.Text) || string.IsNullOrEmpty(TXTE_CP.Text) || string.IsNullOrEmpty(TXTE_MEDIDOR.Text) 
                )
            {
               
                MessageBox.Show("Debe completar toda la informacion");
                

            }
            else
            {
                //SI SE ESTA AGREGANDO UN CLIENTE NUEVO CON SU PRIMER CONTRATO 
                if (CMBE_CLIENTES.SelectedIndex == 0)
                {
                    Contrato_por_Numero_Servicio vContrato = new Contrato_por_Numero_Servicio();
                    Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
                    NumServ vServicio = new NumServ();
                    DataBaseManager dbm = DataBaseManager.getInstance();

                    //LLENAR CAMPOS 

                    vCliente.Nombre = TXTE_NOMBRES.Text;
                    vCliente.Apellido_Paterno = TXTE_AP.Text;
                    vCliente.Apellido_Materno = TXTE_AM.Text;
                    vCliente.Fecha_Nacimiento = DTPE_FNAC.Value;
                    vCliente.CURP = TXTE_CURP.Text;
                    vCliente.Genero = CMBE_GENERO.Text;
                    vCliente.Nombre_Usuario = TXTE_USUARIO.Text;
                    vCliente.Contrasenia = TXTE_CLAVE.Text;
                    vContrato.NumSer = Convert.ToInt64(TXTE_NROSERVICIO.Text);
                    vContrato.Numero_Medidor = Convert.ToInt32(TXTE_MEDIDOR.Text);
                    vCliente.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);
                    vContrato.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);

                    vContrato.Calle = TXTE_CALLE.Text;
                    vContrato.Ciudad = TXTE_CIUDAD.Text;
                    vContrato.Colonia = TXTE_COLONIA.Text;
                    vContrato.CP = TXTE_CP.Text;
                    vContrato.Estado = TXTE_ESTADO.Text;
                    // vContrato.Numero_Servicio = Convert.ToInt32(TXTE_NROSERVICIO.Text);
                    vContrato.Numero_Exterior = Convert.ToInt32(TXTE_NUMCASA.Text);

                    vContrato.Tipo_Servicio = CMBE_TIPOS.Text;


                    //FUNCION PARA HACER EL INSERT
                    dbm.Contratos('U', vContrato, vCliente);
                    dbm.Contratos('D', vContrato, vCliente);
                    ActualizarDatosCliente();
                    MostrarDatosClientes();
                    //  dbm.insertStudent(vCliente);
                    //FUNCION DE ACTUALIZAR
                    //FUNCION DE MOSTRAR


                }
                else if (CMBE_CLIENTES.SelectedIndex > 0)
                {
                    //EN ESTE CASO VA A IR TODO LO QUE ES CREAR OTRO CONTRATO AL CLIENTE
                    //HARE LA FUNCION DE INSERTAR OTRO CONTRATO CON EL NUMERO ID QUE ESTE EN EL AUX , PARA DARLE ESE CONTRATO A UN 
                    //CLIENTE QUE YA EXISTA Y QUE PUEDA TENER VARIOS CONTRATOS, SIN HACER UN INSERT DEL CLIENTE COMO TAL
                    Contrato_por_Numero_Servicio vContrato = new Contrato_por_Numero_Servicio();
                    DataBaseManager dbm = DataBaseManager.getInstance();
                    vContrato.Calle = TXTE_CALLE.Text;
                    vContrato.Ciudad = TXTE_CIUDAD.Text;
                    vContrato.Colonia = TXTE_COLONIA.Text;
                    vContrato.CP = TXTE_CP.Text;
                    vContrato.Estado = TXTE_ESTADO.Text;
                    vContrato.NumSer = Convert.ToInt64(TXTE_NROSERVICIO.Text);
                    vContrato.Numero_Exterior = Convert.ToInt32(TXTE_NUMCASA.Text);
                    vContrato.Tipo_Servicio = CMBE_TIPOS.Text;
                    vContrato.Numero_Medidor = Convert.ToInt32(TXTE_MEDIDOR.Text);
                    vContrato.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);
                    dbm.Contratos('C', vContrato,null);
                    ActualizarDatosCliente();
                    MostrarDatosClientes();

                }

            }
        }

        public void ActualizarDatosCliente()
        {
            DataBaseManager dbm = DataBaseManager.getInstance();
            List<Cliente_por_Id_Cliente> listaClientes = dbm.ObtenerCliente('X', null).ToList();
            CLASEGENERAL.ActualizarComboC(CMBE_CLIENTES, listaClientes, "Ingrese nuevo empleado");
            setPONERCOMBO2(0);
        }

        private void MostrarDatosClientes()
        {
            if (CMBE_CLIENTES.SelectedIndex == 0)
            {
                //vaciar campos para permitir que el usuario pueda ingresar un nuevo cliente
                TXTE_NOMBRES.Text = "";
                TXTE_AM.Text = "";
                TXTE_AP.Text = "";
                TXTE_CALLE.Text = "";
                TXTE_CIUDAD.Text = "";
                TXTE_CLAVE.Text = "";
                TXTE_MEDIDOR.Text = "";
                TXTE_COLONIA.Text = "";
                TXTE_CURP.Text = "";
                TXTE_EMAIL.Text = "";
                CMBE_GENERO.SelectedIndex = -1;
                TXTE_USUARIO.Text = "";
                CMBE_TIPOS.SelectedIndex = -1;
                TXTE_ESTADO.Text = "";
                TXTE_NUMCASA.Text = "";
                TXTE_CP.Text = "";
                //ID_AUXCLIENTE.Text = "";
                //TXTE_NROSERVICIO.Text = "";


            }
            else if (CMBE_CLIENTES.SelectedIndex > 0)
            {
                DataBaseManager dbm = DataBaseManager.getInstance();
                Cliente_por_Id_Cliente vClienteElegido = (Cliente_por_Id_Cliente)CMBE_CLIENTES.SelectedItem;
                List<Cliente_por_Id_Cliente> clienteElegido = dbm.ObtenerCliente('S', vClienteElegido).ToList();
             //   TXTE_NROSERVICIO.Text = "";
                TXTE_NOMBRES.Text = clienteElegido[0].Nombre;
                TXTE_AM.Text = clienteElegido[0].Apellido_Materno;
                TXTE_AP.Text = clienteElegido[0].Apellido_Paterno;
                TXTE_CLAVE.Text = clienteElegido[0].Contrasenia;
                TXTE_CURP.Text = clienteElegido[0].CURP;
                // TXTE_EMAIL.Text = "";
                CMBE_GENERO.Text = clienteElegido[0].Genero;
                TXTE_USUARIO.Text = clienteElegido[0].Nombre_Usuario;
                DTPE_FNAC.Value = clienteElegido[0].Fecha_Nacimiento;
                ID_AUXCLIENTE.Text = clienteElegido[0].Id_Cliente.ToString();
            }
        }

        private void setPONERCOMBO2(int index)
        {
            if (index >= -1)
            {
                try
                {
                    CMBE_CLIENTES.SelectedIndex = index;
                }
                catch (Exception)
                {

                }

            }

        }
        private void BTNC_EMAIL_Click(object sender, EventArgs e)
        {
            IEnumerable<string> items = new string[] { (TXTE_EMAIL.Text) };
            items = items.Concat(new[] { (TXTE_EMAIL.Text) });

            Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
            vCliente.Email = items;

        }

        private void CMBE_CLIENTES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( CMBE_CLIENTES.SelectedIndex == 0)
            {
                DataBaseManager dbm = DataBaseManager.getInstance();
                NumServ vServicio = new NumServ();
                vServicio.idBASE = PIA.Text;
                dbm.INSERTSERVICIO('U', vServicio);
                string aux = "";
                aux = dbm.NUMSERVICIO();
                TXTE_NROSERVICIO.Text = aux;

                //para el id del cliente 
                NumCliente vNCliente = new NumCliente();
                vNCliente.idBASE2 = PIA.Text;
                dbm.CLIENTEID('U', vNCliente);
                string aux2 = "";
                aux2 = dbm.NUMCLIENTE();
                ID_AUXCLIENTE.Text = aux2;
                MostrarDatosClientes();

            }
            else
            {
                DataBaseManager dbm = DataBaseManager.getInstance();
                NumServ vServicio = new NumServ();
                vServicio.idBASE = PIA.Text;
                dbm.INSERTSERVICIO('U', vServicio);
                string aux = "";
                aux = dbm.NUMSERVICIO();
                TXTE_NROSERVICIO.Text = aux;
                MostrarDatosClientes();


            }

        }

        private void E_PANTALLA_PRINCIPAL_Load(object sender, EventArgs e)
        {
            //Llenado del combobox para clientes 
            DataBaseManager dbm = DataBaseManager.getInstance();
            List<Cliente_por_Id_Cliente> listaClientes = dbm.ObtenerCliente('X', null).ToList();
            CLASEGENERAL.ActualizarComboC(CMBE_CLIENTES, listaClientes, "Ingrese nuevo empleado");
        }

        private void BTNE_CACTUALIZAR_Click(object sender, EventArgs e)
        {
            //EDICION DE ALGUN CLIENTE , SU INFO 
            if (string.IsNullOrEmpty(TXTE_NOMBRES.Text) || string.IsNullOrEmpty(TXTE_AP.Text) || string.IsNullOrEmpty(TXTE_AM.Text) ||
                string.IsNullOrEmpty(TXTE_CURP.Text) || string.IsNullOrEmpty(CMBE_GENERO.Text) ||
                string.IsNullOrEmpty(TXTE_CLAVE.Text)  || string.IsNullOrEmpty(TXTE_USUARIO.Text)

                )
            {

                MessageBox.Show("Todos los campos deben estar completos");


            }
            else
            {
                if (CMBE_CLIENTES.SelectedIndex > 0)
                {
                    Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();

                    //INFO QUE VOY A OBTENER PARA EDITAR 
                    vCliente.Nombre = TXTE_NOMBRES.Text;
                    vCliente.Apellido_Paterno = TXTE_AP.Text;
                    vCliente.Apellido_Materno = TXTE_AM.Text;
                    vCliente.Fecha_Nacimiento = DTPE_FNAC.Value;
                    vCliente.CURP = TXTE_CURP.Text;
                    vCliente.Genero = CMBE_GENERO.Text;
                    vCliente.Nombre_Usuario = TXTE_USUARIO.Text;
                    vCliente.Contrasenia = TXTE_CLAVE.Text;
                    vCliente.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);

                    DataBaseManager dbm = DataBaseManager.getInstance();
                    dbm.UpdateDeleteCliente('U', vCliente);
                    ActualizarDatosCliente();
                    MostrarDatosClientes();
                }
            }

        }

        private void BTNE_BAJA_Click(object sender, EventArgs e)
        {
            //AQUI SE HARA UNA BAJA LOGICA PARA EL CLIENTE 
            //checar que este seleccionado algo para borrar, sino mostar advertencia 
            if (CMBE_CLIENTES.SelectedIndex == -1 || CMBE_CLIENTES.SelectedIndex == 0)
            {
                //  que no este seleccionado nada o que este seleccionado el de ingresar nuevo empleado
                MessageBox.Show("Debe seleccionar el cliente a borrar");
            }
            else
            {
                Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
                vCliente.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);
                DataBaseManager dbm = DataBaseManager.getInstance();
                dbm.UpdateDeleteCliente('D', vCliente);
                ActualizarDatosCliente();
                MostrarDatosClientes();
            }
        }
    }
}