using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class TecnicosAplicacion : ITecnicosAplicacion
    {
        private IConexion IConexion;

        public TecnicosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Tecnicos Actualizar(Tecnicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Tecnicos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Tecnicos Borrar(Tecnicos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Tecnicos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tecnicos> Buscar(Tecnicos entidad)
        {
            return this.IConexion.Tecnicos!
                .Include(x => x._Trabajador)
                .Where(x => x.Especializacion!.Contains(entidad.Especializacion!))
                .ToList();
        }

        public List<Tecnicos> Consultar()
        {
            return this.IConexion.Tecnicos!
                .Include(x => x._Trabajador)
                .Take(5).ToList();
        }

        public Tecnicos Insertar(Tecnicos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Tecnicos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Tecnicos entidad)
        {
            return entidad.TrabajadorId <= 0 ||
                string.IsNullOrEmpty(entidad.Especializacion) ||
                entidad.Especializacion.Length > 100;
        }
    }
}
