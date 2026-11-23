using Front_Celulares;
using Pre_Celulares.Implementaciones;
using Pre_Celulares.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();
builder.Services.AddScoped<IBonosPresentacion, BonosPresentacion>();
builder.Services.AddScoped<ICelularesPresentacion, CelularesPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IComponentesPresentacion, ComponentesPresentacion>();
builder.Services.AddScoped<IComprasPresentacion, ComprasPresentacion>();
builder.Services.AddScoped<IDetallesComprasPresentacion, DetallesComprasPresentacion>();
builder.Services.AddScoped<IDetallesFacturasPresentacion, DetallesFacturasPresentacion>();
builder.Services.AddScoped<IDetallesReparacionesPresentacion, DetallesReparacionesPresentacion>();
builder.Services.AddScoped<IDevolucionesPresentacion, DevolucionesPresentacion>();
builder.Services.AddScoped<IEnviosPresentacion, EnviosPresentacion>();
builder.Services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
builder.Services.AddScoped<IGarantiasPresentacion, GarantiasPresentacion>();
builder.Services.AddScoped<IMarcasPresentacion, MarcasPresentacion>();
builder.Services.AddScoped<IPermisosPresentacion, PermisosPresentacion>();
builder.Services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IReparacionesPresentacion, ReparacionesPresentacion>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<ITecnicosPresentacion, TecnicosPresentacion>();
builder.Services.AddScoped<ITrabajadoresPresentacion, TrabajadoresPresentacion>();
builder.Services.AddScoped<ITransportadorasPresentacion, TransportadorasPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<IVendedoresPresentacion, VendedoresPresentacion>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// Cada ventana (/Ventanas/...) exige sesion iniciada y que alguno de los roles
// del usuario tenga el Permiso (Permisos.Ventana) para esa ventana. Esto evita
// que se entre escribiendo la direccion a mano, aunque el menu no la muestre.
app.Use(async (context, next) =>
{
    const string prefijo = "/Ventanas/";
    var ruta = context.Request.Path.Value ?? string.Empty;

    if (ruta.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
    {
        if (!Seguridad.EstaLogueado(context.Session))
        {
            context.Response.Redirect("/");
            return;
        }

        var ventana = ruta.Substring(prefijo.Length).Split('/')[0];
        if (!Seguridad.TieneAcceso(context.Session, ventana))
        {
            context.Response.Redirect("/AccesoDenegado");
            return;
        }
    }

    await next(context);
});

// Auditoria: cada Guardar / Borrar / Comprar hecho en una ventana queda en la
// tabla Auditorias con el usuario, la ventana y la fecha.
app.Use(async (context, next) =>
{
    await next(context);

    const string prefijo = "/Ventanas/";
    var ruta = context.Request.Path.Value ?? string.Empty;
    if (!HttpMethods.IsPost(context.Request.Method) ||
        !ruta.StartsWith(prefijo, StringComparison.OrdinalIgnoreCase))
        return;

    var ventana = ruta.Substring(prefijo.Length).Split('/')[0];
    if (string.Equals(ventana, "Auditorias", StringComparison.OrdinalIgnoreCase))
        return;

    var accion = (string?)context.Request.Query["handler"] switch
    {
        "BtGuardar" => "Guardó cambios en",
        "BtBorrar" => "Borró un registro en",
        "BtComprar" => "Finalizó una compra en",
        _ => null
    };
    if (accion == null)
        return;

    var usuarioId = Seguridad.UsuarioId(context.Session);
    var auditorias = context.RequestServices.GetRequiredService<IAuditoriasPresentacion>();
    RegistroAuditoria.Registrar(auditorias, usuarioId, $"{accion} {ventana}");
});

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();