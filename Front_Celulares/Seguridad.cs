using System.Text.Json;
using lib_Celulares.Nucleo;

namespace Front_Celulares
{
    // Guarda y lee en la sesion quien inicio sesion, con que rol y a que ventanas
    // puede entrar. Los datos vienen de Usuarios, Roles y Permisos (ver
    // UsuariosAplicacion.Autenticar).
    public static class Seguridad
    {
        private const string LlaveUsuario = "Usuario";
        private const string LlaveRol = "Rol";
        private const string LlaveRoles = "Roles";
        private const string LlaveVentanas = "Ventanas";

        public static void Iniciar(ISession session, SesionUsuario sesion)
        {
            session.Clear();
            session.SetString(LlaveUsuario, sesion.Nombre_Usuario ?? string.Empty);
            session.SetString(LlaveRol, MenuVentanas.RolPrincipal(sesion.Roles));
            session.SetString(LlaveRoles, JsonSerializer.Serialize(sesion.Roles));
            session.SetString(LlaveVentanas, JsonSerializer.Serialize(sesion.Ventanas));
        }

        public static bool EstaLogueado(ISession session)
            => !string.IsNullOrEmpty(session.GetString(LlaveUsuario));

        public static string? Nombre(ISession session)
            => session.GetString(LlaveUsuario);

        // Rol principal: el que decide la interfaz de inicio.
        public static string? Rol(ISession session)
            => session.GetString(LlaveRol);

        public static HashSet<string> Ventanas(ISession session)
        {
            var json = session.GetString(LlaveVentanas);
            var lista = string.IsNullOrEmpty(json)
                ? new List<string>()
                : JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

            return new HashSet<string>(lista, StringComparer.OrdinalIgnoreCase);
        }

        public static bool TieneAcceso(ISession session, string? ventana)
            => !string.IsNullOrEmpty(ventana) && Ventanas(session).Contains(ventana);

        public static IEnumerable<GrupoVentanas> GruposVisibles(ISession session)
            => MenuVentanas.GruposVisibles(Ventanas(session));

        // Texto corto para la barra superior: "Juan (Cliente)". Vacio si no hay sesion.
        public static string Chip(ISession session)
            => EstaLogueado(session) ? $"{Nombre(session)} ({Rol(session)})" : string.Empty;
    }
}
