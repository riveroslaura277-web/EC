using Microsoft.AspNetCore.Mvc;
using EC.Data;
using EC.Models;

namespace EC.Controllers
{

    // Controlador real que usa ApplicationDbContext
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EstudiantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista de estudiantes
        public IActionResult Index()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        // Formulario de registro
        [HttpGet]
        public IActionResult Registrar() => View();

        [HttpPost]
        public IActionResult Registrar(EC.Models.Estudiantes estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Estudiantes.Add(estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "Estudiante registrado correctamente ✅";
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

    }
}
