using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IMarcasAplicacion
    {
        Marcas Insertar(Marcas entidad);
        Marcas Actualizar(Marcas entidad);
        List<Marcas> Consultar();
        List<Marcas> Buscar(Marcas entidad);
        Marcas Borrar(Marcas entidad);
    }
}