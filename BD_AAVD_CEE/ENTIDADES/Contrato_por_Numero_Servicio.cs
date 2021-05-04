using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Contrato_por_Numero_Servicio
    {
        public int Numero_Servicio { get; set; }
        public int Numero_Medidor { get; set; }
        public string Tipo_Servicio { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public int CP { get; set; }
        public int Numero_Exterior { get; set; }
        public int Id_Cliente { get; set; }
        public string Empleado_Modificacion { get; set; }

    }
}
