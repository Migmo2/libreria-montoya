using System;

namespace libreria_montoya.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }
        public bool Disponible { get; set; }

        public Libro()
        {
            Disponible = true;
        }

        public Libro(int id, string titulo, string autor, int anio)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Anio = anio;
            Disponible = true;
        }

        public string ResumenCorto()
        {
            return $"{Titulo} - {Autor}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nTítulo: {Titulo}\nAutor: {Autor}\nAño: {Anio}\nDisponible: {Disponible}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}

