using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IBonosAplicacion
    {
        Bonos Insertar(Bonos entidad);
        Bonos Actualizar(Bonos entidad);
        List<Bonos> Consultar();
        List<Bonos> Buscar(Bonos entidad);
        Bonos Borrar(Bonos entidad);
    }
}