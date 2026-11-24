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
    [Direccion] NVARCHAR(200) NOT NULL,
    [Logo] NVARCHAR(MAX) NULL
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
    [Almacenamiento] NVARCHAR(50) NOT NULL,
    [Imagen] NVARCHAR(MAX) NULL
);

CREATE TABLE [Transportadoras](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre] NVARCHAR(100) NOT NULL,
    [Correo] NVARCHAR(100) NOT NULL,
    [Telefono] NVARCHAR(20) NOT NULL,
    [Logo] NVARCHAR(MAX) NULL
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
    [Subtotal] DECIMAL(15,2) NOT NULL,
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

CREATE TABLE [Usuarios](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [Nombre_Usuario] NVARCHAR(30) NOT NULL,
    [Contraseña] NVARCHAR(100) NOT NULL
);

CREATE TABLE [Roles](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [UsuarioId] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [Nombre] NVARCHAR(30) NOT NULL
);

CREATE TABLE [Auditorias](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [UsuarioId] INT NOT NULL REFERENCES [Usuarios] ([Id]),
    [Descripción] NVARCHAR(200) NOT NULL,
    [Fecha] DATETIME NOT NULL
);

CREATE TABLE [Permisos](
    [Id] INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    [RolId] INT NOT NULL REFERENCES [Roles] ([Id]),
    [Ventana] NVARCHAR(100) NOT NULL
);

INSERT INTO [Personas] 
    ([Cedula], [Nombre], [Edad], [Direccion])
VALUES
    ('1234567890', 'Juan Perez', 25, 'Calle 10 # 20-30'),
    ('1020304050', 'Maria Gomez', 32, 'Carrera 43A # 15-20'),
    ('1098765432', 'Carlos Rodriguez', 40, 'Avenida El Poblado # 12-45'),
    ('1122334455', 'Laura Martinez', 28, 'Calle 33 # 65-10'),
    ('5566778899', 'Andres Lopez', 35, 'Carrera 70 # 44-12'),
    ('9988776655', 'Sofia Ramirez', 29, 'Transversal 39 # 72-18');

INSERT INTO [Clientes]
    ([PersonaId], [TipoCliente], [PaisResidencia], [Correo])
VALUES
    (1, 'Frecuente', 'Colombia', 'juan.perez@gmail.com'),
    (2, 'VIP', 'Colombia', 'maria.gomez@hotmail.com'),
    (3, 'Nuevo', 'Colombia', 'carlos.rodriguez@outlook.com');

INSERT INTO [Trabajadores]
    ([PersonaId], [Experiencia], [Salario], [Turno])
VALUES
    (4, '2 años', 2500000.00, 'Diurno'),
    (5, '5 años', 3200000.00, 'Mixto'),
    (6, '3 años', 2800000.00, 'Nocturno');

INSERT INTO [Vendedores]
    ([TrabajadorId], [CelularesVendidos], [MarcaEncargada])
VALUES
    (1, 10, 'Samsung'),
    (2, 25, 'Apple'),
    (3, 18, 'Xiaomi');

INSERT INTO [Tecnicos]
    ([TrabajadorId], [CelularesReparados], [Especializacion])
VALUES
    (1, 15, 'Reparación de pantallas y baterías'),
    (2, 40, 'Microsoldadura y placas base'),
    (3, 22, 'Software y recuperación de datos');

INSERT INTO [Marcas]
    ([Nombre], [Telefono], [Correo], [Direccion])
VALUES
    ('Samsung', '3001234567', 'contacto@samsung.com', 'Calle 50 # 40-20'),
    ('Apple', '3002345678', 'soporte@apple.com', 'Carrera 11 # 82-01'),
    ('Xiaomi', '3003456789', 'ventas@xiaomi.com', 'Avenida 19 # 100-45');

INSERT INTO [Componentes]
    ([Procesador], [MemoriaRam], [Pantalla], [Bateria], [Camara], [SistemaOperativo])
