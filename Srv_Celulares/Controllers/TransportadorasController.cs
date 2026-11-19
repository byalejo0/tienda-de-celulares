using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransportadorasController : ControllerBase
    {
        private ITransportadorasAplicacion ITransportadorasAplicacion;

        public TransportadorasController(ITransportadorasAplicacion ITransportadorasAplicacion)
        {
            this.ITransportadorasAplicacion = ITransportadorasAplicacion;
        }

        [HttpPost]
        public List<Transportadoras> Consultar()
        {
            return this.ITransportadorasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Transportadoras> Buscar(Transportadoras entidad)
        {
            return this.ITransportadorasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Transportadoras Insertar(Transportadoras entidad)
        {
            return this.ITransportadorasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Transportadoras Actualizar(Transportadoras entidad)
        {
            return this.ITransportadorasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Transportadoras Borrar(Transportadoras entidad)
        {
            return this.ITransportadorasAplicacion.Borrar(entidad);
        }
    }
}
