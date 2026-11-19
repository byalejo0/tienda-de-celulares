using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class DetallesFacturasAplicacion : IDetallesFacturasAplicacion
    {
        private IConexion IConexion;

        public DetallesFacturasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesFacturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesFacturas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesFacturas> Buscar(DetallesFacturas entidad)
        {
            return this.IConexion.DetallesFacturas!
                .Include(x => x._Factura)
                .Include(x => x._Celular)
                .Where(x => x.FacturaId == entidad.FacturaId)
                .ToList();
        }

        public List<DetallesFacturas> Consultar()
        {
            return this.IConexion.DetallesFacturas!
                .Include(x => x._Factura)
                .Include(x => x._Celular)
                .Take(5).ToList();
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesFacturas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesFacturas entidad)
        {
            return entidad.FacturaId <= 0 ||
                entidad.CelularId <= 0 ||
                entidad.Cantidad <= 0;
        }
    }
}
