using System;
using System.IO;

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

        // Datos de usuarios (arrays fijos, tamaño máximo 100)
        string[] documentos = new string[100];
        string[] nombres = new string[100];
        string[] contactos = new string[100];
        bool[] activos = new bool[100];
        int contadorUsuarios = 0;

        // Datos de préstamos (arrays fijos, tamaño máximo 100)
        int[] idPrestamos = new int[100];
        string[] idUsuariosPrestamo = new string[100];
        string[] idLibrosPrestamo = new string[100];
        string[] fechasPrestamo = new string[100];
        string[] fechasLimite = new string[100];
        string[] fechasDevolucion = new string[100];
        string[] estados = new string[100]; // "activo" o "devuelto"
        int contadorPrestamos = 0;

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

            string? opcion = Console.ReadLine();

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

                        string? subOpcion = Console.ReadLine();

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
                                string? listOpcion = Console.ReadLine();
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
                                string? buscarIsbn = Console.ReadLine();
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
                                string? actualizarIsbn = Console.ReadLine();
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
                                    string? updateOpcion = Console.ReadLine();
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
                                string? eliminarIsbn = Console.ReadLine();
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
                    // Submenú de Usuarios
                    bool volverMenuPrincipalUsuarios = false;
                    while (!volverMenuPrincipalUsuarios)
                    {
                        Console.Clear();
                        Console.WriteLine("=== MENÚ USUARIOS ===");
                        Console.WriteLine("1. Registrar usuario");
                        Console.WriteLine("2. Listar usuarios");
                        Console.WriteLine("3. Ver detalle de usuario (por ID/documento)");
                        Console.WriteLine("4. Actualizar usuario");
                        Console.WriteLine("5. Eliminar usuario");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Selecciona una opción: ");

                        string? subOpcionUsuarios = Console.ReadLine();

                        switch (subOpcionUsuarios)
                        {
                            case "1":
                                // Registrar usuario
                                if (contadorUsuarios < 100)
                                {
                                    Console.Write("Documento/ID: ");
                                    documentos[contadorUsuarios] = Console.ReadLine();
                                    Console.Write("Nombre: ");
                                    nombres[contadorUsuarios] = Console.ReadLine();
                                    Console.Write("Contacto: ");
                                    contactos[contadorUsuarios] = Console.ReadLine();
                                    activos[contadorUsuarios] = true;
                                    contadorUsuarios++;
                                    Console.WriteLine("Usuario registrado exitosamente.");
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "No se pueden registrar más usuarios (límite alcanzado)."
                                    );
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "2":
                                // Listar usuarios
                                Console.WriteLine("=== LISTA DE USUARIOS ===");
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    Console.WriteLine(
                                        $"{documentos[i]} - {nombres[i]} - {contactos[i]} - {(activos[i] ? "Activo" : "Inactivo")}"
                                    );
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "3":
                                // Ver detalle
                                Console.Write("Ingresa ID/Documento: ");
                                string? buscarDocumento = Console.ReadLine();
                                bool encontradoUsuario = false;
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    if (documentos[i] == buscarDocumento)
                                    {
                                        Console.WriteLine($"Documento: {documentos[i]}");
                                        Console.WriteLine($"Nombre: {nombres[i]}");
                                        Console.WriteLine($"Contacto: {contactos[i]}");
                                        Console.WriteLine($"Activo: {(activos[i] ? "Sí" : "No")}");
                                        encontradoUsuario = true;
                                        break;
                                    }
                                }
                                if (!encontradoUsuario)
                                {
                                    Console.WriteLine("Usuario no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "4":
                                // Actualizar usuario - submenú
                                Console.Write("Ingresa ID/Documento del usuario a actualizar: ");
                                string? actualizarDocumento = Console.ReadLine();
                                int indexUsuario = -1;
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    if (documentos[i] == actualizarDocumento)
                                    {
                                        indexUsuario = i;
                                        break;
                                    }
                                }
                                if (indexUsuario != -1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("=== ACTUALIZAR USUARIO ===");
                                    Console.WriteLine("1. Editar nombre");
                                    Console.WriteLine("2. Editar contacto");
                                    Console.WriteLine("3. Activar / desactivar");
                                    Console.Write("Selecciona: ");
                                    string? updateOpcionUsuario = Console.ReadLine();
                                    switch (updateOpcionUsuario)
                                    {
                                        case "1":
                                            Console.Write("Nuevo nombre: ");
                                            nombres[indexUsuario] = Console.ReadLine();
                                            break;
                                        case "2":
                                            Console.Write("Nuevo contacto: ");
                                            contactos[indexUsuario] = Console.ReadLine();
                                            break;
                                        case "3":
                                            Console.Write("Activar (s/n): ");
                                            string? activar = Console.ReadLine().ToLower();
                                            activos[indexUsuario] = (activar == "s");
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                    Console.WriteLine("Usuario actualizado.");
                                }
                                else
                                {
                                    Console.WriteLine("Usuario no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "5":
                                // Eliminar usuario
                                Console.Write("Ingresa ID/Documento del usuario a eliminar: ");
                                string? eliminarDocumento = Console.ReadLine();
                                int elimIndexUsuario = -1;
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    if (documentos[i] == eliminarDocumento)
                                    {
                                        elimIndexUsuario = i;
                                        break;
                                    }
                                }
                                if (elimIndexUsuario != -1)
                                {
                                    // Validar si tiene préstamos activos
                                    bool tienePrestamos = false;
                                    for (int k = 0; k < contadorPrestamos; k++)
                                    {
                                        if (
                                            idUsuariosPrestamo[k] == eliminarDocumento
                                            && estados[k] == "activo"
                                        )
                                        {
                                            tienePrestamos = true;
                                            break;
                                        }
                                    }
                                    if (tienePrestamos)
                                    {
                                        Console.WriteLine(
                                            "No se puede eliminar un usuario con préstamos activos."
                                        );
                                    }
                                    else
                                    {
                                        // Eliminar moviendo el último al lugar del eliminado
                                        documentos[elimIndexUsuario] = documentos[
                                            contadorUsuarios - 1
                                        ];
                                        nombres[elimIndexUsuario] = nombres[contadorUsuarios - 1];
                                        contactos[elimIndexUsuario] = contactos[
                                            contadorUsuarios - 1
                                        ];
                                        activos[elimIndexUsuario] = activos[contadorUsuarios - 1];
                                        contadorUsuarios--;
                                        Console.WriteLine("Usuario eliminado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Usuario no encontrado.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "0":
                                volverMenuPrincipalUsuarios = true;
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
                case "3":
                    // Submenú de Préstamos
                    bool volverMenuPrincipalPrestamos = false;
                    while (!volverMenuPrincipalPrestamos)
                    {
                        Console.Clear();
                        Console.WriteLine("=== MENÚ PRÉSTAMOS ===");
                        Console.WriteLine("1. Crear préstamo");
                        Console.WriteLine("2. Listar préstamos");
                        Console.WriteLine("3. Ver detalle de préstamo (por ID)");
                        Console.WriteLine("4. Registrar devolución");
                        Console.WriteLine("5. Eliminar préstamo");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Selecciona una opción: ");

                        string? subOpcionPrestamos = Console.ReadLine();

                        switch (subOpcionPrestamos)
                        {
                            case "1":
                                // Crear préstamo
                                if (contadorPrestamos < 100)
                                {
                                    Console.Write("ID/Documento del usuario: ");
                                    string? idUsuario = Console.ReadLine();
                                    bool usuarioValido = false;
                                    int indexUsuario = -1;
                                    for (int i = 0; i < contadorUsuarios; i++)
                                    {
                                        if (documentos[i] == idUsuario && activos[i])
                                        {
                                            usuarioValido = true;
                                            indexUsuario = i;
                                            break;
                                        }
                                    }
                                    if (!usuarioValido)
                                    {
                                        Console.WriteLine("Usuario no encontrado o inactivo.");
                                        Console.WriteLine(
                                            "Presiona cualquier tecla para continuar..."
                                        );
                                        Console.ReadKey();
                                        break;
                                    }

                                    Console.Write("ISBN del libro: ");
                                    string? idLibro = Console.ReadLine();
                                    bool libroValido = false;
                                    int indexLibro = -1;
                                    for (int i = 0; i < contadorLibros; i++)
                                    {
                                        if (isbn[i] == idLibro && disponibles[i])
                                        {
                                            libroValido = true;
                                            indexLibro = i;
                                            break;
                                        }
                                    }
                                    if (!libroValido)
                                    {
                                        Console.WriteLine("Libro no encontrado o no disponible.");
                                        Console.WriteLine(
                                            "Presiona cualquier tecla para continuar..."
                                        );
                                        Console.ReadKey();
                                        break;
                                    }

                                    // Crear préstamo
                                    idPrestamos[contadorPrestamos] = contadorPrestamos + 1;
                                    idUsuariosPrestamo[contadorPrestamos] = idUsuario;
                                    idLibrosPrestamo[contadorPrestamos] = idLibro;
                                    Console.Write("Fecha de préstamo (dd/mm/yyyy): ");
                                    fechasPrestamo[contadorPrestamos] = Console.ReadLine();
                                    Console.Write("Fecha límite (dd/mm/yyyy): ");
                                    fechasLimite[contadorPrestamos] = Console.ReadLine();
                                    fechasDevolucion[contadorPrestamos] = null;
                                    estados[contadorPrestamos] = "activo";
                                    disponibles[indexLibro] = false; // Marcar libro como no disponible
                                    contadorPrestamos++;
                                    Console.WriteLine("Préstamo creado exitosamente.");
                                }
                                else
                                {
                                    Console.WriteLine(
                                        "No se pueden crear más préstamos (límite alcanzado)."
                                    );
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "2":
                                // Listar préstamos - submenú
                                Console.Clear();
                                Console.WriteLine("=== LISTAR PRÉSTAMOS ===");
                                Console.WriteLine("1. Todos");
                                Console.WriteLine("2. Activos");
                                Console.WriteLine("3. Cerrados (devueltos)");
                                Console.Write("Selecciona: ");
                                string? listOpcionPrestamos = Console.ReadLine();
                                switch (listOpcionPrestamos)
                                {
                                    case "1":
                                        Console.WriteLine("=== TODOS LOS PRÉSTAMOS ===");
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            Console.WriteLine(
                                                $"ID: {idPrestamos[i]} - Usuario: {idUsuariosPrestamo[i]} - Libro: {idLibrosPrestamo[i]} - Estado: {estados[i]}"
                                            );
                                        }
                                        break;
                                    case "2":
                                        Console.WriteLine("=== PRÉSTAMOS ACTIVOS ===");
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            if (estados[i] == "activo")
                                            {
                                                Console.WriteLine(
                                                    $"ID: {idPrestamos[i]} - Usuario: {idUsuariosPrestamo[i]} - Libro: {idLibrosPrestamo[i]}"
                                                );
                                            }
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("=== PRÉSTAMOS CERRADOS ===");
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            if (estados[i] == "devuelto")
                                            {
                                                Console.WriteLine(
                                                    $"ID: {idPrestamos[i]} - Usuario: {idUsuariosPrestamo[i]} - Libro: {idLibrosPrestamo[i]}"
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
                                Console.Write("Ingresa ID del préstamo: ");
                                if (int.TryParse(Console.ReadLine(), out int buscarIdPrestamo))
                                {
                                    bool encontradoPrestamo = false;
                                    for (int i = 0; i < contadorPrestamos; i++)
                                    {
                                        if (idPrestamos[i] == buscarIdPrestamo)
                                        {
                                            Console.WriteLine($"ID Préstamo: {idPrestamos[i]}");
                                            Console.WriteLine(
                                                $"ID Usuario: {idUsuariosPrestamo[i]}"
                                            );
                                            Console.WriteLine($"ID Libro: {idLibrosPrestamo[i]}");
                                            Console.WriteLine(
                                                $"Fecha Préstamo: {fechasPrestamo[i]}"
                                            );
                                            Console.WriteLine($"Fecha Límite: {fechasLimite[i]}");
                                            Console.WriteLine(
                                                $"Fecha Devolución: {fechasDevolucion[i] ?? "N/A"}"
                                            );
                                            Console.WriteLine($"Estado: {estados[i]}");
                                            encontradoPrestamo = true;
                                            break;
                                        }
                                    }
                                    if (!encontradoPrestamo)
                                    {
                                        Console.WriteLine("Préstamo no encontrado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "4":
                                // Registrar devolución
                                Console.Write("Ingresa ID del préstamo a devolver: ");
                                if (int.TryParse(Console.ReadLine(), out int devolverIdPrestamo))
                                {
                                    bool encontradoDevolucion = false;
                                    for (int i = 0; i < contadorPrestamos; i++)
                                    {
                                        if (
                                            idPrestamos[i] == devolverIdPrestamo
                                            && estados[i] == "activo"
                                        )
                                        {
                                            Console.Write("Fecha de devolución (dd/mm/yyyy): ");
                                            fechasDevolucion[i] = Console.ReadLine();
                                            estados[i] = "devuelto";
                                            // Marcar libro como disponible
                                            for (int j = 0; j < contadorLibros; j++)
                                            {
                                                if (isbn[j] == idLibrosPrestamo[i])
                                                {
                                                    disponibles[j] = true;
                                                    break;
                                                }
                                            }
                                            Console.WriteLine("Devolución registrada.");
                                            encontradoDevolucion = true;
                                            break;
                                        }
                                    }
                                    if (!encontradoDevolucion)
                                    {
                                        Console.WriteLine("Préstamo no encontrado o ya devuelto.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "5":
                                // Eliminar préstamo
                                Console.Write("Ingresa ID del préstamo a eliminar: ");
                                if (int.TryParse(Console.ReadLine(), out int eliminarIdPrestamo))
                                {
                                    int elimIndexPrestamo = -1;
                                    for (int i = 0; i < contadorPrestamos; i++)
                                    {
                                        if (idPrestamos[i] == eliminarIdPrestamo)
                                        {
                                            elimIndexPrestamo = i;
                                            break;
                                        }
                                    }
                                    if (elimIndexPrestamo != -1)
                                    {
                                        if (estados[elimIndexPrestamo] == "activo")
                                        {
                                            // Devolver libro automáticamente
                                            for (int j = 0; j < contadorLibros; j++)
                                            {
                                                if (isbn[j] == idLibrosPrestamo[elimIndexPrestamo])
                                                {
                                                    disponibles[j] = true;
                                                    break;
                                                }
                                            }
                                        }
                                        // Eliminar moviendo el último al lugar del eliminado
                                        idPrestamos[elimIndexPrestamo] = idPrestamos[
                                            contadorPrestamos - 1
                                        ];
                                        idUsuariosPrestamo[elimIndexPrestamo] = idUsuariosPrestamo[
                                            contadorPrestamos - 1
                                        ];
                                        idLibrosPrestamo[elimIndexPrestamo] = idLibrosPrestamo[
                                            contadorPrestamos - 1
                                        ];
                                        fechasPrestamo[elimIndexPrestamo] = fechasPrestamo[
                                            contadorPrestamos - 1
                                        ];
                                        fechasLimite[elimIndexPrestamo] = fechasLimite[
                                            contadorPrestamos - 1
                                        ];
                                        fechasDevolucion[elimIndexPrestamo] = fechasDevolucion[
                                            contadorPrestamos - 1
                                        ];
                                        estados[elimIndexPrestamo] = estados[contadorPrestamos - 1];
                                        contadorPrestamos--;
                                        Console.WriteLine("Préstamo eliminado.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Préstamo no encontrado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("ID inválido.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "0":
                                volverMenuPrincipalPrestamos = true;
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
                case "4":
                    // Submenú de Búsquedas y reportes
                    bool volverMenuPrincipalBusquedas = false;
                    while (!volverMenuPrincipalBusquedas)
                    {
                        Console.Clear();
                        Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
                        Console.WriteLine("1. Buscar libro");
                        Console.WriteLine("2. Buscar usuario");
                        Console.WriteLine("3. Reportes");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Selecciona una opción: ");

                        string? subOpcionBusquedas = Console.ReadLine();

                        switch (subOpcionBusquedas)
                        {
                            case "1":
                                // Buscar libro - submenú
                                Console.Clear();
                                Console.WriteLine("=== BUSCAR LIBRO ===");
                                Console.WriteLine("1. Por título");
                                Console.WriteLine("2. Por autor");
                                Console.WriteLine("3. Por ID/ISBN");
                                Console.WriteLine("4. Por categoría");
                                Console.Write("Selecciona: ");
                                string? buscarLibroOpcion = Console.ReadLine();
                                Console.Write("Ingresa el término de búsqueda: ");
                                string? termino = Console.ReadLine();
                                bool encontradoLibro = false;
                                for (int i = 0; i < contadorLibros; i++)
                                {
                                    bool coincide = false;
                                    switch (buscarLibroOpcion)
                                    {
                                        case "1":
                                            coincide = titulos[i]
                                                .ToLower()
                                                .Contains(termino.ToLower());
                                            break;
                                        case "2":
                                            coincide = autores[i]
                                                .ToLower()
                                                .Contains(termino.ToLower());
                                            break;
                                        case "3":
                                            coincide = isbn[i] == termino;
                                            break;
                                        case "4":
                                            coincide = categorias[i]
                                                .ToLower()
                                                .Contains(termino.ToLower());
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                    if (coincide)
                                    {
                                        Console.WriteLine(
                                            $"{isbn[i]} - {titulos[i]} - {autores[i]} - {categorias[i]} - {(disponibles[i] ? "Disponible" : "Prestado")}"
                                        );
                                        encontradoLibro = true;
                                    }
                                }
                                if (!encontradoLibro)
                                {
                                    Console.WriteLine("No se encontraron libros.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "2":
                                // Buscar usuario - submenú
                                Console.Clear();
                                Console.WriteLine("=== BUSCAR USUARIO ===");
                                Console.WriteLine("1. Por nombre");
                                Console.WriteLine("2. Por ID/documento");
                                Console.Write("Selecciona: ");
                                string? buscarUsuarioOpcion = Console.ReadLine();
                                Console.Write("Ingresa el término de búsqueda: ");
                                string? terminoUsuario = Console.ReadLine();
                                bool encontradoUsuario = false;
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    bool coincideUsuario = false;
                                    switch (buscarUsuarioOpcion)
                                    {
                                        case "1":
                                            coincideUsuario = nombres[i]
                                                .ToLower()
                                                .Contains(terminoUsuario.ToLower());
                                            break;
                                        case "2":
                                            coincideUsuario = documentos[i] == terminoUsuario;
                                            break;
                                        default:
                                            Console.WriteLine("Opción no válida.");
                                            break;
                                    }
                                    if (coincideUsuario)
                                    {
                                        Console.WriteLine(
                                            $"{documentos[i]} - {nombres[i]} - {contactos[i]} - {(activos[i] ? "Activo" : "Inactivo")}"
                                        );
                                        encontradoUsuario = true;
                                    }
                                }
                                if (!encontradoUsuario)
                                {
                                    Console.WriteLine("No se encontraron usuarios.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "3":
                                // Reportes - submenú
                                Console.Clear();
                                Console.WriteLine("=== REPORTES ===");
                                Console.WriteLine("1. Préstamos por usuario");
                                Console.WriteLine("2. Préstamos por libro");
                                Console.WriteLine("3. Préstamos vencidos");
                                Console.WriteLine("4. Resumen general");
                                Console.Write("Selecciona: ");
                                string? reporteOpcion = Console.ReadLine();
                                switch (reporteOpcion)
                                {
                                    case "1":
                                        Console.Write("Ingresa ID/Documento del usuario: ");
                                        string usuarioReporte = Console.ReadLine();
                                        Console.WriteLine("=== PRÉSTAMOS POR USUARIO ===");
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            if (idUsuariosPrestamo[i] == usuarioReporte)
                                            {
                                                Console.WriteLine(
                                                    $"ID Préstamo: {idPrestamos[i]}, Libro: {idLibrosPrestamo[i]}, Estado: {estados[i]}"
                                                );
                                            }
                                        }
                                        break;
                                    case "2":
                                        Console.Write("Ingresa ID/ISBN del libro: ");
                                        string libroReporte = Console.ReadLine();
                                        Console.WriteLine("=== PRÉSTAMOS POR LIBRO ===");
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            if (idLibrosPrestamo[i] == libroReporte)
                                            {
                                                Console.WriteLine(
                                                    $"ID Préstamo: {idPrestamos[i]}, Usuario: {idUsuariosPrestamo[i]}, Estado: {estados[i]}"
                                                );
                                            }
                                        }
                                        break;
                                    case "3":
                                        Console.WriteLine("=== PRÉSTAMOS VENCIDOS ===");
                                        // Placeholder: asumir vencidos si fechaLimite < hoy, pero sin fechas reales
                                        Console.WriteLine(
                                            "Funcionalidad no implementada (requiere manejo de fechas)."
                                        );
                                        break;
                                    case "4":
                                        Console.WriteLine("=== RESUMEN GENERAL ===");
                                        int totalLibros = contadorLibros;
                                        int disponiblesCount = 0;
                                        int prestadosCount = 0;
                                        for (int i = 0; i < contadorLibros; i++)
                                        {
                                            if (disponibles[i])
                                                disponiblesCount++;
                                            else
                                                prestadosCount++;
                                        }
                                        Console.WriteLine($"Total libros: {totalLibros}");
                                        Console.WriteLine($"Disponibles: {disponiblesCount}");
                                        Console.WriteLine($"Prestados: {prestadosCount}");
                                        Console.WriteLine($"Total usuarios: {contadorUsuarios}");
                                        Console.WriteLine($"Total préstamos: {contadorPrestamos}");
                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida.");
                                        break;
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "0":
                                volverMenuPrincipalBusquedas = true;
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
                case "5":
                    // Submenú de Guardar / Cargar datos
                    bool volverMenuPrincipalGuardar = false;
                    while (!volverMenuPrincipalGuardar)
                    {
                        Console.Clear();
                        Console.WriteLine("=== GUARDAR / CARGAR DATOS ===");
                        Console.WriteLine("1. Guardar datos");
                        Console.WriteLine("2. Cargar datos");
                        Console.WriteLine("3. Reiniciar datos");
                        Console.WriteLine("0. Volver al menú principal");
                        Console.Write("Selecciona una opción: ");

                        string subOpcionGuardar = Console.ReadLine();

                        switch (subOpcionGuardar)
                        {
                            case "1":
                                // Guardar datos
                                try
                                {
                                    // Guardar libros
                                    using (StreamWriter writer = new StreamWriter("libros.txt"))
                                    {
                                        for (int i = 0; i < contadorLibros; i++)
                                        {
                                            writer.WriteLine(
                                                $"{isbn[i]},{titulos[i]},{autores[i]},{categorias[i]},{anios[i]},{disponibles[i]}"
                                            );
                                        }
                                    }
                                    // Guardar usuarios
                                    using (StreamWriter writer = new StreamWriter("usuarios.txt"))
                                    {
                                        for (int i = 0; i < contadorUsuarios; i++)
                                        {
                                            writer.WriteLine(
                                                $"{documentos[i]},{nombres[i]},{contactos[i]},{activos[i]}"
                                            );
                                        }
                                    }
                                    // Guardar préstamos
                                    using (StreamWriter writer = new StreamWriter("prestamos.txt"))
                                    {
                                        for (int i = 0; i < contadorPrestamos; i++)
                                        {
                                            writer.WriteLine(
                                                $"{idPrestamos[i]},{idUsuariosPrestamo[i]},{idLibrosPrestamo[i]},{fechasPrestamo[i]},{fechasLimite[i]},{fechasDevolucion[i]},{estados[i]}"
                                            );
                                        }
                                    }
                                    Console.WriteLine("Datos guardados exitosamente.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al guardar: {ex.Message}");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "2":
                                // Cargar datos
                                try
                                {
                                    // Cargar libros
                                    if (File.Exists("libros.txt"))
                                    {
                                        contadorLibros = 0;
                                        using (StreamReader reader = new StreamReader("libros.txt"))
                                        {
                                            string line;
                                            while (
                                                (line = reader.ReadLine()) != null
                                                && contadorLibros < 100
                                            )
                                            {
                                                string[] parts = line.Split(',');
                                                if (parts.Length == 6)
                                                {
                                                    isbn[contadorLibros] = parts[0];
                                                    titulos[contadorLibros] = parts[1];
                                                    autores[contadorLibros] = parts[2];
                                                    categorias[contadorLibros] = parts[3];
                                                    anios[contadorLibros] = int.Parse(parts[4]);
                                                    disponibles[contadorLibros] = bool.Parse(
                                                        parts[5]
                                                    );
                                                    contadorLibros++;
                                                }
                                            }
                                        }
                                    }
                                    // Cargar usuarios
                                    if (File.Exists("usuarios.txt"))
                                    {
                                        contadorUsuarios = 0;
                                        using (
                                            StreamReader reader = new StreamReader("usuarios.txt")
                                        )
                                        {
                                            string line;
                                            while (
                                                (line = reader.ReadLine()) != null
                                                && contadorUsuarios < 100
                                            )
                                            {
                                                string[] parts = line.Split(',');
                                                if (parts.Length == 4)
                                                {
                                                    documentos[contadorUsuarios] = parts[0];
                                                    nombres[contadorUsuarios] = parts[1];
                                                    contactos[contadorUsuarios] = parts[2];
                                                    activos[contadorUsuarios] = bool.Parse(
                                                        parts[3]
                                                    );
                                                    contadorUsuarios++;
                                                }
                                            }
                                        }
                                    }
                                    // Cargar préstamos
                                    if (File.Exists("prestamos.txt"))
                                    {
                                        contadorPrestamos = 0;
                                        using (
                                            StreamReader reader = new StreamReader("prestamos.txt")
                                        )
                                        {
                                            string line;
                                            while (
                                                (line = reader.ReadLine()) != null
                                                && contadorPrestamos < 100
                                            )
                                            {
                                                string[] parts = line.Split(',');
                                                if (parts.Length == 7)
                                                {
                                                    idPrestamos[contadorPrestamos] = int.Parse(
                                                        parts[0]
                                                    );
                                                    idUsuariosPrestamo[contadorPrestamos] = parts[
                                                        1
                                                    ];
                                                    idLibrosPrestamo[contadorPrestamos] = parts[2];
                                                    fechasPrestamo[contadorPrestamos] = parts[3];
                                                    fechasLimite[contadorPrestamos] = parts[4];
                                                    fechasDevolucion[contadorPrestamos] =
                                                        parts[5] == "null" ? null : parts[5];
                                                    estados[contadorPrestamos] = parts[6];
                                                    contadorPrestamos++;
                                                }
                                            }
                                        }
                                    }
                                    Console.WriteLine("Datos cargados exitosamente.");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error al cargar: {ex.Message}");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "3":
                                // Reiniciar datos
                                Console.Write(
                                    "¿Estás seguro de reiniciar todos los datos? (s/n): "
                                );
                                string confirmacion = Console.ReadLine().ToLower();
                                if (confirmacion == "s")
                                {
                                    contadorLibros = 0;
                                    contadorUsuarios = 0;
                                    contadorPrestamos = 0;
                                    Console.WriteLine("Datos reiniciados.");
                                }
                                else
                                {
                                    Console.WriteLine("Operación cancelada.");
                                }
                                Console.WriteLine("Presiona cualquier tecla para continuar...");
                                Console.ReadKey();
                                break;
                            case "0":
                                volverMenuPrincipalGuardar = true;
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
                case "6":
                    Console.Write("¿Guardar antes de salir? (S/N): ");
                    string guardarSalir = Console.ReadLine().ToLower();
                    if (guardarSalir == "s")
                    {
                        try
                        {
                            // Guardar libros
                            using (StreamWriter writer = new StreamWriter("libros.txt"))
                            {
                                for (int i = 0; i < contadorLibros; i++)
                                {
                                    writer.WriteLine(
                                        $"{isbn[i]},{titulos[i]},{autores[i]},{categorias[i]},{anios[i]},{disponibles[i]}"
                                    );
                                }
                            }
                            // Guardar usuarios
                            using (StreamWriter writer = new StreamWriter("usuarios.txt"))
                            {
                                for (int i = 0; i < contadorUsuarios; i++)
                                {
                                    writer.WriteLine(
                                        $"{documentos[i]},{nombres[i]},{contactos[i]},{activos[i]}"
                                    );
                                }
                            }
                            // Guardar préstamos
                            using (StreamWriter writer = new StreamWriter("prestamos.txt"))
                            {
                                for (int i = 0; i < contadorPrestamos; i++)
                                {
                                    writer.WriteLine(
                                        $"{idPrestamos[i]},{idUsuariosPrestamo[i]},{idLibrosPrestamo[i]},{fechasPrestamo[i]},{fechasLimite[i]},{fechasDevolucion[i]},{estados[i]}"
                                    );
                                }
                            }
                            Console.WriteLine("Datos guardados. Saliendo...");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al guardar: {ex.Message}. Saliendo...");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Saliendo sin guardar...");
                    }
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
