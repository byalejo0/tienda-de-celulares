/*
    public class Persona
    {
        public int Id { get; set; }
        public string? Cedula { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }
        public string? Direccion { get; set; }

        public List<Cliente>? Clientes { get; set; }
        public List<Trabajador>? Trabajadores { get; set; }
    }

    public class Cliente
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string? TipoCliente { get; set; }
        public string? PaisResidencia { get; set; }
        public string? Correo { get; set; }

        public Persona? Persona { get; set; }
        public List<Factura>? Facturas { get; set; }
        public List<Garantia>? Garantias { get; set; }
        public List<Envio>? Envios { get; set; }
        public List<Devolucion>? Devoluciones { get; set; }
        public List<Reparacion>? Reparaciones { get; set; }
    }

    public class Trabajador
    {
        public int Id { get; set; }
        public int PersonaId { get; set; }
        public string? Experiencia { get; set; }
        public decimal Salario { get; set; }
        public string? Turno { get; set; }

        public Persona? Persona { get; set; }
        public List<Vendedor>? Vendedores { get; set; }
        public List<Tecnico>? Tecnicos { get; set; }
        public List<Factura>? Facturas { get; set; }
        public List<Compra>? Compras { get; set; }
    }

    public class Vendedor
    {
        public int Id { get; set; }
        public int TrabajadorId { get; set; }
        public int CelularesVendidos { get; set; }
        public string? MarcaEncargada { get; set; }

        public Trabajador? Trabajador { get; set; }
    }

    public class Tecnico
    {
        public int Id { get; set; }
        public int TrabajadorId { get; set; }
        public int CelularesReparados { get; set; }
        public string? Especializacion { get; set; }

        public Trabajador? Trabajador { get; set; }
        public List<Bono>? Bonos { get; set; }
        public List<Reparacion>? Reparaciones { get; set; }
    }

    public class Marca
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Direccion { get; set; }

        public List<Celular>? Celulares { get; set; }
    }

    public class Componente
    {
        public int Id { get; set; }
        public string? Procesador { get; set; }
        public string? MemoriaRam { get; set; }
        public string? Pantalla { get; set; }
        public string? Bateria { get; set; }
        public string? Camara { get; set; }
        public string? SistemaOperativo { get; set; }

        public List<Celular>? Celulares { get; set; }
    }

    public class Celular
    {
        public int Id { get; set; }
        public int MarcaId { get; set; }
        public int ComponenteId { get; set; }
        public bool Disponible { get; set; }
        public int CantidadDisponible { get; set; }
        public string? Color { get; set; }
        public decimal Precio { get; set; }
        public string? Modelo { get; set; }
        public string? Almacenamiento { get; set; }

        public Marca? Marca { get; set; }
        public Componente? Componente { get; set; }
        public List<Garantia>? Garantias { get; set; }
        public List<DetalleFactura>? DetallesFacturas { get; set; }
        public List<Reparacion>? Reparaciones { get; set; }
        public List<DetalleCompra>? DetallesCompras { get; set; }
    }

    public class Factura
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TrabajadorId { get; set; }
        public int? ReparacionId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public Cliente? Cliente { get; set; }
        public Trabajador? Trabajador { get; set; }
        public Reparacion? Reparacion { get; set; }
        public Envio? Envio { get; set; }
        public List<DetalleFactura>? DetallesFacturas { get; set; }
        public List<Garantia>? Garantias { get; set; }
        public List<Devolucion>? Devoluciones { get; set; }
    }

    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int CelularId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public Factura? Factura { get; set; }
        public Celular? Celular { get; set; }
    }

    public class Garantia
    {
        public int Id { get; set; }
        public int CelularId { get; set; }
        public int ClienteId { get; set; }
        public int FacturaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string? TipoGarantia { get; set; }
        public string? Estado { get; set; }

        public Celular? Celular { get; set; }
        public Cliente? Cliente { get; set; }
        public Factura? Factura { get; set; }
    }

    public class Transportadora
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }

        public List<Envio>? Envios { get; set; }
    }

    public class Envio
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int TransportadoraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public decimal CostoEnvio { get; set; }

        public Factura? Factura { get; set; }
        public Transportadora? Transportadora { get; set; }
        public Cliente? Cliente { get; set; }
    }

    public class Devolucion
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string? Motivo { get; set; }
        public decimal ValorDevuelto { get; set; }

        public Factura? Factura { get; set; }
        public Cliente? Cliente { get; set; }
    }

    public class Reparacion
    {
        public int Id { get; set; }
        public int CelularId { get; set; }
        public int TecnicoId { get; set; }
        public int ClienteId { get; set; }
        public int? BonoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? Estado { get; set; }

        public Celular? Celular { get; set; }
        public Tecnico? Tecnico { get; set; }
        public Cliente? Cliente { get; set; }
        public Bono? Bono { get; set; }
        public List<DetalleReparacion>? DetallesReparaciones { get; set; }
        public List<Factura>? Facturas { get; set; }
    }

    public class DetalleReparacion
    {
        public int Id { get; set; }
        public int ReparacionId { get; set; }
        public string? Diagnostico { get; set; }
        public string? ServicioRealizado { get; set; }
        public string? ComponenteReemplazado { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Subtotal { get; set; }

        public Reparacion? Reparacion { get; set; }
    }

    public class Bono
    {
        public int Id { get; set; }
        public int TecnicoId { get; set; }
        public int CantidadReparaciones { get; set; }
        public decimal ValorBono { get; set; }

        public Tecnico? Tecnico { get; set; }
        public List<Reparacion>? Reparaciones { get; set; }
    }

    public class Proveedor
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }

        public List<Compra>? Compras { get; set; }
    }

    public class Compra
    {
        public int Id { get; set; }
        public int ProveedorId { get; set; }
        public int TrabajadorId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public string? Estado { get; set; }

        public Proveedor? Proveedor { get; set; }
        public Trabajador? Trabajador { get; set; }
        public List<DetalleCompra>? DetallesCompras { get; set; }
    }

    public class DetalleCompra
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int CelularId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }

        public Compra? Compra { get; set; }
        public Celular? Celular { get; set; }
    }
*/