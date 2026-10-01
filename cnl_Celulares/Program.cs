using lib_Celulares.Implementaciones;
using lib_Celulares.Interfaces;
using Microsoft.EntityFrameworkCore;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost\\DEV;database=tienda_celulares_db;Integrated Security=True;TrustServerCertificate=true;";
    
    var lista_personas = conexion.Personas!
        .ToList();

    var lista_marca = conexion.Marcas!
        .ToList();
    
    var lista_componente = conexion.Componentes!
        .ToList();

    var lista_transportadora = conexion.Transportadoras!
        .ToList();

    var lista_proveedor = conexion.Proveedores!
        .ToList();

    var lista_clientes = conexion.Clientes!
        .Include(x => x._Persona)
        .ToList();

    var lista_trabajador = conexion.Trabajadores!
        .Include(x => x._Persona)
        .ToList();

    var lista_vendedor = conexion.Vendedores!
        .Include(x => x._Trabajador)
        .ToList();

    var lista_tecnico = conexion.Tecnicos!
        .Include(x => x._Trabajador)
        .ToList();

    var lista_celular = conexion.Celulares!
        .Include(x => x._Marca)
        .Include(x => x._Componente)
        .ToList();

    var lista_compra = conexion.Compras!
        .Include(x => x._Proveedor)
        .Include(x => x._Trabajador)
        .ToList();

    var lista_detalleCompra = conexion.DetallesCompras!
        .Include(x => x._Compra)
        .Include(x => x._Celular)
        .ToList();

    var lista_bono = conexion.Bonos!
        .Include(x => x._Tecnico)
        .ToList();

    var lista_reparacion = conexion.Reparaciones!
        .Include(x => x._Celular)
        .Include(x => x._Tecnico)
        .Include(x => x._Cliente)
        .Include(x => x._Bono)
        .ToList();

    var lista_detalleReparacion = conexion.DetallesReparaciones!
        .Include(x => x._Reparacion)
        .ToList();

    var lista_factura = conexion.Facturas!
        .Include(x => x._Cliente)
        .Include(x => x._Trabajador)
        .Include(x => x._Reparacion)
        .ToList();

    var lista_detalleFactura = conexion.DetallesFacturas!
        .Include(x => x._Factura)
        .Include(x => x._Celular)
        .ToList();

    var lista_garantia = conexion.Garantias!
        .Include(x => x._Celular)
        .Include(x => x._Cliente)
        .Include(x => x._Factura)
        .ToList();

    var lista_envio = conexion.Envios!
        .Include(x => x._Factura)
        .Include(x => x._Transportadora)
        .Include(x => x._Cliente)
        .ToList();

    var lista_devolucion = conexion.Devoluciones!
        .Include(x => x._Factura)
        .Include(x => x._Cliente)
        .ToList();


}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("cnl_celulares");
