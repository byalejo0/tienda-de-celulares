using lib_Celulares.Entidades;
using lib_Celulares.Nucleo;

namespace lib_Celulares.Interfaces
{
    public interface IUsuariosAplicacion
    {
        Usuarios Insertar(Usuarios entidad);
        Usuarios Actualizar(Usuarios entidad);
        List<Usuarios> Consultar();
        List<Usuarios> Buscar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
        SesionUsuario Autenticar(Usuarios entidad);
    }
}