using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Cryptography;


public class UsuarioController : Controller
{
    private readonly ApplicationDbContext _context;

    public UsuarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    // =========================
    // LISTAR USUARIOS
    // =========================
    [HttpGet]
    public IActionResult Listar()
    {
        var usuarios = _context.Usuarios.ToList();
        return View(usuarios);
    }
    // =========================
    // LOGIN
    // =========================

    [HttpGet]
    public IActionResult Inicio(string rol = null)
    {
        ViewBag.RolSeleccionado = rol;
        return View("~/Views/Usuario/Inicio.cshtml");
    }

    [HttpPost]
    public IActionResult Inicio(string Email, string Password)
    {
        var usuario = _context.Usuarios
            .FirstOrDefault(u => (u.Correo ?? "").ToLower() == (Email ?? "").ToLower());

        if (usuario == null || usuario.Contrasena != HashearContrasena(Password))
        {
            TempData["Error"] = "Correo o contraseña incorrectos.";
            return View("~/Views/Usuario/Inicio.cshtml");
        }

        HttpContext.Session.SetString("UsuarioEmail", usuario.Correo);
        HttpContext.Session.SetInt32("UsuarioId", usuario.IdUsuario);
        HttpContext.Session.SetString("Rol", usuario.Rol ?? "");

        return RedirigirPorRol(usuario.Rol ?? "");
    }

    // =========================
    // REGISTRO
    // =========================

    [HttpGet]
    public IActionResult Registrar()
    {
        return View("~/Views/Registro/Index.cshtml");
    }

    [HttpPost]
    public IActionResult Registrar(
        string Email,
        string Password,
        string ConfirmarPassword,
        string Rol,
        string Nombres,
        string Apellidos)
    {
        if (Password != ConfirmarPassword)
        {
            TempData["Error"] = "Las contraseñas no coinciden.";
            return View("~/Views/Registro/Index.cshtml");
        }

        var existe = _context.Usuarios.FirstOrDefault(u => u.Correo == Email);

        if (existe != null)
        {
            TempData["Error"] = "El correo ya está registrado.";
            return View("~/Views/Registro/Index.cshtml");
        }

        Usuarios nuevo = new Usuarios
        {
            Correo = Email,
            Contrasena = HashearContrasena(Password),
            Rol = Rol,
            Nombres = Nombres,
            Apellidos = Apellidos,
            FechaRegistro = DateTime.Now
        };

        _context.Usuarios.Add(nuevo);
        _context.SaveChanges();

        TempData["Success"] = "Usuario registrado correctamente.";

        return RedirectToAction("Inicio");
    }
    // =========================
    // RECUPERAR CONTRASEÑA
    // =========================

    [HttpGet]
    public IActionResult RecuperarContrasena()
    {
        return View("~/Views/Usuario/RecuperarContrasena.cshtml");
    }

    [HttpPost]
    public IActionResult RecuperarContrasena(string Email)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == Email);

        if (usuario == null)
        {
            TempData["Error"] = "Ese correo no está registrado.";
            return View("~/Views/Usuario/RecuperarContrasena.cshtml");
        }

        string token = Guid.NewGuid().ToString();

        _context.PasswordResets.Add(new PasswordReset
        {
            Email = Email,
            Token = token,
            Expira = DateTime.Now.AddMinutes(30)
        });

        _context.SaveChanges();

        string enlace = Url.Action(
            "RestablecerContrasena",
            "Usuario",
            new { email = Email, token = token },
            Request.Scheme);

        TempData["Success"] = "Haz clic en el siguiente enlace para cambiar la contraseña.";
        ViewBag.Enlace = enlace;

        return View("~/Views/Usuario/RecuperarContrasena.cshtml");
    }

    // =========================
    // RESTABLECER CONTRASEÑA
    // =========================

    [HttpGet]
    public IActionResult RestablecerContrasena(string email, string token)
    {
        var reset = _context.PasswordResets
            .FirstOrDefault(r => r.Email == email &&
                                 r.Token == token &&
                                 r.Expira > DateTime.Now);

        if (reset == null)
        {
            TempData["Error"] = "El enlace es inválido o expiró.";
            return RedirectToAction("RecuperarContrasena");
        }

        ViewBag.Email = email;
        ViewBag.Token = token;

        return View("~/Views/Usuario/RestablecerContrasena.cshtml");
    }

    [HttpPost]
    public IActionResult RestablecerContrasena(string Email, string Token, string NuevaPassword, string ConfirmarPassword)
    {
        if (NuevaPassword != ConfirmarPassword)
        {
            TempData["Error"] = "Las contraseñas no coinciden.";
            ViewBag.Email = Email;
            ViewBag.Token = Token;
            return View("~/Views/Usuario/RestablecerContrasena.cshtml");
        }

        var reset = _context.PasswordResets
            .FirstOrDefault(r => r.Email == Email &&
                                 r.Token == Token &&
                                 r.Expira > DateTime.Now);

        if (reset == null)
        {
            TempData["Error"] = "El enlace es inválido o expiró.";
            return RedirectToAction("RecuperarContrasena");
        }

        var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == Email);

        if (usuario != null)
        {
            usuario.Contrasena = HashearContrasena(NuevaPassword);

            _context.PasswordResets.Remove(reset);

            _context.SaveChanges();
        }

        TempData["Success"] = "Contraseña actualizada correctamente.";

        return RedirectToAction("Inicio");
    }
    // =========================
    // HASH
    // =========================

    private static string HashearContrasena(string contrasena)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(contrasena);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    // =========================
    // REDIRECCIÓN POR ROL
    // =========================

    private IActionResult RedirigirPorRol(string rol)
    {
        switch (rol)
        {
            case "Administrador":
                return RedirectToAction("LoginAdministrador", "Usuario");

            case "Rector":
                return RedirectToAction("RolRector", "Rector");

            case "Docente":
                return RedirectToAction("Docente", "Docente");

            case "Acudiente":
                return RedirectToAction("Padres", "Acudiente");

            case "Estudiante":
                return RedirectToAction("Index", "Alumnos");

            default:
                return RedirectToAction("Index", "Home");
        }
    }
}