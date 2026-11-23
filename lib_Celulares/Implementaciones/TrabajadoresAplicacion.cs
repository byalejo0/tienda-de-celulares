using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class TrabajadoresAplicacion : ITrabajadoresAplicacion
    {
        private IConexion IConexion;

        public TrabajadoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Trabajadores Actualizar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Trabajadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Trabajadores Borrar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Trabajadores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Trabajadores> Buscar(Trabajadores entidad)
        {
            return this.IConexion.Trabajadores!
                .Include(x => x._Persona)
                .Where(x => x.Experiencia!.Contains(entidad.Experiencia!))
                .ToList();
        }

        public List<Trabajadores> Consultar()
        {
            return this.IConexion.Trabajadores!
                .Include(x => x._Persona)
                .Take(5).ToList();
        }

        public Trabajadores Insertar(Trabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Trabajadores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Trabajadores entidad)
        {
            return string.IsNullOrEmpty(entidad.Experiencia) ||
                string.IsNullOrEmpty(entidad.Turno) ||
                entidad.Salario < 0;
        }
    }
}
