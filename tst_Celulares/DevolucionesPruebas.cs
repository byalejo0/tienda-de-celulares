using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class DevolucionesPruebas
    {
        private Conexion conexion;
        private Devoluciones? entidad = null;

        public DevolucionesPruebas()
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
            this.entidad = new Devoluciones()
            {
                FacturaId = 1,
                ClienteId = 1,
                FechaDevolucion = DateTime.Now,
                Motivo = "Producto con defecto de fábrica",
                ValorDevuelto = 3808000
            };
            this.conexion.Devoluciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Devoluciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.ValorDevuelto = 3908000;

            var entry = this.conexion!.Entry<Devoluciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Devoluciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

