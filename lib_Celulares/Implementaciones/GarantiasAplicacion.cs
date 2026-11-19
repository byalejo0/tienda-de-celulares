using lib_Celulares.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Interfaces
{
    public class GarantiasAplicacion : IGarantiasAplicacion
    {
        private IConexion IConexion;

        public GarantiasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Garantias Actualizar(Garantias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Garantias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Garantias Borrar(Garantias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Garantias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Garantias> Buscar(Garantias entidad)
        {
            return this.IConexion.Garantias!
                .Include(x => x._Celular)
                .Include(x => x._Cliente)
                .Include(x => x._Factura)
                .Where(x => x.TipoGarantia!.Contains(entidad.TipoGarantia!))
                .ToList();
        }

        public List<Garantias> Consultar()
        {
            return this.IConexion.Garantias!
                .Include(x => x._Celular)
                .Include(x => x._Cliente)
                .Include(x => x._Factura)
                .Take(5).ToList();
        }

        public Garantias Insertar(Garantias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Garantias!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Garantias entidad)
        {
            return entidad.CelularId <= 0 ||
                entidad.ClienteId <= 0 ||
                entidad.FacturaId <= 0 ||
                entidad.FechaInicio == null ||
                entidad.FechaInicio < new DateTime(1753, 1, 1) ||
                entidad.FechaVencimiento == null ||
                entidad.FechaVencimiento < new DateTime(1753, 1, 1) ||
                string.IsNullOrEmpty(entidad.TipoGarantia) ||
                entidad.TipoGarantia.Length > 100 ||
                string.IsNullOrEmpty(entidad.Estado) ||
                entidad.Estado.Length > 50;
        }
    }
}
