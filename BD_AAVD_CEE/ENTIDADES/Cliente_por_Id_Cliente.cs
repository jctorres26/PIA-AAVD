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

        public Cliente_por_Id_Cliente(string nombreDefault)
        {
            this.Nombre = nombreDefault;
        }


        public long Id_Cliente { get; set; }
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
        public DateTime Fecha_Alta { get; set; }
        public LocalDate Fecha_Modificacion { get; set; }
        public string Empleado_Modificacion { get; set; }

        public LocalDate FN { get; set; }
        public LocalDate FA { get; set; }

        public Cliente_por_Id_Cliente(Cliente_por_Id_Cliente vCliente)
        {
            this.Nombre = vCliente.Nombre;
            this.Id_Cliente = vCliente.Id_Cliente;
        }

        public Cliente_por_Id_Cliente()
        {
        }

        public override string ToString()
        {
            return this.Nombre + " " + this.Apellido_Paterno + " " + this.Apellido_Materno;
        }

        public void ActualizarFechaCQLC()
        {
            try
            {
                if (FN != null)
                {
                    Fecha_Nacimiento = new DateTime(FN.Year, FN.Month, FN.Day);
                }
                if (FA != null)
                {
                    Fecha_Alta = new DateTime(FA.Year, FA.Month, FA.Day);
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
