using lib_Celulares.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Interfaces
{
    public class DevolucionesAplicacion : IDevolucionesAplicacion
    {
        private IConexion IConexion;

        public DevolucionesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Devoluciones Actualizar(Devoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Devoluciones>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Devoluciones Borrar(Devoluciones entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Devoluciones!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Devoluciones> Buscar(Devoluciones entidad)
        {
            return this.IConexion.Devoluciones!
                .Include(x => x._Factura)
                .Include(x => x._Cliente)
                .Where(x => x.Motivo!.Contains(entidad.Motivo!))
                .ToList();
        }

        public List<Devoluciones> Consultar()
        {
            return this.IConexion.Devoluciones!
                .Include(x => x._Factura)
                .Include(x => x._Cliente)
                .Take(5).ToList();
        }

        public Devoluciones Insertar(Devoluciones entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Devoluciones!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Devoluciones entidad)
        {
            return entidad.FacturaId <= 0 ||
                entidad.ClienteId <= 0 ||
                entidad.FechaDevolucion == null ||
                entidad.FechaDevolucion < new DateTime(1753, 1, 1) ||
                string.IsNullOrEmpty(entidad.Motivo) ||
                entidad.Motivo.Length > 200;
        }
    }
}
