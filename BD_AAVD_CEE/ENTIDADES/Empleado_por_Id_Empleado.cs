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
       

        public Empleado_por_Id_Empleado(string nombreDefault)
        {
            this.Nombre = nombreDefault;
        }

        public Guid Id_Empleado { get; set; }
        public String Id_EmpleadoC { get; set; }
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
        public IEnumerable<DateTime> Fecha_Modificacion { get; set; }
        public bool UsuarioACT { get; set; }
        public int Empleado { get; set; }
        //no estoy segura de porque agregar asi la fecha pero por mientras:
        public LocalDate Fecha_Nacimiento_C { get; set; }
        public LocalDate Fecha_AltaC { get; set; }
        public LocalDate Fecha_ModificacionC { get; set; }
        

        public Empleado_por_Id_Empleado(Empleado_por_Id_Empleado vEmpleado)
        {
            this.Nombre = vEmpleado.Nombre;
            this.Id_Empleado = vEmpleado.Id_Empleado;
        }

        public Empleado_por_Id_Empleado()
        {
        }

        public override string ToString()
        {
            return this.Nombre + " "+ this.Apellido_Paterno+ " "+ this.Apellido_Materno;
        }

        public void ActualizarFechaCQL()
        {
            try
            {
                if (Fecha_Nacimiento_C != null)
                {
                    Fecha_Nacimiento = new DateTime(Fecha_Nacimiento_C.Year, Fecha_Nacimiento_C.Month, Fecha_Nacimiento_C.Day);
                }
                if (Fecha_AltaC != null)
                {
                    Fecha_Alta = new DateTime(Fecha_AltaC.Year, Fecha_AltaC.Month, Fecha_AltaC.Day);
                }
               
            }
            catch (Exception)
            {

            }
        }
    }
}
