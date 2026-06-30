using EC.Data;
using EC.Models;
using EC.Services;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controladores
{
    public class Contactanos : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public Contactanos(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: Contactanos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contactanos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contactanos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contactanos/Create
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

        // GET: Contactanos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contactanos/Edit/5
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

        // GET: Contactanos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contactanos/Delete/5
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

        // POST: Contactanos/Enviar  ?? método nuevo al final
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enviar(Mensaje modelo)
        {
            if (!ModelState.IsValid)
                return View("Index", modelo);

            modelo.FechaEnvio = DateTime.Now;
            modelo.Leido = false;

            _context.Mensajes.Add(modelo);
            await _context.SaveChangesAsync();

            try { _emailService.EnviarNotificacionAdmin(modelo); }
            catch (Exception ex) { Console.WriteLine($"Error email: {ex.Message}"); }

            TempData["Enviado"] = "¡Mensaje enviado con éxito!";
            return RedirectToAction("Index");
        }
    }
}
