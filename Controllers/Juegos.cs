using Microsoft.AspNetCore.Mvc;

namespace EC.Controladores
{
    public class matematicasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}