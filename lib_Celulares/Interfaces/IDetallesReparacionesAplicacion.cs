using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IDetallesReparacionesAplicacion
    {
        DetallesReparaciones Insertar(DetallesReparaciones entidad);
        DetallesReparaciones Actualizar(DetallesReparaciones entidad);
        List<DetallesReparaciones> Consultar();
        List<DetallesReparaciones> Buscar(DetallesReparaciones entidad);
        DetallesReparaciones Borrar(DetallesReparaciones entidad);
    }
}