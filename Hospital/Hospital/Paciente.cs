using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Paciente : Persona
    {
        public string RazonIngreso { get; set; }
        public string Seguro { get; set; }
        public Medico MedicoAsignado { get; set; }

        public Paciente(string dni, string nombre, string apellido1, string apellido2, string genero, int edad, string hospital, string razonIngreso, string seguro, Medico medicoAsignado = null)
            : base(dni, nombre, apellido1, apellido2, genero, edad, hospital)
        {
            RazonIngreso = razonIngreso;
            Seguro = seguro;
            MedicoAsignado = medicoAsignado;
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellidos: " + Apellido1 + " " + Apellido2);
            Console.WriteLine("Género: " + Genero);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Hospital: " + Hospital);
            Console.WriteLine("Razón de Ingreso: " + RazonIngreso);
            Console.WriteLine("Seguro: " + Seguro);
            if (MedicoAsignado != null)
            {
                Console.WriteLine("Médico Asignado: " + MedicoAsignado.Nombre + " " + MedicoAsignado.Apellido1 + " " + MedicoAsignado.Apellido2);
            }
            Console.WriteLine();
        }
    }
}