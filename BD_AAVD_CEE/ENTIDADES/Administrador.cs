﻿using System;
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
        public IDictionary <DateTimeOffset,string> Gestion_Empleados { get; set; }
        public int Administrador2 { get; set; }


    }
}
