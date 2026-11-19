using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class MarcasAplicacion : IMarcasAplicacion
    {
        private IConexion IConexion;

        public MarcasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Marcas Actualizar(Marcas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Marcas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Marcas Borrar(Marcas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Marcas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Marcas> Buscar(Marcas entidad)
        {
            return this.IConexion.Marcas!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Marcas> Consultar()
        {
            return this.IConexion.Marcas!
                .Take(5).ToList();
        }

        public Marcas Insertar(Marcas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Marcas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Marcas entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Nombre.Length > 100 ||
                string.IsNullOrEmpty(entidad.Telefono) ||
                entidad.Telefono.Length > 20 ||
                string.IsNullOrEmpty(entidad.Correo) ||
                entidad.Correo.Length > 100 ||
                string.IsNullOrEmpty(entidad.Direccion) ||
                entidad.Direccion.Length > 200;
        }
    }
}
