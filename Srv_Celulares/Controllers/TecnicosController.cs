using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TecnicosController : ControllerBase
    {
        private ITecnicosAplicacion ITecnicosAplicacion;

        public TecnicosController(ITecnicosAplicacion ITecnicosAplicacion)
        {
            this.ITecnicosAplicacion = ITecnicosAplicacion;
        }

        [HttpPost]
        public List<Tecnicos> Consultar()
        {
            return this.ITecnicosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Tecnicos> Buscar(Tecnicos entidad)
        {
            return this.ITecnicosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Tecnicos Insertar(Tecnicos entidad)
        {
            return this.ITecnicosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Tecnicos Actualizar(Tecnicos entidad)
        {
            return this.ITecnicosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Tecnicos Borrar(Tecnicos entidad)
        {
            return this.ITecnicosAplicacion.Borrar(entidad);
        }
    }
}
