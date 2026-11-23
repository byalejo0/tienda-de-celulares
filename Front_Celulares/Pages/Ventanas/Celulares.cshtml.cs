using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using lib_Celulares.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Celulares.Pages.Ventanas
{
    public class CelularesModel : PageModel
    {
        private ICelularesPresentacion ICelularesPresentacion;

        public CelularesModel(ICelularesPresentacion ICelularesPresentacion)
        {
            this.ICelularesPresentacion = ICelularesPresentacion;
            this.Filtro = new Celulares();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<Celulares> Lista { get; set; }
        [BindProperty] public Celulares? Filtro { get; set; }
        [BindProperty] public Celulares? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;
        
        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                var variable_session = HttpContext.Session.GetString("Usuario");
                if (String.IsNullOrEmpty(variable_session))
                {
                    HttpContext.Response.Redirect("/");
                    return;
                }

                Filtro!.Modelo = Filtro!.Modelo ?? "";
                Lista = this.ICelularesPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtAgregar(string data)
        {
            try
            {
                OnPostBtConsultar();
                var celular = this.Lista?.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
                if (celular == null)
                    return;

                if (!celular.Disponible || celular.CantidadDisponible <= 0)
                    throw new InvalidOperationException("Celular no disponible");

                var items = CarritoSesion.Leer(HttpContext.Session);
                var item = items.FirstOrDefault(x => x.CelularId == celular.Id);
                if (item == null)
                {
                    items.Add(new ItemCarrito
                    {
                        CelularId = celular.Id,
                        Modelo = celular.Modelo,
                        Color = celular.Color,
                        Almacenamiento = celular.Almacenamiento,
                        Precio = celular.Precio,
                        Cantidad = 1
                    });
                }
                else
                {
                    if (item.Cantidad >= celular.CantidadDisponible)
                        throw new InvalidOperationException("No hay mas unidades disponibles");
                    item.Cantidad++;
                }

                CarritoSesion.Guardar(HttpContext.Session, items);
                ViewData["Mensaje"] = celular.Modelo + " agregado al carrito";
            }
            catch (InvalidOperationException ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Celulares();
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (FormFile != null)
                {
                    var memoryStream = new MemoryStream();
                    FormFile.CopyToAsync(memoryStream).Wait();
                    Actual!.Imagen = Convert.ToBase64String(memoryStream.ToArray());
                    memoryStream.Dispose();
                }

                if (this.Actual!.Id == 0)
                    this.Actual = this.ICelularesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.ICelularesPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.ICelularesPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}
