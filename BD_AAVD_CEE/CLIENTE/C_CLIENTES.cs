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

namespace BD_MAD_CEE.CLIENTE
{
    public partial class C_CLIENTES : Form
    {
        public C_CLIENTES()
        {
            InitializeComponent();
            anioCC.Format = DateTimePickerFormat.Custom;
            anioCC.CustomFormat = "yyyy";
            anioCC.ShowUpDown = true;
            mesCC.Format = DateTimePickerFormat.Custom;
            mesCC.CustomFormat = "M";
            mesCC.ShowUpDown = true;
            anioCHH.Format = DateTimePickerFormat.Custom;
            anioCHH.CustomFormat = "yyyy";
            anioCHH.ShowUpDown = true;

            anioPR.Format = DateTimePickerFormat.Custom;
            anioPR.CustomFormat = "yyyy";
            anioPR.ShowUpDown = true;
            mesPR.Format = DateTimePickerFormat.Custom;
            mesPR.CustomFormat = "M";
            mesPR.ShowUpDown = true;

        }

        private void BTNC_PDF_Click(object sender, EventArgs e)
        {
            //checar que el servicio que escogio con la fecha seleccionada si exista
            DataBaseManager dbm = DataBaseManager.getInstance();
            bool existe = false;
            string anio = "";
            string mes = "";
            int servicio = 0;
            servicio = Convert.ToInt32(CMBC_SERVICIOS.Text);
            anio = anioCC.Value.Year.ToString();
            mes = mesCC.Value.Month.ToString();
            existe = dbm.ReciboPDFCLIENTES(servicio, anio, mes);
            if (existe == true)
            {
                MessageBox.Show("Recibo listo para generar");
            }
            else
            {
                MessageBox.Show("No hay recibos en la fecha indicada");
            }

        }

        private void C_CLIENTES_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void C_CLIENTES_Load(object sender, EventArgs e)
        {
            //Tengo que actualizar el combobox de los servicios contratados
            //para hacer esto debo de cargar solo los servicios que tengan recibo con la condicion generado
            DataBaseManager dbm = DataBaseManager.getInstance();
            Recibo_por_Numero_Servicio_Anio_Mes vRecibo = new Recibo_por_Numero_Servicio_Anio_Mes();
            vRecibo.Usuario = Program.usuarioIng.ToString();
            List<Recibo_por_Numero_Servicio_Anio_Mes> listaServicios = dbm.ObtenerServicios(vRecibo).ToList();
            CLASEGENERAL.ComboServicios(CMBC_SERVICIOS, listaServicios);
            CLASEGENERAL.ComboServicios(CMBC_PSERVICIOS, listaServicios);

        }

