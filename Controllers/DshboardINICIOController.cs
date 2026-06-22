using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EC.Controllers
{
    public class DshboardINICIOController : Controller
    {
        public IActionResult Index()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            return View();
        }
    }
}
