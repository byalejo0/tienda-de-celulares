using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComponentesController : ControllerBase
    {
        private IComponentesAplicacion IComponentesAplicacion;

        public ComponentesController(IComponentesAplicacion IComponentesAplicacion)
        {
            this.IComponentesAplicacion = IComponentesAplicacion;
        }

        [HttpPost]
        public List<Componentes> Consultar()
        {
            return this.IComponentesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Componentes> Buscar(Componentes entidad)
        {
            return this.IComponentesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Componentes Insertar(Componentes entidad)
        {
            return this.IComponentesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Componentes Actualizar(Componentes entidad)
        {
            return this.IComponentesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Componentes Borrar(Componentes entidad)
        {
            return this.IComponentesAplicacion.Borrar(entidad);
        }
    }
}
