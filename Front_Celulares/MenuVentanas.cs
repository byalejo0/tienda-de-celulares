namespace Front_Celulares
{
    public record Ventana(string Pagina, string Etiqueta);

    public record GrupoVentanas(string Titulo, Ventana[] Ventanas);

    public record PerfilRol(string Clase, string Titulo, string Descripcion);


    public static class MenuVentanas
    {
        public const string Cliente = "Cliente";
        public const string Trabajador = "Trabajador";
        public const string Administrador = "Administrador";

        private static readonly string[] PrioridadRoles = [Administrador, Trabajador, Cliente];

        public static readonly GrupoVentanas[] Grupos =
        [
            new("Tienda",
            [
                new("Celulares", "Celulares"),
                new("Marcas", "Marcas"),
                new("Carrito", "Carrito"),
                new("Facturas", "Facturas"),
                new("DetallesFacturas", "Detalles de facturas"),
                new("Garantias", "Garantías"),
                new("Envios", "Envíos"),
                new("Devoluciones", "Devoluciones"),
                new("Reparaciones", "Reparaciones"),
                new("DetallesReparaciones", "Detalles de reparaciones")
            ]),

            new("Operación",
            [
                new("Clientes", "Clientes"),
                new("Componentes", "Componentes"),
                new("Compras", "Compras"),
                new("DetallesCompras", "Detalles de compras"),
                new("Proveedores", "Proveedores"),
                new("Transportadoras", "Transportadoras")
            ]),

            new("Administración",
            [
                new("Personas", "Personas"),
                new("Trabajadores", "Trabajadores"),
                new("Vendedores", "Vendedores"),
                new("Tecnicos", "Técnicos"),
                new("Bonos", "Bonos"),
                new("Usuarios", "Usuarios"),
                new("Roles", "Roles"),
                new("Permisos", "Permisos"),
                new("Auditorias", "Auditorías")
            ])
        ];

        public static IEnumerable<GrupoVentanas> GruposVisibles(IEnumerable<string> ventanasPermitidas)
        {
            var permitidas = new HashSet<string>(ventanasPermitidas, StringComparer.OrdinalIgnoreCase);

            return Grupos
                .Select(g => new GrupoVentanas(
                    g.Titulo,
                    g.Ventanas.Where(v => permitidas.Contains(v.Pagina)).ToArray()))
                .Where(g => g.Ventanas.Length > 0);
        }

        public static string RolPrincipal(IEnumerable<string> roles)
        {
            var lista = roles.ToList();

            foreach (var prioridad in PrioridadRoles)
            {
                var encontrado = lista.FirstOrDefault(r =>
                    string.Equals(r, prioridad, StringComparison.OrdinalIgnoreCase));
                if (encontrado != null)
                    return prioridad;
            }

            return lista.FirstOrDefault() ?? string.Empty;
        }

        public static PerfilRol PerfilDe(string? rol)
        {
            if (string.Equals(rol, Administrador, StringComparison.OrdinalIgnoreCase))
                return new PerfilRol("rol-administrador", "Panel de administración",
                    "Gestiona el personal, los bonos y las cuentas, además de toda la operación de la tienda.");

            if (string.Equals(rol, Trabajador, StringComparison.OrdinalIgnoreCase))
                return new PerfilRol("rol-trabajador", "Panel de trabajo",
                    "Atiende clientes y lleva el inventario y el abastecimiento de la tienda.");

            if (string.Equals(rol, Cliente, StringComparison.OrdinalIgnoreCase))
                return new PerfilRol("rol-cliente", "Mi tienda",
                    "Explora el catálogo, arma tu carrito y gestiona facturas, garantías, envíos, devoluciones y reparaciones.");

            return new PerfilRol("rol-otro", "Mi espacio",
                "Estas son las ventanas disponibles para tu usuario.");
        }
    }
}