VALUES
    ('Snapdragon 8 Gen 2', '8 GB', '6.5 pulgadas AMOLED', '5000 mAh', '50 MP', 'Android 14'),
    ('Apple A17 Pro', '8 GB', '6.1 pulgadas Super Retina XDR', '3274 mAh', '48 MP', 'iOS 17'),
    ('Dimensity 9200+', '12 GB', '6.67 pulgadas AMOLED 144Hz', '5000 mAh', '50 MP Leica', 'Android 14 (HyperOS)');

INSERT INTO [Celulares]
    ([MarcaId], [ComponenteId], [Disponible], [CantidadDisponible], [Color], [Precio], [Modelo], [Almacenamiento])
VALUES
    (1, 1, 1, 20, 'Negro', 2500000.00, 'Galaxy S23', '256 GB'),
    (2, 2, 1, 15, 'Titanio Natural', 4800000.00, 'iPhone 15 Pro', '256 GB'),
    (3, 3, 1, 30, 'Azul', 2100000.00, 'Xiaomi 13T Pro', '512 GB');

INSERT INTO [Transportadoras]
    ([Nombre], [Correo], [Telefono])
VALUES
    ('Servientrega', 'contacto@servientrega.com', '3009876543'),
    ('Coordinadora', 'envios@coordinadora.com', '3108765432'),
    ('Inter Rapidisimo', 'soporte@interrapidisimo.com', '3207654321');

INSERT INTO [Proveedores]
    ([Nombre], [Correo], [Telefono], [Direccion])
VALUES
    ('Proveedor Celulares S.A.S', 'ventas@proveedor.com', '3014567890', 'Carrera 45 # 30-15'),
    ('Importadora Tech Colombia', 'comercial@importadoratech.co', '3156789012', 'Calle 80 # 25-40'),
    ('Distribuidora Global Movil', 'pedidos@globalmovil.com', '3189012345', 'Zona Franca Bodega 12');

INSERT INTO [Compras]
    ([ProveedorId], [TrabajadorId], [FechaCompra], [Total], [Estado])
VALUES
    (1, 1, '2026-10-01 08:00:00', 20000000.00, 'Completada'),
    (2, 2, '2026-10-05 10:30:00', 38000000.00, 'Completada'),
    (3, 3, '2026-10-10 14:15:00', 16000000.00, 'Pendiente');

INSERT INTO [DetallesCompras]
    ([CompraId], [CelularId], [Cantidad], [PrecioCompra])
VALUES
    (1, 1, 10, 2000000.00),
    (2, 2, 10, 3800000.00),
    (3, 3, 10, 1600000.00);

INSERT INTO [Bonos]
    ([TecnicoId], [CantidadReparaciones], [ValorBono])
VALUES
    (1, 15, 500000.00),
    (2, 40, 1200000.00),
    (3, 22, 700000.00);

INSERT INTO [Reparaciones]
    ([CelularId], [TecnicoId], [ClienteId], [BonoId], [FechaIngreso], [FechaEntrega], [Estado])
VALUES
    (1, 1, 1, 1, '2026-10-01 09:00:00', '2026-10-03 15:00:00', 'Reparado'),
    (2, 2, 2, 2, '2026-10-04 11:00:00', '2026-10-06 17:00:00', 'Reparado'),
    (3, 3, 3, 3, '2026-10-08 10:00:00', '2026-10-10 12:00:00', 'En proceso');

INSERT INTO [DetallesReparaciones]
    ([ReparacionId], [Diagnostico], [ServicioRealizado], [ComponenteReemplazado], [Cantidad], [Precio], [Subtotal])
VALUES
    (1, 'Pantalla dañada por golpe', 'Cambio de pantalla', 'Pantalla AMOLED', 1, 500000.00, 500000.00),
    (2, 'Cortocircuito en placa', 'Reconstrucción de pistas', 'IC de carga', 1, 450000.00, 450000.00),
    (3, 'Batería degradada', 'Reemplazo de batería', 'Batería 5000 mAh', 1, 180000.00, 180000.00);

INSERT INTO [Facturas]
    ([ClienteId], [TrabajadorId], [ReparacionId], [Fecha], [Subtotal], [Iva], [Total])
