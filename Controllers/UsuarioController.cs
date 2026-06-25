using EC.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Inicio(string rol)
        {
            ViewBag.RolSeleccionado = rol;
            return View();
        }

        [HttpPost]
        public IActionResult Inicio(string Email, string Password, string rol)
        {
            // Hashear la contraseña igual que en registro
            string hash = HashearContrasena(Password);

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == Email && u.Contrasena == hash);

            if (usuario == null)
            {
                TempData["Error"] = "Correo o contraseña incorrectos.";
                ViewBag.RolSeleccionado = rol;
                return View();
            }

            HttpContext.Session.SetString("UsuarioEmail", usuario.Correo);
            HttpContext.Session.SetString("UsuarioRol", rol);
            HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);

            return rol switch
            {
                "Administrador" => RedirectToAction("LoginAdministrador", "Usuario"),
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("docente", "Docente"),
                "Estudiante" => RedirectToAction("Index", "Alumnos"),
                "Acudiente" => RedirectToAction("LoginAcudiente", "Usuario"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        private static string HashearContrasena(string contrasena)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(contrasena);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }


        [HttpGet]
        public IActionResult IniciarConGoogle(string rol)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleCallback", new { rol })
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GoogleCallback(string rol)
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (!result.Succeeded)
            {
                TempData["Error"] = "Error al iniciar sesión con Google.";
                return RedirectToAction("Inicio");
            }

            var email = result.Principal?.FindFirst(ClaimTypes.Email)?.Value;

            // Guardar sesión
            HttpContext.Session.SetString("UsuarioEmail", email ?? "");
            HttpContext.Session.SetString("UsuarioRol", rol);

            // Redirigir según el rol
            return rol switch
            {
                "Administrador" => RedirectToAction("admin", "Administrador"),
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("PanelDocente", "Docente"),
                "Estudiante" => RedirectToAction("Index", "Alumnos"),
                "Acudiente" => RedirectToAction("padres", "Acudiente"),
                _ => RedirectToAction("Index", "Home")
            };
        }
    }
}