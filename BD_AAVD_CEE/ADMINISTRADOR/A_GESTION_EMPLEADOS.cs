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

            //LLENAR CAMPOS 
            #region Llenar Campos
            BD_AAVD_CEE.ENTIDADES.Empleado_por_Id_Empleado vEmpleado = new BD_AAVD_CEE.ENTIDADES.Empleado_por_Id_Empleado();
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




        }
    }
}
