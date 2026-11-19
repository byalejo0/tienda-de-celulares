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
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.UseSession();
app.Run();