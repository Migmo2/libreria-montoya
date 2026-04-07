using System;
using System.Collections.Generic;
using System.Linq;
using libreria_montoya.Models;

namespace libreria_montoya.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public bool AgregarUsuario(Usuario usuario)
        {
            if (BuscarPorId(usuario.Id) != null)
                return false;

            usuarios.Add(usuario);
            return true;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return usuarios;
        }

        public Usuario? BuscarPorId(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        public bool ActualizarUsuario(int id, Usuario usuarioActualizado)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null)
                return false;

            usuario.Nombre = usuarioActualizado.Nombre;
            usuario.Email = usuarioActualizado.Email;
            usuario.Activo = usuarioActualizado.Activo;
            return true;
        }

        public bool CambiarEstadoActivo(int id, bool activo)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null)
                return false;

            usuario.Activo = activo;
            return true;
        }

        public bool EliminarUsuario(int id)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null)
                return false;

            usuarios.Remove(usuario);
            return true;
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            return usuarios.Where(u => u.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
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