        private void CMBC_PSERVICIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void BTNC_PAGAR_Click(object sender, EventArgs e)
        {

            if (BTNC_PAGAR.Enabled == true)
            {
                //entonces que nos deje hacer el pago y hacer las verificaciones pendientes 
                if (string.IsNullOrEmpty(CMBC_FORMA.Text) || string.IsNullOrEmpty(TEXTC_CANTP.Text))
                {
                    MessageBox.Show("Favor de llenar los campos necesarios para hacer el pago");
                }
                else
                {
                    float pagopendiente = 0;
                    float pagodelcliente = 0;
                    string pago = "";
                    string pendiente = "";
                    pago = TEXTC_CANTP.Text;
                    pagodelcliente = Convert.ToSingle(pago);
                    pendiente = TEXTC_TOTAL.Text;
                    pagopendiente = Convert.ToSingle(pendiente);
                     if (pagodelcliente > pagopendiente)
                    {
                        MessageBox.Show("Favor de verificar bien el pago pendiente");
                    }
                    else
                    {
                        //checar que si el pago del cliente es igual al pago pendiente, marcar que el estatus es pagado
                        //si no, seguir marcando que esta pendiente
                        //tambien hacer el update en la tabla de recibos 

                        //CALCULO DE PAGO PENDIENTE QUE QUED
                        DataBaseManager dbm = DataBaseManager.getInstance();
                        string cant = "";
                        string anio = "";
                        string mes = "";
                        int servicio = 0;
                        bool pagos = false;
                        servicio = Convert.ToInt32(CMBC_PSERVICIOS.Text);
                        anio = anioPR.Value.Year.ToString();
                        mes = mesPR.Value.Month.ToString();
                        cant = dbm.CANTIDADPAGADA(servicio, anio, mes);
                        float cant2 = 0;
                        cant2 = Convert.ToSingle(cant);
                        float pcliente = 0;
                        pcliente = cant2 + pagodelcliente;
                        //CALCULO DE TOTAL PENDIENTE A PAGAR 
                        float cantidadTOTAL = 0;
                        cantidadTOTAL = pagopendiente - pagodelcliente;
                        //CALCULOS HASTA AQUI
                         

                        if (TEXTC_TOTAL.Text == TEXTC_CANTP.Text)
                        {
                            //significa que el recibo ya fue cobrado totalmente 
                            //cambiar lo de el estatus a pagado 
                            pagos = true;
                        }
                        //HACER EL UPDATE DE LA INFO 
                        dbm.UPDATEPAGO(servicio, anio, mes, "",cantidadTOTAL, pcliente, pagos);
                        //CMBC_PSERVICIOS.SelectedIndex = -1;
                        CMBC_PSERVICIOS.Text = "";
                        CMBC_FORMA.Text = "";
                        TEXTC_TOTAL.Text = "";
                        TEXTC_CANTP.Text = "";
                        TEXTC_ESTATUS.Text = "";
                        BTNC_PAGAR.Enabled = false;
                        MessageBox.Show("Pago realizado");
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CMBC_PSERVICIOS.Text))
            {
                MessageBox.Show("Faltan campos a llenar ");
                // checar si hay recibos con esa fecha para pagar o ver su estado 
                DataBaseManager dbm = DataBaseManager.getInstance();
                bool existe = false;
                string anio = "";
                string mes = "";
                int servicio = 0;
                servicio = Convert.ToInt32(CMBC_PSERVICIOS.Text);
                anio = anioPR.Value.Year.ToString();
                mes = mesPR.Value.Month.ToString();
                

            }
            else
            {
                //checar si existe un recibo generado 
                DataBaseManager dbm = DataBaseManager.getInstance();
                bool existe = false;
                string anio = "";
                string mes = "";
                int servicio = 0;
                servicio = Convert.ToInt32(CMBC_PSERVICIOS.Text);
                anio = anioPR.Value.Year.ToString();
                mes = mesPR.Value.Month.ToString();
                existe = dbm.ReciboPDFCLIENTES(servicio, anio, mes);
                if (existe == true)
                {
                    MessageBox.Show("Campos habilitados para pagar el servicio");
                    // hacer un select del total a pagar y el estatus de pago 
                    TEXTC_TOTAL.Text = dbm.TotalAPagar(servicio, anio, mes);
                    string pago = "";
                    pago=dbm.Estatus(servicio, anio, mes);

                    if ( pago == "True")
                    {
                        TEXTC_ESTATUS.Text = "Pagado";
                        BTNC_PAGAR.Enabled = false;
                    }
                    else
                    {
                        TEXTC_ESTATUS.Text = "Pendiente";
                        BTNC_PAGAR.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("No hay recibos para consultar en la fecha indicada");

                }
            }
        }

        private void CMBC_CHVISUAL_Click(object sender, EventArgs e)
        {
            DataBaseManager dbm = DataBaseManager.getInstance();


            if (string.IsNullOrEmpty(CMBC_CHMEDIDOR.Text) && string.IsNullOrEmpty(CMBC_CHSERVICIO.Text))
            {
                MessageBox.Show("Faltan campos a llenar para hacer la consulta");
            }
            else
            {
                //este es el caso de que se busque por numero de servicio
                if (string.IsNullOrEmpty(CMBC_CHMEDIDOR.Text))
                {
                    string anio = "";
                    int servicio = 0;
                    bool existe = false;
                    bool existeS = false;
                    servicio = Convert.ToInt32(CMBC_CHSERVICIO.Text);
                    anio = anioCHH.Value.Year.ToString();
                    existeS = dbm.NumSerExistente(servicio);
                    if (existeS == true)
                    {
                        existe = dbm.ConsumoHistoricoExistente('S', anio, 0, servicio);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si tiene consumos en este año");
                            ///Llenar datagriew con informacion de la tabla de consumosH
                            ///
                            List<CH> CH2 = new List<CH>();
                            CH2 = dbm.AllConsumosS(anio, servicio);
                            DTG_CONSUMOH.DataSource = CH2;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene consumos en este año");
                            DTG_CONSUMOH.DataSource = "";
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

                    medidor = Convert.ToInt32(CMBC_CHMEDIDOR.Text);
                    anio = anioCHH.Value.Year.ToString();
                    existeM = dbm.MedidorExistente(CMBC_CHMEDIDOR.Text);
                    if (existeM == true)
                    {
                        existe = dbm.ConsumoHistoricoExistente('M', anio, medidor, 0);
                        if (existe == true)
                        {
                            MessageBox.Show("El cliente si tiene consumos en este año");
                            List<CH> CH = new List<CH>();
                            CH = dbm.AllConsumosM(anio, medidor);
                            DTG_CONSUMOH.DataSource = CH;
                        }
                        else
                        {
                            MessageBox.Show("El cliente no tiene consumos en este año");
                            DTG_CONSUMOH.DataSource = "";
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

        private void BTN_MASIVO_Click(object sender, EventArgs e)
        {
            //Hacer el update de la tabla 
            DataBaseManager dbm = DataBaseManager.getInstance();
            dbm.UPDATEPAGOMASIVO();
            MessageBox.Show("Pago masivo realizado");
        }
    }
}
