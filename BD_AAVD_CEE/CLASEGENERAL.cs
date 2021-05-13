using BD_AAVD_CEE.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BD_AAVD_CEE
{
    class CLASEGENERAL
    {

        static public void ActualizarCombo(ComboBox comboboxActualizar, List<Empleado_por_Id_Empleado> listaEmpleados, string text= "")
        {
            comboboxActualizar.DataSource = null;
            comboboxActualizar.Items.Clear();

            if (text != "")
            {
                Empleado_por_Id_Empleado firstvalue = new Empleado_por_Id_Empleado(text);
                comboboxActualizar.Items.Add(firstvalue);
            }

            for (int i=0; i< listaEmpleados.Count; i++)
            {
                comboboxActualizar.Items.Add(listaEmpleados[i]);
            }
        }

        
      
        
        
    }
}