VALUES
    (1, 1, 1, '2026-10-03 16:00:00', 2500000.00, 475000.00, 2975000.00),
    (2, 2, 2, '2026-10-06 18:00:00', 4800000.00, 912000.00, 5712000.00),
    (3, 3, 3, '2026-10-10 14:00:00', 2100000.00, 399000.00, 2499000.00);

INSERT INTO [DetallesFacturas]
    ([FacturaId], [CelularId], [Cantidad], [Subtotal], [Iva], [Total])
VALUES
    (1, 1, 1, 2500000.00, 475000.00, 2975000.00),
    (2, 2, 1, 4800000.00, 912000.00, 5712000.00),
    (3, 3, 1, 2100000.00, 399000.00, 2499000.00);

INSERT INTO [Garantias]
    ([CelularId], [ClienteId], [FacturaId], [FechaInicio], [FechaVencimiento], [TipoGarantia], [Estado])
VALUES
    (1, 1, 1, '2026-10-03 16:00:00', '2027-10-03 16:00:00', 'Garantia de fabrica', 'Activa'),
    (2, 2, 2, '2026-10-06 18:00:00', '2027-10-06 18:00:00', 'Garantia extendida AppleCare', 'Activa'),
    (3, 3, 3, '2026-10-10 14:00:00', '2027-10-10 14:00:00', 'Garantia de fabrica', 'Activa');

INSERT INTO [Envios]
    ([FacturaId], [TransportadoraId], [ClienteId], [FechaEnvio], [FechaEntrega], [CostoEnvio])
VALUES
    (1, 1, 1, '2026-10-04 08:00:00', '2026-10-05 14:00:00', 25000.00),
    (2, 2, 2, '2026-10-07 09:30:00', '2026-10-08 11:00:00', 30000.00),
    (3, 3, 3, '2026-10-11 10:00:00', '2026-10-13 16:30:00', 20000.00);

INSERT INTO [Devoluciones]
    ([FacturaId], [ClienteId], [FechaDevolucion], [Motivo], [ValorDevuelto])
VALUES
    (1, 1, '2026-10-10 10:00:00', 'Defecto de fábrica en micrófono', 2975000.00),
    (2, 2, '2026-10-12 15:20:00', 'Cliente solicitó cambio de color', 5712000.00),
    (3, 3, '2026-10-15 09:45:00', 'Problema con carga rápida', 2499000.00);



SET NOCOUNT ON;

UPDATE Permisos SET Ventana = N'Facturas'     WHERE Ventana LIKE N'Facturas(%';
UPDATE Permisos SET Ventana = N'Compras'      WHERE Ventana LIKE N'Compras(%';
UPDATE Permisos SET Ventana = N'Reparaciones' WHERE Ventana LIKE N'Reparaciones(%';

DECLARE @Ventanas TABLE (Ventana NVARCHAR(100) NOT NULL, Nivel INT NOT NULL);
INSERT INTO @Ventanas (Ventana, Nivel) VALUES
    (N'Celulares', 1),
    (N'Marcas', 1),
    (N'Carrito', 1),
    (N'Facturas', 1),
    (N'DetallesFacturas', 1),
    (N'Garantias', 1),
    (N'Envios', 1),
    (N'Devoluciones', 1),
    (N'Reparaciones', 1),
    (N'DetallesReparaciones', 1),
    (N'Clientes', 2),
    (N'Componentes', 2),
    (N'Compras', 2),
    (N'DetallesCompras', 2),
    (N'Proveedores', 2),
    (N'Transportadoras', 2),
    (N'Personas', 3),
    (N'Trabajadores', 3),
    (N'Vendedores', 3),
    (N'Tecnicos', 3),
    (N'Bonos', 3),
    (N'Usuarios', 3),
    (N'Roles', 3),
    (N'Permisos', 3),
    (N'Auditorias', 3);

DECLARE @Cuentas TABLE (
    Usuario  NVARCHAR(30)  NOT NULL,
    Clave    NVARCHAR(100) NOT NULL,
    Rol      NVARCHAR(30)  NOT NULL,
    NivelMax INT           NOT NULL);
INSERT INTO @Cuentas (Usuario, Clave, Rol, NivelMax) VALUES
    (N'Usuario',    N'123', N'Administrador', 3),
    (N'Trabajador', N'123', N'Trabajador',    2),
    (N'Cliente',    N'123', N'Cliente',       1);

