using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class ClientesPruebas
    {
        private Conexion conexion;
        private Clientes? entidad = null;

        public ClientesPruebas()
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
            this.entidad = new Clientes()
            {
                PersonaId = 1,
                TipoCliente = "Minorista",
                PaisResidencia = "Colombia",
                Correo = "laura.gomez@correo.com"
            };
            this.conexion.Clientes!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Clientes!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.PaisResidencia = "Mexico";

            var entry = this.conexion!.Entry<Clientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Clientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

