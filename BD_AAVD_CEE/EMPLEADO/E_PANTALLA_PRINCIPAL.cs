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
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "M";
            dateTimePicker2.ShowUpDown = true;

            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy";
            dateTimePicker3.ShowUpDown = true;
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "yyyy";
            dateTimePicker4.ShowUpDown = true;

            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.CustomFormat = "yyyy";
            dateTimePicker5.ShowUpDown = true;
            dateTimePicker6.Format = DateTimePickerFormat.Custom;
            dateTimePicker6.CustomFormat = "M";
            dateTimePicker6.ShowUpDown = true;

            dateTimePicker7.Format = DateTimePickerFormat.Custom;
            dateTimePicker7.CustomFormat = "yyyy";
            dateTimePicker7.ShowUpDown = true;

            dateTimePicker9.Format = DateTimePickerFormat.Custom;
            dateTimePicker9.CustomFormat = "M";
            dateTimePicker9.ShowUpDown = true;

            anioRGDT.Format = DateTimePickerFormat.Custom;
            anioRGDT.CustomFormat = "yyyy";
            anioRGDT.ShowUpDown = true;

            dateTimePicker10.Format = DateTimePickerFormat.Custom;
            dateTimePicker10.CustomFormat = "yyyy";
            dateTimePicker10.ShowUpDown = true;

            dateTimePicker8.Format = DateTimePickerFormat.Custom;
            dateTimePicker8.CustomFormat = "M";
            dateTimePicker8.ShowUpDown = true;


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
                || string.IsNullOrEmpty(TXTE_EMAIL.Text)
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
                    Empleado_por_Id_Empleado vEmpleado = new Empleado_por_Id_Empleado();
                    //LLENAR CAMPOS 

                    vCliente.Nombre = TXTE_NOMBRES.Text;
                    vCliente.Apellido_Paterno = TXTE_AP.Text;
                    vCliente.Apellido_Materno = TXTE_AM.Text;
                    vCliente.Fecha_Nacimiento = DTPE_FNAC.Value;
                    vCliente.CURP = TXTE_CURP.Text;
                    vCliente.Genero = CMBE_GENERO.Text;
                    vCliente.Nombre_Usuario = TXTE_USUARIO.Text;
                    vCliente.Contrasenia = TXTE_CLAVE.Text;
                    vCliente.Email = TXTE_EMAIL.Text;
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
                    vContrato.Empleado_Modificacion = Program.usuarioIng.ToString();
                    vCliente.Empleado_Modificacion = Program.usuarioIng.ToString();
                    vContrato.Tipo_Servicio = CMBE_TIPOS.Text;


                    //FUNCION PARA HACER EL INSERT
                    dbm.Contratos('U', vContrato, vCliente);
                    dbm.Contratos('D', vContrato, vCliente);
                    string US = "";
                    US = TXTE_NOMBRES.Text+ " "+ TXTE_AP.Text+ " " + TXTE_AM.Text;
               
                    Guid g = new Guid(EMPLEADO_ID_T.Text);
                    dbm.EMPLEADOU(g, US);
                    ActualizarDatosCliente();
                    MostrarDatosClientes();
                  


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
                    vContrato.Empleado_Modificacion = Program.usuarioIng.ToString();
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
                TXTE_EMAIL.Text = clienteElegido[0].Email;
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
            string id=dbm.IDEMPLEADO(Program.usuarioIng.ToString(), Program.ContraIng.ToString());
            EMPLEADO_ID_T.Text = id;

        }

        private void BTNE_CACTUALIZAR_Click(object sender, EventArgs e)
        {
            //EDICION DE ALGUN CLIENTE , SU INFO 
            if (string.IsNullOrEmpty(TXTE_NOMBRES.Text) || string.IsNullOrEmpty(TXTE_AP.Text) || string.IsNullOrEmpty(TXTE_AM.Text) ||
                string.IsNullOrEmpty(TXTE_CURP.Text) || string.IsNullOrEmpty(CMBE_GENERO.Text) ||
                string.IsNullOrEmpty(TXTE_CLAVE.Text)  || string.IsNullOrEmpty(TXTE_USUARIO.Text) || string.IsNullOrEmpty(TXTE_EMAIL.Text)

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
                    vCliente.Email = TXTE_EMAIL.Text;
                    vCliente.Id_Cliente = Convert.ToInt64(ID_AUXCLIENTE.Text);
                    vCliente.Empleado_Modificacion = Program.usuarioIng.ToString();
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

        private void BTNE_REESTABLCER_Click(object sender, EventArgs e)
        {
            //HACER FUNCION PARA QUE SE HAGA UN UPDATE 

            //Checar que haya un cliente seleccionado del combobox para poder recuperar el id
            if (CMBE_CLIENTES.SelectedIndex == -1 || CMBE_CLIENTES.SelectedIndex == 0)
            {
                //  que no este seleccionado nada o que este seleccionado el de ingresar nuevo empleado
                MessageBox.Show("Debe seleccionar el cliente a reestablecer");
            }
            else
            {
                Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
               
                
                int num = Convert.ToInt32(ID_AUXCLIENTE.Text);
                vCliente.Id_Cliente = num;
              
                DataBaseManager dbm = DataBaseManager.getInstance();
                dbm.CLIENTE_REESTABLECER(vCliente);
                ActualizarDatosCliente();
                MostrarDatosClientes();

            }
        }

        private void E_PANTALLA_PRINCIPAL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BTNE_CTARIFA_Click(object sender, EventArgs e)
        {
            //HACER FUNCION PARA EL INSERT DE LAS TARIFAS 

            //CHECAR QUE ESTE TODO LLENO
           if (string.IsNullOrEmpty(TXTE_TBASICA.Text) || string.IsNullOrEmpty(TXTE_TINT.Text) ||
                string.IsNullOrEmpty(TXTE_TEXC.Text) || string.IsNullOrEmpty(CMBE_TCSERVICIO.Text)  )
            {
                MessageBox.Show("Faltan campos a llenar ");
            }
            else
            {
                //Checar si ya hay una tarifa para ese tipo, año y mes
                //si hay ya una tarifa existente entonces se manda mensaje, si no existe, se inserta
                DataBaseManager dbm = DataBaseManager.getInstance();
                bool chek = false;
               
                chek =dbm.TarifaExistente(CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text);

                if (chek == true)
                {
                    //Significa que si existe, entonces ya no se hace el insert porque ya se cargo
                    MessageBox.Show("La tarifa ya se ha cargado en esta fecha ");
                    CMBE_TCSERVICIO.Text = "";
                    TXTE_TBASICA.Text = "";
                    TXTE_TINT.Text = "";
                    TXTE_TEXC.Text = "";
                }
                else
                {
                    
                    float b = 0;
                    float i = 0;
                    float ex = 0;
                    string emp = "";
                    b = Convert.ToSingle(TXTE_TBASICA.Text);
                    i = Convert.ToSingle(TXTE_TINT.Text);
                    ex = Convert.ToSingle(TXTE_TEXC.Text);
                    emp = Program.usuarioIng.ToString();
                    int aux1 = 0;
                    int aux2 = 0;
                    string a1 = "";
                    string a2 = "";
                    aux2 = Convert.ToInt32(dateTimePicker2.Text);
                    dbm.InserTarifaUNIT('I', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    dbm.InserTarifaUNIT('S', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    //if (CMBE_TCSERVICIO.Text == "Industrial")
                    //{
                    //    dbm.InserTarifaUNIT('I', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    //    dbm.InserTarifaUNIT('S', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    //}
                    //else
                    //{
                    //    if (aux2 == 2 || aux2 == 4 || aux2== 6 || aux2==8 || aux2==10 || aux2==12 )
                    //    {
                    //        aux2 = aux2-1;
                    //        a1 = aux2.ToString();
                    //    }
                    //    else
                    //    {
                    //        aux2 = aux2 + 1;
                    //        a1 = aux2.ToString();
                    //    }
                    //    //insercion normal
                    //    dbm.InserTarifaUNIT('I', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    //    dbm.InserTarifaUNIT('S', CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
                    //    //insercion de la tarifa del siguiente mes
                    //    dbm.InserTarifaUNIT('I', CMBE_TCSERVICIO.Text, a1, dateTimePicker1.Text, b, i, ex, emp);
                    //    dbm.InserTarifaUNIT('S', CMBE_TCSERVICIO.Text, a1, dateTimePicker1.Text, b, i, ex, emp);

                    //}

                    CMBE_TCSERVICIO.Text = "";
                    TXTE_TBASICA.Text = "";
                    TXTE_TINT.Text = "";
                    TXTE_TEXC.Text = "";
                    MessageBox.Show("Tarifa cargada con exito");
                }

            }
           

        }

        private void BTNE_CCONSUMO_Click(object sender, EventArgs e)
        {
            //PRIMERO CHECAR QUE TODOS LOS DATOS ESTEN LLENOS 
            if (string.IsNullOrEmpty(TXTE_CMEDIDOR.Text) || string.IsNullOrEmpty(TXTE_CONSUMOKWH.Text))
            {
                MessageBox.Show("Faltan campos a llenar ");
            }
            else
            {
                //CHECAR QUE EXISTA EL MEDIDOR QUE SE QUIERE CARGAR CONSUMO 
                bool existe = false;
                DataBaseManager dbm = DataBaseManager.getInstance();
                existe = dbm.MedidorExistente(TXTE_CMEDIDOR.Text);
                if (existe == true)
                {
                    MessageBox.Show("Si hay un contrato con este medidor ");

                    //SI existe un medidor, entonces hay que checar cual es su tipo de contrato, si domiciliar o industrial, y poner 
                    //esto en una variable , para poder meter esto en la tabla de consumos 

                    //CHECAR SI EXISTE UN CONSUMO CARGADO ANTERIORMENTE EN LA FECHA INDICADA PARA ESE MEDIDOR
                    //que haga un select en la tabla de consumos 
                    string tipo = "";
                    tipo = dbm.MedidorTipo(TXTE_CMEDIDOR.Text);
                    string a = "";
                    string m = "";
                    bool existe3 = false;
                    bool exite4 = false;
                  
                    //Esta checando que exista una tarifa cargada para ese mes, donde cheque si para el numero de medidor,
                    //con su numero de medidor, mes, año  hay algo cargado 
                    //Sacar del select el año, mes 
                    a = DTPE_FECHACONSUMO.Value.Year.ToString();
                    m = DTPE_FECHACONSUMO.Value.Month.ToString();
                    string date = "";
                    date = DTPE_FECHACONSUMO.Value.ToShortDateString();
                    exite4 = dbm.ConsumoPeriodo(TXTE_CMEDIDOR.Text, date);
                    existe3 = dbm.ConsumoExistente(TXTE_CMEDIDOR.Text, a, m, date);
                    if (tipo == "Industrial")
                    {
                        if (exite4 == true)
                        {
                            //si existe entonces que ponga mensaje de que ya hay un consumo 
                            TXTE_CMEDIDOR.Text = "";
                            TXTE_CONSUMOKWH.Text = "";
                            MessageBox.Show("No esta permitido hacer un cargo en la fecha especificada");


                        }
                        else
                        {
                            bool existe2 = false;
                            existe2 = dbm.TarifaExistente(tipo, m, a);
                            if (existe2 == true)
                            {
                                //Entonces si podremos hacer la carga del consumo 
                                //primero hacer una funcion donde saque que tarifas le corresponde segun el año, y mes que se escogio
                                //Pondremos que
                                //Consumo basico = 150
                                //Consumo intermedio = 200 
                                //Consumo excedente = pues el sobrante de esto 
                                //Calcular consumo basico, intermedio, excedente 
                                string tb = "";
                                string ti = "";
                                string tx = "";
                                int Cons = 0;
                                int bas = 0;
                                int med = 0;
                                int exp = 0;
                                float tb1 = 0;
                                float tb2 = 0;
                                float tb3 = 0;
                                //Aqui calcular cual sera el consumo basico, intermedio y excedente
                                Cons = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                if (Cons >= 150)
                                {
                                    bas = 150;
                                    if (Cons > 150)
                                    {
                                        Cons = Cons - 150;
                                        if (Cons <= 200)
                                        {
                                            med = Cons;
                                            exp = 0;
                                        }
                                        else
                                        {
                                            med = 200;
                                            Cons = Cons - 200;
                                            exp = Cons;
                                        }
                                    }
                                    else
                                    {
                                        med = 0;
                                        exp = 0;
                                    }

                                }
                                else
                                {
                                    bas = Cons;
                                    med = 0;
                                    exp = 0;
                                }
                                //Aqui calcule las tarifas para ese cargo de consumo especifico 
                                tb = dbm.TarifasParaConsumo('B', tipo, m, a);
                                ti = dbm.TarifasParaConsumo('I', tipo, m, a);
                                tx = dbm.TarifasParaConsumo('E', tipo, m, a);
                                //convertir tarifas a float 
                                tb1 = Convert.ToSingle(tb);
                                tb2 = Convert.ToSingle(ti);
                                tb3 = Convert.ToSingle(tx);
                                //llenar datos finales para insercion 
                                Consumo_por_Numero_Medidor_Fecha vConsumo = new Consumo_por_Numero_Medidor_Fecha();
                                vConsumo.Numero_Medidor = Convert.ToInt32(TXTE_CMEDIDOR.Text);
                                vConsumo.Fecha = DTPE_FECHACONSUMO.Value;
                                vConsumo.Consumo = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                vConsumo.Basico = bas;
                                vConsumo.Intermedio = med;
                                vConsumo.Excedente = exp;
                                vConsumo.Empleado_Modificacion = Program.usuarioIng.ToString();
                                vConsumo.Basicot = tb1;
                                vConsumo.Intermediot = tb2;
                                vConsumo.Excedentet = tb3;
                                vConsumo.FechaAnio = DTPE_FECHACONSUMO.Value.Year.ToString();
                                vConsumo.FechaMes = DTPE_FECHACONSUMO.Value.Month.ToString();
                                vConsumo.tipo = tipo;
                                vConsumo.FechaFinal = DTPE_FECHACONSUMO.Value.ToShortDateString();
                                vConsumo.FechaInicio = DTPE_FECHACONSUMO.Value.AddMonths(-1).ToShortDateString();
                                vConsumo.FechaExcedente = DTPE_FECHACONSUMO.Value.AddMonths(1).ToShortDateString();
                                
                                // vConsumo.FechaInicio = DTPE_FECHACONSUMO.Value.AddMonths(-1).ToString();

                                //Hacer ahora el insert en la tabla de consumos 
                                long num = 0;
                                string numcheck = "";
                                
                                numcheck= dbm.NumeroServicioGET(TXTE_CMEDIDOR.Text);
                                num = Convert.ToInt64(numcheck);
                                //Sacar numero de servicio con el numero de medidor 
                                //  idN = dbm.NumeroServicioGET(TXTE_CMEDIDOR.Text);
                                // Guid g = new Guid(idN); //Convertir ese string en un guid para meter en la tabla 
                                //Insertar para la tabla de recibos 
                                #region before
                                //if (tipo == "Industrial")
                                //{
                                //    int a1 = 0;
                                //    int m1 = 0;
                                //    a1 = Convert.ToInt32(a);
                                //    m1 = Convert.ToInt32(m);
                                //    dbm.InsertConsumoUNIT('S', vConsumo);
                                //    dbm.InsertConsumoUNIT('I', vConsumo);
                                //    if (m1 ==1)
                                //    {
                                //        a1 = a1 - 1;
                                //        m1 = 12;

                                //    }
                                //    m1 = m1 - 1;
                                //    vConsumo.Fecha = DTPE_FECHACONSUMO.Value.AddMonths(-1);
                                //    vConsumo.FechaAnio = a1.ToString();
                                //    vConsumo.FechaMes = m1.ToString();
                                //    dbm.InsertConsumoUNIT('S', vConsumo);
                                //    dbm.InsertConsumoUNIT('I', vConsumo);

                                //}
                                //else
                                //{

                                //}
                                #endregion
                                //int aux = 0;
                                dbm.InsertConsumoUNIT('S', vConsumo);
                                dbm.InsertConsumoUNIT('I', vConsumo);
                                // VARIABLES PARA LLENAR EL RECIBO
                                Recibo_por_Numero_Servicio_Anio_Mes vRecibo = new Recibo_por_Numero_Servicio_Anio_Mes();
                                vRecibo.Consumo = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                vRecibo.Numero_Servicio = num;
                                vRecibo.Fecha = DTPE_FECHACONSUMO.Value;
                                vRecibo.AnioF = DTPE_FECHACONSUMO.Value.Year.ToString();
                                vRecibo.MesF = DTPE_FECHACONSUMO.Value.Month.ToString();
                                vRecibo.FechaF = DTPE_FECHACONSUMO.Value.ToShortDateString();
                                vRecibo.FechaI = DTPE_FECHACONSUMO.Value.AddMonths(-1).ToShortDateString();
                                vRecibo.Dia = DTPE_FECHACONSUMO.Value.Day.ToString();
                                vRecibo.Tipo_Servicio = tipo;
                                vRecibo.Consumo_Basico = bas;
                                vRecibo.Consumo_Intermedio = med;
                                vRecibo.Consumo_Excedente = exp;
                                vRecibo.Tarifa_Basico = tb1;
                                vRecibo.Tarifa_Intermedio = tb2;
                                vRecibo.Tarifa_Excedente = tb3;
                                vRecibo.Cantidad_Pagada = 0;
                                vRecibo.Medidor = Convert.ToInt32(TXTE_CMEDIDOR.Text);
                                //CALCULO DE LOS COBROS 
                                vRecibo.Subtotal_Basico = bas * tb1;
                                vRecibo.Subtotal_Intermedio = med * tb2;
                                vRecibo.Subtotal_Excedente = exp * tb3;
                                vRecibo.Importe = vRecibo.Subtotal_Basico + vRecibo.Subtotal_Intermedio + vRecibo.Subtotal_Excedente;
                                double iva = 0;
                                iva = vRecibo.Importe * .16;
                                vRecibo.Importe_IVA = vRecibo.Importe + iva;
                                vRecibo.Cantidad_Pendiente = vRecibo.Importe_IVA;
                                dbm.Recibo(vRecibo);

                                //LLENAR TABLA PARA CONSUMO HISTORICO 
                                dbm.ConsumoH(num, Convert.ToInt32(TXTE_CMEDIDOR.Text), vRecibo.AnioF,
                                    vRecibo.MesF, vRecibo.Dia, Convert.ToInt32(TXTE_CONSUMOKWH.Text),
                                    vRecibo.Importe_IVA, 0, vRecibo.Cantidad_Pendiente,tipo, vRecibo.FechaF);




                                //
                                TXTE_CMEDIDOR.Text = "";
                                TXTE_CONSUMOKWH.Text = "";
                                MessageBox.Show("Consumo cargado con exito ");
                            }
                            else
                            {
                                TXTE_CMEDIDOR.Text = "";
                                TXTE_CONSUMOKWH.Text = "";
                                MessageBox.Show("No hay tarifas cargadas para esta fecha");
                            }
                        }
                        #region help
                        //bool existe2 = false;
                        //existe2 = dbm.TarifaExistente(tipo, m, a);
                        //if ( existe2 == true)
                        //{
                        //    //Entonces si podremos hacer la carga del consumo 
                        //    //primero hacer una funcion donde saque que tarifas le corresponde segun el año, y mes que se escogio
                        //    //Pondremos que
                        //    //Consumo basico = 150
                        //    //Consumo intermedio = 200 
                        //    //Consumo excedente = pues el sobrante de esto 
                        //    //Calcular consumo basico, intermedio, excedente 
                        //    string tb = "";
                        //    string ti = "";
                        //    string tx = "";
                        //    int Cons = 0;
                        //    int bas = 0;
                        //    int med = 0;
                        //    int exp = 0;
                        //    float tb1 = 0;
                        //    float tb2 = 0;
                        //    float tb3 = 0;
                        //    //Aqui calcular cual sera el consumo basico, intermedio y excedente
                        //    Cons = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                        //    if (Cons >= 150) {
                        //        bas = 150;
                        //        if ( Cons > 150)
                        //        {
                        //            Cons = Cons - 150;
                        //            if ( Cons <= 200)
                        //            {
                        //                med = Cons;
                        //                exp = 0;
                        //            }
                        //            else
                        //            {
                        //                med = 200;
                        //                Cons = Cons - 200;
                        //                exp = Cons;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            med = 0;
                        //            exp = 0;
                        //        }

                        //    }
                        //    else
                        //    {
                        //        bas = Cons;
                        //        med = 0;
                        //        exp = 0;
                        //    }
                        //    //Aqui calcule las tarifas para ese cargo de consumo especifico 
                        //    tb= dbm.TarifasParaConsumo('B', tipo, m, a);
                        //    ti=dbm.TarifasParaConsumo('I', tipo, m, a);
                        //    tx=dbm.TarifasParaConsumo('E', tipo, m, a);
                        //    //convertir tarifas a float 
                        //    tb1 = Convert.ToSingle(tb);
                        //    tb2 = Convert.ToSingle(ti);
                        //    tb3 = Convert.ToSingle(tx);
                        //    //llenar datos finales para insercion 
                        //    Consumo_por_Numero_Medidor_Fecha vConsumo = new Consumo_por_Numero_Medidor_Fecha();
                        //    vConsumo.Numero_Medidor = Convert.ToInt32(TXTE_CMEDIDOR.Text);
                        //    vConsumo.Fecha = DTPE_FECHACONSUMO.Value;
                        //    vConsumo.Consumo = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                        //    vConsumo.Basico = bas;
                        //    vConsumo.Intermedio = med;
                        //    vConsumo.Excedente = exp;
                        //    vConsumo.Empleado_Modificacion = Program.usuarioIng.ToString();
                        //    vConsumo.Basicot = tb1;
                        //    vConsumo.Intermediot = tb2;
                        //    vConsumo.Excedentet = tb3;
                        //    vConsumo.FechaAnio = DTPE_FECHACONSUMO.Value.Year.ToString();
                        //    vConsumo.FechaMes = DTPE_FECHACONSUMO.Value.Month.ToString();
                        //    //Hacer ahora el insert en la tabla de consumos 
                        //    dbm.InsertConsumoUNIT(vConsumo);

                        //    MessageBox.Show("Consumo cargado con exito ");
                        //}
                        //else
                        //{
                        //    MessageBox.Show("No hay tarifas cargadas para esta fecha");
                        //} 
                        #endregion
                    }
                    else
                    {
                        if (exite4 == true)
                        {
                            //si existe entonces que ponga mensaje de que ya hay un consumo 
                            TXTE_CMEDIDOR.Text = "";
                            TXTE_CONSUMOKWH.Text = "";
                            MessageBox.Show("No esta permitido hacer un cargo en la fecha especificada");


                        }
                        else
                        {
                            bool existe2 = false;
                            existe2 = dbm.TarifaExistente(tipo, m, a);
                            if (existe2 == true)
                            {
                                //Entonces si podremos hacer la carga del consumo 
                                //primero hacer una funcion donde saque que tarifas le corresponde segun el año, y mes que se escogio
                                //Pondremos que
                                //Consumo basico = 150
                                //Consumo intermedio = 200 
                                //Consumo excedente = pues el sobrante de esto 
                                //Calcular consumo basico, intermedio, excedente 
                                string tb = "";
                                string ti = "";
                                string tx = "";
                                int Cons = 0;
                                int bas = 0;
                                int med = 0;
                                int exp = 0;
                                float tb1 = 0;
                                float tb2 = 0;
                                float tb3 = 0;
                                //Aqui calcular cual sera el consumo basico, intermedio y excedente
                                Cons = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                if (Cons >= 150)
                                {
                                    bas = 150;
                                    if (Cons > 150)
                                    {
                                        Cons = Cons - 150;
                                        if (Cons <= 200)
                                        {
                                            med = Cons;
                                            exp = 0;
                                        }
                                        else
                                        {
                                            med = 200;
                                            Cons = Cons - 200;
                                            exp = Cons;
                                        }
                                    }
                                    else
                                    {
                                        med = 0;
                                        exp = 0;
                                    }

                                }
                                else
                                {
                                    bas = Cons;
                                    med = 0;
                                    exp = 0;
                                }
                                //Aqui calcule las tarifas para ese cargo de consumo especifico 
                                tb = dbm.TarifasParaConsumo('B', tipo, m, a);
                                ti = dbm.TarifasParaConsumo('I', tipo, m, a);
                                tx = dbm.TarifasParaConsumo('E', tipo, m, a);
                                //convertir tarifas a float 
                                tb1 = Convert.ToSingle(tb);
                                tb2 = Convert.ToSingle(ti);
                                tb3 = Convert.ToSingle(tx);
                                //llenar datos finales para insercion 
                                Consumo_por_Numero_Medidor_Fecha vConsumo = new Consumo_por_Numero_Medidor_Fecha();
                                vConsumo.Numero_Medidor = Convert.ToInt32(TXTE_CMEDIDOR.Text);
                                vConsumo.Fecha = DTPE_FECHACONSUMO.Value;
                                vConsumo.Consumo = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                vConsumo.Basico = bas;
                                vConsumo.Intermedio = med;
                                vConsumo.Excedente = exp;
                                vConsumo.Empleado_Modificacion = Program.usuarioIng.ToString();
                                vConsumo.Basicot = tb1;
                                vConsumo.Intermediot = tb2;
                                vConsumo.Excedentet = tb3;
                                vConsumo.FechaAnio = DTPE_FECHACONSUMO.Value.Year.ToString();
                                vConsumo.FechaMes = DTPE_FECHACONSUMO.Value.Month.ToString();
                                vConsumo.tipo = tipo;
                                vConsumo.FechaFinal = DTPE_FECHACONSUMO.Value.ToShortDateString();
                                vConsumo.FechaInicio = DTPE_FECHACONSUMO.Value.AddMonths(-2).ToShortDateString();
                                vConsumo.FechaExcedente = DTPE_FECHACONSUMO.Value.AddMonths(2).ToShortDateString();
                                // vConsumo.FechaInicio = DTPE_FECHACONSUMO.Value.AddMonths(-1).ToString();

                                //Hacer ahora el insert en la tabla de consumos 
                                string idN = "";
                                long num = 0;
                                string numcheck = "";

                                numcheck = dbm.NumeroServicioGET(TXTE_CMEDIDOR.Text);
                                num = Convert.ToInt64(numcheck);
                                //Sacar numero de servicio con el numero de medidor 
                                //idN = dbm.NumeroServicioGET(TXTE_CMEDIDOR.Text);
                                //Guid g = new Guid(idN); //Convertir ese string en un guid para meter en la tabla 
                                //Insertar para la tabla de recibos 
                                Recibo_por_Numero_Servicio_Anio_Mes vRecibo = new Recibo_por_Numero_Servicio_Anio_Mes();
                                vRecibo.Consumo = Convert.ToInt32(TXTE_CONSUMOKWH.Text);
                                vRecibo.Numero_Servicio = num;
                                vRecibo.Fecha = DTPE_FECHACONSUMO.Value;
                                vRecibo.AnioF = DTPE_FECHACONSUMO.Value.Year.ToString();
                                vRecibo.MesF = DTPE_FECHACONSUMO.Value.Month.ToString();
                                vRecibo.Dia = DTPE_FECHACONSUMO.Value.Day.ToString();
                                vRecibo.FechaF = DTPE_FECHACONSUMO.Value.ToShortDateString();
                                vRecibo.FechaI = DTPE_FECHACONSUMO.Value.AddMonths(-2).ToShortDateString();
                                vRecibo.Tipo_Servicio = tipo;
                                vRecibo.Consumo_Basico = bas;
                                vRecibo.Consumo_Intermedio = med;
                                vRecibo.Consumo_Excedente = exp;
                                vRecibo.Tarifa_Basico = tb1;
                                vRecibo.Tarifa_Intermedio = tb2;
                                vRecibo.Tarifa_Excedente = tb3;
                                vRecibo.Cantidad_Pagada = 0;
                                vRecibo.Medidor = Convert.ToInt32(TXTE_CMEDIDOR.Text);
                                //CALCULO DE LOS COBROS 
                                vRecibo.Subtotal_Basico = bas * tb1;
                                vRecibo.Subtotal_Intermedio = med * tb2;
                                vRecibo.Subtotal_Excedente = exp * tb3;
                                vRecibo.Importe = vRecibo.Subtotal_Basico + vRecibo.Subtotal_Intermedio + vRecibo.Subtotal_Excedente;
                                double iva = 0;
                                iva = vRecibo.Importe * .16;
                                vRecibo.Importe_IVA = vRecibo.Importe + iva;
                                vRecibo.Cantidad_Pendiente = vRecibo.Importe_IVA;

                                //LLENAR TABLA PARA CONSUMO HISTORICO 
                                dbm.ConsumoH(num, Convert.ToInt32(TXTE_CMEDIDOR.Text), vRecibo.AnioF,
                                     vRecibo.MesF, vRecibo.Dia, Convert.ToInt32(TXTE_CONSUMOKWH.Text),
                                     vRecibo.Importe_IVA, 0, vRecibo.Cantidad_Pendiente, tipo, vRecibo.FechaF);


                                dbm.Recibo(vRecibo);

                                dbm.InsertConsumoUNIT('S', vConsumo);
                                dbm.InsertConsumoUNIT('I', vConsumo);

                                TXTE_CMEDIDOR.Text = "";
                                TXTE_CONSUMOKWH.Text = "";
                                MessageBox.Show("Consumo cargado con exito ");
                            }
                            else
                            {
                                TXTE_CMEDIDOR.Text = "";
                                TXTE_CONSUMOKWH.Text = "";
                                MessageBox.Show("No hay tarifas cargadas para esta fecha");
                            }
                        }
                    }
                    
                }
                else
                {
                    TXTE_CMEDIDOR.Text = "";
                    TXTE_CONSUMOKWH.Text = "";
                    MessageBox.Show("No hay contrato con este medidor ");
                }
            }
        }

        private void Consultar_Tarifa_Click(object sender, EventArgs e)
        {
            bool existe = false;
            string anio = "";
            anio = dateTimePicker3.Value.Year.ToString();
            //Hacer un select para ver si existen tarifas cargadas para el año que se pide 
            DataBaseManager dbm = DataBaseManager.getInstance();
            existe = dbm.TarifaPorAnio(anio);
            if (existe == true)
            {
                //Entonces hacer el despliegue de los datos en esta parte
                List<Tarifa_por_Anio> Tarifas = new List<Tarifa_por_Anio>();
                Tarifas = dbm.AllTarifas(anio);
                DGVE_REPORTET.DataSource = Tarifas;

            }
            else
            {
                
                MessageBox.Show("No existen tarifas cargadas en el año de "+ anio + " " );

            }
        }

        private void Consultar_Consumo_Click(object sender, EventArgs e)
        {
            //Checar si existen consumos cargados en ese año 
            bool existe = false;
            string anio = "";
            anio = dateTimePicker4.Value.Year.ToString();
            DataBaseManager dbm = DataBaseManager.getInstance();
            existe = dbm.ConsumoPorAnio(anio);
            if ( existe == true)
            {
                //Hacer despliegue de los datos en el datagriew
                List<Reporte_Consumos> Consumos = new List<Reporte_Consumos>();
                Consumos = dbm.AllConsumos(anio);
                DGVE_REPORTEC.DataSource = Consumos;
            }
            else
            {
                MessageBox.Show("No existen consumos cargados en el año de " + anio + " ");
            }

        }

        private void BTNE_RCARGA_Click(object sender, EventArgs e)
        {
            bool existe = false;
            bool existe2 = false;
            string anio = "";
            string mes = "";
            int anio1 = 0;
            int mes2 = 0;
            anio = dateTimePicker5.Value.Year.ToString();
            mes = dateTimePicker6.Value.Month.ToString();
            anio1 = Convert.ToInt32(anio);
            mes2 = Convert.ToInt32(mes);
            DataBaseManager dbm = DataBaseManager.getInstance();
            #region before
            //debo de checar tambien si ya se generaron los recibos para este periodo 
            //if (CMBE_RTIPOS.Text == "Industrial")
            //{
            //    if (mes2 == 1)
            //    {
            //        anio1 = anio1 - 1;
            //        mes2 = 12;
            //    }
            //    else
            //    {
            //        mes2 = mes2 - 1;
            //    }

            //    existe2 = dbm.ConsumosParaRecibo('I', anio1.ToString(), mes2.ToString(), CMBE_RTIPOS.Text);
            //    existe = dbm.ConsumosParaRecibo('I', anio, mes, CMBE_RTIPOS.Text);

            //    if (existe == true && existe2 == true)
            //    {
            //        MessageBox.Show("Si hay consumos para generar el recibo industrial ");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No hay consumos para generar el recibo industrial ");
            //    }
            //}
            //else if (CMBE_RTIPOS.Text =="Domiciliar")
            //{
            //    if (mes2 != 1 && mes2 != 2)
            //    {
            //        mes2 = mes2 - 2;
            //    }
            //    if (mes2== 1)
            //    {
            //        anio1 = anio1 - 1;
            //        mes2 = 11;
            //    }
            //    if(mes2 == 2)
            //    {
            //        anio1 = anio1 - 1;
            //        mes2 = 12;

            //    }

            //    existe2 = dbm.ConsumosParaRecibo('I', anio1.ToString(), mes2.ToString(), CMBE_RTIPOS.Text);
            //    existe = dbm.ConsumosParaRecibo('I', anio, mes, CMBE_RTIPOS.Text);
            //    if (existe == true && existe2 == true)
            //    {
            //        MessageBox.Show("Si hay consumos para generar el recibo domiciliar ");
            //    }
            //    else
            //    {
            //        MessageBox.Show("No hay consumos para generar el recibo domiciliar ");
            //    }


            //}
            #endregion
            //Checar que existan recibos con fecha final en ese año y mes 
            //Despues ahora si a los recibos en ese periodo seleccionado, cambiarles el valor de generado a verdadero
            existe = dbm.ReciboExistente(anio, mes, CMBE_RTIPOS.Text);
            if (existe == true)
            {
                MessageBox.Show("Recibos Cargados");
                //Hacer un update para actualizar el estado de generado a no generado 
                dbm.ActivarRecibos(anio, mes, CMBE_RTIPOS.Text);
                dbm.ActivarConsumoH(anio, mes, CMBE_RTIPOS.Text);
            }
            else
            {
                MessageBox.Show("No hay consumos para generar los recibos de la fecha indicada");
            }

        }

        private void BTNE_CHVISUALIZAR_Click(object sender, EventArgs e)
        {
            //PRIMERO VERIFICAR QUE EXISTAN RECIBOS GENERADOS EN ESE AÑO
            //checar que si ingrese cosas
            DataBaseManager dbm = DataBaseManager.getInstance();
            

            if (string.IsNullOrEmpty(textBox21.Text) && string.IsNullOrEmpty(textBox22.Text))
            {
                MessageBox.Show("Faltan campos a llenar para hacer la consulta");
            }
            else 
            {
                //este es el caso de que se busque por numero de servicio
                if (string.IsNullOrEmpty(textBox21.Text) )
                {
                    string anio = "";
                    int servicio = 0;
                    bool existe = false;
                    bool existeS = false;
                    servicio = Convert.ToInt32(textBox22.Text);
                    anio = dateTimePicker7.Value.Year.ToString();
                    existeS = dbm.NumSerExistente(servicio);
                    if (existeS == true)
                    {
                        existe = dbm.ConsumoHistoricoExistente('S', anio, 0, servicio);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si tiene consumos en este año");
                            ///Llenar datagriew con informacion de la tabla de consumosH
                            ///
                            List<ConsumoH> CH = new List<ConsumoH>();
                            CH = dbm.AllConsumosS(anio, servicio);
                            DGVE_REPORTECH.DataSource = CH;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene consumos en este año");
                            DGVE_REPORTECH.DataSource = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe el numero de servicio ingresado");
                    }
                   
                }
                else
                {
                    bool existeM = false;
                    string anio = "";
                    int medidor = 0;
                    bool existe = false;

                    medidor = Convert.ToInt32(textBox21.Text);
                    anio = dateTimePicker7.Value.Year.ToString();
                    existeM = dbm.MedidorExistente(textBox21.Text);
                    if (existeM == true)
                    {
                        existe = dbm.ConsumoHistoricoExistente('M', anio, medidor, 0);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si tiene consumos en este año");
                            List<ConsumoH> CH = new List<ConsumoH>();
                            CH = dbm.AllConsumosM(anio, medidor);
                            DGVE_REPORTECH.DataSource = CH;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene consumos en este año");
                            DGVE_REPORTECH.DataSource = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("No existe el medidor ingresado");
                    }
                    
                    //este es el caso de que se busque por medidor
                }
            }
            
        }

        private void BTNE_VISUALIZAR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMBE_RGTIPOS.Text))
            {
                MessageBox.Show("Faltan campos a llenar para hacer la consulta");
            }
            else
            {
                bool existe = false;
                string anio = "";
                string mes = "";
                anio = anioRGDT.Value.Year.ToString();
                mes = dateTimePicker9.Value.Month.ToString();
                DataBaseManager dbm = DataBaseManager.getInstance();
                existe = dbm.ReciboRGExistente(anio, mes, CMBE_RGTIPOS.Text);

                if (existe == true)
                {
                    MessageBox.Show("Si existen recibos generados");
                    //Llenar el datagriew con todos los datos 
                    List<Recibo_por_Numero_Servicio_Anio_Mes> Recibos = new List<Recibo_por_Numero_Servicio_Anio_Mes>();
                    Recibos = dbm.AllRecibosRG(anio, mes, CMBE_RGTIPOS.Text);
                    DGVE_REPORTEG.DataSource = Recibos;

                }
                else
                {
                    MessageBox.Show("Aun no hay recibos generados");
                }

            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {
        }

        private void BTNE_GENERARPDF_Click(object sender, EventArgs e)
        {
            //Checar si existe el recibo a consultar en el año, fecha, numero, servicio indicados
            DataBaseManager dbm = DataBaseManager.getInstance();


            if (string.IsNullOrEmpty(textBox23.Text) && string.IsNullOrEmpty(textBox24.Text))
            {
                MessageBox.Show("Faltan campos a llenar para hacer el recibo");
            }
            else
            {
                //caso para checarlo con el numero de servicio 
                if (string.IsNullOrEmpty(textBox24.Text))
                {
                    string anio = "";
                    string mes = "";
                    int servicio = 0;
                    bool existe = false;
                    bool existeS = false;
                    servicio = Convert.ToInt32(textBox23.Text);
                    anio = dateTimePicker8.Value.Year.ToString();
                    mes = dateTimePicker10.Value.Month.ToString();
                    existeS = dbm.NumSerExistente(servicio);
                    if (existeS == true)
                    {
                        existe = dbm.ReciboPDF('S', anio, mes, 0, servicio);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si tiene recibos en la fecha indicada");
                            ///Llenar datagriew con informacion de la tabla de consumosH
                            ///
                            List<ConsumoH> CH = new List<ConsumoH>();
                            CH = dbm.AllConsumosS(anio, servicio);
                            DGVE_REPORTECH.DataSource = CH;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene recibos en la fecha indicada");
                            DGVE_REPORTECH.DataSource = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("No existe el numero de servicio ingresado");
                    }

                }
                else
                {
                    //caso de generarlo con el medidor
                    bool existeM = false;
                    string anio = "";
                    string mes = "";
                    int medidor = 0;
                    bool existe = false;

                    medidor = Convert.ToInt32(textBox24.Text);
                    anio = dateTimePicker8.Value.Year.ToString();
                    mes = dateTimePicker10.Value.Month.ToString();
                    existeM = dbm.MedidorExistente(textBox24.Text);
                    if (existeM == true)
                    {
                        existe = dbm.ReciboPDF('M', anio, mes, medidor, 0);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si recibos en la fecha indicada");
                            List<ConsumoH> CH = new List<ConsumoH>();
                            CH = dbm.AllConsumosM(anio, medidor);
                            DGVE_REPORTECH.DataSource = CH;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene recibos en la fecha indicada");
                            DGVE_REPORTECH.DataSource = "";
                        }

                    }
                    else
                    {
                        MessageBox.Show("No existe el medidor ingresado");
                    }
                }
            }

        }
    }
}