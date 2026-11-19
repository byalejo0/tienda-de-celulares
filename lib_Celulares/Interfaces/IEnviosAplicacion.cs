using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IEnviosAplicacion
    {
        Envios Insertar(Envios entidad);
        Envios Actualizar(Envios entidad);
        List<Envios> Consultar();
        List<Envios> Buscar(Envios entidad);
        Envios Borrar(Envios entidad);
    }
}