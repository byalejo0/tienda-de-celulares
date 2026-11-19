using aplicaciones_horarios.entidades;

namespace aplicaciones_horarios.interfaces
{
    public interface IAsignacionesAplicacion
    {
        Asignaciones Insertar(Asignaciones entidad);
        Asignaciones Actualizar(Asignaciones entidad);
        List<Asignaciones> Consultar();
        List<Asignaciones> Buscar(Asignaciones entidad);
        Asignaciones Borrar(Asignaciones entidad);
    }
}