using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class ReparacionesPruebas
    {
        private Conexion conexion;
        private Reparaciones? entidad = null;

        public ReparacionesPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=localhost\\DEV;database=tienda_celulares_db;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new Reparaciones()
            {
                CelularId = 1,
                TecnicoId = 1,
                ClienteId = 1,
                BonoId = 1,
                FechaIngreso = DateTime.Now,
                FechaEntrega = DateTime.Now,
                Estado = "Entregada"
            };
            this.conexion.Reparaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Reparaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Pendiente";

            var entry = this.conexion!.Entry<Reparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Reparaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

