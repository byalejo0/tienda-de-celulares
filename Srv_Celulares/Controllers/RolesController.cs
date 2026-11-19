using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesAplicacion IRolesAplicacion;

        public RolesController(IRolesAplicacion IRolesAplicacion)
        {
            this.IRolesAplicacion = IRolesAplicacion;
        }

        [HttpPost]
        public List<Roles> Consultar()
        {
            return this.IRolesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Roles> Buscar(Roles entidad)
        {
            return this.IRolesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Roles Insertar(Roles entidad)
        {
            return this.IRolesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Roles Actualizar(Roles entidad)
        {
            return this.IRolesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Roles Borrar(Roles entidad)
        {
            return this.IRolesAplicacion.Borrar(entidad);
        }
    }
}
