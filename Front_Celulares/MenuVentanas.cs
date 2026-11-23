namespace Front_Celulares
{
    public record Ventana(string Pagina, string Etiqueta);

    public record GrupoVentanas(string Titulo, Ventana[] Ventanas);

    // Como se ve el inicio segun el rol: clase CSS, titulo y descripcion.
    public record PerfilRol(string Clase, string Titulo, string Descripcion);

    // Catalogo de ventanas de la aplicacion, agrupadas para el menu.
    //
    // Quien puede entrar a cada ventana NO se define aqui: sale de la base de
    // datos (Usuarios -> Roles -> Permisos). Permisos.Ventana debe ser igual a
    // Ventana.Pagina. Para sumar una ventana nueva: crear la pagina, agregarla
    // a este catalogo y crear el Permiso para el rol que deba verla.
    public static class MenuVentanas
    {
        public const string Cliente = "Cliente";
        public const string Trabajador = "Trabajador";
        public const string Administrador = "Administrador";

        // Si un usuario tiene varios roles, manda el de mayor jerarquia.
        private static readonly string[] PrioridadRoles = [Administrador, Trabajador, Cliente];

        public static readonly GrupoVentanas[] Grupos =
        [
            // Lo que gira alrededor del cliente: catálogo y sus trámites
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

            // El día a día del local: clientes, inventario y abastecimiento
            new("Operación",
            [
                new("Clientes", "Clientes"),
                new("Componentes", "Componentes"),
                new("Compras", "Compras"),
                new("DetallesCompras", "Detalles de compras"),
                new("Proveedores", "Proveedores"),
                new("Transportadoras", "Transportadoras")
            ]),

            // Datos personales, salarios, bonos y cuentas
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

        // Los grupos con solo las ventanas permitidas; los grupos vacios no se muestran.
        public static IEnumerable<GrupoVentanas> GruposVisibles(IEnumerable<string> ventanasPermitidas)
        {
            var permitidas = new HashSet<string>(ventanasPermitidas, StringComparer.OrdinalIgnoreCase);

            return Grupos
                .Select(g => new GrupoVentanas(
                    g.Titulo,
                    g.Ventanas.Where(v => permitidas.Contains(v.Pagina)).ToArray()))
                .Where(g => g.Ventanas.Length > 0);
        }

        // El rol "principal" decide que interfaz de inicio se muestra.
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
