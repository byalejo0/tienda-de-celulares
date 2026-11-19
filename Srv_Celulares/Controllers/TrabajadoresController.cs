using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TrabajadoresController : ControllerBase
    {
        private ITrabajadoresAplicacion ITrabajadoresAplicacion;

        public TrabajadoresController(ITrabajadoresAplicacion ITrabajadoresAplicacion)
        {
            this.ITrabajadoresAplicacion = ITrabajadoresAplicacion;
        }

        [HttpPost]
        public List<Trabajadores> Consultar()
        {
            return this.ITrabajadoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Trabajadores> Buscar(Trabajadores entidad)
        {
            return this.ITrabajadoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Trabajadores Insertar(Trabajadores entidad)
        {
            return this.ITrabajadoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Trabajadores Actualizar(Trabajadores entidad)
        {
            return this.ITrabajadoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Trabajadores Borrar(Trabajadores entidad)
        {
            return this.ITrabajadoresAplicacion.Borrar(entidad);
        }
    }
}
