using EC.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;

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
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == Email && u.Rol == rol);

            if (usuario == null || usuario.Contrasena != Password)
            {
                TempData["Error"] = "Correo o contraseña incorrectos.";
                ViewBag.RolSeleccionado = rol;
                return View();
            }

            HttpContext.Session.SetString("UsuarioEmail", usuario.Correo);
            HttpContext.Session.SetString("UsuarioRol", usuario.Rol);
            HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);

            return rol switch
            {
                "Administrador" => RedirectToAction("admin", "Administrador"),
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("Paneldocente", "Docente"),
                "Estudiante" => RedirectToAction("Index", "Alumnos"),
                "Acudiente" => RedirectToAction("padres", "Acudiente"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        [HttpGet]
        public IActionResult IniciarConGoogle(string rol)
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("CallbackGoogle", "Usuario"),
                Items = { { "rol", rol } }
            };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> CallbackGoogle()
        {
            var result = await HttpContext.AuthenticateAsync(
                GoogleDefaults.AuthenticationScheme);

            if (!result.Succeeded)
                return RedirectToAction("Index", "Home");

            var email = result.Principal?.FindFirst(ClaimTypes.Email)?.Value;
            string rolSeleccionado = "";
            result.Properties?.Items.TryGetValue("rol", out rolSeleccionado);
            rolSeleccionado ??= "";

            // Verificar si la BD está disponible
            bool bdDisponible = false;
            try
            {
                bdDisponible = await _context.Database.CanConnectAsync();
            }
            catch { }

            if (bdDisponible)
            {
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.Correo == email && u.Rol == rolSeleccionado);

                if (usuario == null)
                {
                    TempData["Error"] = $"El correo {email ?? "desconocido"} no está registrado como {rolSeleccionado} en EduClick.";
                    return RedirectToAction("Index", "Home");
                }

                HttpContext.Session.SetString("UsuarioEmail", email ?? "");
                HttpContext.Session.SetString("UsuarioRol", rolSeleccionado);
                HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);
            }
            else
            {
                // BD no disponible - guarda sesión sin validar
                HttpContext.Session.SetString("UsuarioEmail", email ?? "");
                HttpContext.Session.SetString("UsuarioRol", rolSeleccionado);
            }

            return rolSeleccionado switch
            {
                "Administrador" => RedirectToAction("admin", "Administrador"),
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("Paneldocente", "Docente"),
                "Estudiante" => RedirectToAction("Index", "Alumnos"),
                "Acudiente" => RedirectToAction("padres", "Acudiente"),
                _ => RedirectToAction("Index", "Home")
            };
        }
    }
}