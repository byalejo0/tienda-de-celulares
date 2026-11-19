using lib_Celulares.Entidades;
using lib_Celulares.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cnl_Celulares.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MarcasController : ControllerBase
    {
        private IMarcasAplicacion IMarcasAplicacion;

        public MarcasController(IMarcasAplicacion IMarcasAplicacion)
        {
            this.IMarcasAplicacion = IMarcasAplicacion;
        }

        [HttpPost]
        public List<Marcas> Consultar()
        {
            return this.IMarcasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Marcas> Buscar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Marcas Insertar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Marcas Actualizar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Marcas Borrar(Marcas entidad)
        {
            return this.IMarcasAplicacion.Borrar(entidad);
        }
    }
}
