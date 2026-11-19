using lib_Celulares.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Interfaces
{
    public class ComponentesAplicacion : IComponentesAplicacion
    {
        private IConexion IConexion;

        public ComponentesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Componentes Actualizar(Componentes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Componentes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Componentes Borrar(Componentes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Componentes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Componentes> Buscar(Componentes entidad)
        {
            return this.IConexion.Componentes!
                .Where(x => x.Procesador!.Contains(entidad.Procesador!))
                .ToList();
        }

        public List<Componentes> Consultar()
        {
            return this.IConexion.Componentes!
                .Take(5).ToList();
        }

        public Componentes Insertar(Componentes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Componentes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Componentes entidad)
        {
            return string.IsNullOrEmpty(entidad.Procesador) ||
                entidad.Procesador.Length > 100 ||
                string.IsNullOrEmpty(entidad.MemoriaRam) ||
                entidad.MemoriaRam.Length > 50 ||
                string.IsNullOrEmpty(entidad.Pantalla) ||
                entidad.Pantalla.Length > 100 ||
                string.IsNullOrEmpty(entidad.Bateria) ||
                entidad.Bateria.Length > 50 ||
                string.IsNullOrEmpty(entidad.Camara) ||
                entidad.Camara.Length > 100 ||
                string.IsNullOrEmpty(entidad.SistemaOperativo) ||
                entidad.SistemaOperativo.Length > 100;
        }
    }
}
