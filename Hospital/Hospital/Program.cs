using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            List<Persona> personasHospital = new List<Persona>();

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("1. Dar de alta a un médico.");
                Console.WriteLine("2. Dar de alta a un paciente.");
                Console.WriteLine("3. Dar de alta a personal amdinistrativo.");
                Console.WriteLine("4. Listar los médicos");
                Console.WriteLine("5. Listar los paciente de un médico");
                Console.WriteLine("6. Eliminar un paciente");
                Console.WriteLine("7. Ver lista de personas del hospital");
                Console.WriteLine("0. Salir");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        darAltaMedico();
                        break;

                    case 2:
                        darAltaPaciente();
                        break;

                    case 3:
                        darAltaAdministrativo();
                        break;

                    case 4:
                        listarMedicos();
                        break;

                    case 5:
                        listarPacientesDeMedico();
                        break;

                    case 6:
                        eliminarPaciente();
                        break;
                    
                    case 7:
                        listarPersonasHospital();
                        break;

                    case 0:
                        salir = true;
                        break;

                    default:
                        break;
                }
            }

            void darAltaMedico()
            {
                Console.WriteLine("Introduce un DNI:");
                string dni = Console.ReadLine();
                Console.WriteLine("Introduce un Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Primer apellido:");
                string apellido1 = Console.ReadLine();
                Console.WriteLine("Segundo apellido :");
                string apellido2 = Console.ReadLine();
                Console.WriteLine("Introduce el genero:");
                string genero = Console.ReadLine();
                Console.WriteLine("Introduce la edad:");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el hospital asignado: ");
                string hospital = Console.ReadLine();
                Console.WriteLine("Introduce la especialidad");
                string especialidad = Console.ReadLine();

                Medico nuevoMedico = new Medico(dni, nombre, apellido1, apellido2, genero, edad, hospital, especialidad);
                personasHospital.Add(nuevoMedico);
                Console.WriteLine();
                Console.WriteLine("Se ha guardado la información");
                Console.ReadKey();
            }

            void darAltaPaciente()
            {
                Console.WriteLine("Introduce un DNI:");
                string dni = Console.ReadLine();
                Console.WriteLine("Introduce un Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Primer apellido:");
                string apellido1 = Console.ReadLine();
                Console.WriteLine("Segundo apellido :");
                string apellido2 = Console.ReadLine();
                Console.WriteLine("Introduce el genero:");
                string genero = Console.ReadLine();
                Console.WriteLine("Introduce la edad:");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el hospital asignado: ");
                string hospital = Console.ReadLine();
                Console.WriteLine("Razon del ingreso:");
                string razonIngreso = Console.ReadLine();
                Console.WriteLine("Introduce el nombre del seguro:");
                string seguro = Console.ReadLine();

                Console.WriteLine("Seleccione el médico a asignar:");
                Console.WriteLine();
                List<Medico> medicos = listarMedicosRetornados();
                for (int i = 0; i < medicos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {medicos[i].Nombre} {medicos[i].Apellido1} {medicos[i].Apellido2}");
                }
                int medicoSeleccionado = int.Parse(Console.ReadLine()) - 1;
                Medico medicoAsignado = medicos[medicoSeleccionado];

                Paciente nuevoPaciente = new Paciente(dni, nombre, apellido1, apellido2, genero, edad, hospital, razonIngreso, seguro, medicoAsignado);
                personasHospital.Add(nuevoPaciente);
                medicoAsignado.AsignarPaciente(nuevoPaciente); // Asignar el paciente al médico

                Console.WriteLine();
                Console.WriteLine("Se ha guardado la información");
                Console.ReadKey();
            }

            void darAltaAdministrativo()
            {
                Console.WriteLine("Introduce un DNI:");
                string dni = Console.ReadLine();
                Console.WriteLine("Introduce un Nombre:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Primer apellido:");
                string apellido1 = Console.ReadLine();
                Console.WriteLine("Segundo apellido :");
                string apellido2 = Console.ReadLine();
                Console.WriteLine("Introduce el genero:");
                string genero = Console.ReadLine();
                Console.WriteLine("Introduce la edad:");
                int edad = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce el hospital asignado: ");
                string hospital = Console.ReadLine();
                Console.WriteLine("Introduce el cargo");
                string cargo = Console.ReadLine();

                PersonalAdministrativo personalA = new PersonalAdministrativo(dni, nombre, apellido1, apellido2, genero, edad, hospital, cargo);
                personasHospital.Add(personalA);
                Console.WriteLine();
                Console.WriteLine("Se ha guardado la información");
                Console.ReadKey();
            }

            void listarMedicos()
            {
                foreach (Persona p in personasHospital)
                {
                    if (p is Medico m)
                    {
                        Console.WriteLine("Nombre: " + m.Nombre);
                        Console.WriteLine("Apellidos: " + m.Apellido1 + " " + m.Apellido2);
                        Console.WriteLine("Genero: " + m.Genero);
                        Console.WriteLine("DNI: " + m.DNI);
                        Console.WriteLine("Edad: " + m.Edad);
                        Console.WriteLine("Hospital: " + m.Hospital);
                        Console.WriteLine("Especialidad: " + m.Especialidad);
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }

            void listarPacientesDeMedico()
            {
                Console.WriteLine("Seleccione el médico cuyos pacientes desea listar:");
                List<Medico> medicos = listarMedicosRetornados();
                for (int i = 0; i < medicos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {medicos[i].Nombre} {medicos[i].Apellido1} {medicos[i].Apellido2}");
                }
                int medicoSeleccionado = int.Parse(Console.ReadLine()) - 1;
                Medico medico = medicos[medicoSeleccionado];

                medico.MostrarPacientesAsignados();
                Console.ReadKey();
            }

            void eliminarPaciente()
            {
                foreach (Persona p in personasHospital)
                {
                    if (p is Paciente pa)
                    {
                        Console.WriteLine(pa.Nombre + " " + pa.Apellido1 + " " + pa.Apellido2);
                        Console.WriteLine(pa.DNI);
                    }
                }
                Console.WriteLine("Introduce el DNI del paciente a eliminar:");
                string dni = Console.ReadLine();
                Paciente pacienteAEliminar = null;

                foreach (Persona p in personasHospital)
                {
                    if (p is Paciente pa && pa.DNI == dni)
                    {
                        pacienteAEliminar = pa;
                        break;
                    }
                }

                if (pacienteAEliminar != null)
                {
                    // Eliminar el paciente de la lista de su médico
                    pacienteAEliminar.MedicoAsignado?.PacientesAsignados.Remove(pacienteAEliminar);
                    // Eliminar el paciente de la lista de personas del hospital
                    personasHospital.Remove(pacienteAEliminar);
                    Console.WriteLine("El paciente ha sido eliminado.");
                }
                else
                {
                    Console.WriteLine("No se encontró un paciente con el DNI proporcionado.");
                }

                Console.ReadKey();
            }

            void listarPersonasHospital()
            {
                Console.WriteLine("Introduce el nombre del Hospital");
                string hospName = Console.ReadLine();
                foreach (Persona p in personasHospital)
                {
                    if (p.Hospital == hospName)
                    {
                        if (p is Medico m)
                        {
                            m.MostrarInformacion();
                            Console.WriteLine();
                        }
                        else if (p is Paciente pa)
                        {
                            pa.MostrarInformacion();
                            Console.WriteLine();
                        }
                        else if (p is PersonalAdministrativo personal)
                        {
                            personal.MostrarInformacion();
                            Console.WriteLine();
                        }
                    }
                }
            }

            List<Medico> listarMedicosRetornados()
            {
                List<Medico> medicos = new List<Medico>();
                foreach (Persona p in personasHospital)
                {
                    if (p is Medico m)
                    {
                        medicos.Add(m);
                    }
                }
                return medicos;
            }

        }
    }
}