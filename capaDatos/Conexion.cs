using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace capaDatos
{
    public class Conexion
    {
        //coexión a la base de datos en forma de cadena
        public static string cn = ConfigurationManager.ConnectionStrings["cadena"].ToString();
    }
}
