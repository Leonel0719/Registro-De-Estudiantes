using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_estudiantes
{   //Clase para añadir los metodos 
    public class AlumnoDAL
    {   
        //Metodo Para agregar un registro a la base de datos ↓↓↓↓↓↓↓↓
        public static int AgregarAlumno(Alumno alumno)
        {
            int retorna = 0;

            using (SqlConnection conexion = BDAlumno.ObtenerConexion())
            {   
                //Comando para insertar elnregistro en la base de datos↓↓↓
                string query = "Insert Into Alumno (Nombre,Apellido,Edad,Direccion,Responsable,Telefono)Values('"+alumno.Nombre+"' , '"+alumno.Apellido+"' , "+alumno.Edad+" , '"+alumno.Direccion+"' , '"+alumno.Responsable+"' , '"+alumno.Telefono+"')";
                SqlCommand comando = new SqlCommand(query,conexion);

                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        } 

        //Metodo para presentar los registros en del DataGridView ↓↓↓↓
        public static List<Alumno> PresentarRegistro()
        {
            List<Alumno> lista = new List<Alumno>();

            //Comando para mostrar todos los registro en el DataView
            using (SqlConnection conexion = BDAlumno.ObtenerConexion())
            {   
                //Comando para mostrar todos los registro en el DataView↓↓↓↓↓↓
                string query = "Select *From Alumno";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.Id = reader.GetInt32(0);
                    alumno.Nombre = reader.GetString(1);
                    alumno.Apellido = reader.GetString(2);
                    alumno.Edad = reader.GetInt32(3);
                    alumno.Direccion = reader.GetString(4);
                    alumno.Responsable = reader.GetString(5);
                    alumno.Telefono = reader.GetString(6);
                    lista.Add(alumno);
                }

                conexion.Close();
                return lista;
            }
                
        }

        //Metodo para modificar alumno(Falta modificarlo y adaptarlo con un boton independiente)
        public static int ModificarAlumno(Alumno alumno)
        {
            int result = 0;
            using (SqlConnection conexion = BDAlumno.ObtenerConexion())
            {
                string query = "update Alumno set Nombre='"+alumno.Nombre+"' , Apellido='"+alumno.Apellido+"' , Edad="+alumno.Edad+" , Direccion='"+alumno.Direccion+"' , Responsable='"+alumno.Responsable+"' , Telefono='"+alumno.Telefono+"' where Id="+alumno.Id+" ";
                SqlCommand comando = new SqlCommand( query, conexion);

                result = comando.ExecuteNonQuery();
                conexion.Close();
            }

            return result;
        }

        //Metodo para eliminar alumno.
        public static int EliminarAlumno(int id)
        {
            int retorna = 0;

            using (SqlConnection conexion = BDAlumno.ObtenerConexion())
            {
                string query = "delete from Alumno where Id=" + id + "";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }
    }
}
