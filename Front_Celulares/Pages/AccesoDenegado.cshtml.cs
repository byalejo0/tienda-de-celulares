using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Front_Celulares.Pages
{
    public class AccesoDenegadoModel : PageModel
    {
        public void OnGet()
        {
            Response.StatusCode = StatusCodes.Status403Forbidden;
        }
    }
}
