using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GarantiasController : ControllerBase
    {
        private IGarantiasAplicacion IGarantiasAplicacion;

        public GarantiasController(IGarantiasAplicacion IGarantiasAplicacion)
        {
            this.IGarantiasAplicacion = IGarantiasAplicacion;
        }

        [HttpPost]
        public List<Garantias> Consultar()
        {
            return this.IGarantiasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Garantias> Buscar(Garantias entidad)
        {
            return this.IGarantiasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Garantias Insertar(Garantias entidad)
        {
            return this.IGarantiasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Garantias Actualizar(Garantias entidad)
        {
            return this.IGarantiasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Garantias Borrar(Garantias entidad)
        {
            return this.IGarantiasAplicacion.Borrar(entidad);
        }
    }
}
