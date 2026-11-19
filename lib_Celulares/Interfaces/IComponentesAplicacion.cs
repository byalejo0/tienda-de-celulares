using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IComponentesAplicacion
    {
        Componentes Insertar(Componentes entidad);
        Componentes Actualizar(Componentes entidad);
        List<Componentes> Consultar();
        List<Componentes> Buscar(Componentes entidad);
        Componentes Borrar(Componentes entidad);
    }
}