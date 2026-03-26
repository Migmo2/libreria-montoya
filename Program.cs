using System;
using System.Collections.Generic;
using libreria_montoya.Models;
using libreria_montoya.Services;

class Program
{
    static LibroService libroService = new LibroService();
    static UsuarioService usuarioService = new UsuarioService();
    static PrestamoService prestamoService = new PrestamoService();

    static void Main(string[] args)
    {
        Console.WriteLine("¡Bienvenido al Sistema de Biblioteca Montoya!");
        Console.WriteLine("Sitio: Servicios, KPI y demos de Array vs List");
        Console.WriteLine("Presiona cualquier tecla para iniciar...");
        Console.ReadKey();

        SeedData();

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. KPI de sistema");
            Console.WriteLine("5. Ejemplo: Array vs List");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": MenuLibros(); break;
                case "2": MenuUsuarios(); break;
                case "3": MenuPrestamos(); break;
                case "4": MenuKpis(); break;
                case "5": MenuArrayVsList(); break;
                case "6": salir = true; break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("¡Gracias por usar Biblioteca Montoya!");
    }

    static void SeedData()
    {
        if (libroService.TotalLibros() == 0)
        {
            libroService.AgregarLibro(new Libro(1, "Cien años de soledad", "Gabo", 1967));
            libroService.AgregarLibro(new Libro(2, "El principito", "Saint-Exupéry", 1943));
        }

        if (usuarioService.TotalUsuarios() == 0)
        {
            usuarioService.AgregarUsuario(new Usuario(1, "Miguel", "correo@mail.com"));
            usuarioService.AgregarUsuario(new Usuario(2, "Laura", "correo2@mail.com"));
        }

        if (prestamoService.TotalPrestamos() == 0)
        {
            var libro = libroService.ObtenerLibros().Find(l => l.Id == 1);
            var usuario = usuarioService.ObtenerUsuarios().Find(u => u.Id == 1);
            if (libro != null && usuario != null)
            {
                libro.Disponible = false;
                prestamoService.AgregarPrestamo(new Prestamo(1, libro, usuario, DateTime.Now.AddDays(-10)));
            }
        }
    }

