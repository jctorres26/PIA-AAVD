using BD_AAVD_CEE.ENTIDADES;
using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_AAVD_CEE.DataBaseConnections
{
    class DataBaseManager
    {
        private DataBaseManager()
        {
            cassandraHome = ConfigurationManager.AppSettings["cassandra_home"].ToString();
            keyspace = ConfigurationManager.AppSettings["keyspace"].ToString();
            cluster = Cluster.Builder().AddContactPoint(cassandraHome).Build();
        }

        static private DataBaseManager _instance = null;

        static public DataBaseManager getInstance()
        {
            if (_instance == null)
            {
                _instance = new DataBaseManager();
            }
            return _instance;
        }

        static private string cassandraHome { get; set; }
        static private string keyspace { get; set; }

        static private Cluster cluster;
        static private ISession session;


        //AQUI ABAJO VAN TODOS LOS QUERYS 
        public void ActualizarFecha(List<Empleado_por_Id_Empleado> listaEmpleados)
        {
            for (int i = 0; i < listaEmpleados.Count; i++)
            {
                listaEmpleados[i].ActualizarFechaCQL();
            }
        }

        public void ActualizarFechaC(List<Cliente_por_Id_Cliente> listaClientes)
        {
            for (int i = 0; i < listaClientes.Count; i++)
            {
                listaClientes[i].ActualizarFechaCQLC();  
            }
        }

        public void FechaConsumo ( List <Consumo_por_Numero_Medidor_Fecha> listaConsumos)
        {
            for (int i = 0; i < listaConsumos.Count; i++)
            {
                listaConsumos[i].ActualizarFechaCQLC();
            }
        }

        //EMPLEADOS

        public bool InsertUpdateDeleteEmpleado(char Opc, ENTIDADES.Empleado_por_Id_Empleado vEmpleado)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'I':
                        string query = String.Format("INSERT INTO Empleado_por_Id_Empleado (Id_Empleado,CURP,RFC,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento, Nombre_Usuario, Contrasenia,Activo,Fecha_Alta,UsuarioACT, Empleado)" +
                        "VALUES(uuid(),'{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}','{7}',true, toDate(now()), true, 0);"
                      , vEmpleado.CURP, vEmpleado.RFC, vEmpleado.Nombre, vEmpleado.Apellido_Paterno, vEmpleado.Apellido_Materno, vEmpleado.Fecha_Nacimiento.ToString("yyyy-MM-dd"), vEmpleado.Nombre_Usuario, vEmpleado.Contrasenia, vEmpleado.Activo, vEmpleado.Fecha_Alta.ToString("yyyy-MM-dd"));
                        session = cluster.Connect(keyspace);
                        session.Execute(query);
                        break;
                    case 'U':
                        //select del empleado a actualizar
                        //primero el select y luego el update 
                        //  List<Empleado_por_Id_Empleado> empleadoElegido = this.ObtenerEmpleado('S', vEmpleado).ToList();

                        string query2 = String.Format("UPDATE Empleado_por_Id_Empleado " +
                            " SET " +
                            "Nombre= '{1}', " +
                            "Apellido_Paterno= '{2}', " +
                            "Apellido_Materno= '{3}', " +
                            "Fecha_Nacimiento= '{4}', " +
                            "Nombre_Usuario= '{5}', " +
                            "Contrasenia= '{6}', " +
                            "CURP= '{7}', " +
                            "RFC= '{8}', " +
                            "Fecha_Modificacion= toTimestamp(now())  " +
                            "WHERE Id_Empleado =  {0} ; "
                        //por alguna razon no lo actualiza?
                        , vEmpleado.Id_Empleado, vEmpleado.Nombre, vEmpleado.Apellido_Paterno, vEmpleado.Apellido_Materno, vEmpleado.Fecha_Nacimiento.ToString("yyyy-MM-dd"), vEmpleado.Nombre_Usuario, vEmpleado.Contrasenia, vEmpleado.CURP, vEmpleado.RFC);
                        session = cluster.Connect(keyspace);
                        session.Execute(query2);


                        break;
                    case 'D':
                        string query3 = String.Format("UPDATE Empleado_por_Id_Empleado " +
                           " SET " +
                           "ACTIVO= false " +
                           "WHERE Id_Empleado =  {0} ; "
                       //por alguna razon no lo actualiza?
                       , vEmpleado.Id_Empleado);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);

                        break;

                }


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public IEnumerable<Empleado_por_Id_Empleado> ObtenerEmpleado(char Opc, Empleado_por_Id_Empleado vEmpleado)
        {
            IEnumerable<Empleado_por_Id_Empleado> Empleados = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<Empleado_por_Id_Empleado> listaEmpleados = null;

            switch (Opc)
            {
                case 'S':
                    string query = "SELECT Id_Empleado AS Id_Empleado, CURP AS CURP, RFC AS RFC, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Fecha_Nacimiento AS Fecha_Nacimiento_C, Nombre_Usuario AS Nombre_Usuario, Contrasenia AS Contrasenia " +
                        "FROM Empleado_por_Id_Empleado " +
                        "WHERE Id_Empleado = ? ;";

                    Empleados = mapper.Fetch<Empleado_por_Id_Empleado>(query, vEmpleado.Id_Empleado);

                    break;

                case 'X':
                    string query2 = "SELECT Id_Empleado AS Id_Empleado, CURP AS CURP, RFC AS RFC, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Nombre_Usuario AS Nombre_Usuario, Contrasenia AS Contrasenia, Fecha_Nacimiento AS Fecha_Nacimiento_C " +
                        "FROM Empleado_por_Id_Empleado " +
                        "WHERE Activo= true " +
                        "ALLOW FILTERING ; ";

                    Empleados = mapper.Fetch<Empleado_por_Id_Empleado>(query2);

                    break;

            }
            if (Empleados != null)
            {
                listaEmpleados = Empleados.ToList();

                ActualizarFecha(listaEmpleados);

            }



            return listaEmpleados;
        }

        //SERVICIO

        public bool INSERTSERVICIO(char Opc, NumServ vServicio)



        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'U':
                        string query2 = String.Format(

                            "UPDATE NumServ  " +
                            " SET " +
                            "numero = numero + 100 " +
                            "WHERE idBASE = '{0}';",
                            vServicio.idBASE
                       );

                        session = cluster.Connect(keyspace);
                        session.Execute(query2);


                        break;
                    case 'S':

                        //string query3 = String.Format(

                        //    " SELECT numero " +
                        //    " FROM  " +
                        //    "NumServ; " );
                        //foreach (Row row in rs)




                        break;

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return queryCorrecto;
        }

        public string NUMSERVICIO()
        {
            var dato = "";
            string query3 = "SELECT numero FROM NumServ; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["numero"].ToString();


            }
            return dato;
        }


        //CLIENTES 

        public bool UpdateDeleteCliente(char Opc, Cliente_por_Id_Cliente vCliente)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {

                    case 'U':
                        string query2 = String.Format("UPDATE Cliente_por_Id_Cliente " +
                            " SET " +
                            "Nombre= '{1}', " +
                            "Apellido_Paterno= '{2}', " +
                            "Apellido_Materno= '{3}', " +
                            "Fecha_Nacimiento= '{4}', " +
                            "Nombre_Usuario= '{5}', " +
                            "Contrasenia= '{6}', " +
                            "CURP= '{7}', " +
                            "Email = '{8}', " +
                            "Fecha_Modificacion= Fecha_Modificacion + [toTimestamp(now())], " +
                            "Empleado_Modificacion= '{9}'  " +
                            "WHERE Id_Cliente =  {0} ; "

                        , vCliente.Id_Cliente, vCliente.Nombre, vCliente.Apellido_Paterno, vCliente.Apellido_Materno, vCliente.Fecha_Nacimiento.ToString("yyyy-MM-dd"), vCliente.Nombre_Usuario, vCliente.Contrasenia, vCliente.CURP, vCliente.Email, vCliente.Empleado_Modificacion);
                        session = cluster.Connect(keyspace);
                        session.Execute(query2);



                        break;
                    case 'D':
                        string query3 = String.Format("UPDATE Cliente_por_Id_Cliente " +
                           " SET " +
                           "ACTIVO= false " +
                           "WHERE  Id_Cliente =  {0} ; "

                       , vCliente.Id_Cliente);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);


                        break;

                }


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }




        public bool Contratos(char Opc, Contrato_por_Numero_Servicio vContrato, Cliente_por_Id_Cliente vCliente)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'C':
                        string query3 = String.Format("INSERT INTO Contrato_por_Numero_Servicio ( Numero_Servicio, NumSer, Numero_Medidor, Tipo_Servicio, " +
                            "Estado, Ciudad , Colonia, Calle, CP, Numero_Exterior, Id_Cliente, Empleado_Modificacion, Usuario " +
                           " )" +
                       "VALUES(uuid(), {0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, '{10}', '{11}' );"
                       , vContrato.NumSer, vContrato.Numero_Medidor, vContrato.Tipo_Servicio, vContrato.Estado, vContrato.Ciudad, vContrato.Colonia, vContrato.Calle,
                       vContrato.CP, vContrato.Numero_Exterior, vContrato.Id_Cliente, vContrato.Empleado_Modificacion, vContrato.Usuario);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);


                        break;
                    case 'U':
                        string query = String.Format("INSERT INTO Cliente_por_Id_Cliente (Id_Cliente, CURP, Nombre, Apellido_Paterno, " +
                            "Apellido_Materno, Fecha_Nacimiento, Genero, Email, Nombre_Usuario, Contrasenia, Activo, Fecha_Alta,Empleado_Modificacion, ClienteACT, Cliente )" +
                        "VALUES({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}', true, toDate(now()), '{10}', true, 0 );"
                        , vCliente.Id_Cliente, vCliente.CURP, vCliente.Nombre, vCliente.Apellido_Paterno, vCliente.Apellido_Materno,
                        vCliente.Fecha_Nacimiento.ToString("yyyy-MM-dd"), vCliente.Genero, vCliente.Email, vCliente.Nombre_Usuario, vCliente.Contrasenia, vCliente.Empleado_Modificacion);
                        session = cluster.Connect(keyspace);
                        session.Execute(query);
                        break;
                    case 'D':
                        string query2 = String.Format("INSERT INTO Contrato_por_Numero_Servicio ( Numero_Servicio, NumSer, Numero_Medidor, Tipo_Servicio, " +
                            "Estado, Ciudad , Colonia, Calle, CP, Numero_Exterior, Id_Cliente, Empleado_Modificacion, Usuario " +
                           " )" +
                       "VALUES(uuid(), {0}, {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8}, {9}, '{10}', '{11}' );"
                       , vContrato.NumSer, vContrato.Numero_Medidor, vContrato.Tipo_Servicio, vContrato.Estado, vContrato.Ciudad, vContrato.Colonia, vContrato.Calle,
                       vContrato.CP, vContrato.Numero_Exterior, vContrato.Id_Cliente, vContrato.Empleado_Modificacion, vContrato.Usuario);
                        session = cluster.Connect(keyspace);
                        session.Execute(query2);

                        break;


                }


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public IEnumerable<Cliente_por_Id_Cliente> ObtenerCliente(char Opc, Cliente_por_Id_Cliente vCliente)
        {
            IEnumerable<Cliente_por_Id_Cliente> Clientes = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<Cliente_por_Id_Cliente> listaClientes = null;

            switch (Opc)
            {
                //Para mostrarlos en los campos
                case 'S':
                    string query = "SELECT Id_Cliente AS Id_Cliente, CURP AS CURP, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, " +
                        "Apellido_Materno AS Apellido_Materno, Fecha_Nacimiento AS FN, Genero AS Genero, Email AS Email, Nombre_Usuario AS Nombre_Usuario, " +
                        "Contrasenia AS Contrasenia  " +
                        "FROM Cliente_por_Id_Cliente " +
                        "WHERE Id_Cliente = ? ;";

                    Clientes = mapper.Fetch<Cliente_por_Id_Cliente>(query, vCliente.Id_Cliente);

                    break;
                //para actualizar el combo 
                case 'X':
                    string query2 = "SELECT Id_Cliente AS Id_Cliente, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Activo AS Activo  " +
                        "FROM Cliente_por_Id_Cliente " +
                        "WHERE Activo= true " +
                        "ALLOW FILTERING ; ";

                    Clientes = mapper.Fetch<Cliente_por_Id_Cliente>(query2);

                    break;

            }
            if (Clientes != null)
            {
                listaClientes = Clientes.ToList();

                ActualizarFechaC(listaClientes);

            }



            return listaClientes;
        }
        public IEnumerable <Recibo_por_Numero_Servicio_Anio_Mes> ObtenerServicios( Recibo_por_Numero_Servicio_Anio_Mes vServicio)
        {
            IEnumerable<Recibo_por_Numero_Servicio_Anio_Mes> Servicios = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<Recibo_por_Numero_Servicio_Anio_Mes> listaServicios = null;
            
                    string query2 = "SELECT Numero_Servicio  " +
                        "FROM Recibo_por_Numero_Servicio_Anio_Mes " +
                        "WHERE Recibo_Generado= true " +
                        "AND Usuario = '"+ vServicio.Usuario +"' " +
                        "ALLOW FILTERING ; ";

            Servicios = mapper.Fetch<Recibo_por_Numero_Servicio_Anio_Mes>(query2);
            
            if (Servicios != null)
            {
                listaServicios = Servicios.ToList();

            }



            return listaServicios;
        }

        public bool CLIENTEID(char Opc, NumCliente vNCliente)



        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'U':
                        string query2 = String.Format(

                            "UPDATE NumCliente  " +
                            " SET " +
                            "numero2 = numero2 + 1 " +
                            "WHERE idBASE2 = '{0}';",
                            vNCliente.idBASE2
                       );

                        session = cluster.Connect(keyspace);
                        session.Execute(query2);


                        break;


                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return queryCorrecto;
        }

        public string NUMCLIENTE()
        {
            var dato = "";
            string query3 = "SELECT numero2 FROM NumCliente; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["numero2"].ToString();


            }
            return dato;
        }

        //LOGIN 
        public int PROGRAM_LOGIN(string Tipo, string usuario, string clave)
        {
            int ret = 0;
            var us = "";
            var ps = "";
            try
            {
                session = cluster.Connect(keyspace);
                //Si ingresa el administrador del sistema
                if (Tipo == "Administrador" && usuario == "Admin")
                {
                    string query = String.Format("SELECT  Contrasenia FROM Administrador WHERE Usuario = '{0}'; ",
                      usuario);
                    // session = cluster.Connect(keyspace);
                    // session.Execute(query);
                    //string qry = "SELECT Contrasenia FROM Administrador WHERE Usuario = " + usuario + ";";

                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["contrasenia"].ToString();
                        if (clave == ps) { ret = 1; }
                    }
                }
                //si ingresa un empleado 
                else if (Tipo == "Empleado")
                {
                    string qry = "SELECT Nombre_Usuario, Contrasenia FROM Empleado_por_Id_Empleado WHERE Activo = true AND UsuarioACT= true ALLOW FILTERING;";
                    session = cluster.Connect(keyspace);
                    var rs = session.Execute(qry);
                    foreach (Row row in rs)
                    {
                        us = row["nombre_usuario"].ToString();
                        ps = row["contrasenia"].ToString();
                        if (usuario == us && clave == ps) { ret = 2; }
                    }


                }
                //si ingresa un cliente 
                else if (Tipo == "Cliente")
                {
                    string qry = "SELECT Nombre_Usuario, Contrasenia FROM Cliente_por_Id_Cliente WHERE Activo = true AND ClienteACT= true ALLOW FILTERING;";
                    session = cluster.Connect(keyspace);
                    var rs = session.Execute(qry);
                    foreach (Row row in rs)
                    {
                        us = row["nombre_usuario"].ToString();
                        ps = row["contrasenia"].ToString();
                        if (usuario == us && clave == ps) { ret = 3; }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return ret;
        }

        public int PROGRAM_CHECK (string Tipo, string usuario, string clave)
        {
            int ret = 0;
            
            var ps = "";
            try
            {
                session = cluster.Connect(keyspace);
                if (Tipo == "Empleado")
                {

                    string query = String.Format("SELECT  Contrasenia FROM Empleado_por_Id_Empleado WHERE Nombre_Usuario = '{0}' ALLOW FILTERING; ",
                      usuario);


                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["contrasenia"].ToString();
                        if (clave == ps) { ret = 1; }
                       

                    }
                }
                if (Tipo == "Cliente")
                {
                    string query = String.Format("SELECT  Contrasenia FROM Cliente_por_Id_Cliente WHERE Nombre_Usuario = '{0}' ALLOW FILTERING; ",
                      usuario);


                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["contrasenia"].ToString();
                        if (clave == ps) { ret = 1; }

                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            return ret;

        }

       public bool INSERTLOGIN_INGRESO(string usuario, string clave, string tipo)
        {
            bool queryCorrecto = true;
            try
            {
                        string query3 = String.Format("INSERT INTO LOGIN_GUARDADO ( BASE, Tipo, Recordar, Usuario, Contrasenia ) " +
                            "VALUES ('pia','{0}', true, '{1}', '{2}') ;"
                       ,tipo, usuario, clave);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);

            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public bool UPDATELOGIN_INGRESO ()
        {
            bool queryCorrecto = true;
            try
            {
                string query2 = String.Format(

                            "UPDATE LOGIN_GUARDADO " +
                            " SET " +
                            "Recordar = false " +
                            "WHERE BASE = 'pia';"
                            
                       );

                session = cluster.Connect(keyspace);
                session.Execute(query2);

            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public string USUARIOLOGIN()
        {
            var dato = "";
            string query3 = "SELECT Usuario FROM LOGIN_GUARDADO WHERE Recordar = true ALLOW FILTERING;; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["usuario"].ToString();


            }
            return dato;
        }
        public string CLAVELOGIN()
        {
            var dato = "";
            string query3 = "SELECT Contrasenia FROM LOGIN_GUARDADO WHERE Recordar = true ALLOW FILTERING; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["contrasenia"].ToString();
                
            }
            return dato;
        }
        public string TIPOLOGIN()
        {
            var dato = "";
            string query3 = "SELECT Tipo FROM LOGIN_GUARDADO WHERE Recordar = true ALLOW FILTERING; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["tipo"].ToString();

            }
            return dato;
        }
        public string UsuarioParaRecibo(int medidor)
        {
            var dato = "";
            string query3 = "SELECT Usuario FROM Contrato_por_Numero_Servicio WHERE Numero_Medidor = " +  medidor + "  ALLOW FILTERING;; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["usuario"].ToString();


            }
            return dato;
        }
        //ADMINISTRADOR,  MAP CON LOS EMPLEADOS AGREGADOS Y LA FECHA EN LA QUE FUERON INGRESADOS
        public bool InsertAdmin(char Opc, string A, string UsuarioC)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'I':


                        break;
                    case 'U':
                        session = cluster.Connect(keyspace);
                        string qry = "UPDATE Administrador SET Gestion_Empleados = Gestion_Empleados + { toTimestamp(now()): '" + UsuarioC + "' } WHERE Usuario = 'Admin';";

                        var rs = session.Execute(qry);


                        break;


                }


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return queryCorrecto;
        }

        

        //SELECT DEL ID DEL EMPLEADO
        public string IDEMPLEADO(string NU, string NC)
        {
            var dato = "";
            string query3 = "SELECT Id_Empleado FROM Empleado_por_Id_Empleado WHERE Nombre_Usuario= '"+ NU+"' AND Contrasenia='"+NC +"' ALLOW FILTERING ; ";
            session = cluster.Connect(keyspace);
            var rs = session.Execute(query3);
            foreach (Row row in rs)
            {
                dato = row["id_empleado"].ToString();


            }
            return dato;
        }
        //SELECT DEL ID DEL EMPLEADO EN EL LOGIN
        public string IDEMPLEADOL(char opc, string NU)
        {
            var dato = "";
            switch (opc)
            {
                case 'E':
                    
                    string query3 = "SELECT Id_Empleado FROM Empleado_por_Id_Empleado WHERE Nombre_Usuario= '" + NU + "' ALLOW FILTERING ; ";
                    session = cluster.Connect(keyspace);
                    var rs = session.Execute(query3);
                    foreach (Row row in rs)
                    {
                        dato = row["id_empleado"].ToString();


                    }
                    break;
                case 'C':
                    string query4 = "SELECT Id_Cliente FROM Cliente_por_Id_Cliente WHERE Nombre_Usuario= '" + NU + "' ALLOW FILTERING ; ";
                    session = cluster.Connect(keyspace);
                    var rs2 = session.Execute(query4);
                    foreach (Row row in rs2)
                    {
                        dato = row["id_cliente"].ToString();


                    }

                    break;
            }
            //var dato = "";
            //string query3 = "SELECT Id_Empleado FROM Empleado_por_Id_Empleado WHERE Nombre_Usuario= '" + NU + "' ALLOW FILTERING ; ";
            //session = cluster.Connect(keyspace);
            //var rs = session.Execute(query3);
            //foreach (Row row in rs)
            //{
            //    dato = row["id_empleado"].ToString();


            //}
            return dato;
        }
        //UPDATE DEL SET DE EMPLEADOS 
        public bool EMPLEADOU( Guid c, string Client)
        {
            bool queryCorrecto = true;
            try
            {
               
                        session = cluster.Connect(keyspace);
                        string qry = "UPDATE Empleado_por_Id_Empleado SET Clientes = Clientes + { '" + Client+ "' } WHERE Id_Empleado = "+ c+";";

                        var rs = session.Execute(qry);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return queryCorrecto;
        }
        //UPDATE DEL EMPLEADO POR EL LOGIN
        public bool EMPLEADOUL(char opc, Guid c, string Client, int num)
        {
            bool queryCorrecto = true;
            try
            {
                switch (opc)
                {
                    case 'E':
                        session = cluster.Connect(keyspace);
                        string qry = "UPDATE Empleado_por_Id_Empleado SET UsuarioACT = false WHERE Id_Empleado = " + c + ";";

                        var rs = session.Execute(qry);
                        break;
                    case 'C':
                        session = cluster.Connect(keyspace);
                        string qry2 = "UPDATE Cliente_por_Id_Cliente SET ClienteACT = false WHERE Id_Cliente = " + num + ";";

                        var rs2 = session.Execute(qry2);
                        break;

                }
                //session = cluster.Connect(keyspace);
                //string qry = "UPDATE Empleado_por_Id_Empleado SET UsuarioACT = false WHERE Id_Empleado = " + c + ";";

                //var rs = session.Execute(qry);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return queryCorrecto;
        }
        public bool EMPLEADO_REESTABLECER (Empleado_por_Id_Empleado vEmpleado)
        {
            bool queryCorrecto = true;
            try
            {
                
                        string query3 = String.Format("UPDATE Empleado_por_Id_Empleado " +
                           " SET " +
                           "UsuarioACT= true " +
                           "WHERE  Id_Empleado =  {0} ; "

                       , vEmpleado.Id_Empleado);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        //CLIENTES
        public bool CLIENTE_REESTABLECER (Cliente_por_Id_Cliente vCliente)
        {
            bool queryCorrecto = true;
            try
            {

                string query3 = String.Format("UPDATE Cliente_por_Id_Cliente " +
                   " SET " +
                   "ClienteACT= true " +
                   "WHERE  Id_Empleado =  {0} ; "

               , vCliente.Id_Cliente);
                session = cluster.Connect(keyspace);
                session.Execute(query3);


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }


        //TARIFASSS
        public bool InserTarifaUNIT ( char opc, string tipo, string mes, string anio, float basico, float intermedio, float excedente, string empleado)
        {
            bool queryCorrecto = true;
            try
            {
                switch (opc)
                {
                    case 'I':
                        string query3 = String.Format("INSERT INTO Tarifa_por_Tipo_Anio_Mes ( Anio, Mes, Tipo_Servicio, Basico, Intermedio, Excedente, Empleado_Modificacion ) " +
                    "VALUES ('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}' ) ;"
               , anio, mes, tipo, basico, intermedio, excedente, empleado);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);
                        break;
                    case 'S':
                        string query4 = String.Format("INSERT INTO Tarifa_por_Anio ( Anio, Mes,Basico, Intermedio, Excedente, Tipo_Servicio ) " +
                    "VALUES ('{0}', '{1}', {2}, {3}, {4}, '{5}' ) ;"
               , anio, mes, basico, intermedio, excedente, tipo);
                        session = cluster.Connect(keyspace);
                        session.Execute(query4);
                        break;
                        //Caso de que sea domiciliar la tarifa 
                    

                }
            
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return queryCorrecto;
        }

        //CONSUMOS
        public bool TarifaExistente (string tipo, string mes, string anio)
        {

            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Anio, Mes, Tipo_Servicio FROM Tarifa_por_Tipo_Anio_Mes WHERE Anio= '{0}' AND Mes = '{1}' AND Tipo_Servicio= '{2}'; ",
                  anio, mes, tipo);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["anio"].ToString();
                ps2 = row["mes"].ToString();
                ps3 = row["tipo_servicio"].ToString();
                if (anio == ps && mes == ps2 && tipo == ps3)
                { existe = true; }


            }

            return existe;

        }
        public bool MedidorExistente(string medidor)
        {
            bool existe = false;
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Numero_Medidor FROM Contrato_por_Numero_Servicio WHERE Numero_Medidor = {0} ALLOW FILTERING; ",
                  medidor);
            var rs = session.Execute(query);
            foreach (Row row in rs)
             {
                  ps = row["numero_medidor"].ToString();
                  if (medidor == ps) { existe = true;  }


            }
       
            return existe;
        }
        public string MedidorTipo (string medidor)
        {
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Tipo_Servicio FROM Contrato_por_Numero_Servicio WHERE Numero_Medidor = {0} ALLOW FILTERING; ",
                  medidor);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["tipo_servicio"].ToString();
                

            }
            return ps;
        }
         public bool InsertConsumoUNIT (char opc, Consumo_por_Numero_Medidor_Fecha vConsumo)
        {
            bool queryCorrecto = true;
            try
            {
                switch (opc)
                {
                    case 'S':
                        string query3 = String.Format("INSERT INTO Consumo_por_Numero_Medidor_Fecha ( Numero_Medidor, Fecha, Consumo, Basico, Intermedio, Excedente, Empleado_Modificacion, Basicot, Intermediot, Excedentet, FechaAnio, FechaMes, tipo, FechaInicio, FechaFinal, FechaExcedente ) " +
                    "VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, '{6}', {7}, {8}, {9}, '{10}', '{11}', '{12}', '{13}', '{14}', '{15}' ) ;"
               , vConsumo.Numero_Medidor, vConsumo.Fecha.ToString("yyyy-MM-dd"), vConsumo.Consumo, vConsumo.Basico, vConsumo.Intermedio, vConsumo.Excedente, vConsumo.Empleado_Modificacion, vConsumo.Basicot, vConsumo.Intermediot, vConsumo.Excedentet, vConsumo.FechaAnio, vConsumo.FechaMes, vConsumo.tipo, vConsumo.FechaInicio, vConsumo.FechaFinal, vConsumo.FechaExcedente);
                        session = cluster.Connect(keyspace);
                        session.Execute(query3);
                        break;
                    case 'I':
                        string query4 = String.Format("INSERT INTO Reporte_Consumos ( Anio, Mes, Numero_Medidor, Basico, Intermedio, Excedente, Fecha ) " +
                    "VALUES ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}' ) ;"
               , vConsumo.FechaAnio, vConsumo.FechaMes, vConsumo.Numero_Medidor, vConsumo.Basico, vConsumo.Intermedio, vConsumo.Excedente, vConsumo.FechaFinal);
                        session = cluster.Connect(keyspace);
                        session.Execute(query4);
                        break;
                    case 'R':
                        string query5 = String.Format("INSERT INTO Reporte_Consumos ( Anio, Mes, Numero_Medidor, Basico, Intermedio, Excedente, Fecha ) " +
                    "VALUES ('{0}', '{1}', {2}, {3}, {4}, {5} . '{6}') ;"
               , vConsumo.FechaAnio, vConsumo.FechaMes, vConsumo.Numero_Medidor, vConsumo.Basico, vConsumo.Intermedio, vConsumo.Excedente, vConsumo.FechaFinal);
                        session = cluster.Connect(keyspace);
                        session.Execute(query5);
                        break;

                }
               // string query3 = String.Format("INSERT INTO Consumo_por_Numero_Medidor_Fecha ( Numero_Medidor, Fecha, Consumo, Basico, Intermedio, Excedente, Empleado_Modificacion, Basicot, Intermediot, Excedentet, FechaAnio, FechaMes ) " +
               //     "VALUES ({0}, '{1}', {2}, {3}, {4}, {5}, '{6}', {7}, {8}, {9}, '{10}', '{11}' ) ;"
               //,vConsumo.Numero_Medidor, vConsumo.Fecha.ToString("yyyy-MM-dd"),vConsumo.Consumo, vConsumo.Basico, vConsumo.Intermedio, vConsumo.Excedente,vConsumo.Empleado_Modificacion, vConsumo.Basicot, vConsumo.Intermediot, vConsumo.Excedentet, vConsumo.FechaAnio, vConsumo.FechaMes );
               // session = cluster.Connect(keyspace);
               // session.Execute(query3);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }


            return queryCorrecto;
        }
        public string TarifasParaConsumo (char opc,string tipo, string mes, string anio)
        {
            string dato = "";
            switch (opc)
            {
                case 'B':
                    //sacar tarifa basica
                    session = cluster.Connect(keyspace);
                    string query = String.Format("SELECT  Basico FROM Tarifa_por_Tipo_Anio_Mes WHERE Anio = '{0}' AND Mes= '{1}' AND Tipo_Servicio= '{2}' ; ",
                          anio, mes, tipo);
                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        dato = row["basico"].ToString();
                    }
                    break;
                case 'I':
                    //sacar tarifa intermedia
                    session = cluster.Connect(keyspace);
                    string query2 = String.Format("SELECT  Intermedio FROM Tarifa_por_Tipo_Anio_Mes WHERE Anio = '{0}' AND Mes= '{1}' AND Tipo_Servicio= '{2}' ; ",
                          anio, mes, tipo);
                    var rs2 = session.Execute(query2);
                    foreach (Row row in rs2)
                    {
                        dato = row["intermedio"].ToString();
                    }
                    break;
                case 'E':

                    //sacar tarifa excedente
                    session = cluster.Connect(keyspace);
                    string query3 = String.Format("SELECT  Excedente FROM Tarifa_por_Tipo_Anio_Mes WHERE Anio = '{0}' AND Mes= '{1}' AND Tipo_Servicio= '{2}' ; ",
                          anio, mes, tipo);
                    var rs3 = session.Execute(query3);
                    foreach (Row row in rs3)
                    {
                        dato = row["excedente"].ToString();
                    }
                    break;

            }
            return dato;

        }
        public bool ConsumoExistente (string medidor, string anio, string mes, string fecha)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            var ps4 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Numero_Medidor,FechaAnio, FechaMes, FechaFinal FROM Consumo_por_Numero_Medidor_Fecha WHERE Numero_Medidor = {0} AND FechaAnio = '{1}' AND FechaMes= '{2}' AND FechaFinal= '{3}' ; ",
                  medidor, anio, mes, fecha);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["numero_medidor"].ToString();
                ps2 = row["fechaanio"].ToString();
                ps3 = row["fechames"].ToString();
                ps4= row["fechafinal"].ToString();
                if (medidor == ps && anio == ps2 && mes == ps3 && fecha == ps4)
                { existe = true; }


            }

            return existe;
        }
        public bool ConsumoPeriodo (string medidor, string fecha)
        {
            //Esto sera para los contratos de tipo industrial, los que son por mes
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            var ps4 = "";
            DateTime fI;
            DateTime fF;
            //Hacer el calculo de la fecha hacia adelante que no debe de dejar tampoco 
            string fechaexcedente = "";
           
            DateTime fechaO;
            DateTime fechaex;
            fechaO = DateTime.ParseExact(fecha, "dd/MM/yyyy", null);
            //fechaexcedente = fechaO.AddMonths(1).ToShortDateString();
           // fechaex = DateTime.ParseExact(fechaexcedente,"dd/MM/yyyy", null);
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Numero_Medidor,FechaInicio, FechaFinal, FechaExcedente FROM Consumo_por_Numero_Medidor_Fecha WHERE Numero_Medidor = {0}  ALLOW FILTERING; ",
                  medidor);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                
                ps = row["fechainicio"].ToString();
                ps2 = row["fechafinal"].ToString();
                ps3 = row["fechaexcedente"].ToString();
                fI = DateTime.ParseExact(ps, "dd/MM/yyyy", null);
                fF = DateTime.ParseExact (ps2, "dd/MM/yyyy", null);
                fechaex= DateTime.ParseExact(ps3,"dd/MM/yyyy", null);
                
                int aux = 0;
                if ((fechaO >= fI) && (fechaO <= fechaex))
                {
                    //significa que la fecha esta en un rango de cobro que no se puede && (fechaO <= fF)) && ((fechaO >= fF) &&
                    existe = true;
                }
              
            }

            return existe;
        }
       
        //REPORTES 

        //REPORTE DE TARIFAS POR AÑO 
        public bool TarifaPorAnio ( string anio)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Anio FROM Tarifa_por_Tipo_Anio_Mes WHERE Anio= '{0}' ALLOW FILTERING; ",
                  anio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["anio"].ToString();
                if (anio == ps)
                { existe = true; }
            }


            return existe;
        }
        public List<Tarifa_por_Anio> AllTarifas ( string anio)
        {
            string query = String.Format("SELECT  Anio, Mes, Basico, Intermedio, Excedente, Tipo_Servicio FROM Tarifa_por_Anio WHERE Anio = '{0}' ; ",
                          anio);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Tarifa_por_Anio> tarifa = mapper.Fetch<Tarifa_por_Anio>(query);
            return tarifa.ToList();
        }
        //REPORTE DE CONSUMOS POR AÑO
        public bool ConsumoPorAnio (string anio)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Anio FROM Reporte_Consumos WHERE Anio= '{0}'" +
                "; ",
                  anio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["anio"].ToString();
                if (anio == ps)
                { existe = true; }
            }


            return existe;
        }
        public List<Reporte_Consumos> AllConsumos (string anio)
        {
            string query = String.Format("SELECT  Anio, Mes, Numero_Medidor, Basico, Intermedio, Excedente FROM Reporte_Consumos WHERE Anio = '{0}' ; ",
                         anio);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Reporte_Consumos> consumo = mapper.Fetch<Reporte_Consumos>(query);
            return consumo.ToList();
        }

        //SACAR NUMERO DE SERVICIO SEGUN EL MEDIDOR 
        public string NumeroServicioGET(string medidor)
        {
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  NumSer FROM Contrato_por_Numero_Servicio WHERE Numero_Medidor = {0} ALLOW FILTERING; ",
                  medidor);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["numser"].ToString();


            }
            return ps;
        }
        public bool Recibo(Recibo_por_Numero_Servicio_Anio_Mes vRecibo)
        {
            bool queryCorrecto = true;
            try
            {
                string query3 = String.Format("INSERT INTO Recibo_por_Numero_Servicio_Anio_Mes ( Numero_Servicio, Fecha,  AnioF, MesF, FechaF, FechaI, Tipo_Servicio,Consumo, Consumo_Basico, Consumo_Intermedio, Consumo_Excedente, Tarifa_Basico, Tarifa_Intermedio, Tarifa_Excedente, Subtotal_Basico, Subtotal_Intermedio, Subtotal_Excedente, Is_Paid, Importe, Importe_IVA, Cantidad_Pagada, Cantidad_Pendiente, Recibo_Generado, Medidor, Dia, Usuario) " +
                   "VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}',{7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, false, {17}, {18}, {19}, {20}, false, {21}, '{22}', '{23}' ) ;"
              , vRecibo.Numero_Servicio,vRecibo.Fecha.ToString("yyyy-MM-dd"), vRecibo.AnioF, vRecibo.MesF, vRecibo.FechaF, vRecibo.FechaI, vRecibo.Tipo_Servicio, vRecibo.Consumo,
              vRecibo.Consumo_Basico, vRecibo.Consumo_Intermedio, vRecibo.Consumo_Excedente, vRecibo.Tarifa_Basico, vRecibo.Tarifa_Intermedio, vRecibo.Tarifa_Excedente, vRecibo.Subtotal_Basico,
              vRecibo.Subtotal_Intermedio, vRecibo.Subtotal_Excedente,  vRecibo.Importe, vRecibo.Importe_IVA, vRecibo.Cantidad_Pagada, vRecibo.Cantidad_Pendiente,  vRecibo.Medidor, vRecibo.Dia, vRecibo.Usuario);
                session = cluster.Connect(keyspace);
                session.Execute(query3);



            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public bool ConsumoH(long ns, int medidor, string anio, string mes, string dia, int consumo, double importe, float cantidadp, double cantidadpendiente, string tipo, string fecha)
        {
            bool queryCorrecto = true;
            try
            {
                string query3 = String.Format("INSERT INTO ConsumoH ( Numero_Servicio, Medidor, AnioF, MesF, Dia, Consumo, Importe_IVA, Cantidad_Pagada, Cantidad_Pendiente, Generado, Tipo, Fecha ) " +
                   "VALUES ({0}, {1}, '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, false, '{9}', '{10}') ;"
              ,ns, medidor, anio, mes, dia, consumo, importe, cantidadp, cantidadpendiente, tipo, fecha);
                session = cluster.Connect(keyspace);
                session.Execute(query3);



            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        //GENERACION DE RECIBO
        public bool ConsumosParaRecibo(char opc, string anio, string mes, string tipo)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            switch (opc)
            {
                case 'I':
                    session = cluster.Connect(keyspace);
                    string query = String.Format("SELECT  FechaAnio, FechaMes, tipo  FROM Consumo_por_Numero_Medidor_Fecha WHERE FechaAnio = '{0}' AND FechaMes= '{1}' AND tipo= '{2}' ALLOW FILTERING; ",
                          anio, mes, tipo);
                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["fechaanio"].ToString();
                        ps2 = row["fechames"].ToString();
                        ps3 = row["tipo"].ToString();
                        if (anio == ps && mes == ps2 && tipo == ps3)
                        { existe = true; }
                    }
                    break;
                case 'D':
                    break;
            }
            

            return existe;
        }
        public bool ReciboExistente (string anio, string mes, string tipo)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
                    session = cluster.Connect(keyspace);
                    string query = String.Format("SELECT  AnioF, MesF, Tipo_Servicio  FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE  AnioF = '{0}' AND MesF= '{1}' AND Tipo_Servicio= '{2}' ALLOW FILTERING; ",
                          anio, mes, tipo);
                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["aniof"].ToString();
                        ps2 = row["mesf"].ToString();
                        ps3 = row["tipo_servicio"].ToString();
                        if (anio == ps && mes == ps2 && tipo == ps3)
                        { existe = true; }
                    }


            return existe;
        }
        public bool ActivarRecibos (string anio, string mes, string tipo)
        {
            bool queryCorrecto = true;
            try
            {
                var ps = "";
                var ps2 = "";
                var ps3 = "";
                var fechita1 = "";
                var num = "";
                int num2 = 0;
                session = cluster.Connect(keyspace);
                string query = String.Format("SELECT  Numero_Servicio, AnioF, MesF, Tipo_Servicio, Dia   FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE  AnioF = '{0}' AND MesF= '{1}' AND Tipo_Servicio= '{2}' ALLOW FILTERING; ",
                      anio, mes, tipo);
                var rs = session.Execute(query);
                foreach (Row row in rs)
                {
                    num = row["numero_servicio"].ToString();
                    ps = row["aniof"].ToString();
                    ps2 = row["mesf"].ToString();
                    ps3 = row["tipo_servicio"].ToString();
                    fechita1 = row["dia"].ToString();
                    num2=Convert.ToInt32(num);
                    int aux = 0;
                    //string query3 = String.Format(

                    //        "UPDATE Recibo_por_Numero_Servicio_Anio_Mes SET Recibo_Generado = true WHERE Numero_Servicio= {0} AnioF= '{1}'  AND MesF= '{2}'  AND Fecha = '{3}';"
                    //        , num2, anio, mes, fechita1
                    //   );
                    //session = cluster.Connect(keyspace);
                    //session.Execute(query3);
                    session = cluster.Connect(keyspace);
                    string qry = "UPDATE Recibo_por_Numero_Servicio_Anio_Mes SET Recibo_Generado = true WHERE Numero_Servicio = " + num2 + " AND AnioF='"+anio+"' AND MesF= '"+mes+"' AND Dia= '"+fechita1 +"'  ;";

                    var rs2 = session.Execute(qry);
                }

                

            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
       public bool ActivarConsumoH(string anio, string mes, string tipo)
        {
            bool queryCorrecto = true;
            try
            {
                var ps = "";
                var ps2 = "";
                var ps3 = "";
                var fechita1 = "";
                var num = "";
                int num2 = 0;
                session = cluster.Connect(keyspace);
                string query = String.Format("SELECT  Numero_Servicio, AnioF, MesF, Tipo, Dia   FROM ConsumoH WHERE  AnioF = '{0}' AND MesF= '{1}' AND Tipo= '{2}' ALLOW FILTERING; ",
                      anio, mes, tipo);
                var rs = session.Execute(query);
                foreach (Row row in rs)
                {
                    num = row["numero_servicio"].ToString();
                    ps = row["aniof"].ToString();
                    ps2 = row["mesf"].ToString();
                    ps3 = row["tipo"].ToString();
                    fechita1 = row["dia"].ToString();
                    num2 = Convert.ToInt32(num);
                    int aux = 0;
                   
                    session = cluster.Connect(keyspace);
                    string qry = "UPDATE ConsumoH SET Generado = true WHERE Numero_Servicio = " + num2 + " AND AnioF='" + anio + "' AND MesF= '" + mes + "' AND Dia= '" + fechita1 + "'  ;";

                    var rs2 = session.Execute(qry);
                }



            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public bool ReciboRGExistente(string anio, string mes, string tipo)
        {

            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  AnioF, MesF, Tipo_Servicio  FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE  AnioF = '{0}' AND MesF= '{1}' AND Tipo_Servicio= '{2}' AND Recibo_Generado= true ALLOW FILTERING; ",
                  anio, mes, tipo);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["aniof"].ToString();
                ps2 = row["mesf"].ToString();
                ps3 = row["tipo_servicio"].ToString();
                if (anio == ps && mes == ps2 && tipo == ps3)
                { existe = true; }
            }


            return existe;
        }
        public List<Recibo_por_Numero_Servicio_Anio_Mes> AllRecibosRG(string anio, string mes, string tipo)
        {
            string query = String.Format("SELECT  Numero_Servicio, AnioF, MesF, Tipo_Servicio, Cantidad_Pagada, Cantidad_Pendiente FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE AnioF = '{0}' AND MesF = '{1}' AND Tipo_Servicio= '{2}' ALLOW FILTERING ; ",
                         anio, mes, tipo);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<Recibo_por_Numero_Servicio_Anio_Mes> consumo = mapper.Fetch<Recibo_por_Numero_Servicio_Anio_Mes>(query);
            return consumo.ToList();
        }
        //CONSUMO HISTORICO 
        public bool ConsumoHistoricoExistente (char opc,string anio, int medidor, int servicio)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            var ps4 = "";
            switch (opc)
            {
                case 'M':
                    //Caso en el que consulte con el medidor 
                    session = cluster.Connect(keyspace);
                    string query = String.Format("SELECT  AnioF,  Medidor  FROM ConsumoH WHERE  AnioF = '{0}' AND Medidor= {1} AND Generado= true ALLOW FILTERING; ",
                          anio, medidor);
                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["aniof"].ToString();
                        ps2 = row["medidor"].ToString();
                        int m = 0;
                        m = Convert.ToInt32(ps2);
                        if (anio == ps && medidor== m)
                        { existe = true; }
                    }

                    break;
                case 'S':
                    session = cluster.Connect(keyspace);
                    string query2 = String.Format("SELECT  AnioF,  Numero_Servicio  FROM ConsumoH WHERE  AnioF = '{0}' AND  Numero_Servicio= {1} AND Generado= true ALLOW FILTERING; ",
                          anio, servicio);
                    var rs2 = session.Execute(query2);
                    foreach (Row row in rs2)
                    {
                        ps3 = row["aniof"].ToString();
                        ps4 = row["numero_servicio"].ToString();
                        int m = 0;
                        m = Convert.ToInt32(ps4);
                        if (anio == ps3 && servicio == m)
                        { existe = true; }
                    }
                    break;
            }



            return existe;
        }
        public bool NumSerExistente(int servicio)
        {
            bool existe = false;
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  Numero_Servicio FROM ConsumoH WHERE Numero_Servicio = {0} ALLOW FILTERING; ",
                  servicio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["numero_servicio"].ToString();
                int i = 0;
                i = Convert.ToInt32(ps);
                if (servicio == i) { existe = true; }


            }

            return existe;
        }
        public List <CH> AllConsumosM (string anio, int medidor)
        {
            string query = String.Format("SELECT  FechaF, Consumo, Importe_IVA, Cantidad_Pagada, Cantidad_Pendiente FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE AnioF = '{0}' AND Medidor ={1} ALLOW FILTERING ; ",
                         anio, medidor);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<CH> consumo = mapper.Fetch<CH>(query);
            return consumo.ToList();
        }

        public List<CH> AllConsumosS(string anio, int servicio)
        {
            string query = String.Format("SELECT  FechaF, Consumo, Importe_IVA, Cantidad_Pagada, Cantidad_Pendiente FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE AnioF = '{0}' AND Numero_Servicio ={1} ALLOW FILTERING ; ",
                         anio, servicio);
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            IEnumerable<CH> consumo = mapper.Fetch<CH>(query);
            return consumo.ToList();
        }

        //CHECAR GENERACION DEL PDF DE UN RECIBO
        public bool ReciboPDF(char opc, string anio,string mes, int medidor, int servicio)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            var ps4 = "";
            var ps5 = "";
            switch (opc)
            {
                case 'M':
                    //Caso en el que consulte con el medidor 
                    session = cluster.Connect(keyspace);
                    string query = String.Format("SELECT  AnioF, MesF,  Medidor  FROM ConsumoH WHERE  AnioF = '{0}' AND MesF= '{1}' AND Medidor= {2} AND Generado= true ALLOW FILTERING; ",
                          anio,mes, medidor);
                    var rs = session.Execute(query);
                    foreach (Row row in rs)
                    {
                        ps = row["aniof"].ToString();
                        ps3 = row["mesf"].ToString();
                        ps2 = row["medidor"].ToString();
                        int m = 0;
                        m = Convert.ToInt32(ps2);
                        if (anio == ps && medidor == m && mes==ps3)
                        { existe = true; }
                    }

                    break;
                case 'S':
                    session = cluster.Connect(keyspace);
                    string query2 = String.Format("SELECT  AnioF,MesF,  Numero_Servicio  FROM ConsumoH WHERE  AnioF = '{0}' MesF= '{1}' AND  Numero_Servicio= {2} AND Generado= true ALLOW FILTERING; ",
                          anio,mes, servicio);
                    var rs2 = session.Execute(query2);
                    foreach (Row row in rs2)
                    {
                        ps3 = row["aniof"].ToString();
                        ps5 = row["mesf"].ToString();
                        ps4 = row["numero_servicio"].ToString();
                        int m = 0;
                        m = Convert.ToInt32(ps4);
                        if (anio == ps3 && servicio == m && mes== ps5)
                        { existe = true; }
                    }
                    break;
            }



            return existe;
        }



        //CLIENTES 
        public bool ReciboPDFCLIENTES( int servicio, string anio, string mes)
        {
            bool existe = false;
            var ps = "";
            var ps2 = "";
            var ps3 = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT  AnioF, MesF, Numero_Servicio  FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE  AnioF = '{0}' AND MesF= '{1}' AND Numero_Servicio= {2} ALLOW FILTERING; ",
                  anio, mes, servicio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["aniof"].ToString();
                ps2 = row["mesf"].ToString();
                ps3 = row["numero_servicio"].ToString();
                int i = 0;
                i = Convert.ToInt32(ps3);
                if (anio == ps && mes == ps2 && servicio == i)
                { existe = true; }
            }


            return existe;
        }
        public string TotalAPagar (int servicio, string anio, string mes)
        {
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT Cantidad_Pendiente FROM Recibo_por_Numero_Servicio_Anio_Mes  WHERE  AnioF = '{0}' AND MesF= '{1}' AND Numero_Servicio= {2} ALLOW FILTERING; ",
                  anio, mes,  servicio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["cantidad_pendiente"].ToString();


            }
            return ps;
        }

        public string Estatus(int servicio, string anio, string mes)
        {
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT Is_Paid FROM Recibo_por_Numero_Servicio_Anio_Mes  WHERE  AnioF = '{0}' AND MesF= '{1}' AND Numero_Servicio= {2} ALLOW FILTERING; ",
                  anio, mes, servicio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["is_paid"].ToString();
            }
            return ps;
        }


        public bool UPDATEPAGO (int servicio, string anio, string mes, string forma, float pendiente, float pagado, bool status)
        {
            bool queryCorrecto = true;
            try
            {
                var ps = "";
                var ps2 = "";
                var ps3 = "";
                var fechita1 = "";
                var num = "";
                int num2 = 0;
                session = cluster.Connect(keyspace);
                string query = String.Format("SELECT  Numero_Servicio, AnioF, MesF, Dia   FROM Recibo_por_Numero_Servicio_Anio_Mes WHERE  Numero_Servicio= {0} AND AnioF = '{1}' AND MesF= '{2}'  ALLOW FILTERING; ",
                      servicio, anio, mes);
                var rs = session.Execute(query);
                foreach (Row row in rs)
                {
                    num = row["numero_servicio"].ToString();
                    ps = row["aniof"].ToString();
                    ps2 = row["mesf"].ToString();
                    ps3= row["dia"].ToString();
                    num2 = Convert.ToInt32(num);
                    int aux = 0;

                    session = cluster.Connect(keyspace);
                    string qry = "UPDATE Recibo_por_Numero_Servicio_Anio_Mes SET Cantidad_Pagada = "+pagado+", Cantidad_Pendiente= "+ pendiente+", Is_Paid= "+status+"  WHERE Numero_Servicio = " + num2 + " AND AnioF='" + anio + "' AND MesF= '" + mes + "' AND Dia= '" + ps3 + "'  ;";

                    var rs2 = session.Execute(qry);
                }



            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
        public string CANTIDADPAGADA ( int servicio, string anio, string mes)
        {
            var ps = "";
            session = cluster.Connect(keyspace);
            string query = String.Format("SELECT Cantidad_Pagada FROM Recibo_por_Numero_Servicio_Anio_Mes  WHERE  AnioF = '{0}' AND MesF= '{1}' AND Numero_Servicio= {2} ALLOW FILTERING; ",
                  anio, mes, servicio);
            var rs = session.Execute(query);
            foreach (Row row in rs)
            {
                ps = row["cantidad_pagada"].ToString();


            }
            return ps;
        }
        public bool UPDATEPAGOMASIVO()
        {
            bool queryCorrecto = true;
            try
            {
                var ps = "";
                var ps2 = "";
                var ps3 = "";
                var ps4 = "";
                var num = "";
                int num2 = 0;
                session = cluster.Connect(keyspace);
                string query = String.Format("SELECT  Numero_Servicio, AnioF, MesF, Dia, Importe_IVA  FROM Recibo_por_Numero_Servicio_Anio_Mes ; ");
                var rs = session.Execute(query);
                foreach (Row row in rs)
                {
                    num = row["numero_servicio"].ToString();
                    ps = row["aniof"].ToString();
                    ps2 = row["mesf"].ToString();
                    ps3 = row["dia"].ToString();
                    ps4 = row["importe_iva"].ToString();
                    float cantp = 0;
                    cantp = Convert.ToSingle(ps4);
                    num2 = Convert.ToInt32(num);
                    int aux = 0;
                    session = cluster.Connect(keyspace);
                    string qry = "UPDATE Recibo_por_Numero_Servicio_Anio_Mes SET Cantidad_Pagada = " + cantp + ", Cantidad_Pendiente= " + 0 + ", Is_Paid= " + true + "  WHERE Numero_Servicio = " + num2 + " AND AnioF='" + ps + "' AND MesF= '" + ps2 + "' AND Dia= '" + ps3 + "'  ;";

                    var rs2 = session.Execute(qry);
                }



            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }
    }

    
}
