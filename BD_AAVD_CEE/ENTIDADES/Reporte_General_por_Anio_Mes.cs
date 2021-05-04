using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Reporte_General_por_Anio_Mes
    {
        public string Anio { get; set; }
        public string Mes { get; set; }
        public string Tipo_Servicio { get; set; }
        public float Total_Pagado { get; set; }
        public float Pendiente_Pago { get; set; }

    }
}
