using BD_AAVD_CEE.ENTIDADES;
using Cassandra;
using Cassandra.Mapping;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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

        //EMPLEADOS
        //BD_AAVD_CEE.
        public bool InsertUpdateDeleteEmpleado(char Opc, ENTIDADES.Empleado_por_Id_Empleado vEmpleado)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'I':
                        string query = String.Format("INSERT INTO Empleado_por_Id_Empleado (Id_Empleado,CURP,RFC,Nombre,Apellido_Paterno,Apellido_Materno,Fecha_Nacimiento, Nombre_Usuario, Contrasenia,Activo,Fecha_Alta)" +
                        "VALUES(uuid(),'{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}','{7}',true, toDate(now()));"
                      ,  vEmpleado.CURP, vEmpleado.RFC, vEmpleado.Nombre, vEmpleado.Apellido_Paterno, vEmpleado.Apellido_Materno, vEmpleado.Fecha_Nacimiento.ToString("yyyy-MM-dd"), vEmpleado.Nombre_Usuario, vEmpleado.Contrasenia, vEmpleado.Activo, vEmpleado.Fecha_Alta.ToString("yyyy-MM-dd"));
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
                            "RFC= '{8}' " +
                            "WHERE Id_Empleado =  {0} ; "
                            //por alguna razon no lo actualiza?
                        , vEmpleado.Id_Empleado, vEmpleado.Nombre, vEmpleado.Apellido_Paterno, vEmpleado.Apellido_Materno, vEmpleado.Fecha_Nacimiento.ToString("yyyy-MM-dd"),vEmpleado.Nombre_Usuario, vEmpleado.Contrasenia, vEmpleado.CURP, vEmpleado.RFC);
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
         public IEnumerable<Empleado_por_Id_Empleado> ObtenerEmpleado(char Opc,Empleado_por_Id_Empleado vEmpleado)
        {
            IEnumerable<Empleado_por_Id_Empleado> Empleados = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<Empleado_por_Id_Empleado> listaEmpleados = null;

             switch (Opc)
            {
                case 'S':
                    string query = "SELECT Id_Empleado AS Id_Empleado, CURP AS CURP, RFC AS RFC, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Fecha_Nacimiento AS Fecha_Nacimiento_C, Nombre_Usuario AS Nombre_Usuario, Contrasenia AS Contrasenia " +
                        "FROM Empleado_por_Id_Empleado "+
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
        public bool Contratos (char Opc , Contrato_por_Numero_Servicio vContrato, Cliente_por_Id_Cliente vCliente)
        {
            bool queryCorrecto = true;
            try
            {
                switch (Opc)
                {
                    case 'I':
                        string query = String.Format("BEGIN BATCH " +
                            "INSERT INTO Contrato_por_Numero_Servicio " +
                            "(Numero_Servicio, NumSer, Numero_Medidor, Tipo_Servicio, Estado, Ciudad, Colonia, Calle, CP, Numero_Exterior,Id_Cliente) " +
                            "VALUES ({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}',{9}, {10}); " +
                            "INSERT INTO Cliente_por_Id_Cliente " +
                            "(Id_Cliente,CURP,Nombre, Apellido_Paterno,Apellido_Materno,Genero, Nombre_Usuario,Contrasenia) " +
                            "VALUES ({11}, '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}' );" +
                            "APPLY BATCH ;" 
                            , (vContrato.Numero_Servicio, vContrato.NumSer, vContrato.Numero_Medidor, 
                            vContrato.Tipo_Servicio, vContrato.Estado, vContrato.Ciudad, vContrato.Colonia, vContrato.Calle,
                            vContrato.CP, vContrato.Numero_Exterior, vCliente.Id_Cliente, vCliente.Id_Cliente, vCliente.CURP,
                            vCliente.Nombre, vCliente.Apellido_Paterno, vCliente.Apellido_Materno, vCliente.Genero, vCliente.Contrasenia)
                             );
                        session = cluster.Connect(keyspace);
                        session.Execute(query);
                        break;
                    case 'U':
                       


                        break;
                    case 'D':
                        

                        break;

                }


            }
            catch (Exception e)
            {
                throw e;
            }


            return queryCorrecto;
        }

        /*public IEnumerable <NumServ> ObtenerNumero( char Opc, NumServ vServicio)
        {
            IEnumerable<NumServ> Servicios  = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<NumServ> listaServicios = null;

            switch (Opc)
            {
                case 'S':
                    string query = "SELECT numero AS numero " +
                        "FROM NumServ ; ";
                    Servicios = mapper.Fetch<NumServ>(query);

                    break;

             

            }
            if (Servicios != null)
            {
                listaServicios = Servicios.ToList();

               
            }



            return listaServicios;
        }*/
    }
}
