using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class CelularesAplicacion : ICelularesAplicacion
    {
        private IConexion IConexion;

        public CelularesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Celulares Actualizar(Celulares entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Celulares>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Celulares Borrar(Celulares entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Celulares!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Celulares> Buscar(Celulares entidad)
        {
            return this.IConexion.Celulares!
                .Include(x => x._Marca)
                .Include(x => x._Componente)
                .Where(x => x.Modelo!.Contains(entidad.Modelo!))
                .ToList();
        }

        public List<Celulares> Consultar()
        {
            return this.IConexion.Celulares!
                .Include(x => x._Marca)
                .Include(x => x._Componente)
                .Take(5).ToList();
        }

        public Celulares Insertar(Celulares entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Celulares!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Celulares entidad)
        {
            return string.IsNullOrEmpty(entidad.Color) ||
                string.IsNullOrEmpty(entidad.Modelo) ||
                string.IsNullOrEmpty(entidad.Almacenamiento) ||
                entidad.CantidadDisponible < 0 ||
                entidad.Precio <= 0;
        }
    }
}
