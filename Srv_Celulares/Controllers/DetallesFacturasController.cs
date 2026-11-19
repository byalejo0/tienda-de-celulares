using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DetallesFacturasController : ControllerBase
    {
        private IDetallesFacturasAplicacion IDetallesFacturasAplicacion;

        public DetallesFacturasController(IDetallesFacturasAplicacion IDetallesFacturasAplicacion)
        {
            this.IDetallesFacturasAplicacion = IDetallesFacturasAplicacion;
        }

        [HttpPost]
        public List<DetallesFacturas> Consultar()
        {
            return this.IDetallesFacturasAplicacion.Consultar();
        }

        [HttpPost]
        public List<DetallesFacturas> Buscar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            return this.IDetallesFacturasAplicacion.Borrar(entidad);
        }
    }
}
