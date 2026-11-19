using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion IConexion;

        public UsuariosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Actualizar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Usuarios Borrar(Usuarios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Usuarios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Buscar(Usuarios entidad)
        {
            return this.IConexion.Usuarios!
                .Where(x => x.Nombre_Usuario!.Contains(entidad.Nombre_Usuario!))
                .ToList();
        }

        public List<Usuarios> Consultar()
        {
            return this.IConexion.Usuarios!
                .Take(5).ToList();
        }

        public Usuarios Insertar(Usuarios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Usuarios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Usuarios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Usuario) ||
                string.IsNullOrEmpty(entidad.Contraseña);
        }
    }
}
