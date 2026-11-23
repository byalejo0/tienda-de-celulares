using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
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
                .Where(x => entidad.Id == 0 || x.Id == entidad.Id)
                .Where(x => string.IsNullOrEmpty(entidad.Correo) || x.Correo!.Contains(entidad.Correo!))
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
            return string.IsNullOrEmpty(entidad.TipoCliente) ||
              string.IsNullOrEmpty(entidad.PaisResidencia) ||
              string.IsNullOrEmpty(entidad.Correo);
        }
    }
}
