using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
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
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.TipoGarantia) || x.TipoGarantia!.Contains(entidad.TipoGarantia!))
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
            return string.IsNullOrEmpty(entidad.TipoGarantia) ||
                   string.IsNullOrEmpty(entidad.Estado) ||
                    entidad.FechaInicio == null ||
                    entidad.FechaInicio == DateTime.MinValue ||

                    entidad.FechaVencimiento == null ||
                    entidad.FechaVencimiento == DateTime.MinValue;
        }
    }
}
