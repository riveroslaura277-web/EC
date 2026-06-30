using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EC.Data;
using Microsoft.EntityFrameworkCore;

namespace EC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AccesoDenegado()
        {
            return View();
        }

        // Inicia el flujo de autenticación con Google
        public IActionResult LoginWithGoogle()
        {
            var redirectUrl = Url.Action("GoogleCallback", "Account");
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        // Google redirige aquí después de autenticar
        public async Task<IActionResult> GoogleCallback()
        {
            // ✅ Autenticar contra Google
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);


            if (!result.Succeeded)
                return RedirectToAction("Login");

            var claims = result.Principal.Claims.ToList();
            var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login");

            // Buscar el usuario en la BD por su correo
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == email);

            if (usuario == null)
            {
                TempData["Error"] = "Tu correo no está registrado en EduClick.";
                return RedirectToAction("Login");
            }

            // Mapear IdRol → nombre de rol para [Authorize(Roles = "...")]
            string nombreRol = usuario.IdRol switch
            {
                2 => "Rector",
                3 => "Docente",
                4 => "Acudiente",
                5 => "Estudiante",
                _ => "Desconocido"
            };

            // Crear los claims con el rol incluido
            var nuevosClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, name ?? ""),
                new Claim(ClaimTypes.Role, nombreRol)
            };

            var identity = new ClaimsIdentity(nuevosClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            // ✅ Guardar la cookie con los claims (correo + rol)
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Redirigir según el rol
            return nombreRol switch
            {
                "Rector" => RedirectToAction("RolRector", "Rector"),
                "Docente" => RedirectToAction("Index", "Docente"),
                "Acudiente" => RedirectToAction("Padres", "Acudiente"),
                "Estudiante" => RedirectToAction("Index", "Estudiantes"),
                _ => RedirectToAction("Index", "Home")
            };
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
