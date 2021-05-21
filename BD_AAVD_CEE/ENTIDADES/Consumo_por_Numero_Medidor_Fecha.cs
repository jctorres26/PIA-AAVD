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
        public DateTime Fecha { get; set; }
        public int Consumo { get; set; }
        public int Basico { get; set; }
        public int Intermedio { get; set; }
        public int Excedente { get; set; }
        public string Empleado_Modificacion { get; set; }
        public float Basicot { get; set; }
        public float Intermediot { get; set; }
        public float Excedentet { get; set; }
        public string FechaAnio { get; set; }
        public string FechaMes { get; set; }
        public string tipo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string FechaExcedente { get; set; }
        public LocalDate FechaC { get; set; }
        public void ActualizarFechaCQLC()
        {
            try
            {
                if (FechaC != null)
                {
                    Fecha = new DateTime(FechaC.Year,FechaC.Month, FechaC.Day);
                }
              

            }
            catch (Exception)
            {

            }
        }
    }
}
