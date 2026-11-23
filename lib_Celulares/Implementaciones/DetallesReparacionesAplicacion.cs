using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class DetallesReparacionesAplicacion : IDetallesReparacionesAplicacion
    {
        private IConexion IConexion;

        public DetallesReparacionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesReparaciones Actualizar(DetallesReparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesReparaciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesReparaciones Borrar(DetallesReparaciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesReparaciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesReparaciones> Buscar(DetallesReparaciones entidad)
        {
            return this.IConexion.DetallesReparaciones!
                .Where(x => string.IsNullOrEmpty(entidad.Diagnostico) || x.Diagnostico!.Contains(entidad.Diagnostico!))
                .ToList();
        }

        public List<DetallesReparaciones> Consultar()
        {
            return this.IConexion.DetallesReparaciones!
                .Include(x => x._Reparacion)
                .Take(5).ToList();
        }

        public DetallesReparaciones Insertar(DetallesReparaciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesReparaciones!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesReparaciones entidad)
        {
            return string.IsNullOrEmpty(entidad.Diagnostico) ||
                string.IsNullOrEmpty(entidad.ServicioRealizado) ||
                string.IsNullOrEmpty(entidad.ComponenteReemplazado) ||
                entidad.Cantidad < 0 ||
                entidad.Precio <= 0 ||
                entidad.Subtotal <= 0;
        }
    }
}
