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

        public Libro? BuscarPorId(int id)
        {
            return libros.FirstOrDefault(l => l.Id == id);
        }

        public bool ActualizarLibro(int id, Libro libroActualizado)
        {
            var libro = BuscarPorId(id);
            if (libro == null)
                return false;

            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.Anio = libroActualizado.Anio;
            libro.Categoria = libroActualizado.Categoria;
            return true;
        }

        public bool EliminarLibro(int id)
        {
            var libro = BuscarPorId(id);
            if (libro == null)
                return false;

            libros.Remove(libro);
            return true;
        }

        public List<Libro> ObtenerLibrosDisponibles()
        {
            return libros.Where(l => l.Disponible).ToList();
        }

        public List<Libro> ObtenerLibrosPrestados()
        {
            return libros.Where(l => !l.Disponible).ToList();
        }

        public List<Libro> BuscarPorTitulo(string titulo)
        {
            return libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> BuscarPorAutor(string autor)
        {
            return libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> BuscarPorCategoria(string categoria)
        {
            return libros.Where(l => l.Categoria.Contains(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        public List<Libro> OrdenarPorAnio()
        {
            return libros.OrderBy(l => l.Anio).ToList();
        }

        public int TotalLibros() => libros.Count;
        public int LibrosDisponibles() => libros.Count(l => l.Disponible);
        public int LibrosPrestados() => libros.Count(l => !l.Disponible);
    }
}
