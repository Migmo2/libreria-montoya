using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;
using libreria_montoya.Services;

class Program
{
    static LibroService libroService = new LibroService();
    static UsuarioService usuarioService = new UsuarioService();
    static PrestamoService prestamoService = new PrestamoService();
    static bool datosGuardados = false;

    static void Main(string[] args)
    {
        if (args.Contains("--self-test"))
        {
            RunSelfTest();
            return;
        }

        Console.WriteLine("¡Bienvenido al Sistema de Biblioteca Montoya!");
        Console.WriteLine("Menú completo con libros, usuarios, préstamos, búsquedas y reportes.");
        Console.WriteLine("Presiona cualquier tecla para iniciar...");
        Console.ReadKey();

        SeedData();

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            ShowMainMenu();
            switch (Console.ReadLine())
            {
                case "1": ShowBooksMenu(); break;
                case "2": ShowUsersMenu(); break;
                case "3": ShowLoansMenu(); break;
                case "4": ShowSearchReportsMenu(); break;
                case "5": ShowPersistenceMenu(); break;
                case "6": salir = ConfirmExitAndSave(); break;
                default:
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                    Pause();
                    break;
            }
        }

        Console.WriteLine("Gracias por usar Biblioteca Montoya.");
    }

    static void SeedData()
    {
        if (libroService.TotalLibros() == 0)
        {
            libroService.AgregarLibro(new Libro(1, "Cien años de soledad", "Gabriel García Márquez", 1967, "Novela"));
            libroService.AgregarLibro(new Libro(2, "El principito", "Antoine de Saint-Exupéry", 1943, "Infantil"));
        }

        if (usuarioService.TotalUsuarios() == 0)
        {
            usuarioService.AgregarUsuario(new Usuario(1, "Miguel", "miguel@mail.com"));
            usuarioService.AgregarUsuario(new Usuario(2, "Laura", "laura@mail.com"));
        }

        if (prestamoService.TotalPrestamos() == 0)
        {
            var libro = libroService.BuscarPorId(1);
            var usuario = usuarioService.BuscarPorId(1);
            if (libro != null && usuario != null)
            {
                libro.Disponible = false;
                prestamoService.AgregarPrestamo(new Prestamo(1, libro, usuario, DateTime.Now.AddDays(-10)));
            }
        }
    }

    static void ShowMainMenu()
    {
        ShowSectionTitle("MENÚ PRINCIPAL");
        Console.WriteLine("1. Libros");
        Console.WriteLine("2. Usuarios");
        Console.WriteLine("3. Préstamos");
        Console.WriteLine("4. Búsquedas y reportes");
        Console.WriteLine("5. Guardar / Cargar datos");
        Console.WriteLine("6. Salir");
        Console.Write("Opción: ");
    }

    static void ShowBooksMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("MENU LIBROS");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle por ID");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": RegisterBook(); break;
                case "2": ListBooksMenu(); break;
                case "3": ViewBookDetail(); break;
                case "4": UpdateBookMenu(); break;
                case "5": DeleteBook(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowUsersMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("MENU USUARIOS");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle por ID");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": RegisterUser(); break;
                case "2": ListUsers(); break;
                case "3": ViewUserDetail(); break;
                case "4": UpdateUserMenu(); break;
                case "5": DeleteUser(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowLoansMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("MENU PRESTAMOS");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle por ID");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": CreateLoan(); break;
                case "2": ListLoansMenu(); break;
                case "3": ViewLoanDetail(); break;
                case "4": RegisterReturn(); break;
                case "5": DeleteLoan(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowSearchReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("BUSQUEDAS Y REPORTES");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": SearchBook(); break;
                case "2": SearchUser(); break;
                case "3": ReportsMenu(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static void ShowPersistenceMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("GUARDAR / CARGAR DATOS");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": SaveData(); break;
                case "2": LoadData(); break;
                case "3": ResetData(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static bool ConfirmExitAndSave()
    {
        Console.WriteLine("¿Deseas guardar antes de salir? (S/N)");
        if (datosGuardados)
        {
            Console.WriteLine("Los datos ya están guardados.");
        }
        else if (Confirm("Guardar datos? S/N: "))
        {
            SaveData();
        }
        return true;
    }

    static void RegisterBook()
    {
        Console.Clear();
        ShowSectionTitle("REGISTRAR LIBRO");
        int id = ReadInt("ID: ");
        string titulo = ReadText("Título: ");
        string autor = ReadText("Autor: ");
        int anio = ReadInt("Año: ");
        string categoria = ReadText("Categoría: ");
        if (libroService.AgregarLibro(new Libro(id, titulo, autor, anio, categoria)))
        {
            Console.WriteLine("Libro registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Ya existe un libro con ese ID.");
        }
        Pause();
    }

    static void ListBooksMenu()
    {
        Console.Clear();
        ShowSectionTitle("LISTAR LIBROS");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": ListBooksAll(); break;
            case "2": ListBooksAvailable(); break;
            case "3": ListBooksBorrowed(); break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Pause();
    }

    static void ListBooksAll()
    {
        foreach (var libro in libroService.ObtenerLibros())
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ListBooksAvailable()
    {
        foreach (var libro in libroService.ObtenerLibrosDisponibles())
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ListBooksBorrowed()
    {
        foreach (var libro in libroService.ObtenerLibrosPrestados())
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ViewBookDetail()
    {
        int id = ReadInt("ID del libro: ");
        var libro = libroService.BuscarPorId(id);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
        }
        else
        {
            Console.WriteLine(libro.DetalleCompleto());
        }
        Pause();
    }

    static void UpdateBookMenu()
    {
        int id = ReadInt("ID del libro a actualizar: ");
        var libro = libroService.BuscarPorId(id);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
            Pause();
            return;
        }

        Console.Clear();
        ShowSectionTitle("ACTUALIZAR LIBRO");
        Console.WriteLine("1. Editar título");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año/categoría");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": EditBookTitle(libro); break;
            case "2": EditBookAuthor(libro); break;
            case "3": EditBookYearCategory(libro); break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Pause();
    }

    static void EditBookTitle(Libro libro)
    {
        string nuevoTitulo = ReadText("Nuevo título: ");
        var actualizado = new Libro(libro.Id, nuevoTitulo, libro.Autor, libro.Anio, libro.Categoria);

        if (libroService.ActualizarLibro(libro.Id, actualizado))
        {
            Console.WriteLine("Título actualizado.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el libro.");
        }
    }

    static void EditBookAuthor(Libro libro)
    {
        string nuevoAutor = ReadText("Nuevo autor: ");
        var actualizado = new Libro(libro.Id, libro.Titulo, nuevoAutor, libro.Anio, libro.Categoria);

        if (libroService.ActualizarLibro(libro.Id, actualizado))
        {
            Console.WriteLine("Autor actualizado.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el libro.");
        }
    }

    static void EditBookYearCategory(Libro libro)
    {
        int nuevoAnio = ReadInt("Nuevo año: ");
        string nuevaCategoria = ReadText("Nueva categoría: ");
        var actualizado = new Libro(libro.Id, libro.Titulo, libro.Autor, nuevoAnio, nuevaCategoria);

        if (libroService.ActualizarLibro(libro.Id, actualizado))
        {
            Console.WriteLine("Año y categoría actualizados.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el libro.");
        }
    }

    static void DeleteBook()
    {
        int id = ReadInt("ID del libro a eliminar: ");
        var libro = libroService.BuscarPorId(id);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
        }
        else if (!libro.Disponible)
        {
            Console.WriteLine("No se puede eliminar si está prestado.");
        }
        else if (libroService.EliminarLibro(id))
        {
            Console.WriteLine("Libro eliminado.");
        }
        else
        {
            Console.WriteLine("No se pudo eliminar el libro.");
        }
        Pause();
    }

    static void RegisterUser()
    {
        Console.Clear();
        ShowSectionTitle("REGISTRAR USUARIO");
        int id = ReadInt("ID: ");
        string nombre = ReadText("Nombre: ");
        string email = ReadText("Email: ");
        if (usuarioService.AgregarUsuario(new Usuario(id, nombre, email)))
        {
            Console.WriteLine("Usuario registrado correctamente.");
        }
        else
        {
            Console.WriteLine("Ya existe un usuario con ese ID.");
        }
        Pause();
    }

    static void ListUsers()
    {
        Console.Clear();
        ShowSectionTitle("LISTAR USUARIOS");
        foreach (var usuario in usuarioService.ObtenerUsuarios())
        {
            Console.WriteLine(usuario.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
        Pause();
    }

    static void ViewUserDetail()
    {
        int id = ReadInt("ID del usuario: ");
        var usuario = usuarioService.BuscarPorId(id);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
        }
        else
        {
            Console.WriteLine(usuario.DetalleCompleto());
        }
        Pause();
    }

    static void UpdateUserMenu()
    {
        int id = ReadInt("ID del usuario a actualizar: ");
        var usuario = usuarioService.BuscarPorId(id);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Pause();
            return;
        }

        Console.Clear();
        ShowSectionTitle("ACTUALIZAR USUARIO");
        Console.WriteLine("1. Editar nombre");
        Console.WriteLine("2. Editar contacto");
        Console.WriteLine("3. Activar / desactivar");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": EditUserName(usuario); break;
            case "2": EditUserContact(usuario); break;
            case "3": ToggleUserActiveStatus(usuario); break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Pause();
    }

    static void EditUserName(Usuario usuario)
    {
        var actualizado = new Usuario(usuario.Id, ReadText("Nuevo nombre: "), usuario.Email)
        {
            Activo = usuario.Activo
        };

        if (usuarioService.ActualizarUsuario(usuario.Id, actualizado))
        {
            Console.WriteLine("Nombre actualizado.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el usuario.");
        }
    }

    static void EditUserContact(Usuario usuario)
    {
        var actualizado = new Usuario(usuario.Id, usuario.Nombre, ReadText("Nuevo contacto (email): "))
        {
            Activo = usuario.Activo
        };

        if (usuarioService.ActualizarUsuario(usuario.Id, actualizado))
        {
            Console.WriteLine("Contacto actualizado.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el usuario.");
        }
    }

    static void ToggleUserActiveStatus(Usuario usuario)
    {
        bool nuevoEstado = !usuario.Activo;

        if (usuarioService.CambiarEstadoActivo(usuario.Id, nuevoEstado))
        {
            Console.WriteLine($"Usuario {(nuevoEstado ? "activado" : "desactivado")}.");
        }
        else
        {
            Console.WriteLine("No se pudo actualizar el usuario.");
        }
    }

    static void DeleteUser()
    {
        int id = ReadInt("ID del usuario a eliminar: ");
        var usuario = usuarioService.BuscarPorId(id);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
        }
        else if (prestamoService.ObtenerPrestamos().Any(p => p.Usuario.Id == id && p.Estado == EstadoPrestamo.Activo))
        {
            Console.WriteLine("No se puede eliminar si tiene préstamos activos.");
        }
        else if (usuarioService.EliminarUsuario(id))
        {
            Console.WriteLine("Usuario eliminado.");
        }
        else
        {
            Console.WriteLine("No se pudo eliminar el usuario.");
        }
        Pause();
    }

    static void CreateLoan()
    {
        Console.Clear();
        ShowSectionTitle("CREAR PRESTAMO");
        Console.WriteLine("Validaciones: libro disponible, usuario activo, ID correcto.");
        int libroId = ReadInt("ID del libro: ");
        int usuarioId = ReadInt("ID del usuario: ");

        var libro = libroService.BuscarPorId(libroId);
        var usuario = usuarioService.BuscarPorId(usuarioId);

        if (libro == null)
        {
            Console.WriteLine("Libro no existe.");
            Pause();
            return;
        }

        if (!libro.Disponible)
        {
            Console.WriteLine("El libro no está disponible.");
            Pause();
            return;
        }

        if (usuario == null)
        {
            Console.WriteLine("Usuario no existe.");
            Pause();
            return;
        }

        if (!usuario.Activo)
        {
            Console.WriteLine("Usuario inactivo.");
            Pause();
            return;
        }

        libro.Disponible = false;
        int nuevoId = prestamoService.ObtenerPrestamos().Any()
            ? prestamoService.ObtenerPrestamos().Max(p => p.Id) + 1
            : 1;
        if (prestamoService.AgregarPrestamo(new Prestamo(nuevoId, libro, usuario, DateTime.Now)))
        {
            Console.WriteLine("Préstamo creado con éxito.");
        }
        else
        {
            libro.Disponible = true;
            Console.WriteLine("Ya existe un préstamo con ese ID.");
        }
        Pause();
    }

    static void ListLoansMenu()
    {
        Console.Clear();
        ShowSectionTitle("LISTAR PRESTAMOS");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados");
        Console.Write("Opción: ");

        switch (Console.ReadLine())
        {
            case "1": ListLoansAll(); break;
            case "2": ListLoansActive(); break;
            case "3": ListLoansClosed(); break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
        Pause();
    }

    static void ListLoansAll()
    {
        foreach (var prestamo in prestamoService.ObtenerPrestamos())
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ListLoansActive()
    {
        foreach (var prestamo in prestamoService.ObtenerPrestamosActivos())
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ListLoansClosed()
    {
        foreach (var prestamo in prestamoService.ObtenerPrestamosCerrados())
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
    }

    static void ViewLoanDetail()
    {
        int id = ReadInt("ID del préstamo: ");
        var prestamo = prestamoService.BuscarPorId(id);
        if (prestamo == null)
        {
            Console.WriteLine("Préstamo no encontrado.");
        }
        else
        {
            Console.WriteLine(prestamo.DetalleCompleto());
        }
        Pause();
    }

    static void RegisterReturn()
    {
        int id = ReadInt("ID del préstamo a devolver: ");
        if (prestamoService.RegistrarDevolucion(id))
        {
            Console.WriteLine("Devolución registrada correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo registrar la devolución. Verifica el ID o el estado.");
        }
        Pause();
    }

    static void DeleteLoan()
    {
        int id = ReadInt("ID del préstamo a eliminar: ");
        var prestamo = prestamoService.BuscarPorId(id);
        if (prestamo == null)
        {
            Console.WriteLine("Préstamo no encontrado.");
        }
        else
        {
            Console.WriteLine("Reglas sugeridas: validar antes de eliminar, especialmente si está activo.");
            if (prestamo.Estado == EstadoPrestamo.Activo)
            {
                Console.WriteLine("Advertencia: se eliminará un préstamo activo.");
            }

            if (prestamoService.EliminarPrestamo(id))
            {
                Console.WriteLine("Préstamo eliminado.");
            }
            else
            {
                Console.WriteLine("No se pudo eliminar el préstamo.");
            }
        }
        Pause();
    }

    static void SearchBook()
    {
        Console.Clear();
        ShowSectionTitle("BUSCAR LIBRO");
        Console.WriteLine("Busca por ID, título, autor o categoría.");
        string termino = ReadText("Ingrese término de búsqueda: ");

        if (int.TryParse(termino, out int id))
        {
            var libro = libroService.BuscarPorId(id);
            if (libro != null)
            {
                Console.WriteLine(libro.DetalleCompleto());
                Pause();
                return;
            }
        }

        var resultados = libroService.BuscarPorTitulo(termino)
            .Concat(libroService.BuscarPorAutor(termino))
            .Concat(libroService.BuscarPorCategoria(termino))
            .Distinct();

        foreach (var libro in resultados)
        {
            Console.WriteLine(libro.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }

        if (!resultados.Any())
        {
            Console.WriteLine("No se encontraron libros.");
        }
        Pause();
    }

    static void SearchUser()
    {
        Console.Clear();
        ShowSectionTitle("BUSCAR USUARIO");
        Console.WriteLine("Busca por ID o nombre.");
        string termino = ReadText("Ingrese término de búsqueda: ");

        if (int.TryParse(termino, out int id))
        {
            var usuario = usuarioService.BuscarPorId(id);
            if (usuario != null)
            {
                Console.WriteLine(usuario.DetalleCompleto());
                Pause();
                return;
            }
        }

        var resultados = usuarioService.BuscarPorNombre(termino);
        foreach (var usuario in resultados)
        {
            Console.WriteLine(usuario.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }

        if (!resultados.Any())
        {
            Console.WriteLine("No se encontraron usuarios.");
        }
        Pause();
    }

    static void ReportsMenu()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            ShowSectionTitle("REPORTES");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Préstamos vencidos");
            Console.WriteLine("4. Resumen general");
            Console.WriteLine("5. Comparación Array vs List");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");

            switch (Console.ReadLine())
            {
                case "1": ReportByUser(); break;
                case "2": ReportByBook(); break;
                case "3": ReportOverdue(); break;
                case "4": ReportSummary(); break;
                case "5": CompareArrayVsList(); break;
                case "0": volver = true; break;
                default:
                    Console.WriteLine("Opción no válida.");
                    Pause();
                    break;
            }
        }
    }

    static void ReportByUser()
    {
        int id = ReadInt("ID del usuario para reporte: ");
        var usuario = usuarioService.BuscarPorId(id);
        if (usuario == null)
        {
            Console.WriteLine("Usuario no encontrado.");
            Pause();
            return;
        }

        var prestamos = prestamoService.BuscarPorUsuario(usuario.Nombre);
        Console.WriteLine($"Préstamos para {usuario.Nombre}: {prestamos.Count}");
        foreach (var prestamo in prestamos)
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
        Pause();
    }

    static void ReportByBook()
    {
        int id = ReadInt("ID del libro para reporte: ");
        var libro = libroService.BuscarPorId(id);
        if (libro == null)
        {
            Console.WriteLine("Libro no encontrado.");
            Pause();
            return;
        }

        var prestamos = prestamoService.BuscarPorLibro(libro.Titulo);
        Console.WriteLine($"Préstamos para '{libro.Titulo}': {prestamos.Count}");
        foreach (var prestamo in prestamos)
        {
            Console.WriteLine(prestamo.ResumenCorto());
        }
        Pause();
    }

    static void ReportOverdue()
    {
        var vencidos = prestamoService.ObtenerPrestamosActivos().Where(p => p.EstaVencido()).ToList();
        Console.WriteLine($"Préstamos vencidos: {vencidos.Count}");
        foreach (var prestamo in vencidos)
        {
            Console.WriteLine(prestamo.DetalleCompleto());
            Console.WriteLine("-------------------------");
        }
        Pause();
    }

    static void ReportSummary()
    {
        ShowSectionTitle("RESUMEN GENERAL");
        Console.WriteLine($"Total libros: {libroService.TotalLibros()}");
        Console.WriteLine($"Libros disponibles: {libroService.LibrosDisponibles()}");
        Console.WriteLine($"Libros prestados: {libroService.LibrosPrestados()}");
        Console.WriteLine($"Total usuarios: {usuarioService.TotalUsuarios()}");
        Console.WriteLine($"Usuarios activos: {usuarioService.UsuariosActivos()}");
        Console.WriteLine($"Usuarios inactivos: {usuarioService.UsuariosInactivos()}");
        Console.WriteLine($"Total préstamos: {prestamoService.TotalPrestamos()}");
        Console.WriteLine($"Préstamos activos: {prestamoService.PrestamosActivos()}");
        Console.WriteLine($"Préstamos vencidos: {prestamoService.PrestamosVencidos()}");
        Console.WriteLine($"Préstamos devueltos: {prestamoService.PrestamosDevueltos()}");
        Console.WriteLine($"Promedio días de préstamo: {prestamoService.PromedioDiasPrestamo():0.00}");
        Pause();
    }

    static void CompareArrayVsList()
    {
        string[] categoriasArray = { "Novela", "Infantil" };
        var categoriasList = new List<string> { "Novela", "Infantil" };

        ShowSectionTitle("COMPARACION ARRAY VS LIST");
        Console.WriteLine($"Array inicial: {string.Join(", ", categoriasArray)}");
        Console.WriteLine("Array: tamaño fijo, para cambiar su capacidad hay que crear otro arreglo.");
        Console.WriteLine($"List inicial: {string.Join(", ", categoriasList)}");
        categoriasList.Add("Ciencia ficción");
        Console.WriteLine($"List después de Add: {string.Join(", ", categoriasList)}");
        Console.WriteLine("List<T>: tamaño dinámico y métodos integrados como Add, Remove y Find.");
        Pause();
    }

    static void SaveData()
    {
        datosGuardados = true;
        Console.WriteLine("Datos guardados (simulado). Esto registra la acción de guardar.");
        Pause();
    }

    static void LoadData()
    {
        Console.WriteLine("Datos cargados (simulado). Se recuperaría la información desde un archivo o base de datos.");
        Pause();
    }

    static void ResetData()
    {
        if (!Confirm("¿Confirma reiniciar los datos actuales? S/N: "))
        {
            Console.WriteLine("Reinicio cancelado.");
            Pause();
            return;
        }

        libroService = new LibroService();
        usuarioService = new UsuarioService();
        prestamoService = new PrestamoService();
        datosGuardados = false;
        SeedData();
        Console.WriteLine("Datos reiniciados a valores de ejemplo.");
        Pause();
    }

    static bool Confirm(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var respuesta = Console.ReadLine()?.Trim().ToUpper();
            if (respuesta == "S" || respuesta == "Y") return true;
            if (respuesta == "N") return false;
            Console.WriteLine("Respuesta inválida. Use S o N.");
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int valor))
                return valor;
            Console.WriteLine("Entrada inválida, ingrese un número.");
        }
    }

    static string ReadText(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    static void ShowSectionTitle(string title)
    {
        string line = new string('=', title.Length + 10);
        Console.WriteLine();
        Console.WriteLine(line);
        Console.WriteLine($"   {title}");
        Console.WriteLine(line);
        Console.WriteLine();
    }

    static void Pause()
    {
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }

    static void RunSelfTest()
    {
        libroService = new LibroService();
        usuarioService = new UsuarioService();
        prestamoService = new PrestamoService();
        datosGuardados = false;

        var resultados = new List<string>();

        var libro = new Libro(10, "Libro CRUD", "Autor Inicial", 2020, "Prueba");
        libroService.AgregarLibro(libro);
        resultados.Add(libroService.BuscarPorId(10) != null ? "OK: crear libro" : "FAIL: crear libro");

        var libroActualizado = new Libro(10, "Libro CRUD Editado", "Autor Editado", 2024, "Demo");
        bool libroEditado = libroService.ActualizarLibro(10, libroActualizado);
        resultados.Add(libroEditado && libroService.BuscarPorId(10)?.Titulo == "Libro CRUD Editado"
            ? "OK: actualizar libro"
            : "FAIL: actualizar libro");

        bool libroEliminado = libroService.EliminarLibro(10);
        resultados.Add(libroEliminado && libroService.BuscarPorId(10) == null
            ? "OK: eliminar libro"
            : "FAIL: eliminar libro");

        var usuario = new Usuario(20, "Usuario CRUD", "crud@mail.com");
        usuarioService.AgregarUsuario(usuario);
        resultados.Add(usuarioService.BuscarPorId(20) != null ? "OK: crear usuario" : "FAIL: crear usuario");

        var usuarioActualizado = new Usuario(20, "Usuario Editado", "editado@mail.com") { Activo = false };
        bool usuarioEditado = usuarioService.ActualizarUsuario(20, usuarioActualizado);
        resultados.Add(usuarioEditado && usuarioService.BuscarPorId(20)?.Activo == false
            ? "OK: actualizar usuario"
            : "FAIL: actualizar usuario");

        bool usuarioEliminado = usuarioService.EliminarUsuario(20);
        resultados.Add(usuarioEliminado && usuarioService.BuscarPorId(20) == null
            ? "OK: eliminar usuario"
            : "FAIL: eliminar usuario");

        var libroPrestamo = new Libro(30, "Libro Prestado", "Autor", 2021, "Prueba");
        var usuarioPrestamo = new Usuario(40, "Lector", "lector@mail.com");
        libroService.AgregarLibro(libroPrestamo);
        usuarioService.AgregarUsuario(usuarioPrestamo);
        libroPrestamo.Disponible = false;
        prestamoService.AgregarPrestamo(new Prestamo(50, libroPrestamo, usuarioPrestamo, DateTime.Now.AddDays(-10)));

        resultados.Add(prestamoService.BuscarPorId(50) != null ? "OK: crear préstamo" : "FAIL: crear préstamo");
        resultados.Add(prestamoService.PrestamosVencidos() == 1 ? "OK: detectar préstamo vencido" : "FAIL: detectar préstamo vencido");

        bool devolucion = prestamoService.RegistrarDevolucion(50);
        resultados.Add(devolucion && libroPrestamo.Disponible ? "OK: devolver préstamo" : "FAIL: devolver préstamo");

        bool prestamoEliminado = prestamoService.EliminarPrestamo(50);
        resultados.Add(prestamoEliminado && prestamoService.BuscarPorId(50) == null
            ? "OK: eliminar préstamo"
            : "FAIL: eliminar préstamo");

        Console.WriteLine("=== AUTOPRUEBA CRUD ===");
        foreach (var resultado in resultados)
        {
            Console.WriteLine(resultado);
        }
    }
}
