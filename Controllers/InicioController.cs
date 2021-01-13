using Microsoft.AspNetCore.Mvc;

namespace ApiProductos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioController : Controller
    {
        public IActionResult Inicio()=> Ok("Api Productos by ing.Lucio Perez");
    }
}
