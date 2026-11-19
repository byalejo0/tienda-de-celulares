using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_Celulares.Implementaciones
{
    public class EnviosAplicacion : IEnviosAplicacion
    {
        private IConexion IConexion;

        public EnviosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Envios Actualizar(Envios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Envios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Envios Borrar(Envios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Envios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Envios> Buscar(Envios entidad)
        {
            return this.IConexion.Envios!
                .Include(x => x._Factura)
                .Include(x => x._Transportadora)
                .Include(x => x._Cliente)
                .Where(x => x.FacturaId == entidad.FacturaId)
                .ToList();
        }

        public List<Envios> Consultar()
        {
            return this.IConexion.Envios!
                .Include(x => x._Factura)
                .Include(x => x._Transportadora)
                .Include(x => x._Cliente)
                .Take(5).ToList();
        }

        public Envios Insertar(Envios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Envios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Envios entidad)
        {
            return entidad.FacturaId <= 0 ||
                entidad.TransportadoraId <= 0 ||
                entidad.ClienteId <= 0 ||
                entidad.FechaEnvio == null ||
                entidad.FechaEnvio < new DateTime(1753, 1, 1) ||
                entidad.FechaEntrega == null ||
                entidad.FechaEntrega < new DateTime(1753, 1, 1);
        }
    }
}
