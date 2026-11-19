using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IVendedoresAplicacion
    {
        Vendedores Insertar(Vendedores entidad);
        Vendedores Actualizar(Vendedores entidad);
        List<Vendedores> Consultar();
        List<Vendedores> Buscar(Vendedores entidad);
        Vendedores Borrar(Vendedores entidad);
    }
}