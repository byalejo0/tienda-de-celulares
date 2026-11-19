using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IFacturasAplicacion
    {
        Facturas Insertar(Facturas entidad);
        Facturas Actualizar(Facturas entidad);
        List<Facturas> Consultar();
        List<Facturas> Buscar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}