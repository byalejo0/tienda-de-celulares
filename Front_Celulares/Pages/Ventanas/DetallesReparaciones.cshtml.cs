using lib_Celulares.Entidades;
using Pre_Celulares.Interfaces;
using lib_Celulares.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Celulares.Pages.Ventanas
{
    public class DetallesReparacionesModel : PageModel
    {
        private IDetallesReparacionesPresentacion IDetallesReparacionesPresentacion;

        public DetallesReparacionesModel(IDetallesReparacionesPresentacion IDetallesReparacionesPresentacion)
        {
            this.IDetallesReparacionesPresentacion = IDetallesReparacionesPresentacion;
            this.Filtro = new DetallesReparaciones();
        }

        public IFormFile? FormFile { get; set; }
        [BindProperty] public List<DetallesReparaciones> Lista { get; set; }
        [BindProperty] public DetallesReparaciones? Filtro { get; set; }
        [BindProperty] public DetallesReparaciones? Actual { get; set; }
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

                Filtro!.Diagnostico = Filtro!.Diagnostico;
                Lista = this.IDetallesReparacionesPresentacion.Buscar(Filtro!);
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
                this.Actual = new DetallesReparaciones();
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

                if (this.Actual!.Id == 0)
                    this.Actual = this.IDetallesReparacionesPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetallesReparacionesPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IDetallesReparacionesPresentacion.Borrar(this.Actual!);
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
