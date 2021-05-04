using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_AAVD_CEE.ENTIDADES
{
    class Administrador
    {
       
         public string Usuario { get; set; }
         public string Contrasenia { get; set; }
        //falta lo del map gestion_empleados!
        public IDictionary <DateTimeOffset,string> Gestion_Empleados { get; set; }


}
}
