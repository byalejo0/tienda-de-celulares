using lib_Celulares.Entidades;
using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace tst_Celulares
{
    [TestClass]
    public class TrabajadoresPruebas
    {
        private Conexion conexion;
        private Trabajadores? entidad = null;

        public TrabajadoresPruebas()
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
            this.entidad = new Trabajadores()
            {
                PersonaId = 1,
                Experiencia = "5 años",
                Salario = 2_500_000m,
                Turno = "Mañana (8:00 a.m. - 4:00 p.m.)"
            };
            this.conexion.Trabajadores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()

        {
            var lista = this.conexion.Trabajadores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Salario = 1000000;

            var entry = this.conexion!.Entry<Trabajadores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Trabajadores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

