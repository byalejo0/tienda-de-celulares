using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class GarantiasPruebas
    {
        private Conexion conexion;
        private Garantias? entidad = null;

        public GarantiasPruebas()
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
            this.entidad = new Garantias()
            {
                Celular = 1,
                Cliente = 1,
                Factura = 1,
                FechaInicio = DateTime.Now,
                FechaVencimiento = DateTime.Now,
                TipoGarantia = "Garantía del fabricante",
                Estado = "Vigente"
            };
            this.conexion.Garantias!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Garantias!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "Vencida";

            var entry = this.conexion!.Entry<Garantias>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Garantias!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

