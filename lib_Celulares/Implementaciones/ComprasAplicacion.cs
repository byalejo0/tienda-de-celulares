using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion IConexion;

        public ComprasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Compras Actualizar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Compras!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            return this.IConexion.Compras!
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.Estado) || x.Estado!.Contains(entidad.Estado!))
                .ToList();
        }

        public List<Compras> Consultar()
        {
            return this.IConexion.Compras!
                .Include(x => x._Proveedor)
                .Include(x => x._Trabajador)
                .Take(5).ToList();
        }

        public Compras Insertar(Compras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Compras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Compras entidad)
        {
            return string.IsNullOrEmpty(entidad.Estado) ||
                entidad.Total <= 0 ||
                entidad.FechaCompra == null ||
                entidad.FechaCompra == DateTime.MinValue ||
                entidad.FechaCompra > DateTime.Now;
        }
    }
}
