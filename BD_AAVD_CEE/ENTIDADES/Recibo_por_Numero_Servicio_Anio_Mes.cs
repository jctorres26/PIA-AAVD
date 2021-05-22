using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Recibo_por_Numero_Servicio_Anio_Mes
    {
        public long Numero_Servicio { get; set; }
        public string AnioF { get; set; }
        public string MesF { get; set; }
        public DateTime Fecha { get; set; }
        public string FechaF { get; set; }
        public string FechaI { get; set; }
        public string Tipo_Servicio { get; set; }
        public int Consumo { get; set; }
        public int Consumo_Basico { get; set; }
        public int Consumo_Intermedio { get; set; }
        public int Consumo_Excedente { get; set; }
        public float Tarifa_Basico { get; set; }
        public float Tarifa_Intermedio { get; set; }
        public float Tarifa_Excedente { get; set; }
        public float Subtotal_Basico { get; set; }
        public float Subtotal_Intermedio { get; set; }
        public float Subtotal_Excedente { get; set; }
        public bool Is_Paid { get; set; }
        public float Importe { get; set; }
        public double Importe_IVA { get; set; }
        public float Cantidad_Pagada { get; set; }
        public double Cantidad_Pendiente { get; set; }
        public bool Recibo_Generado { get; set; }
        public int Medidor { get; set; }
        public string Dia { get; set; }

    }
}
