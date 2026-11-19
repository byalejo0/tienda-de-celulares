using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturasAplicacion IFacturasAplicacion;

        public FacturasController(IFacturasAplicacion IFacturasAplicacion)
        {
            this.IFacturasAplicacion = IFacturasAplicacion;
        }

        [HttpPost]
        public List<Facturas> Consultar()
        {
            return this.IFacturasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Facturas> Buscar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Facturas Insertar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Facturas Actualizar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Facturas Borrar(Facturas entidad)
        {
            return this.IFacturasAplicacion.Borrar(entidad);
        }
    }
}
