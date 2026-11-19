using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProveedoresController : ControllerBase
    {
        private IProveedoresAplicacion IProveedoresAplicacion;

        public ProveedoresController(IProveedoresAplicacion IProveedoresAplicacion)
        {
            this.IProveedoresAplicacion = IProveedoresAplicacion;
        }

        [HttpPost]
        public List<Proveedores> Consultar()
        {
            return this.IProveedoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<Proveedores> Buscar(Proveedores entidad)
        {
            return this.IProveedoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Proveedores Insertar(Proveedores entidad)
        {
            return this.IProveedoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Proveedores Actualizar(Proveedores entidad)
        {
            return this.IProveedoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Proveedores Borrar(Proveedores entidad)
        {
            return this.IProveedoresAplicacion.Borrar(entidad);
        }
    }
}
