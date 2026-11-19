using lib_Celulares.entidades;
using lib_Celulares.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class VendedoresController : ControllerBase
    {
        private IVendedoresAplicacion IVendedoresAplicacion;

        public VendedoresController(IVendedoresAplicacion IVendedoresAplicacion)
        {
            this.IVendedoresAplicacion = IVendedoresAplicacion;
        }

        [HttpPost]
        public List<Vendedores> Consultar()
        {
            return this.IVendedoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Vendedores> Buscar(Vendedores entidad)
        {
            return this.IVendedoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Vendedores Insertar(Vendedores entidad)
        {
            return this.IVendedoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Vendedores Actualizar(Vendedores entidad)
        {
            return this.IVendedoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Vendedores Borrar(Vendedores entidad)
        {
            return this.IVendedoresAplicacion.Borrar(entidad);
        }
    }
}
