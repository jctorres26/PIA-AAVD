using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Cliente_por_Id_Cliente
    {
        public Guid Id_Cliente { get; set; }
        public string CURP { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public DateTime Fecha_Nacimiento { get; set; } //porque aqui es string la fecha??
        public string Genero { get; set; }
        public IEnumerable <string> Email { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasenia { get; set; }
        public bool Activo { get; set; }
        public LocalDate Fecha_Alta { get; set; }
        public LocalDate Fecha_Modificacion { get; set; }
        public string Empleado_Modificacion { get; set; }

        public LocalDate FN { get; set; }

    }
}
