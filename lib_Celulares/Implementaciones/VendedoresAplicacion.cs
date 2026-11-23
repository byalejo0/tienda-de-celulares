using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class VendedoresAplicacion : IVendedoresAplicacion
    {
        private IConexion IConexion;

        public VendedoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Vendedores Actualizar(Vendedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Vendedores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Vendedores Borrar(Vendedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Vendedores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Vendedores> Buscar(Vendedores entidad)
        {
            return this.IConexion.Vendedores!
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.MarcaEncargada) || x.MarcaEncargada!.Contains(entidad.MarcaEncargada!))
                .ToList();
        }

        public List<Vendedores> Consultar()
        {
            return this.IConexion.Vendedores!
                .Include(x => x._Trabajador)
                .Take(5).ToList();
        }

        public Vendedores Insertar(Vendedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Vendedores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Vendedores entidad)
        {
            return string.IsNullOrEmpty(entidad.MarcaEncargada) ||
                entidad.CelularesVendidos < 0;
        }
    }
}
