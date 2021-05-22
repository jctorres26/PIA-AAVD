using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class ConsumoH
    {
        //public long Numero_Servicio { get; set; }
        //public int Medidor { get; set; }
       // public string AnioF { get; set; }
        public string Fecha { get; set; }
       // public string Dia { get; set; }
        public int Consumo { get; set; }
        public double Importe_IVA { get; set; }
        public float Cantidad_Pagada { get; set; }
        public double Cantidad_Pendiente { get; set; }
    }
}
