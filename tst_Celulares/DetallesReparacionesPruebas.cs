using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class DetallesReparacionesPruebas
    {
        private Conexion conexion;
        private DetallesReparaciones? entidad = null;

        public DetallesReparacionesPruebas()
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
            this.entidad = new DetallesReparaciones()
            {
                ReparacionId = 1,
                Diagnostico = "Pantalla rota por caída",
                ServicioRealizado = "Cambio de pantalla",
                ComponenteReemplazado = "Pantalla AMOLED",
                Cantidad = 1,
                Precio = 450000,
                Subtotal = 450000
            };
            this.conexion.DetallesReparaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.DetallesReparaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 2;

            var entry = this.conexion!.Entry<DetallesReparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetallesReparaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

