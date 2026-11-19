using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ComprasController : ControllerBase
    {
        private IComprasAplicacion IComprasAplicacion;

        public ComprasController(IComprasAplicacion IComprasAplicacion)
        {
            this.IComprasAplicacion = IComprasAplicacion;
        }

        [HttpPost]
        public List<Compras> Consultar()
        {
            return this.IComprasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Compras> Buscar(Compras entidad)
        {
            return this.IComprasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Compras Insertar(Compras entidad)
        {
            return this.IComprasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Compras Actualizar(Compras entidad)
        {
            return this.IComprasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Compras Borrar(Compras entidad)
        {
            return this.IComprasAplicacion.Borrar(entidad);
        }
    }
}
