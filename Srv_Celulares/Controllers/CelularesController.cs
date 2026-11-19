using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CelularesController : ControllerBase
    {
        private ICelularesAplicacion ICelularesAplicacion;

        public CelularesController(ICelularesAplicacion ICelularesAplicacion)
        {
            this.ICelularesAplicacion = ICelularesAplicacion;
        }

        [HttpPost]
        public List<Celulares> Consultar()
        {
            return this.ICelularesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Celulares> Buscar(Celulares entidad)
        {
            return this.ICelularesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Celulares Insertar(Celulares entidad)
        {
            return this.ICelularesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Celulares Actualizar(Celulares entidad)
        {
            return this.ICelularesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Celulares Borrar(Celulares entidad)
        {
            return this.ICelularesAplicacion.Borrar(entidad);
        }
    }
}
