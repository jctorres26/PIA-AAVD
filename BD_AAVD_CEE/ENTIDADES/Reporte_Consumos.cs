using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Reporte_Consumos
    {
        public string Anio { get; set; }
        public string Mes { get; set; }
        public int Numero_Medidor { get; set; }
        public int Basico { get; set; }
        public int Intermedio { get; set; }
        public int Excedente { get; set; }

    }
}
