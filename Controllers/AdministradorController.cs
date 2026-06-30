using EC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdministradorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Admin()
        {
            return View();
        }

        public async Task<IActionResult> Estudiantes()
        {
            var estudiantes = await _context.Usuarios
                .Where(u => u.Rol == "Estudiante")

                .ToListAsync();

            return View(estudiantes);
        }

        public async Task<IActionResult> Docentes()
        {
            var docentes = await _context.Usuarios
                .Where(u => u.Rol == "Docentes")
                .ToListAsync();

            return View(docentes);
        }

        public async Task<IActionResult> Acudientes()
        {
            var acudientes = await _context.Usuarios
                .Where(u => u.Rol == "Acudientes")
                .ToListAsync();

            return View(acudientes);
        }

        public async Task<IActionResult> Rectores()
        {
            var rectores = await _context.Usuarios
                .Where(u => u.Rol == "Rectores")
                .ToListAsync();

            return View(rectores);
        }
    }
}