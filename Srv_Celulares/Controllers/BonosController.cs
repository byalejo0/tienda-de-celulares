using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BonosController : ControllerBase
    {
        private IBonosAplicacion IBonosAplicacion;

        public BonosController(IBonosAplicacion IBonosAplicacion)
        {
            this.IBonosAplicacion = IBonosAplicacion;
        }

        [HttpPost]
        public List<Bonos> Consultar()
        {
            return this.IBonosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Bonos> Buscar(Bonos entidad)
        {
            return this.IBonosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Bonos Insertar(Bonos entidad)
        {
            return this.IBonosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Bonos Actualizar(Bonos entidad)
        {
            return this.IBonosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Bonos Borrar(Bonos entidad)
        {
            return this.IBonosAplicacion.Borrar(entidad);
        }
    }
}
