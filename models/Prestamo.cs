using System;

namespace libreria_montoya.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro Libro { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public Prestamo()
        {
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo)
        {
            Id = id;
            Libro = libro;
            Usuario = usuario;
            FechaPrestamo = fechaPrestamo;
            Estado = EstadoPrestamo.Activo;
            FechaDevolucion = null;
        }

        public bool EstaVencido()
        {
            return (DateTime.Now - FechaPrestamo).TotalDays > 7;
        }

        public int DiasTranscurridos()
        {
            return (DateTime.Now - FechaPrestamo).Days;
        }

        public string ResumenCorto()
        {
            return $"Libro: {Libro.Titulo} - Usuario: {Usuario.Nombre}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nLibro: {Libro.Titulo}\nUsuario: {Usuario.Nombre}\nFecha: {FechaPrestamo}\nEstado: {Estado}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}