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
            this.Hide();
            //BD_MAD_CEE.ADMINISTRADOR.A_GESTION_EMPLEADOS fmr = new ADMINISTRADOR.A_GESTION_EMPLEADOS();
            BD_MAD_CEE.EMPLEADO.E_PANTALLA_PRINCIPAL fmr = new EMPLEADO.E_PANTALLA_PRINCIPAL();
            fmr.Show();



        }
    }
}
