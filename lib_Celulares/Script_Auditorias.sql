/*
  Script_Auditorias.sql
  Datos de ejemplo para la tabla Auditorias (quien hizo que y cuando).
  Requiere haber ejecutado antes Script_Seguridad.sql (necesita los Usuarios).
  Se puede ejecutar varias veces: no duplica filas.
*/
USE tienda_celulares_db;
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
