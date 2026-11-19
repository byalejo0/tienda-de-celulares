using lib_Celulares.Entidades;

namespace lib_Celulares.Interfaces
{
    public interface IDevolucionesAplicacion
    {
        Devoluciones Insertar(Devoluciones entidad);
        Devoluciones Actualizar(Devoluciones entidad);
        List<Devoluciones> Consultar();
        List<Devoluciones> Buscar(Devoluciones entidad);
        Devoluciones Borrar(Devoluciones entidad);
    }
}