using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class TransportadorasPruebas
    {
        private Conexion conexion;
        private Transportadoras? entidad = null;

        public TransportadorasPruebas()
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
            this.entidad = new Transportadoras()
            {
                Nombre = "Servientrega",
                Correo = "servicio@servientrega.com",
                Telefono = "018000123456"
            };
            this.conexion.Transportadoras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Transportadoras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Telefono = "3180001234";

            var entry = this.conexion!.Entry<Transportadoras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Transportadoras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