INSERT INTO [Usuarios] ([Nombre_Usuario], [Contraseña])
SELECT c.Usuario, c.Clave
FROM @Cuentas c
WHERE NOT EXISTS (SELECT 1 FROM [Usuarios] u WHERE u.[Nombre_Usuario] = c.Usuario);

INSERT INTO [Roles] ([UsuarioId], [Nombre])
SELECT u.[Id], c.Rol
FROM @Cuentas c
JOIN [Usuarios] u ON u.[Nombre_Usuario] = c.Usuario
WHERE NOT EXISTS (SELECT 1 FROM [Roles] r WHERE r.[UsuarioId] = u.[Id] AND r.[Nombre] = c.Rol);

INSERT INTO [Permisos] ([RolId], [Ventana])
SELECT r.[Id], v.Ventana
FROM @Cuentas c
JOIN [Usuarios] u ON u.[Nombre_Usuario] = c.Usuario
JOIN [Roles] r ON r.[UsuarioId] = u.[Id] AND r.[Nombre] = c.Rol
JOIN @Ventanas v ON v.Nivel <= c.NivelMax
WHERE NOT EXISTS (SELECT 1 FROM [Permisos] p WHERE p.[RolId] = r.[Id] AND p.[Ventana] = v.Ventana);

SELECT u.[Nombre_Usuario] AS Usuario, r.[Nombre] AS Rol, COUNT(p.[Id]) AS Ventanas
FROM [Usuarios] u
JOIN [Roles] r ON r.[UsuarioId] = u.[Id]
LEFT JOIN [Permisos] p ON p.[RolId] = r.[Id]
GROUP BY u.[Nombre_Usuario], r.[Nombre]
ORDER BY u.[Nombre_Usuario];
GO


SET NOCOUNT ON;

DECLARE @Ejemplos TABLE (Usuario NVARCHAR(30), Descripcion NVARCHAR(200), Fecha DATETIME);
INSERT INTO @Ejemplos (Usuario, Descripcion, Fecha) VALUES
    (N'Usuario',    N'Inicio de sesión (Administrador)',          '2026-11-20 08:00:00'),
    (N'Usuario',    N'Guardó cambios en Trabajadores',            '2026-11-20 08:15:00'),
    (N'Usuario',    N'Guardó cambios en Bonos',                   '2026-11-20 08:40:00'),
    (N'Usuario',    N'Cierre de sesión',                          '2026-11-20 09:00:00'),
    (N'Trabajador', N'Inicio de sesión (Trabajador)',             '2026-11-21 09:00:00'),
    (N'Trabajador', N'Guardó cambios en Compras',                 '2026-11-21 09:20:00'),
    (N'Trabajador', N'Guardó cambios en Facturas',                '2026-11-21 10:05:00'),
    (N'Trabajador', N'Borró un registro en Devoluciones',         '2026-11-21 11:30:00'),
    (N'Trabajador', N'Cierre de sesión',                          '2026-11-21 12:00:00'),
    (N'Cliente',    N'Inicio de sesión (Cliente)',                '2026-11-22 15:00:00'),
    (N'Cliente',    N'Finalizó una compra en Carrito',            '2026-11-22 15:12:00'),
    (N'Cliente',    N'Cierre de sesión',                          '2026-11-22 15:20:00');

INSERT INTO [Auditorias] ([UsuarioId], [Descripción], [Fecha])
SELECT u.[Id], e.Descripcion, e.Fecha
FROM @Ejemplos e
JOIN [Usuarios] u ON u.[Nombre_Usuario] = e.Usuario
WHERE NOT EXISTS (SELECT 1 FROM [Auditorias] a
                  WHERE a.[UsuarioId] = u.[Id] AND a.[Descripción] = e.Descripcion AND a.[Fecha] = e.Fecha);

SELECT a.[Id], u.[Nombre_Usuario] AS Usuario, a.[Descripción], a.[Fecha]
FROM [Auditorias] a JOIN [Usuarios] u ON u.[Id] = a.[UsuarioId]
ORDER BY a.[Fecha];
GO


*/