using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
