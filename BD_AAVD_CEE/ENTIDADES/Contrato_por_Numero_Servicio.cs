using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Contrato_por_Numero_Servicio
    {
        public Guid Numero_Servicio { get; set; }
        public long NumSer { get; set; }
        public int Numero_Medidor { get; set; }
        public string Tipo_Servicio { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Calle { get; set; }
        public string CP { get; set; }
        public int Numero_Exterior { get; set; }
        public long Id_Cliente { get; set; }
        public string Empleado_Modificacion { get; set; }

    }
}
