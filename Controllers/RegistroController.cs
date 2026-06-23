using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EC.Data;
using EC.Models;


namespace WebApplication1.Controllers
{
    public class RegistroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        // REGISTRAR
        [HttpPost]
        public IActionResult Registrar(string Nombres, string Apellidos, string Correo, string Contrasena, string ConfirmarContrasena, int IdRol)
        {
            // 1. Validar campos
            if (string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(Contrasena))
            {
                ViewBag.Error = "Debes llenar todos los campos";
                return View("Index");
            }

            // 2. Confirmar contraseña
            if (Contrasena != ConfirmarContrasena)
            {
                ViewBag.Error = "Las contraseñas no coinciden";
                return View("Index");
            }

            // 3. Verificar duplicado
            var existe = _context.Usuarios.Any(x => x.Correo == Correo);
            if (existe)
            {
                ViewBag.Error = "Este correo ya está registrado";
                return View("Index");
            }

            // 4. Hash de contraseña
            string hash = HashearContrasena(Contrasena);

            // 5. Crear usuario
            var usuario = new Usuarios
            {
                Nombres = Nombres,
                Apellidos = Apellidos,
                Correo = Correo,
                Contrasena = hash,
                IdRol = IdRol,
                FechaRegistro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            TempData["Mensaje"] = "Registro exitoso";
            return RedirectToAction("Login", "Usuario");
        }
        [HttpPost]
        public IActionResult EditarInline(int IdUsuario, string Nombres, string Apellidos, string Correo, int IdRol)
        {
            var usuario = _context.Usuarios.Find(IdUsuario);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado" });
            }

            // Actualizar campos
            usuario.Nombres = Nombres;
            usuario.Apellidos = Apellidos;
            usuario.Correo = Correo;
            usuario.IdRol = IdRol;

            try
            {
                _context.Update(usuario);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        // LISTAR
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return View(usuarios);
        }

        // ELIMINAR UNO
        [HttpPost]
        public IActionResult EliminarSeleccionada(int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);

                if (usuario == null)
                    return Json(new { success = false, message = "Usuario no encontrado" });

                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        // ELIMINAR VARIOS
        [HttpPost]
        public IActionResult EliminarSeleccionada(int[] ids)
        {
            var usuarios = _context.Usuarios
                                   .Where(u => ids.Contains(u.IdUsuario))
                                   .ToList();

            if (usuarios.Count == 0)
                return NotFound();

            _context.Usuarios.RemoveRange(usuarios);
            _context.SaveChanges();

            return RedirectToAction("Listar");
        }

        // HASH CONSISTENTE
        private static string HashearContrasena(string contrasena)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contrasena);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
