/*CREATE DATABASE tienda_celulares_db;
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

INSERT INTO [Personas] ([Cedula], [Nombre], [Edad], [Direccion])
VALUES (N'1023456789', N'Carlos Andrés Ramírez', 32, N'Calle 45 # 12-30, Bogotá');

INSERT INTO [Clientes] ([TipoCliente], [PaisResidencia], [Correo])
VALUES (N'Frecuente', N'Colombia', N'carlos.ramirez@correo.com');

INSERT INTO [Trabajador] ([Experiencia], [Salario], [Turno])
VALUES (N'3 años', 2500000.00, N'Mañana (8:00 a.m. - 4:00 p.m.)');

INSERT INTO [Vendedor] ([CelularesVendidos], [MarcaEncargada])
VALUES (120, N'Samsung');

INSERT INTO [Tecnico] ([CelularesReparados], [Especializacion])
VALUES (85, N'Reparación de pantallas y baterías');

INSERT INTO [Marca] ([Nombre], [Telefono], [Correo], [Direccion])
VALUES (N'Samsung', N'6017451234', N'contacto@samsung.com', N'Carrera 7 # 71-21, Bogotá');

INSERT INTO [Componente] ([Procesador], [MemoriaRam], [Pantalla], [Bateria], [Camara], [SistemaOperativo])
VALUES (N'Snapdragon 8 Gen 2', N'8 GB', N'AMOLED 6.1" 120Hz', N'4000 mAh', N'50 MP + 12 MP + 10 MP', N'Android 14');

INSERT INTO [Celular] ([Disponible], [CantidadDisponible], [Color], [Precio], [Modelo], [Almacenamiento])
VALUES (1, 15, N'Negro', 3200000.00, N'Galaxy S23', N'256 GB');

INSERT INTO [Transportadora] ([Nombre], [Correo], [Telefono])
VALUES (N'Servientrega', N'servicio@servientrega.com', N'6015551234');

INSERT INTO [Proveedor] ([Nombre], [Correo], [Telefono], [Direccion])
VALUES (N'Distribuidora Tech S.A.S', N'ventas@distritech.com', N'6014447788', N'Zona Industrial Puente Aranda, Bogotá');

INSERT INTO [Compra] ([FechaCompra], [Total], [Estado])
VALUES ('2026-09-10 10:30:00', 32000000.00, N'Recibida');

INSERT INTO [DetalleCompra] ([Cantidad], [PrecioCompra])
VALUES (10, 3200000.00);

INSERT INTO [Bono] ([CantidadReparaciones], [ValorBono])
VALUES (50, 150000.00);

INSERT INTO [Reparacion] ([FechaIngreso], [FechaEntrega], [Estado])
VALUES ('2026-09-15 09:00:00', '2026-09-18 16:00:00', N'Entregada');

INSERT INTO [DetalleReparacion] ([Diagnostico], [ServicioRealizado], [ComponenteReemplazado], [Cantidad], [Precio], [Subtotal])
VALUES (N'Pantalla rota por caída', N'Cambio de pantalla', N'Pantalla AMOLED', 1, 450000.00, 450000.00);

INSERT INTO [Factura] ([Fecha], [Subtotal], [Iva], [Total])
VALUES ('2026-09-20 14:15:00', 3200000.00, 608000.00, 3808000.00);

INSERT INTO [DetalleFactura] ([Cantidad], [Subtotal], [Iva], [Total])
VALUES (1, 3200000.00, 608000.00, 3808000.00);

INSERT INTO [Garantia] ([FechaInicio], [FechaVencimiento], [TipoGarantia], [Estado])
VALUES ('2026-09-20', '2027-09-20', N'Garantía de fábrica', N'Vigente');

INSERT INTO [Envio] ([FechaEnvio], [FechaEntrega], [CostoEnvio])
VALUES ('2026-09-21 08:00:00', '2026-09-23 12:00:00', 15000.00);

INSERT INTO [Devolucion] ([FechaDevolucion], [Motivo], [ValorDevuelto])
VALUES ('2026-09-28 11:00:00', N'Producto con defecto de fábrica', 3808000.00);
GO
);*/