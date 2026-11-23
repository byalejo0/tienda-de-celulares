using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion IConexion;

        public RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Roles!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.IConexion.Roles!
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => entidad.UsuarioId == 0 || x.UsuarioId == entidad.UsuarioId)
                .Where(x => string.IsNullOrEmpty(entidad.Nombre) || x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.IConexion.Roles!
                .Include(x => x._Usuario)
                .Take(5).ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Roles!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles entidad)
        {
            return entidad.UsuarioId <= 0 || string.IsNullOrEmpty(entidad.Nombre);
        }
    }
}
