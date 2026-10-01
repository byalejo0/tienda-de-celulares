/*
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

CREATE TABLE [Trabajadores](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [PersonaId] INT NOT NULL REFERENCES [Personas] ([Id]),
    [Experiencia] NVARCHAR(100) NOT NULL,
    [Salario] DECIMAL(15,2) NOT NULL,
    [Turno] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Vendedores](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajadores] ([Id]),
    [CelularesVendidos] INT NOT NULL,
    [MarcaEncargada] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Tecnicos](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajadores] ([Id]),
    [CelularesReparados] INT NOT NULL,
    [Especializacion] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Marcas](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Componentes](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Procesador] NVARCHAR(100) NOT NULL,
    [MemoriaRam] NVARCHAR(50) NOT NULL,
    [Pantalla] NVARCHAR(100) NOT NULL,
    [Bateria] NVARCHAR(50) NOT NULL,
    [Camara] NVARCHAR(100) NOT NULL,
    [SistemaOperativo] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Celulares](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [MarcaId] INT NOT NULL REFERENCES [Marcas] ([Id]),
    [ComponenteId] INT NOT NULL REFERENCES [Componentes] ([Id]),
    [Disponible] BIT NOT NULL,
    [CantidadDisponible] INT NOT NULL,
    [Color] NVARCHAR(50) NOT NULL,
    [Precio] DECIMAL(15,2) NOT NULL,
    [Modelo] NVARCHAR(100) NOT NULL,
    [Almacenamiento] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Transportadoras](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL
);

CREATE TABLE [Proveedores](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Direccion] NVARCHAR(200) NOT NULL
);

CREATE TABLE [Compras](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ProveedorId] INT NOT NULL REFERENCES [Proveedores] ([Id]),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajadores] ([Id]),
    [FechaCompra] DATETIME NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [DetallesCompras](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CompraId] INT NOT NULL REFERENCES [Compras] ([Id]),
    [CelularId] INT NOT NULL REFERENCES [Celulares] ([Id]),
    [Cantidad] INT NOT NULL,
    [PrecioCompra] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Bonos](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [TecnicoId] INT NOT NULL REFERENCES [Tecnicos] ([Id]),
    [CantidadReparaciones] INT NOT NULL,
    [ValorBono] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Reparaciones](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CelularId] INT NOT NULL REFERENCES [Celulares] ([Id]),
    [TecnicoId] INT NOT NULL REFERENCES [Tecnicos] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [BonoId] INT NULL REFERENCES [Bonos] ([Id]),
    [FechaIngreso] DATETIME NOT NULL,
    [FechaEntrega] DATETIME NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [DetallesReparaciones](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ReparacionId] INT NOT NULL REFERENCES [Reparaciones] ([Id]),
    [Diagnostico] NVARCHAR(200) NOT NULL,
    [ServicioRealizado] NVARCHAR(200) NOT NULL,
    [ComponenteReemplazado] NVARCHAR(100) NOT NULL,
    [Cantidad] INT NOT NULL,
    [Precio] DECIMAL(15,2) NOT NULL,
    [Subtotal] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Facturas](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [TrabajadorId] INT NOT NULL REFERENCES [Trabajadores] ([Id]),
    [ReparacionId] INT NULL REFERENCES [Reparaciones] ([Id]),
    [Fecha] DATETIME NOT NULL,
    [Subtotal] DECIMAL(15,2) NOT NULL,
    [Iva] DECIMAL(15,2) NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [DetallesFacturas](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Facturas] ([Id]),
    [CelularId] INT NOT NULL REFERENCES [Celulares] ([Id]),
    [Cantidad] INT NOT NULL,
    [Subtotal] DECIMAL(18,2) NOT NULL,
    [Iva] DECIMAL(15,2) NOT NULL,
    [Total] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Garantias](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [CelularId] INT NOT NULL REFERENCES [Celulares] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FacturaId] INT NOT NULL REFERENCES [Facturas] ([Id]),
    [FechaInicio] DATETIME NOT NULL,
    [FechaVencimiento] DATETIME NOT NULL,
    [TipoGarantia] NVARCHAR(100) NOT NULL,
    [Estado] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Envios](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Facturas] ([Id]),
    [TransportadoraId] INT NOT NULL REFERENCES [Transportadoras] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FechaEnvio] DATETIME NOT NULL,
    [FechaEntrega] DATETIME NOT NULL,
    [CostoEnvio] DECIMAL(15,2) NOT NULL
);

CREATE TABLE [Devoluciones](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [FacturaId] INT NOT NULL REFERENCES [Facturas] ([Id]),
    [ClienteId] INT NOT NULL REFERENCES [Clientes] ([Id]),
    [FechaDevolucion] DATETIME NOT NULL,
    [Motivo] NVARCHAR(200) NOT NULL,
    [ValorDevuelto] DECIMAL(15,2) NOT NULL
);

INSERT INTO [Personas] 
    ([Cedula], [Nombre], [Edad], [Direccion])
VALUES
    ('1234567890', 'Juan Perez', 25, 'Calle 10 # 20-30');


INSERT INTO [Clientes]
    ([PersonaId], [TipoCliente], [PaisResidencia], [Correo])
VALUES
    (1, 'Frecuente', 'Colombia', 'juan.perez@gmail.com');


INSERT INTO [Trabajadores]
    ([PersonaId], [Experiencia], [Salario], [Turno])
VALUES
    (1, '2 años', 2500000.00, 'Diurno');


INSERT INTO [Vendedores]
    ([TrabajadorId], [CelularesVendidos], [MarcaEncargada])
VALUES
    (1, 10, 'Samsung');


INSERT INTO [Tecnicos]
    ([TrabajadorId], [CelularesReparados], [Especializacion])
VALUES
    (1, 15, 'Reparación de celulares');


INSERT INTO [Marcas]
    ([Nombre], [Telefono], [Correo], [Direccion])
VALUES
    ('Samsung', '3001234567', 'contacto@samsung.com', 'Calle 50 # 40-20');


INSERT INTO [Componentes]
    ([Procesador], [MemoriaRam], [Pantalla], [Bateria], [Camara], [SistemaOperativo])
VALUES
    ('Snapdragon 8 Gen 2', '8 GB', '6.5 pulgadas AMOLED', '5000 mAh', '50 MP', 'Android');


INSERT INTO [Celulares]
    ([MarcaId], [ComponenteId], [Disponible], [CantidadDisponible], [Color], [Precio], [Modelo], [Almacenamiento])
VALUES
    (1, 1, 1, 20, 'Negro', 2500000.00, 'Galaxy S23', '256 GB');


INSERT INTO [Transportadoras]
    ([Nombre], [Correo], [Telefono])
VALUES
    ('Servientrega', 'contacto@servientrega.com', '3009876543');


INSERT INTO [Proveedores]
    ([Nombre], [Correo], [Telefono], [Direccion])
VALUES
    ('Proveedor Celulares S.A.S', 'ventas@proveedor.com', '3014567890', 'Carrera 45 # 30-15');


INSERT INTO [Compras]
    ([ProveedorId], [TrabajadorId], [FechaCompra], [Total], [Estado])
VALUES
    (1, 1, '2026-10-01 08:00:00', 20000000.00, 'Completada');


INSERT INTO [DetallesCompras]
    ([CompraId], [CelularId], [Cantidad], [PrecioCompra])
VALUES
    (1, 1, 10, 2000000.00);


INSERT INTO [Bonos]
    ([TecnicoId], [CantidadReparaciones], [ValorBono])
VALUES
    (1, 15, 500000.00);


INSERT INTO [Reparaciones]
    ([CelularId], [TecnicoId], [ClienteId], [BonoId],
     [FechaIngreso], [FechaEntrega], [Estado])
VALUES
    (1, 1, 1, 1,
     '2026-10-01 09:00:00',
     '2026-10-03 15:00:00',
     'Reparado');


INSERT INTO [DetallesReparaciones]
    ([ReparacionId], [Diagnostico], [ServicioRealizado],
     [ComponenteReemplazado], [Cantidad], [Precio], [Subtotal])
VALUES
    (1, 'Pantalla dañada', 'Cambio de pantalla',
     'Pantalla AMOLED', 1, 500000.00, 500000.00);


INSERT INTO [Facturas]
    ([ClienteId], [TrabajadorId], [ReparacionId],
     [Fecha], [Subtotal], [Iva], [Total])
VALUES
    (1, 1, 1,
     '2026-10-03 16:00:00',
     500000.00, 95000.00, 595000.00);


INSERT INTO [DetallesFacturas]
    ([FacturaId], [CelularId], [Cantidad],
     [Subtotal], [Iva], [Total])
VALUES
    (1, 1, 1,
     2500000.00, 475000.00, 2975000.00);


INSERT INTO [Garantias]
    ([CelularId], [ClienteId], [FacturaId],
     [FechaInicio], [FechaVencimiento],
     [TipoGarantia], [Estado])
VALUES
    (1, 1, 1,
     '2026-10-03 16:00:00',
     '2027-10-03 16:00:00',
     'Garantia de fabrica',
     'Activa');


INSERT INTO [Envios]
    ([FacturaId], [TransportadoraId], [ClienteId],
     [FechaEnvio], [FechaEntrega], [CostoEnvio])
VALUES
    (1, 1, 1,
     '2026-10-04 08:00:00',
     '2026-10-05 14:00:00',
     25000.00);


INSERT INTO [Devoluciones]
    ([FacturaId], [ClienteId], [FechaDevolucion],
     [Motivo], [ValorDevuelto])
VALUES
    (1, 1,
     '2026-10-10 10:00:00',
     'Producto defectuoso',
     595000.00);

*/