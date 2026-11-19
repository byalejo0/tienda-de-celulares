using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IReparacionesAplicacion
    {
        Reparaciones Insertar(Reparaciones entidad);
        Reparaciones Actualizar(Reparaciones entidad);
        List<Reparaciones> Consultar();
        List<Reparaciones> Buscar(Reparaciones entidad);
        Reparaciones Borrar(Reparaciones entidad);
    }
}