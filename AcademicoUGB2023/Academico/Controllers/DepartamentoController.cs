using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class DepartamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
