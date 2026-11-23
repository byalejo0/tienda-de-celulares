using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class ReparacionesAplicacion : IReparacionesAplicacion
    {
        private IConexion IConexion;

        public ReparacionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Reparaciones Actualizar(Reparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Reparaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Reparaciones Borrar(Reparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Reparaciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reparaciones> Buscar(Reparaciones entidad)
        {
            return this.IConexion.Reparaciones!
                .Include(x => x._Celular)
                .Include(x => x._Tecnico)
                .Include(x => x._Cliente)
                .Include(x => x._Bono)
                .Where(x => x.Estado!.Contains(entidad.Estado!))
                .ToList();
        }

        public List<Reparaciones> Consultar()
        {
            return this.IConexion.Reparaciones!
                .Include(x => x._Celular)
                .Include(x => x._Tecnico)
                .Include(x => x._Cliente)
                .Include(x => x._Bono)
                .Take(5).ToList();
        }

        public Reparaciones Insertar(Reparaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Reparaciones!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Reparaciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                    entidad.FechaIngreso == null ||
                    entidad.FechaIngreso == DateTime.MinValue ||
                    entidad.FechaIngreso > DateTime.Now ||

                     entidad.FechaEntrega == null ||
                     entidad.FechaEntrega == DateTime.MinValue;
        }
    }
}
