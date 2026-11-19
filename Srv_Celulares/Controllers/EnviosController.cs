using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EnviosController : ControllerBase
    {
        private IEnviosAplicacion IEnviosAplicacion;

        public EnviosController(IEnviosAplicacion IEnviosAplicacion)
        {
            this.IEnviosAplicacion = IEnviosAplicacion;
        }

        [HttpPost]
        public List<Envios> Consultar()
        {
            return this.IEnviosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Envios> Buscar(Envios entidad)
        {
            return this.IEnviosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Envios Insertar(Envios entidad)
        {
            return this.IEnviosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Envios Actualizar(Envios entidad)
        {
            return this.IEnviosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Envios Borrar(Envios entidad)
        {
            return this.IEnviosAplicacion.Borrar(entidad);
        }
    }
}
