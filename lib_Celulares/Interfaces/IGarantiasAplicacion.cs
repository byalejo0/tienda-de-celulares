using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IGarantiasAplicacion
    {
        Garantias Insertar(Garantias entidad);
        Garantias Actualizar(Garantias entidad);
        List<Garantias> Consultar();
        List<Garantias> Buscar(Garantias entidad);
        Garantias Borrar(Garantias entidad);
    }
}