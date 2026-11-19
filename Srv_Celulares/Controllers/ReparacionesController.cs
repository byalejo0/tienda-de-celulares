using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReparacionesController : ControllerBase
    {
        private IReparacionesAplicacion IReparacionesAplicacion;

        public ReparacionesController(IReparacionesAplicacion IReparacionesAplicacion)
        {
            this.IReparacionesAplicacion = IReparacionesAplicacion;
        }

        [HttpPost]
        public List<Reparaciones> Consultar()
        {
            return this.IReparacionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Reparaciones> Buscar(Reparaciones entidad)
        {
            return this.IReparacionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Reparaciones Insertar(Reparaciones entidad)
        {
            return this.IReparacionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Reparaciones Actualizar(Reparaciones entidad)
        {
            return this.IReparacionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Reparaciones Borrar(Reparaciones entidad)
        {
            return this.IReparacionesAplicacion.Borrar(entidad);
        }
    }
}
