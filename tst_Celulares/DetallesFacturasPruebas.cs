using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class DetallesFacturasPruebas
    {
        private Conexion conexion;
        private DetallesFacturas? entidad = null;

        public DetallesFacturasPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = "server=localhost;database=tienda_celulares_db;Integrated Security=True;TrustServerCertificate=true;";
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
            this.entidad = new DetallesFacturas()
            {
                Factura = 1,
                Celular = 1,
                Cantidad = 1,
                Subtotal = 3200000,
                Iva = 608000,
                Total = 3808000
            };
            this.conexion.DetallesFacturas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.DetallesFacturas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 3;

            var entry = this.conexion!.Entry<DetallesFacturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesFacturas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

