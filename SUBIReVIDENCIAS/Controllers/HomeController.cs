using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SUBIReVIDENCIAS.Models;

namespace SUBIReVIDENCIAS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción principal: muestra la vista Index
        public IActionResult Index()
        {
            return View();
        }

        // Acción para la vista Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Acción para manejar errores
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
