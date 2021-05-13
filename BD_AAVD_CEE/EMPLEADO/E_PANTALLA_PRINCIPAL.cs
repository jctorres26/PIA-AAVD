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
                string.IsNullOrEmpty(TXTE_CURP.Text)  || string.IsNullOrEmpty(CMBE_GENERO.Text) ||
                string.IsNullOrEmpty(TXTE_CLAVE.Text) || string.IsNullOrEmpty(CMBE_TIPOS.Text) || string.IsNullOrEmpty(TXTE_CIUDAD.Text) ||
                string.IsNullOrEmpty(TXTE_COLONIA.Text) || string.IsNullOrEmpty(TXTE_ESTADO.Text) || string.IsNullOrEmpty(TXTE_CALLE.Text) ||
                string.IsNullOrEmpty(TXTE_NUMCASA.Text) || string.IsNullOrEmpty(TXTE_CP.Text) || string.IsNullOrEmpty(TXTE_MEDIDOR.Text) 
                )
            {
               
                MessageBox.Show("Debe completar toda la informacion");
                

            }
            else
            {
                //si no estan vacios entonces podremos hacer el insert
                //ahora debemos checar si va a agregar un nuevo cliente o si va a agregar un nuevo servicio a un cliente ya existente
                //que ya existe 

                //NUEVO CLIENTE CON SU PRIMER CONTRATO
             //   if (CMBE_CLIENTES.SelectedIndex == 0)
               // {
                    // si se agrega un nuevo cliente de  afuerzas se le hara un primer contrato 
                    //haremos un insert en la tabla de clientes y de contratos 
                    Contrato_por_Numero_Servicio vContrato = new Contrato_por_Numero_Servicio();
                    Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
                    NumServ vServicio = new NumServ();
                    DataBaseManager dbm = DataBaseManager.getInstance();


                    //lista de la base de datos donde estaran los ids 
                    //vCliente.Id_Cliente = Guid.NewGuid();
                    
                    //vContrato.Id_Cliente = vCliente.Id_Cliente;
       
                    //vServicio.idBASE = PIA.Text;
                    //dbm.INSERTSERVICIO('U', vServicio);
                    // string aux = "";
                    //aux= dbm.NUMSERVICIO();
                    //TXTE_NROSERVICIO.Text = aux;

                //CREAR UN ID PARA LA TABLA DE CLIENTES CON OTRO COUNTER 


                    //LLENAR CAMPOS 


                    vCliente.Nombre = TXTE_NOMBRES.Text;
                    vCliente.Apellido_Paterno = TXTE_AP.Text;
                    vCliente.Apellido_Materno = TXTE_AM.Text;
                   // vCliente.Fecha_Nacimiento = DTPE_FNAC.Value;
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
                    vContrato.Numero_Exterior = Convert.ToInt32 (TXTE_NUMCASA.Text);
                   
                    vContrato.Tipo_Servicio = CMBE_TIPOS.Text;

                //identificadores del id del cliente y del numero de servicio 
                vContrato.Numero_Servicio = Guid.NewGuid();
                //FUNCION PARA HACER EL INSERT
                dbm.Contratos('I', vContrato, vCliente);

                

             //   }
                //OTRO CONTRATO A UN CLIENTE YA EXISTENTE 
               // else {
                    // aqui tomaremos la info de arriba del cliente ( hay que hacer un bloqueo de los textbox para que no pueda editar esto)

                //}

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
             
               
            }
        }
    }
}