using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class TransportadorasAplicacion : ITransportadorasAplicacion
    {
        private IConexion IConexion;

        public TransportadorasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Transportadoras Actualizar(Transportadoras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Transportadoras>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Transportadoras Borrar(Transportadoras entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Transportadoras!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Transportadoras> Buscar(Transportadoras entidad)
        {
            return this.IConexion.Transportadoras!
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.Nombre) || x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Transportadoras> Consultar()
        {
            return this.IConexion.Transportadoras!
                .Take(5).ToList();
        }

        public Transportadoras Insertar(Transportadoras entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Transportadoras!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Transportadoras entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Telefono);
        }
    }
}
