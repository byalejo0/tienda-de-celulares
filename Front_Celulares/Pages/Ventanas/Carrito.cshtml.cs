using lib_Celulares.Entidades;
using lib_Celulares.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pre_Celulares.Interfaces;

namespace Front_Celulares.Pages.Ventanas
{
    public class CarritoModel : PageModel
    {
        private ICelularesPresentacion ICelularesPresentacion;
        private IFacturasPresentacion IFacturasPresentacion;
        private IDetallesFacturasPresentacion IDetallesFacturasPresentacion;

        public CarritoModel(ICelularesPresentacion ICelularesPresentacion,
            IFacturasPresentacion IFacturasPresentacion,
            IDetallesFacturasPresentacion IDetallesFacturasPresentacion)
        {
            this.ICelularesPresentacion = ICelularesPresentacion;
            this.IFacturasPresentacion = IFacturasPresentacion;
            this.IDetallesFacturasPresentacion = IDetallesFacturasPresentacion;
        }

        public List<ItemCarrito> Items { get; set; } = new();
        public int? FacturaGenerada { get; set; }
        [BindProperty] public int ClienteId { get; set; }
        [BindProperty] public int TrabajadorId { get; set; }

        public decimal Subtotal => Items.Sum(x => x.Subtotal);
        public decimal Iva => Items.Sum(x => x.Iva);
        public decimal Total => Items.Sum(x => x.Total);

        public IActionResult OnGet() => Ejecutar(() => { });

        // El boton "Cerrar" del popup de mensajes llama a este handler
        public IActionResult OnPostBtConsultar() => Ejecutar(() => { });

        public IActionResult OnPostBtMas(int data)
        {
            return Ejecutar(() =>
            {
                var items = CarritoSesion.Leer(HttpContext.Session);
                var item = items.FirstOrDefault(x => x.CelularId == data);
                if (item == null)
                    return;

                // Se valida contra el stock actual de la BD, no contra lo guardado en sesion
                var celular = Catalogo().FirstOrDefault(x => x.Id == data);
                if (celular == null || item.Cantidad + 1 > celular.CantidadDisponible)
                    throw new InvalidOperationException("No hay mas unidades disponibles");

                item.Cantidad++;
                CarritoSesion.Guardar(HttpContext.Session, items);
            });
        }

        public IActionResult OnPostBtMenos(int data)
        {
            return Ejecutar(() =>
            {
                var items = CarritoSesion.Leer(HttpContext.Session);
                var item = items.FirstOrDefault(x => x.CelularId == data);
                if (item == null)
                    return;

                item.Cantidad--;
                if (item.Cantidad <= 0)
                    items.Remove(item);
                CarritoSesion.Guardar(HttpContext.Session, items);
            });
        }

        public IActionResult OnPostBtQuitar(int data)
        {
            return Ejecutar(() =>
            {
                var items = CarritoSesion.Leer(HttpContext.Session);
                items.RemoveAll(x => x.CelularId == data);
                CarritoSesion.Guardar(HttpContext.Session, items);
            });
        }

        public IActionResult OnPostBtVaciar()
        {
            return Ejecutar(() => CarritoSesion.Vaciar(HttpContext.Session));
        }

        public IActionResult OnPostBtComprar()
        {
            return Ejecutar(() =>
            {
                var items = CarritoSesion.Leer(HttpContext.Session);
                if (items.Count == 0)
                    throw new InvalidOperationException("El carrito esta vacio");
                if (ClienteId <= 0 || TrabajadorId <= 0)
                    throw new InvalidOperationException("Indica el Id del cliente y del trabajador");

                // 1. Validar todo ANTES de escribir en la BD, con datos frescos
                var catalogo = Catalogo();
                var lineas = new List<(Celulares celular, ItemCarrito item)>();
                foreach (var item in items)
                {
                    var celular = catalogo.FirstOrDefault(x => x.Id == item.CelularId);
                    if (celular == null)
                        throw new InvalidOperationException($"{item.Modelo} ya no existe");
                    if (!celular.Disponible || celular.CantidadDisponible < item.Cantidad)
                        throw new InvalidOperationException($"Stock insuficiente de {celular.Modelo}");

                    item.Precio = celular.Precio; // precio vigente, no el de cuando se agrego
                    lineas.Add((celular, item));
                }

                // 2. Factura (encabezado)
                var factura = this.IFacturasPresentacion.Insertar(new Facturas
                {
                    ClienteId = ClienteId,
                    TrabajadorId = TrabajadorId,
                    Fecha = DateTime.Now,
                    Subtotal = items.Sum(x => x.Subtotal),
                    Iva = items.Sum(x => x.Iva),
                    Total = items.Sum(x => x.Total)
                });

                // 3. Una fila de DetallesFacturas por linea + descontar stock
                foreach (var (celular, item) in lineas)
                {
                    this.IDetallesFacturasPresentacion.Insertar(new DetallesFacturas
                    {
                        FacturaId = factura.Id,
                        CelularId = celular.Id,
                        Cantidad = item.Cantidad,
                        Subtotal = item.Subtotal,
                        Iva = item.Iva,
                        Total = item.Total
                    });

                    celular.CantidadDisponible -= item.Cantidad;
                    celular.Disponible = celular.CantidadDisponible > 0;
                    celular._Marca = null;       // no mandar los objetos relacionados al actualizar
                    celular._Componente = null;
                    this.ICelularesPresentacion.Actualizar(celular);
                }

                FacturaGenerada = factura.Id;
                CarritoSesion.Vaciar(HttpContext.Session);
            });
        }

        // ---------- Auxiliares ----------

        // Mismo patron que las otras ventanas: sin sesion -> al login
        private IActionResult Ejecutar(Action accion)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Usuario")))
                return Redirect("/");

            try
            {
                accion();
            }
            catch (InvalidOperationException ex)
            {
                ViewData["Mensaje"] = ex.Message; // errores de validacion: mensaje limpio
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }

            Items = CarritoSesion.Leer(HttpContext.Session);
            return Page();
        }

        private List<Celulares> Catalogo()
            => this.ICelularesPresentacion.Buscar(new Celulares { Modelo = "" });
    }
}
