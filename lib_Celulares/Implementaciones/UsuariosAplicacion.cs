using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using lib_Celulares.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Usuarios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IConexion.Usuarios!
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.Nombre_Usuario) || x.Nombre_Usuario!.Contains(entidad.Nombre_Usuario!))
                .ToList();
        }

        public List<Usuarios> Consultar()
        {
            return this.IConexion.Usuarios!
                .Take(5).ToList();
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Usuarios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public SesionUsuario Autenticar(Usuarios entidad)
        {
            var sesion = new SesionUsuario();

            if (string.IsNullOrWhiteSpace(entidad.Nombre_Usuario) ||
                string.IsNullOrEmpty(entidad.Contraseña))
                return sesion;

            // El nombre se busca en la base de datos; la contraseña se compara
            // aqui en C# para que SI distinga mayusculas de minusculas.
            var nombre = entidad.Nombre_Usuario.Trim();
            var usuario = this.IConexion.Usuarios!
                .Where(x => x.Nombre_Usuario == nombre)
                .ToList()
                .FirstOrDefault(x => string.Equals(x.Contraseña,
                    entidad.Contraseña, StringComparison.Ordinal));

            if (usuario == null)
                return sesion;

            // Usuarios -> Roles (Roles.UsuarioId) -> Permisos (Permisos.RolId)
            var roles = this.IConexion.Roles!
                .Where(x => x.UsuarioId == usuario.Id)
                .ToList();

            var permisos = this.IConexion.Permisos!
                .Where(x => x._Rol!.UsuarioId == usuario.Id)
                .ToList();

            sesion.Id = usuario.Id;
            sesion.Nombre_Usuario = usuario.Nombre_Usuario;
            sesion.Roles = roles
                .Where(x => !string.IsNullOrEmpty(x.Nombre))
                .Select(x => x.Nombre!)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            sesion.Ventanas = permisos
                .Where(x => !string.IsNullOrEmpty(x.Ventana))
                .Select(x => x.Ventana!)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            return sesion;
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Usuario) ||
                string.IsNullOrEmpty(entidad.Contraseña);
        }
    }
}
