namespace lib_Celulares.Nucleo
{
    // Lo que el servidor devuelve cuando alguien inicia sesion: quien es, que
    // roles tiene (tabla Roles) y a que ventanas puede entrar (tabla Permisos).
    // Nunca incluye la contraseña. Si Id == 0 las credenciales no son validas.
    public class SesionUsuario
    {
        public int Id { get; set; }
        public string? Nombre_Usuario { get; set; }
        public List<string> Roles { get; set; } = new();
        public List<string> Ventanas { get; set; } = new();
    }
}
