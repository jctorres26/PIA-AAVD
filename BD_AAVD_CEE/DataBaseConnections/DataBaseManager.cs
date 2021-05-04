using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Cassandra;

namespace BD_AAVD_CEE.DataBaseConnections
{
    class DataBaseManager
    {
        private DataBaseManager()
        {
            cassandraHome = ConfigurationManager.AppSettings["cassanda_home"].ToString();
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
        /*
          //EJEMPLO DE COMO HACER EL QUERY 
          public void insertStudent(string name,string lastName,string motherLastName,string career,string semester) {
            string query = String.Format("INSERT INTO STUDENTS (STUDENT_ID,NAME,LAST_NAME,MOTHER_LAST_NAME,CAREER,SEMESTER,CREATION_DATE)" +
               "VALUES(uuid(), '{0}', '{1}', '{2}', '{3}', {4}, ToTimestamp(now()));"
               , name,lastName,motherLastName,career,semester);
            session = cluster.Connect(keyspace);
            session.Execute(query);
        } 
         
         */
    }
}
