using Microsoft.AspNetCore.Mvc;

namespace EduClick.Controllers
{
    public class Alumnos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}