using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class PersonalAdministrativo : Persona
    {
        public string Cargo { get; set; }

        public PersonalAdministrativo(string dni, string nombre, string apellido1, string apellido2, string genero, int edad, string hospital, string cargo)
            : base(dni, nombre, apellido1, apellido2, genero, edad, hospital)
        {
            Cargo = cargo;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellidos: " + Apellido1 + " " + Apellido2);
            Console.WriteLine("Genero: " + Genero);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Cargo: " + Cargo);
        }
    }
}

