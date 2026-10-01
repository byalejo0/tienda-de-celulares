using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class CelularesPruebas
    {
        private Conexion conexion;
        private Celulares? entidad = null;

        public CelularesPruebas()
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
            this.entidad = new Celulares()
            {
                MarcaId = 1,
                ComponenteId = 1,
                Disponible = true,
                CantidadDisponible = 15,
                Color = "Negro",
                Precio = 3200000,
                Modelo = "Galaxy S23",
                Almacenamiento = "256 GB"
            };
            this.conexion.Celulares!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Celulares!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.CantidadDisponible = 5;

            var entry = this.conexion!.Entry<Celulares>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Celulares!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

