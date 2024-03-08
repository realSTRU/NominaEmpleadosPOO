using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Nomina
{
    class Program
    {
        static List<Empleado> empleados = new List<Empleado>();

        static void Main(string[] args)
        {
            int opcion = 0;
            string valor = "";
            do
            {
                Console.Clear();
                Console.WriteLine("~~ Menu de Nomina ~~");
                Console.WriteLine("\n1. Registrar Empleado\n2.Borrar Empleado\n3.Actualizar Empleado\n4.Buscar Empleado\n5. Listar Nomina\n6. Salir");
                Console.Write("\nOpcion: ");
                valor = Console.ReadLine();
                opcion = Convert.ToInt32(valor);

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        RegistrarEmpleado();
                        Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        BorrarEmpleado();
                        Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        ActualizarEmpleado();
                        Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        BuscarEmpleado();
                        Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        ListarNomina();
                        Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("\n\nOpcion incorrecta!");
                        if (opcion != 3)
                            Console.Write("\n\nPresione ENTER para continuar...");
                        Console.ReadLine();
                        break;

                }
            } while (opcion != 6 || opcion < 6 && opcion > 0);
        }

        public static void RegistrarEmpleado()
        {
            string nombre = "";
            string apellido = "";
            string cedula = "";
            string telefono = "";
            string direccion = "";
            string departamento = "";
            string puesto = "";
            float sueldo = 0;
            string valor = "";
            string horasExtras="";
            int horas = 0;

            Console.WriteLine("~~ Registrar Empleado ~~");

            Console.Write("Digite los nombres: ");
            nombre = Console.ReadLine();

            Console.Write("Digite los apellidos: ");
            apellido = Console.ReadLine();

            Console.Write("Digite la cedula: ");
            cedula = Console.ReadLine();

            Console.Write("Digite el numero de telefono: ");
            telefono = Console.ReadLine();

            Console.Write("Digite la direccion: ");
            direccion = Console.ReadLine();

            Console.Write("Digite el departamento: ");
            departamento = Console.ReadLine();

            Console.Write("Digite el puesto: ");
            puesto = Console.ReadLine();

            Console.Write("Digite el sueldo: ");
            valor = Console.ReadLine();
            sueldo = Convert.ToSingle(valor);
            Console.Write("Digite las horas extra Iniciales:");
            horasExtras = Console.ReadLine();
            horas = Convert.ToInt32(horasExtras);
            
            Empleado empleado = new Empleado(nombre,apellido, cedula, telefono, direccion, departamento, puesto, sueldo, horas);
            empleado.GetSueldoNeto();
            empleados.Add(empleado);
            Console.WriteLine("Empleado Registrado!");
        }
        static void BuscarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a buscar:");
            string cedula = Console.ReadLine();
            var r = empleados.Find(e => e.cedula == cedula);
            Empleado empleadoEncontrado = r;

            if (empleadoEncontrado != null)
            {
                Console.WriteLine("Empleado encontrado:");
                Console.WriteLine(empleadoEncontrado);
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        static void BorrarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a borrar:");
            string cedula = Console.ReadLine();

            Empleado empleadoBorrar = empleados.Find(empleado => empleado.cedula == cedula);

            if (empleadoBorrar != null)
            {
                empleados.Remove(empleadoBorrar);
                Console.WriteLine("Empleado borrado correctamente.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        static void ActualizarEmpleado()
        {
            Console.WriteLine("Ingrese la cédula del empleado a actualizar:");
            string cedula = Console.ReadLine();

            Empleado empleadoActualizar = empleados.Find(empleado => empleado.cedula == cedula);
            empleados.Remove(empleadoActualizar);

            if (empleadoActualizar != null)
            {
                Console.WriteLine("Ingrese el nuevo nombre:");
                empleadoActualizar.nombre = Console.ReadLine();
                Console.WriteLine("Ingrese los nuevos apellidos:");
                empleadoActualizar.apellido = Console.ReadLine();
                Console.WriteLine("Ingrese la nueva dirección:");
                empleadoActualizar.direccion = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo teléfono:");
                empleadoActualizar.telefono = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo departamento:");
                empleadoActualizar.departamento = Console.ReadLine();
                Console.WriteLine("Ingrese el nuevo puesto:");
                empleadoActualizar.puesto = Console.ReadLine();

                Console.WriteLine("Empleado actualizado correctamente.");
                empleados.Add(empleadoActualizar);
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
                
            }
        }

        public static void ListarNomina()
        {
            Console.WriteLine("NOMINA DE EMPLEADOS");
            foreach (Empleado e in empleados)
            {
                Console.WriteLine("\n\n"+e.ToString());
            }
        }
    }
}
