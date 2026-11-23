using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {
        private IConexion IConexion;

        public PersonasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Personas Actualizar(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Personas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Personas Borrar(Personas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Personas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Personas> Buscar(Personas entidad)
        {
            return this.IConexion.Personas!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Personas> Consultar()
        {
            return this.IConexion.Personas!
                .Take(5).ToList();
        }

        public Personas Insertar(Personas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Personas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Personas entidad)
        {
            return string.IsNullOrEmpty(entidad.Cedula) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                entidad.Edad <= 0;
        }
    }
}
