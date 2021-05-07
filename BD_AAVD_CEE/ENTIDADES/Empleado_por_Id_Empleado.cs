using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Empleado_por_Id_Empleado
    {
        public Guid Id_Empleado { get; set; }
        public string CURP { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public IEnumerable<LocalDate> Fecha_Modificacion { get; set; }

        //no estoy segura de porque agregar asi la fecha pero por mientras:
        public LocalDate Fecha_Nacimiento_C { get; set; }
        public LocalDate Fecha_AltaC { get; set; }


    }
}
