using System;
using System.Collections.Generic;

namespace Hospital
{
    internal class Medico : PersonalAdministrativo
    {
        public string Especialidad { get; set; }
        public List<Paciente> PacientesAsignados { get; set; } 

        public Medico(string dni, string nombre, string apellido1, string apellido2, string genero, int edad, string hospital, string especialidad)
            : base(dni, nombre, apellido1, apellido2, genero, edad, hospital, "Médico")
        {
            Especialidad = especialidad;
            PacientesAsignados = new List<Paciente>();
        }

        // Método para asignar un paciente al médico
        public void AsignarPaciente(Paciente paciente)
        {
            PacientesAsignados.Add(paciente);
        }

        // Método para mostrar los pacientes asignados al médico
        public void MostrarPacientesAsignados()
        {
            Console.WriteLine($"Pacientes asignados al médico {Nombre} {Apellido1} {Apellido2}:");
            foreach (var paciente in PacientesAsignados)
            {
                Console.WriteLine($"- {paciente.Nombre} {paciente.Apellido1} {paciente.Apellido2}");
            }
        }

        public override void MostrarInformacion()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellidos: " + Apellido1 + " " + Apellido2);
            Console.WriteLine("Genero: " + Genero);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("Edad: " + Edad);
            Console.WriteLine("Hospital: " + Hospital);
            Console.WriteLine("Especialidad: " + Especialidad);
        }
    }
}
