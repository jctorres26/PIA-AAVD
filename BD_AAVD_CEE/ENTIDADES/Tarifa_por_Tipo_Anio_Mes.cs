using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Tarifa_por_Tipo_Anio_Mes
    {
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string Tipo_Servicio { get; set; }
        public float Basico { get; set; }
        public float Intermedio { get; set; }
        public float Excedente { get; set; }
        public string Empleado_Modificacion { get; set; }

    }
}
