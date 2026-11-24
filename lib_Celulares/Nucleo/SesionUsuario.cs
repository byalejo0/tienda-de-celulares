namespace lib_Celulares.Nucleo
{

    public class SesionUsuario
    {
        public int Id { get; set; }
        public string? Nombre_Usuario { get; set; }
        public List<string> Roles { get; set; } = new();
        public List<string> Ventanas { get; set; } = new();
    }
}
