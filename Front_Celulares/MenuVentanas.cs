namespace Front_Celulares
{
    public record Ventana(string Pagina, string Etiqueta);

    public record GrupoVentanas(string Titulo, string[] Roles, Ventana[] Ventanas);

    // Quien puede ver que ventanas. Cliente < Trabajador < Administrador:
    // cada rol ve su lista y las de los roles de abajo; el Administrador ve todo.
    public static class MenuVentanas
    {
        public const string Cliente = "Cliente";
        public const string Trabajador = "Trabajador";
        public const string Administrador = "Administrador";

        // Usuarios de prueba: "Usuario.Clave" -> rol
        private static readonly Dictionary<string, string> Credenciales = new()
        {
            ["Usuario.123"] = Administrador,
            ["Trabajador.123"] = Trabajador,
            ["Cliente.123"] = Cliente
        };

        public static readonly GrupoVentanas[] Grupos =
        [
            // Lo que gira alrededor del cliente: catálogo y sus trámites
            new("Tienda", [Cliente, Trabajador, Administrador],
            [
                new("Celulares", "Celulares"),
                new("Marcas", "Marcas"),
                new("Facturas(Añadir DetallesFacturas)", "Facturas"),
                new("Garantias", "Garantías"),
                new("Envios", "Envíos"),
                new("Devoluciones", "Devoluciones"),
                new("Reparaciones(Añadir DetallesReparaciones)", "Reparaciones")
            ]),

            // El día a día del local: clientes, inventario y abastecimiento
            new("Operación", [Trabajador, Administrador],
            [
                new("Clientes", "Clientes"),
                new("Componentes", "Componentes"),
                new("Compras(Añadir DetallesCompras)", "Compras"),
                new("Proveedores", "Proveedores"),
                new("Transportadoras", "Transportadoras")
            ]),

            // Datos personales, salarios, bonos y cuentas: solo Administrador
            new("Administración", [Administrador],
            [
                new("Personas", "Personas"),
                new("Trabajadores", "Trabajadores"),
                new("Vendedores", "Vendedores"),
                new("Tecnicos", "Técnicos"),
                new("Bonos", "Bonos"),
                new("Usuarios", "Usuarios")
            ])
        ];

        public static string? RolDe(string credencial)
            => Credenciales.TryGetValue(credencial, out var rol) ? rol : null;

        public static IEnumerable<GrupoVentanas> GruposVisibles(string? rol)
            => rol == null ? Enumerable.Empty<GrupoVentanas>() : Grupos.Where(g => g.Roles.Contains(rol));
    }
}
