using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EC.Controllers
{
        public class AccountController : Controller
        {
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
                var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                if (!result.Succeeded)
                    return RedirectToAction("Login");

                // Obtener datos del usuario
                var claims = result.Principal.Claims.ToList();
                var email = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                var name = claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

                // Aquí puedes buscar/crear el usuario en tu base de datos
                // ...

                return RedirectToAction("RolRector", "Rector");
            }

            public async Task<IActionResult> Logout()
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Index", "Home");
            }
        }
}
