/*
  Script_Seguridad.sql
  Datos de ejemplo para el login por roles: Usuarios, Roles y Permisos.

  - Se puede ejecutar varias veces: no duplica nada.
  - Los nombres de Ventana deben ser IGUALES a Ventana.Pagina de MenuVentanas.cs.
  - Modelo actual: Roles.UsuarioId, es decir, cada usuario tiene sus propias filas
    de Roles, y cada rol sus propias filas de Permisos. Por eso el script las crea
    usuario por usuario.
  - Las contraseñas se guardan tal cual (texto plano) porque asi las compara la
    aplicacion hoy. Son solo para pruebas.
*/
USE tienda_celulares_db;
GO

SET NOCOUNT ON;

-- Si ya habias ejecutado una version anterior: renombra los permisos viejos
UPDATE Permisos SET Ventana = N'Facturas'     WHERE Ventana LIKE N'Facturas(%';
UPDATE Permisos SET Ventana = N'Compras'      WHERE Ventana LIKE N'Compras(%';
UPDATE Permisos SET Ventana = N'Reparaciones' WHERE Ventana LIKE N'Reparaciones(%';

-- Ventanas y el nivel minimo de acceso que las ve:
--   1 = Tienda (todos)   2 = Operacion (Trabajador y Administrador)   3 = Administracion (solo Administrador)
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

-- Cuentas de prueba (las mismas que antes estaban fijas en el codigo) y hasta que nivel ven
DECLARE @Cuentas TABLE (
    Usuario  NVARCHAR(30)  NOT NULL,
    Clave    NVARCHAR(100) NOT NULL,
    Rol      NVARCHAR(30)  NOT NULL,
    NivelMax INT           NOT NULL);
INSERT INTO @Cuentas (Usuario, Clave, Rol, NivelMax) VALUES
    (N'Usuario',    N'123', N'Administrador', 3),
    (N'Trabajador', N'123', N'Trabajador',    2),
    (N'Cliente',    N'123', N'Cliente',       1);

-- 1) Usuarios
INSERT INTO [Usuarios] ([Nombre_Usuario], [Contraseña])
SELECT c.Usuario, c.Clave
FROM @Cuentas c
WHERE NOT EXISTS (SELECT 1 FROM [Usuarios] u WHERE u.[Nombre_Usuario] = c.Usuario);

-- 2) Un rol por usuario
INSERT INTO [Roles] ([UsuarioId], [Nombre])
SELECT u.[Id], c.Rol
FROM @Cuentas c
JOIN [Usuarios] u ON u.[Nombre_Usuario] = c.Usuario
WHERE NOT EXISTS (SELECT 1 FROM [Roles] r WHERE r.[UsuarioId] = u.[Id] AND r.[Nombre] = c.Rol);

-- 3) Permisos: cada rol recibe las ventanas hasta su nivel
INSERT INTO [Permisos] ([RolId], [Ventana])
SELECT r.[Id], v.Ventana
FROM @Cuentas c
JOIN [Usuarios] u ON u.[Nombre_Usuario] = c.Usuario
JOIN [Roles] r ON r.[UsuarioId] = u.[Id] AND r.[Nombre] = c.Rol
JOIN @Ventanas v ON v.Nivel <= c.NivelMax
WHERE NOT EXISTS (SELECT 1 FROM [Permisos] p WHERE p.[RolId] = r.[Id] AND p.[Ventana] = v.Ventana);

-- Resultado: deben salir 25 ventanas para Administrador, 16 para Trabajador y 10 para Cliente
SELECT u.[Nombre_Usuario] AS Usuario, r.[Nombre] AS Rol, COUNT(p.[Id]) AS Ventanas
FROM [Usuarios] u
JOIN [Roles] r ON r.[UsuarioId] = u.[Id]
LEFT JOIN [Permisos] p ON p.[RolId] = r.[Id]
GROUP BY u.[Nombre_Usuario], r.[Nombre]
ORDER BY u.[Nombre_Usuario];
GO
