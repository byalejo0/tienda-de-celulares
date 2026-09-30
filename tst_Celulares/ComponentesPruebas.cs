using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class ComponentesPruebas
    {
        private Conexion conexion;
        private Componentes? entidad = null;

        public ComponentesPruebas()
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
            this.entidad = new Componentes()
            {
                Procesador = "Snapdragon 8 Gen 2",
                MemoriaRam = "8 GB",
                Pantalla = "AMOLED 6.1\" 120Hz",
                Bateria = "4000 mAh",
                Camara = "50 MP + 12 MP + 10 MP",
                SistemaOperativo = "Android 14"
            };
            this.conexion.Componentes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Componentes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Bateria = "3500 mAh";

            var entry = this.conexion!.Entry<Componentes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Componentes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

