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

        public IActionResult Index()
        {
            ViewBag.MensajesNoLeidos = _context.Mensajes.Count(m => !m.Leido);
            return View();
        }

        public async Task<IActionResult> Estudiantes()
        {
            var estudiantes = await _context.Usuarios
                .Where(u => u.IdRol == 5)
                .ToListAsync();

            return View(estudiantes);
        }

        public async Task<IActionResult> Docentes()
        {
            var docentes = await _context.Usuarios
                .Where(u => u.IdRol == 3)
                .ToListAsync();

            return View(docentes);
        }

        public async Task<IActionResult> Acudientes()
        {
            var acudientes = await _context.Usuarios
                .Where(u => u.IdRol == 4)
                .ToListAsync();

            return View(acudientes);
        }

        public async Task<IActionResult> Rectores()
        {
            var rectores = await _context.Usuarios
                .Where(u => u.IdRol == 2)
                .ToListAsync();

            return View(rectores);
        }
    }
}