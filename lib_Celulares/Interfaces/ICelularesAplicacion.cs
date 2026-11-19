using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface ICelularesAplicacion
    {
        Celulares Insertar(Celulares entidad);
        Celulares Actualizar(Celulares entidad);
        List<Celulares> Consultar();
        List<Celulares> Buscar(Celulares entidad);
        Celulares Borrar(Celulares entidad);
    }
}