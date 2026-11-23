using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class PermisosAplicacion : IPermisosAplicacion
    {
        private IConexion IConexion;

        public PermisosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Permisos Actualizar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Permisos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Permisos Borrar(Permisos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Permisos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Permisos> Buscar(Permisos entidad)
        {
            return this.IConexion.Permisos!
                .Where(x => entidad.RolId == 0 || x.RolId == entidad.RolId)
                .ToList();
        }

        public List<Permisos> Consultar()
        {
            return this.IConexion.Permisos!
                .Include(x => x._Rol)
                .Take(5).ToList();
        }

        public Permisos Insertar(Permisos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Permisos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Permisos entidad)
        {
            return entidad.RolId <= 0 || string.IsNullOrEmpty(entidad.Ventana);
        }
    }
}
