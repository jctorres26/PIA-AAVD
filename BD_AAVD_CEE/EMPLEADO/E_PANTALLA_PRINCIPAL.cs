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
        //private void BTNC_EMAIL_Click(object sender, EventArgs e)
        //{
        //    IEnumerable<string> items = new string[] { (TXTE_EMAIL.Text) };
        //    items = items.Concat(new[] { (TXTE_EMAIL.Text) });

        //    Cliente_por_Id_Cliente vCliente = new Cliente_por_Id_Cliente();
        //    vCliente.Email = items;

        //}

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
                    dbm.InserTarifaUNIT(CMBE_TCSERVICIO.Text, dateTimePicker2.Text, dateTimePicker1.Text, b, i, ex, emp);
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
                    
                    //Esta checando que exista una tarifa cargada para ese mes, donde cheque si para el numero de medidor,
                    //con su numero de medidor, mes, año  hay algo cargado 
                    //Sacar del select el año, mes 
                    a = DTPE_FECHACONSUMO.Value.Year.ToString();
                    m = DTPE_FECHACONSUMO.Value.Month.ToString();
                    existe3 = dbm.ConsumoExistente(TXTE_CMEDIDOR.Text, a, m);
                    if (existe3 == true)
                    {
                        //si existe entonces que ponga mensaje de que ya hay un consumo 
                        MessageBox.Show("Ya existe un cargo de consumo en esta fecha");


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
                            //Hacer ahora el insert en la tabla de consumos 
                            dbm.InsertConsumoUNIT(vConsumo);

                            MessageBox.Show("Consumo cargado con exito ");
                        }
                        else
                        {
                            MessageBox.Show("No hay tarifas cargadas para esta fecha");
                        }
                    }

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

                }
                else
                {
                    MessageBox.Show("No hay contrato con este medidor ");
                }
            }
        }
    }
}