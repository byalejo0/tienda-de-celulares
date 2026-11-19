using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        private IPersonasAplicacion IPersonasAplicacion;

        public PersonasController(IPersonasAplicacion IPersonasAplicacion)
        {
            this.IPersonasAplicacion = IPersonasAplicacion;
        }

        [HttpPost]
        public List<Personas> Consultar()
        {
            return this.IPersonasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Personas> Buscar(Personas entidad)
        {
            return this.IPersonasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Personas Insertar(Personas entidad)
        {
            return this.IPersonasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Personas Actualizar(Personas entidad)
        {
            return this.IPersonasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Personas Borrar(Personas entidad)
        {
            return this.IPersonasAplicacion.Borrar(entidad);
        }
    }
}
