using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class EnviosPruebas
    {
        private Conexion conexion;
        private Envios? entidad = null;

        public EnviosPruebas()
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
            this.entidad = new Envios()
            {
                FacturaId = 1,
                TransportadoraId = 1,
                ClienteId = 1,
                FechaEnvio = DateTime.Now,
                FechaEntrega = DateTime.Now,
                CostoEnvio = 15000
            };
            this.conexion.Envios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Envios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.CostoEnvio = 15000;

            var entry = this.conexion!.Entry<Envios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Envios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

