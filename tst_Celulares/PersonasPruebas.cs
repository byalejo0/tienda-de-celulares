using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class PersonasPruebas
    {
        private Conexion conexion;
        private Personas? entidad = null;

        public PersonasPruebas()
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
            this.entidad = new Personas()
            {
                Cedula = "42546754",
                Nombre = "Jacqueline",
                Edad = 20,
                Direccion = "Calle 5 # 10-50, Medellín"
            };
            this.conexion.Personas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Personas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Edad = 30;

            var entry = this.conexion!.Entry<Personas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Personas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

