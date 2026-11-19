using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class DetallesComprasAplicacion : IDetallesComprasAplicacion
    {
        private IConexion IConexion;

        public DetallesComprasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<DetallesCompras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.DetallesCompras!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            return this.IConexion.DetallesCompras!
                .Include(x => x._Compra)
                .Include(x => x._Celular)
                .Where(x => x.CompraId == entidad.CompraId)
                .ToList();
        }

        public List<DetallesCompras> Consultar()
        {
            return this.IConexion.DetallesCompras!
                .Include(x => x._Compra)
                .Include(x => x._Celular)
                .Take(5).ToList();
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.DetallesCompras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(DetallesCompras entidad)
        {
            return entidad.CompraId <= 0 ||
                entidad.CelularId <= 0 ||
                entidad.Cantidad <= 0;
        }
    }
}
