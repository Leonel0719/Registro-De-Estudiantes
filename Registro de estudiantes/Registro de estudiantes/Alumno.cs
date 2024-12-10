using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_estudiantes
{   
    //Clase donde se agregan las variables
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Direccion {get; set; }
        public string Responsable { get; set; }
        public string Telefono { get; set; }

        //Constructor 
        public Alumno() { }

        public Alumno(int id, string nombre, string apellido, int edad, string direccion, string responsable, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            Direccion = direccion;
            Responsable = responsable;
            Telefono = telefono;
        }
    }
}
