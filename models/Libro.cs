using System;

namespace libreria_montoya.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int Anio { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public bool Disponible { get; set; }

        public Libro()
        {
            Disponible = true;
            Categoria = "General";
        }

        public Libro(int id, string titulo, string autor, int anio, string categoria = "General")
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            Categoria = categoria;
            Disponible = true;
        }

        public string ResumenCorto()
        {
            return $"{Titulo} - {Autor} ({Categoria})";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nTítulo: {Titulo}\nAutor: {Autor}\nAño: {Anio}\nCategoría: {Categoria}\nDisponible: {Disponible}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}

