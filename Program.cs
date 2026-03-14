using System;

class Program
{
    static void Main(string[] args)
    {
        // Datos de libros (arrays fijos, tamaño máximo 100)
        string[] isbn = new string[100];
        string[] titulos = new string[100];
        string[] autores = new string[100];
        string[] categorias = new string[100];
        int[] anios = new int[100];
        bool[] disponibles = new bool[100];
        int contadorLibros = 0;

        Console.WriteLine("¡Bienvenido al Sistema de Gestión de Biblioteca Montoya!");
        Console.WriteLine("Aquí puedes gestionar libros, usuarios y préstamos.");
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

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Submenú de Libros
                    bool volverMenuPrincipal = false;
                    while (!volverMenuPrincipal)
                    {
                        Console.Clear();
                        Console.WriteLine("=== MENÚ LIBROS ===");
                        Console.WriteLine("1. Registrar libro");
                        Console.WriteLine("2. Listar libros");
                        Console.WriteLine("3. Ver detalle de libro (por ID/ISBN)");
                        Console.WriteLine("4. Actualizar libro");
                        Console.WriteLine("5. Eliminar libro");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Selecciona una opción: ");

                        string subOpcion = Console.ReadLine();

                        switch (subOpcion)
                        {
                            case "1":
                                // Registrar libro
                                if (contadorLibros < 100)
                                {
                                    Console.Write("ISBN: ");
                                    isbn[contadorLibros] = Console.ReadLine();
                                    Console.Write("Título: ");
                                    titulos[contadorLibros] = Console.ReadLine();
                                    Console.Write("Autor: ");
                                    autores[contadorLibros] = Console.ReadLine();
                                    Console.Write("Categoría: ");
                                    categorias[contadorLibros] = Console.ReadLine();
                                    Console.Write("Año: ");
                                    anios[contadorLibros] = int.Parse(Console.ReadLine());
                                    disponibles[contadorLibros] = true;
                                    contadorLibros++;
                                    Console.WriteLine("Libro registrado exitosamente.");
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "No se pueden registrar más libros (límite alcanzado)."
                                    );
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "2":
                                // Listar libros - submenú
                                Console.Clear();
                                Console.WriteLine("=== LISTAR LIBROS ===");
                                Console.WriteLine("1. Listar todos");
                                Console.WriteLine("2. Listar disponibles");
                                Console.WriteLine("3. Listar prestados");
                                Console.Write("Selecciona: ");
                                string listOpcion = Console.ReadLine();
                                switch (listOpcion)
                                {
                                    case "1":
                                        Console.WriteLine("=== TODOS LOS LIBROS ===");
                                        for (int i = 0; i < contadorLibros; i++)
                                        {
                                            Console.WriteLine(
                                                $"{isbn[i]} - {titulos[i]} - {autores[i]} - {(disponibles[i] ? "Disponible" : "Prestado")}"
                                            );
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("=== LIBROS DISPONIBLES ===");
                                        for (int i = 0; i < contadorLibros; i++)
                                        {
                                            if (disponibles[i])
                                            {
                                                Console.WriteLine(
                                                    $"{isbn[i]} - {titulos[i]} - {autores[i]}"
                                                );
                                            }
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("=== LIBROS PRESTADOS ===");
                                        for (int i = 0; i < contadorLibros; i++)
                                        {
                                            if (!disponibles[i])
                                            {
                                                Console.WriteLine(
                                                    $"{isbn[i]} - {titulos[i]} - {autores[i]}"
                                                );
                                            }
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida.");
                                        break;
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "3":
                                // Ver detalle
                                Console.Write("Ingresa ID/ISBN: ");
                                string buscarIsbn = Console.ReadLine();
                                bool encontrado = false;
                                for (int i = 0; i < contadorLibros; i++)
                                {
                                    if (isbn[i] == buscarIsbn)
                                    {
                                        Console.WriteLine($"ISBN: {isbn[i]}");
                                        Console.WriteLine($"Título: {titulos[i]}");
                                        Console.WriteLine($"Autor: {autores[i]}");
                                        Console.WriteLine($"Categoría: {categorias[i]}");
                                        Console.WriteLine($"Año: {anios[i]}");
                                        Console.WriteLine(
                                            $"Disponible: {(disponibles[i] ? "Sí" : "No")}"
                                        );
                                        encontrado = true;
                                        break;
                                    }
                                }
                                if (!encontrado)
                                {
                                    Console.WriteLine("Libro no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "4":
                                // Actualizar libro - submenú
                                Console.Write("Ingresa ID/ISBN del libro a actualizar: ");
                                string actualizarIsbn = Console.ReadLine();
                                int index = -1;
                                for (int i = 0; i < contadorLibros; i++)
                                {
                                    if (isbn[i] == actualizarIsbn)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                if (index != -1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("=== ACTUALIZAR LIBRO ===");
                                    Console.WriteLine("1. Editar título");
                                    Console.WriteLine("2. Editar autor");
                                    Console.WriteLine("3. Editar año / categoría");
                                    Console.Write("Selecciona: ");
                                    string updateOpcion = Console.ReadLine();
                                    switch (updateOpcion)
                                    {
                                        case "1":
                                            Console.Write("Nuevo título: ");
                                            titulos[index] = Console.ReadLine();
                                            break;
                                        case "2":
                                            Console.Write("Nuevo autor: ");
                                            autores[index] = Console.ReadLine();
                                            break;
                                        case "3":
                                            Console.Write("Nuevo año: ");
                                            anios[index] = int.Parse(Console.ReadLine());
                                            Console.Write("Nueva categoría: ");
                                            categorias[index] = Console.ReadLine();
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                    Console.WriteLine("Libro actualizado.");
                                }
                                else
                                {
                                    Console.WriteLine("Libro no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "5":
                                // Eliminar libro
                                Console.Write("Ingresa ID/ISBN del libro a eliminar: ");
                                string eliminarIsbn = Console.ReadLine();
                                int elimIndex = -1;
                                for (int i = 0; i < contadorLibros; i++)
                                {
                                    if (isbn[i] == eliminarIsbn)
                                    {
                                        elimIndex = i;
                                        break;
                                    }
                                }
                                if (elimIndex != -1)
                                {
                                    if (!disponibles[elimIndex])
                                    {
                                        Console.WriteLine(
                                            "No se puede eliminar un libro prestado."
                                        );
                                    }
                                    else
                                    {
                                        // Eliminar moviendo el último al lugar del eliminado
                                        isbn[elimIndex] = isbn[contadorLibros - 1];
                                        titulos[elimIndex] = titulos[contadorLibros - 1];
                                        autores[elimIndex] = autores[contadorLibros - 1];
                                        categorias[elimIndex] = categorias[contadorLibros - 1];
                                        anios[elimIndex] = anios[contadorLibros - 1];
                                        disponibles[elimIndex] = disponibles[contadorLibros - 1];
                                        contadorLibros--;
                                        Console.WriteLine("Libro eliminado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Libro no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "0":
                                volverMenuPrincipal = true;
                                break;
                            default:
                                Console.WriteLine(
                                    "Opción no válida. Presiona cualquier tecla para intentar de nuevo..."
                                );
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Has seleccionado: Usuarios");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Has seleccionado: Préstamos");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Has seleccionado: Búsquedas y reportes");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("Has seleccionado: Guardar / Cargar datos");
                    Console.WriteLine("Presiona cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;
                case "6":
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
    }
}
