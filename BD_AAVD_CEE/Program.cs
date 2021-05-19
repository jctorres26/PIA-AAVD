using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE
{
    static class Program
    {
        public static string usuarioIng = "";
        public static string ContraIng = "";
        public static int cont2 = 0;
        public static int Contador2 = 0;
        public static int Contador = 0;
        public static int CBasico = 150;
        public static int CIntermedio = 75;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
