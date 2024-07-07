using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    abstract class Persona
    {
        // Propiedades
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Genero { get; set; }
        public int Edad { get; set; }
        public string Hospital { get; set; }

        // Constructor
        public Persona(string dni, string nombre, string apellido1, string apellido2, string genero, int edad, string hospital)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            Genero = genero;
            Edad = edad;
            Hospital = hospital;
        }

        // Método abstracto (debe ser implementado por clases derivadas)
        public abstract void MostrarInformacion();
    }
}