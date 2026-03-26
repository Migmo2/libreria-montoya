using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;

namespace libreria_montoya.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            return usuarios.Where(u => u.Nombre.Contains(nombre)).ToList();
        }

        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }

        public int TotalUsuarios() => usuarios.Count;
        public int UsuariosActivos() => usuarios.Count(u => u.Activo);
        public int UsuariosInactivos() => usuarios.Count(u => !u.Activo);
    }
}