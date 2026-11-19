using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();
builder.Services.AddScoped<IBonosAplicacion, BonosAplicacion>();
builder.Services.AddScoped<ICelularesAplicacion, CelularesAplicacion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<IComponentesAplicacion, ComponentesAplicacion>();
builder.Services.AddScoped<IComprasAplicacion, ComprasAplicacion>();
builder.Services.AddScoped<IDetallesComprasAplicacion, DetallesComprasAplicacion>();
builder.Services.AddScoped<IDetallesFacturasAplicacion, DetallesFacturasAplicacion>();
builder.Services.AddScoped<IDetallesReparacionesAplicacion, DetallesReparacionesAplicacion>();
builder.Services.AddScoped<IDevolucionesAplicacion, DevolucionesAplicacion>();
builder.Services.AddScoped<IEnviosAplicacion, EnviosAplicacion>();
builder.Services.AddScoped<IFacturasAplicacion, FacturasAplicacion>();
builder.Services.AddScoped<IGarantiasAplicacion, GarantiasAplicacion>();
builder.Services.AddScoped<IMarcasAplicacion, MarcasAplicacion>();
builder.Services.AddScoped<IPermisosAplicacion, PermisosAplicacion>();
builder.Services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
builder.Services.AddScoped<IReparacionesAplicacion, ReparacionesAplicacion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<ITecnicosAplicacion, TecnicosAplicacion>();
builder.Services.AddScoped<ITrabajadoresAplicacion, TrabajadoresAplicacion>();
builder.Services.AddScoped<ITransportadorasAplicacion, TransportadorasAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<IVendedoresAplicacion, VendedoresAplicacion>();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();
