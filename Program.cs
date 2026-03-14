using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido al Sistema de Gestión de Biblioteca Montoya!");
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una opción: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Has seleccionado: Libros");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Has seleccionado: Usuarios");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Has seleccionado: Préstamos");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Has seleccionado: Búsquedas y reportes");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Has seleccionado: Guardar / Cargar datos");
                        Console.WriteLine("Presiona cualquier tecla para volver al menú...");
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Saliendo del sistema...");
                        salir = true;
                        break;
                    default:
                        Console.WriteLine(
                            "Opción no válida. Presiona cualquier tecla para intentar de nuevo..."
                        );
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine(
                    "Entrada no válida. Presiona cualquier tecla para intentar de nuevo..."
                );
                Console.ReadKey();
            }
        }
    }
}
