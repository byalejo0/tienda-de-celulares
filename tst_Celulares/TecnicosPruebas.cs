using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class TecnicosPruebas
    {
        private Conexion conexion;
        private Tecnicos? entidad = null;

        public TecnicosPruebas()
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
            this.entidad = new Tecnicos()
            {
                TrabajadorId = 1,
                CelularesReparados = 43,
                Especializacion = "Reparación general de Celulares",
            };
            this.conexion.Tecnicos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Tecnicos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.CelularesReparados = 37;

            var entry = this.conexion!.Entry<Tecnicos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tecnicos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

