using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion IConexion;

        public FacturasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Facturas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.IConexion.Facturas!
                .Where(x => entidad.ClienteId == 0 || x.ClienteId == entidad.ClienteId)
                .ToList();
        }

        public List<Facturas> Consultar()
        {
            return this.IConexion.Facturas!
                .Include(x => x._Cliente)
                .Include(x => x._Trabajador)
                .Include(x => x._Reparacion)
                .Take(5).ToList();
        }

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Facturas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Facturas entidad)
        {
            return entidad.Iva < 0 ||
                    entidad.Subtotal <= 0 ||
                    entidad.Total <= 0 ||
                    entidad.Fecha == null ||
                    entidad.Fecha == DateTime.MinValue ||
                    entidad.Fecha > DateTime.Now;
        }
    }
}
