using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesComprasController : ControllerBase
    {
        private IDetallesComprasAplicacion IDetallesComprasAplicacion;

        public DetallesComprasController(IDetallesComprasAplicacion IDetallesComprasAplicacion)
        {
            this.IDetallesComprasAplicacion = IDetallesComprasAplicacion;
        }

        [HttpPost]
        public List<DetallesCompras> Consultar()
        {
            return this.IDetallesComprasAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesCompras> Buscar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            return this.IDetallesComprasAplicacion.Borrar(entidad);
        }
    }
}
