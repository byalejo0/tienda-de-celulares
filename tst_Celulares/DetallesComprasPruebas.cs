using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class DetallesComprasPruebas
    {
        private Conexion conexion;
        private DetallesCompras? entidad = null;

        public DetallesComprasPruebas()
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
            this.entidad = new DetallesCompras()
            {
                CompraId = 1,
                CelularId = 1,
                Cantidad = 10,
                PrecioCompra = 2800000
            };
            this.conexion.DetallesCompras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.DetallesCompras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 9;

            var entry = this.conexion!.Entry<DetallesCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesCompras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

