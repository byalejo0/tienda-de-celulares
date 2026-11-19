using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface ITecnicosAplicacion
    {
        Tecnicos Insertar(Tecnicos entidad);
        Tecnicos Actualizar(Tecnicos entidad);
        List<Tecnicos> Consultar();
        List<Tecnicos> Buscar(Tecnicos entidad);
        Tecnicos Borrar(Tecnicos entidad);
    }
}