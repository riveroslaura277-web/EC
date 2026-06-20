using Microsoft.AspNetCore.Mvc;
using EC.Data;
using EC.Models;

namespace EC.Controllers
{
    // Controlador generado por plantilla (CRUD básico)
    public class Estudiantes : Controller
    {
        // GET: Estudiantes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estudiantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estudiantes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }

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
