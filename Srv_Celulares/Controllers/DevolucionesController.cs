using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DevolucionesController : ControllerBase
    {
        private IDevolucionesAplicacion IDevolucionesAplicacion;

        public DevolucionesController(IDevolucionesAplicacion IDevolucionesAplicacion)
        {
            this.IDevolucionesAplicacion = IDevolucionesAplicacion;
        }

        [HttpPost]
        public List<Devoluciones> Consultar()
        {
            return this.IDevolucionesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Devoluciones> Buscar(Devoluciones entidad)
        {
            return this.IDevolucionesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Devoluciones Insertar(Devoluciones entidad)
        {
            return this.IDevolucionesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Devoluciones Actualizar(Devoluciones entidad)
        {
            return this.IDevolucionesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Devoluciones Borrar(Devoluciones entidad)
        {
            return this.IDevolucionesAplicacion.Borrar(entidad);
        }
    }
}
