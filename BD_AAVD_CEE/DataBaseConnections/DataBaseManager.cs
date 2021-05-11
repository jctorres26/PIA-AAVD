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
                        List<Empleado_por_Id_Empleado> empleadoElegido = this.ObtenerEmpleado('S', vEmpleado).ToList();

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
         public IEnumerable<Empleado_por_Id_Empleado> ObtenerEmpleado(char Opc,Empleado_por_Id_Empleado vEmpleado)
        {
            IEnumerable<Empleado_por_Id_Empleado> Empleados = null;
            session = cluster.Connect(keyspace);
            IMapper mapper = new Mapper(session);
            List<Empleado_por_Id_Empleado> listaEmpleados = null;

             switch (Opc)
            {
                case 'S':
                    string query = "SELECT Id_Empleado AS Id_Empleado, CURP AS CURP, RFC AS RFC, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Fecha_Nacimiento AS Fecha_Nacimiento_C, Nombre_Usuario AS Nombre_Usuario, Contrasenia AS Contrasenia, Fecha_Nacimiento AS Fecha_Nacimiento_C " +
                        "FROM Empleado_por_Id_Empleado "+
                        "WHERE Id_Empleado = ? ;";
                  
                    Empleados = mapper.Fetch<Empleado_por_Id_Empleado>(query, vEmpleado.Id_Empleado);
                    
                    break;

                case 'X':
                    string query2 = "SELECT Id_Empleado AS Id_Empleado, CURP AS CURP, RFC AS RFC, Nombre AS Nombre, Apellido_Paterno AS Apellido_Paterno, Apellido_Materno AS Apellido_Materno, Nombre_Usuario AS Nombre_Usuario, Contrasenia AS Contrasenia, Fecha_Nacimiento AS Fecha_Nacimiento_C " +
                        "FROM Empleado_por_Id_Empleado ;";
                
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
        
    }
}
