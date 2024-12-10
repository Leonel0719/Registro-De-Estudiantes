using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Registro_de_estudiantes
{   //Clase para conectarse a la base de datos.
    public class BDAlumno  
    {   //Metodo para conectarse a la base de datos.
        public static SqlConnection ObtenerConexion()
        {   //Cadena de conexion para acceder a la base de datos.                                               
            SqlConnection conexion = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDAlumnos;Data Source=LeonelPc");
            conexion.Open();

            return conexion;
        }
    }
}
