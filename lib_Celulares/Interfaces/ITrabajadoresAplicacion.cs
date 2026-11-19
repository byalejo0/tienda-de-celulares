using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface ITrabajadoresAplicacion
    {
        Trabajadores Insertar(Trabajadores entidad);
        Trabajadores Actualizar(Trabajadores entidad);
        List<Trabajadores> Consultar();
        List<Trabajadores> Buscar(Trabajadores entidad);
        Trabajadores Borrar(Trabajadores entidad);
    }
}