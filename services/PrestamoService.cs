using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;

namespace libreria_montoya.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        private void SincronizarEstados()
        {
            foreach (var prestamo in prestamos)
            {
                if (prestamo.Estado == EstadoPrestamo.Devuelto)
                    continue;

                prestamo.Estado = prestamo.EstaVencido()
                    ? EstadoPrestamo.Vencido
                    : EstadoPrestamo.Activo;
            }
        }

        public bool AgregarPrestamo(Prestamo prestamo)
        {
            if (BuscarPorId(prestamo.Id) != null)
                return false;

            prestamos.Add(prestamo);
            return true;
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            SincronizarEstados();
            return prestamos;
        }

        public Prestamo? BuscarPorId(int id)
        {
            SincronizarEstados();
            return prestamos.FirstOrDefault(p => p.Id == id);
        }

        public bool ActualizarPrestamo(int id, Prestamo prestamoActualizado)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo == null)
                return false;

            prestamo.Libro = prestamoActualizado.Libro;
            prestamo.Usuario = prestamoActualizado.Usuario;
            prestamo.FechaPrestamo = prestamoActualizado.FechaPrestamo;
            prestamo.FechaDevolucion = prestamoActualizado.FechaDevolucion;
            prestamo.Estado = prestamoActualizado.Estado;
            return true;
        }

        public List<Prestamo> ObtenerPrestamosActivos()
        {
            SincronizarEstados();
            return prestamos.Where(p => p.Estado == EstadoPrestamo.Activo).ToList();
        }

        public List<Prestamo> ObtenerPrestamosCerrados()
        {
            SincronizarEstados();
            return prestamos.Where(p => p.Estado != EstadoPrestamo.Activo).ToList();
        }

        public bool RegistrarDevolucion(int id)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo == null || prestamo.Estado == EstadoPrestamo.Devuelto)
                return false;

            prestamo.Estado = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Libro.Disponible = true;
            return true;
        }

        public bool EliminarPrestamo(int id)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo == null)
                return false;

            if (prestamo.Estado != EstadoPrestamo.Devuelto)
            {
                prestamo.Libro.Disponible = true;
            }

            prestamos.Remove(prestamo);
            return true;
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            SincronizarEstados();
            return prestamos.Where(p => p.Estado == estado).ToList();
        }

        public List<Prestamo> BuscarPorUsuario(string nombre)
        {
            SincronizarEstados();
            return prestamos.Where(p => p.Usuario.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Prestamo> BuscarPorLibro(string titulo)
        {
            SincronizarEstados();
            return prestamos.Where(p => p.Libro.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Prestamo> OrdenarPorFecha()
        {
            SincronizarEstados();
            return prestamos.OrderBy(p => p.FechaPrestamo).ToList();
        }

        public int TotalPrestamos()
        {
            SincronizarEstados();
            return prestamos.Count;
        }

        public int PrestamosActivos()
        {
            SincronizarEstados();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        }

        public int PrestamosVencidos()
        {
            SincronizarEstados();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido);
        }

        public int PrestamosDevueltos()
        {
            SincronizarEstados();
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public double PromedioDiasPrestamo()
        {
            SincronizarEstados();
            if (prestamos.Count == 0) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }
    }
}
