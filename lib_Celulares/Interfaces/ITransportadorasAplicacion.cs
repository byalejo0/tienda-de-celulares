using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface ITransportadorasAplicacion
    {
        Transportadoras Insertar(Transportadoras entidad);
        Transportadoras Actualizar(Transportadoras entidad);
        List<Transportadoras> Consultar();
        List<Transportadoras> Buscar(Transportadoras entidad);
        Transportadoras Borrar(Transportadoras entidad);
    }
}