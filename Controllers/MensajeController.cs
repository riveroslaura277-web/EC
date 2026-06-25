using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class MensajeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MensajeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Enviar(Mensaje mensaje)
        {
            mensaje.FechaEnvio = DateTime.Now;
            mensaje.Leido = false;

            _context.Mensajes.Add(mensaje);
            await _context.SaveChangesAsync();

            TempData["MensajeEnviado"] = "¡Tu mensaje fue enviado correctamente!";
            return RedirectToAction("Index", "Contacto");
        }

        // Para que el admin vea los mensajes
        public async Task<IActionResult> Index()
        {
            var mensajes = _context.Mensajes
                .OrderByDescending(m => m.FechaEnvio)
                .ToList();

            return View(mensajes);
        }

        [HttpPost]
        public async Task<IActionResult> MarcarLeido(int id)
        {
            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje != null)
            {
                mensaje.Leido = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var mensaje = await _context.Mensajes.FindAsync(id);
            if (mensaje != null)
            {
                _context.Mensajes.Remove(mensaje);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
