using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Consumo_por_Numero_Medidor_Fecha
    {
        public int Numero_Medidor { get; set; }
        public LocalDate Fecha { get; set; }
        public int Consumo { get; set; }
        public int Basico { get; set; }
        public int Intermedio { get; set; }
        public int Excedente { get; set; }
        public string Empleado_Modificacion { get; set; }

    }
}
