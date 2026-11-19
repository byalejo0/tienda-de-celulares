using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private IClientesAplicacion IClientesAplicacion;

        public ClientesController(IClientesAplicacion IClientesAplicacion)
        {
            this.IClientesAplicacion = IClientesAplicacion;
        }

        [HttpPost]
        public List<Clientes> Consultar()
        {
            return this.IClientesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Clientes> Buscar(Clientes entidad)
        {
            return this.IClientesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Clientes Insertar(Clientes entidad)
        {
            return this.IClientesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Clientes Actualizar(Clientes entidad)
        {
            return this.IClientesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Clientes Borrar(Clientes entidad)
        {
            return this.IClientesAplicacion.Borrar(entidad);
        }
    }
}
