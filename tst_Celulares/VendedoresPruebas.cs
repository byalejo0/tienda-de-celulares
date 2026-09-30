using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class VendedoresPruebas
    {
        private Conexion conexion;
        private Vendedores? entidad = null;

        public VendedoresPruebas()
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
            this.entidad = new Vendedores()
            {
                Trabajador = 1,
                CelularesVendidos = 85,
                MarcaEncargada = "Samsung"
            };
            this.conexion.Vendedores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Vendedores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.CelularesVendidos = 86;

            var entry = this.conexion!.Entry<Vendedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Vendedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

