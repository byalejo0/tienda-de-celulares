using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IDetallesFacturasAplicacion
    {
        DetallesFacturas Insertar(DetallesFacturas entidad);
        DetallesFacturas Actualizar(DetallesFacturas entidad);
        List<DetallesFacturas> Consultar();
        List<DetallesFacturas> Buscar(DetallesFacturas entidad);
        DetallesFacturas Borrar(DetallesFacturas entidad);
    }
}