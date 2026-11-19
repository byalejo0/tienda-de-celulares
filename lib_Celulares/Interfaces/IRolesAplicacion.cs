using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IRolesAplicacion
    {
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        List<Roles> Consultar();
        List<Roles> Buscar(Roles entidad);
        Roles Borrar(Roles entidad);
    }
}