    static void MenuLibros()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== MENU LIBROS ===");
            Console.WriteLine("1. Listar libros");
            Console.WriteLine("2. Agregar libro");
            Console.WriteLine("3. Eliminar libro (por ID)");
            Console.WriteLine("4. KPI Libros");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    foreach (var l in libroService.ObtenerLibros())
                    {
                        Console.WriteLine(l.DetalleCompleto());
                        Console.WriteLine("-------------------------");
                    }
                    break;
                case "2":
                    Console.Write("ID: "); int idLibro = int.Parse(Console.ReadLine());
                    Console.Write("Título: "); string titulo = Console.ReadLine();
                    Console.Write("Autor: "); string autor = Console.ReadLine();
                    Console.Write("Año: "); int anio = int.Parse(Console.ReadLine());
                    libroService.AgregarLibro(new Libro(idLibro, titulo, autor, anio));
                    Console.WriteLine("Libro agregado.");
                    break;
                case "3":
                    Console.Write("ID a eliminar: "); int idEliminar = int.Parse(Console.ReadLine());
                    libroService.EliminarLibro(idEliminar);
                    Console.WriteLine("Si existía, se eliminó");
                    break;
                case "4":
                    Console.WriteLine($"Total libos: {libroService.TotalLibros()}");
                    Console.WriteLine($"Disponibles: {libroService.LibrosDisponibles()}");
                    Console.WriteLine($"Prestados: {libroService.LibrosPrestados()}");
                    break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MenuUsuarios()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== MENU USUARIOS ===");
            Console.WriteLine("1. Listar usuarios");
            Console.WriteLine("2. Agregar usuario");
            Console.WriteLine("3. KPI Usuarios");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    foreach (var u in usuarioService.ObtenerUsuarios())
                    {
                        Console.WriteLine(u.DetalleCompleto());
                        Console.WriteLine("-------------------------");
                    }
                    break;
                case "2":
                    Console.Write("ID: "); int idUsuario = int.Parse(Console.ReadLine());
                    Console.Write("Nombre: "); string nombre = Console.ReadLine();
                    Console.Write("Email: "); string email = Console.ReadLine();
                    usuarioService.AgregarUsuario(new Usuario(idUsuario, nombre, email));
                    Console.WriteLine("Usuario agregado.");
                    break;
                case "3":
                    Console.WriteLine($"Total usuarios: {usuarioService.TotalUsuarios()}");
                    Console.WriteLine($"Activos: {usuarioService.UsuariosActivos()}");
                    Console.WriteLine($"Inactivos: {usuarioService.UsuariosInactivos()}");
                    break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MenuPrestamos()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRESTAMOS ===");
            Console.WriteLine("1. Listar préstamos");
            Console.WriteLine("2. Agregar préstamo de prueba");
            Console.WriteLine("3. KPI Préstamos");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    foreach (var p in prestamoService.ObtenerPrestamos())
                    {
                        Console.WriteLine(p.DetalleCompleto());
                        Console.WriteLine("-------------------------");
                    }
                    break;
                case "2":
                    var libro = libroService.ObtenerLibros().Count > 0 ? libroService.ObtenerLibros()[0] : null;
                    var usuario = usuarioService.ObtenerUsuarios().Count > 0 ? usuarioService.ObtenerUsuarios()[0] : null;
                    if (libro != null && usuario != null)
                    {
                        libro.Disponible = false;
                        prestamoService.AgregarPrestamo(new Prestamo(prestamoService.TotalPrestamos() + 1, libro, usuario, DateTime.Now.AddDays(-10)));
                        Console.WriteLine("Préstamo agregado.");
                    }
                    else
                    {
                        Console.WriteLine("Necesitas al menos un libro y un usuario registrados.");
                    }
                    break;
                case "3":
                    Console.WriteLine($"Total préstamos: {prestamoService.TotalPrestamos()}");
                    Console.WriteLine($"Activos: {prestamoService.PrestamosActivos()}");
                    Console.WriteLine($"Vencidos: {prestamoService.PrestamosVencidos()}");
                    Console.WriteLine($"Devueltos: {prestamoService.PrestamosDevueltos()}");
                    Console.WriteLine($"Promedio días de préstamo: {prestamoService.PromedioDiasPrestamo():0.00}");
                    break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
            Console.WriteLine("Presiona una tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void MenuKpis()
    {
        Console.Clear();
        Console.WriteLine("=== KPI de la biblioteca ===");
        Console.WriteLine($"Libros: {libroService.TotalLibros()} (Disponibles: {libroService.LibrosDisponibles()}, Prestados: {libroService.LibrosPrestados()})");
        Console.WriteLine($"Usuarios: {usuarioService.TotalUsuarios()} (Activos: {usuarioService.UsuariosActivos()})");
        Console.WriteLine($"Préstamos: {prestamoService.TotalPrestamos()} (Activos: {prestamoService.PrestamosActivos()}, Vencidos: {prestamoService.PrestamosVencidos()})");
        Console.WriteLine($"Promedio días préstamo: {prestamoService.PromedioDiasPrestamo():0.00}");
        Console.WriteLine("Presiona una tecla para volver...");
        Console.ReadKey();
    }

    static void MenuArrayVsList()
    {
        Console.Clear();
        Console.WriteLine("=== ARRAY vs LIST ===");

        Libro[] arrayLibros = new Libro[2];
        arrayLibros[0] = new Libro(1, "A", "Autor", 2000);
        arrayLibros[1] = new Libro(2, "B", "Autor", 2001);

        List<Libro> listaLibros = new List<Libro>();
        listaLibros.Add(new Libro(3, "C", "Autor", 2002));
        listaLibros.Add(new Libro(4, "D", "Autor", 2003));

        Console.WriteLine("Array (tamaño fijo):");
        foreach (var l in arrayLibros)
            Console.WriteLine(l.ResumenCorto());

        Console.WriteLine("List (dinámica):");
        foreach (var l in listaLibros)
            Console.WriteLine(l.ResumenCorto());

        Console.WriteLine("Presiona una tecla para volver...");
        Console.ReadKey();
    }
}
