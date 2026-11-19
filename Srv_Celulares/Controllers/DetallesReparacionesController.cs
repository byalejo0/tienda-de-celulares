using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesReparacionesController : ControllerBase
    {
        private IDetallesReparacionesAplicacion IDetallesReparacionesAplicacion;

        public DetallesReparacionesController(IDetallesReparacionesAplicacion IDetallesReparacionesAplicacion)
        {
            this.IDetallesReparacionesAplicacion = IDetallesReparacionesAplicacion;
        }

        [HttpPost]
        public List<DetallesReparaciones> Consultar()
        {
            return this.IDetallesReparacionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesReparaciones> Buscar(DetallesReparaciones entidad)
        {
            return this.IDetallesReparacionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesReparaciones Insertar(DetallesReparaciones entidad)
        {
            return this.IDetallesReparacionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesReparaciones Actualizar(DetallesReparaciones entidad)
        {
            return this.IDetallesReparacionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesReparaciones Borrar(DetallesReparaciones entidad)
        {
            return this.IDetallesReparacionesAplicacion.Borrar(entidad);
        }
    }
}
