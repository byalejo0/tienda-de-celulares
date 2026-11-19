using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class BonosAplicacion : IBonosAplicacion
    {
        private IConexion IConexion;

        public BonosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Bonos Actualizar(Bonos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Bonos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Bonos Borrar(Bonos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Bonos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Bonos> Buscar(Bonos entidad)
        {
            return this.IConexion.Bonos!
                .Include(x => x._Tecnico)
                .Where(x => x.TecnicoId == entidad.TecnicoId)
                .ToList();
        }

        public List<Bonos> Consultar()
        {
            return this.IConexion.Bonos!
                .Include(x => x._Tecnico)
                .Take(5).ToList();
        }

        public Bonos Insertar(Bonos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Bonos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Bonos entidad)
        {
            return entidad.TecnicoId <= 0;
        }
    }
}
