using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class MarcasPruebas
    {
        private Conexion conexion;
        private Marcas? entidad = null;

        public MarcasPruebas()
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
            this.entidad = new Marcas()
            {
                Nombre = "Samsung",
                Telefono = "6041234567",
                Correo = "contacto@samsung.com",
                Direccion = "Av. El Poblado # 10-50, Medellín"
            };
            this.conexion.Marcas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Marcas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3025431232";

            var entry = this.conexion!.Entry<Marcas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Marcas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

