using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class ProveedoresPruebas
    {
        private Conexion conexion;
        private Proveedores? entidad = null;

        public ProveedoresPruebas()
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
            this.entidad = new Proveedores()
            {
                Nombre = "Distribuidora Tech S.A.S.",
                Correo = "ventas@distritech.com",
                Telefono = "6047654321",
                Direccion = "Zona Industrial, Itagüí"
            };
            this.conexion.Proveedores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Proveedores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3036345343";

            var entry = this.conexion!.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

