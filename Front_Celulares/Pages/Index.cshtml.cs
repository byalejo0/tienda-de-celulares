using lib_Celulares.Entidades;
using lib_Celulares.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pre_Celulares.Interfaces;

namespace Front_Celulares.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUsuariosPresentacion IUsuariosPresentacion;
        private readonly IAuditoriasPresentacion IAuditoriasPresentacion;

        public IndexModel(IUsuariosPresentacion iUsuariosPresentacion,
            IAuditoriasPresentacion iAuditoriasPresentacion)
        {
            this.IUsuariosPresentacion = iUsuariosPresentacion;
            this.IAuditoriasPresentacion = iAuditoriasPresentacion;
        }

        public bool EstaLogueado = false;
        public string? NombreUsuario { get; set; }
        public string? Rol { get; set; }
        public string? MensajeLogin { get; set; }
        public PerfilRol Perfil { get; set; } = MenuVentanas.PerfilDe(null);
        public List<GrupoVentanas> Grupos { get; set; } = new();

        [BindProperty] public string? Email { get; set; }
        [BindProperty] public string? Contraseña { get; set; }

        public void OnGet()
        {
            CargarSesion();
        }

        // Lee de la sesion quien esta logueado y arma la interfaz segun su rol.
        private void CargarSesion()
        {
            var session = HttpContext.Session;
            if (!Seguridad.EstaLogueado(session))
            {
                EstaLogueado = false;
                return;
            }

            EstaLogueado = true;
            NombreUsuario = Seguridad.Nombre(session);
            Rol = Seguridad.Rol(session);
            Perfil = MenuVentanas.PerfilDe(Rol);
            Grupos = Seguridad.GruposVisibles(session).ToList();
        }

        public void OnPostBtClean()
        {
            try
            {
                ModelState.Clear();
                Email = string.Empty;
                Contraseña = string.Empty;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrEmpty(Contraseña))
                {
                    MensajeLogin = "Ingresa tu usuario y tu contraseña.";
                    return;
                }

                // El servidor revisa Usuarios y devuelve sus Roles y Permisos.
                var sesion = this.IUsuariosPresentacion.Autenticar(new Usuarios
                {
                    Nombre_Usuario = Email.Trim(),
                    Contraseña = Contraseña
                });

                if (sesion == null || sesion.Id == 0)
                {
                    MensajeLogin = "Usuario o contraseña incorrectos.";
                    OnPostBtClean();
                    return;
                }

                if ((sesion.Roles?.Count ?? 0) == 0)
                {
                    MensajeLogin = "Tu usuario no tiene un rol asignado. Habla con el administrador.";
                    OnPostBtClean();
                    return;
                }

                Seguridad.Iniciar(HttpContext.Session, sesion);
                RegistroAuditoria.Registrar(this.IAuditoriasPresentacion, sesion.Id,
                    $"Inicio de sesión ({Seguridad.Rol(HttpContext.Session)})");
                OnPostBtClean();
                CargarSesion();
            }
            catch (Exception ex)
            {
                MensajeLogin = "No se pudo iniciar sesión. Verifica que el servidor (Srv_Celulares) esté en ejecución.";
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtClose()
        {
            try
            {
                RegistroAuditoria.Registrar(this.IAuditoriasPresentacion,
                    Seguridad.UsuarioId(HttpContext.Session), "Cierre de sesión");
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }
    }
}
