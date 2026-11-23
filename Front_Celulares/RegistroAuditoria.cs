using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;

namespace Front_Celulares
{
    // Escribe una fila en la tabla Auditorias: quien (UsuarioId), que hizo y cuando.
    // Nunca lanza error: si la auditoria falla, la aplicacion sigue funcionando.
    public static class RegistroAuditoria
    {
        public static void Registrar(IAuditoriasPresentacion auditorias, int usuarioId, string descripcion)
        {
            try
            {
                if (usuarioId <= 0 || string.IsNullOrWhiteSpace(descripcion))
                    return;

                if (descripcion.Length > 200)
                    descripcion = descripcion.Substring(0, 200);

                auditorias.Insertar(new Auditorias
                {
                    UsuarioId = usuarioId,
                    Descripcion = descripcion,
                    Fecha = DateTime.Now
                });
            }
            catch
            {
                // la auditoria no debe tumbar la operacion principal
            }
        }
    }
}
