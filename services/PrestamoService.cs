using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;

namespace libreria_montoya.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamos.Add(prestamo);
        }

        public List<Prestamo> ObtenerPrestamos()
        {
            return prestamos;
        }

        public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
        {
            return prestamos.Where(p => p.Estado == estado).ToList();
        }

        public List<Prestamo> OrdenarPorFecha()
        {
            return prestamos.OrderBy(p => p.FechaPrestamo).ToList();
        }

        public int TotalPrestamos() => prestamos.Count;
        public int PrestamosActivos() => prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        public int PrestamosVencidos() => prestamos.Count(p => p.EstaVencido());
        public int PrestamosDevueltos() => prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);

        public double PromedioDiasPrestamo()
        {
            if (prestamos.Count == 0) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }
    }
}