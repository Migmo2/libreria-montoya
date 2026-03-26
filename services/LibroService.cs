using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;

namespace libreria_montoya.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public List<Libro> ObtenerLibros()
        {
            return libros;
        }

        public void EliminarLibro(int id)
        {
            var libro = libros.FirstOrDefault(l => l.Id == id);
            if (libro != null)
                libros.Remove(libro);
        }

        public List<Libro> BuscarPorTitulo(string titulo)
        {
            return libros.Where(l => l.Titulo.Contains(titulo)).ToList();
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros.Where(l => l.Autor.Contains(autor)).ToList();
        }

        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        public int TotalLibros() => libros.Count;
        public int LibrosDisponibles() => libros.Count(l => l.Disponible);
        public int LibrosPrestados() => libros.Count(l => !l.Disponible);
    }
}