using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Consumo_Historico_por_Anio_Numero_Medidor
    {
        public string Anio { get; set; }
        public int Numero_Medidor { get; set; }
        public string Mes { get; set; }
        public int Consumo { get; set; }
        public float Importe { get; set; }
        public float Pagado { get; set; }
        public float Pendiente_Pago { get; set; }

    }
}
