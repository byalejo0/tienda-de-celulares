CREATE DATABASE tienda_celulares_db;
GO
USE tienda_celulares_db;
GO

CREATE TABLE [Personas](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Cedula] NVARCHAR(20) NOT NULL UNIQUE,
    [Nombre] NVARCHAR(100) NOT NULL,
    [Edad] INT NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Clientes](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [PersonaId] INT NOT NULL REFERENCES [Personas] ([Id]),
    [TipoCliente] NVARCHAR(100) NOT NULL,
    [PaisResidencia] NVARCHAR(50) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Trabajador](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [PersonaId] INT NOT NULL REFERENCES [Personas] ([Id]),
    [Experiencia] NVARCHAR(100) NOT NULL,
    [Salario] DECIMAL(15,2) NOT NULL,
    [Turno] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Vendedor](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajador] ([Id]),
    [CelularesVendidos] INT NOT NULL,
    [MarcaEncargada] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Tecnico](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajador] ([Id]),
    [CelularesReparados] INT NOT NULL,
    [Especializacion] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Marca](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Componente](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Procesador] NVARCHAR(100) NOT NULL,
    [MemoriaRam] NVARCHAR(50) NOT NULL,
    [Pantalla] NVARCHAR(100) NOT NULL,
    [Bateria] NVARCHAR(50) NOT NULL,
    [Camara] NVARCHAR(100) NOT NULL,
    [SistemaOperativo] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Celular](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [MarcaId] INT NOT NULL REFERENCES [Marca] ([Id]),
    [ComponenteId] INT NOT NULL REFERENCES [Componente] ([Id]),
    [Disponible] BIT NOT NULL,
    [CantidadDisponible] INT NOT NULL,
    [Color] NVARCHAR(50) NOT NULL,
    [Precio] DECIMAL(15,2) NOT NULL,
    [Modelo] NVARCHAR(100) NOT NULL,
    [Almacenamiento] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Transportadora](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL
);

CREATE TABLE [Proveedor](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Compra](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ProveedorId] INT NOT NULL REFERENCES [Proveedor] ([Id]),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajador] ([Id]),
    [FechaCompra] DATETIME NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [DetalleCompra](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CompraId] INT NOT NULL REFERENCES [Compra] ([Id]),
    [CelularId] INT NOT NULL REFERENCES [Celular] ([Id]),
    [Cantidad] INT NOT NULL,
    [PrecioCompra] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Bono](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TecnicoId] INT NOT NULL REFERENCES [Tecnico] ([Id]),
    [CantidadReparaciones] INT NOT NULL,
    [ValorBono] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Reparacion](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CelularId] INT NOT NULL REFERENCES [Celular] ([Id]),
    [TecnicoId] INT NOT NULL REFERENCES [Tecnico] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [BonoId] INT NULL REFERENCES [Bono] ([Id]),
    [FechaIngreso] DATETIME NOT NULL,
    [FechaEntrega] DATETIME NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [DetalleReparacion](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ReparacionId] INT NOT NULL REFERENCES [Reparacion] ([Id]),
    [Diagnostico] NVARCHAR(200) NOT NULL,
    [ServicioRealizado] NVARCHAR(200) NOT NULL,
    [ComponenteReemplazado] NVARCHAR(100) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(15,2) NOT NULL,
    [Subtotal] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Factura](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajador] ([Id]),
    [ReparacionId] INT NULL REFERENCES [Reparacion] ([Id]),
    [Fecha] DATETIME NOT NULL,
    [Subtotal] DECIMAL(15,2) NOT NULL,
    [Iva] DECIMAL(15,2) NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [DetalleFactura](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Factura] ([Id]),
    [CelularId] INT NOT NULL REFERENCES [Celular] ([Id]),
    [Cantidad] INT NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Iva] DECIMAL(15,2) NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Garantia](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CelularId] INT NOT NULL REFERENCES [Celular] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FacturaId] INT NOT NULL REFERENCES [Factura] ([Id]),
    [FechaInicio] DATETIME NOT NULL,
    [FechaVencimiento] DATETIME NOT NULL,
    [TipoGarantia] NVARCHAR(100) NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Envio](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Factura] ([Id]),
    [TransportadoraId] INT NOT NULL REFERENCES [Transportadora] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FechaEnvio] DATETIME NOT NULL,
    [FechaEntrega] DATETIME NOT NULL,
    [CostoEnvio] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Devolucion](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Factura] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FechaDevolucion] DATETIME NOT NULL,
    [Motivo] NVARCHAR(200) NOT NULL,
    [ValorDevuelto] DECIMAL(15,2) NOT NULL
);