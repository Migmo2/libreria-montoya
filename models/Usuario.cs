using System;

namespace libreria_montoya.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public Usuario()
        {
            Activo = true;
        }

        public Usuario(int id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Activo = true;
        }

        public string ResumenCorto()
        {
            return $"{Nombre} - {Email}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nNombre: {Nombre}\nEmail: {Email}\nActivo: {Activo}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}