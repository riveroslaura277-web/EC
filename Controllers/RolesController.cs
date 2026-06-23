using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class RolesController : Controller
    {
        public IActionResult fondoRoles()
        {
            return View();
        }

        public IActionResult Docente()
        {
            return View();
        }

        public IActionResult Estudiante()
        {
            return View();
        }

        public IActionResult Acudiente()
        {
            return View();
        }

        public IActionResult Rector()
        {
            return View();
        }
    }
}