using lib_Celulares.Entidades;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Interfaces
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion IConexion;

        public ClientesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Clientes!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.IConexion.Clientes!
                .Include(x => x._Persona)
                .Where(x => x.Correo!.Contains(entidad.Correo!))
                .ToList();
        }

        public List<Clientes> Consultar()
        {
            return this.IConexion.Clientes!
                .Include(x => x._Persona)
                .Take(5).ToList();
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Clientes!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Clientes entidad)
        {
            return entidad.PersonaId <= 0 ||
                string.IsNullOrEmpty(entidad.TipoCliente) ||
                entidad.TipoCliente.Length > 100 ||
                string.IsNullOrEmpty(entidad.PaisResidencia) ||
                entidad.PaisResidencia.Length > 50 ||
                string.IsNullOrEmpty(entidad.Correo) ||
                entidad.Correo.Length > 100;
        }
    }
}
