using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EC.Data;
using EC.Models;
using System.IO;
using System.Linq;


namespace EC.Controllers
{
    public class EvidenciasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvidenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista evidencias subidas
        public IActionResult Index()
        {
            var evidencias = _context.Evidencias
                .Include(e => e.Estudiante)
                .ToList();

            // ✅ Paso 1: enviar lista de estudiantes a la vista
            ViewBag.Estudiantes = _context.Estudiantes.ToList();

            return View(evidencias);
        }

        // Acción para subir archivo
        [HttpPost]
        public IActionResult SubirArchivo(IFormFile archivo)
        {
            int IdEstudiante = 2; // 👈 fijo en código (ejemplo Sofía)

            var estudiante = _context.Estudiantes.Find(IdEstudiante);
            if (estudiante == null)
            {
                TempData["Mensaje"] = "⚠️ El estudiante no existe en la base de datos.";
                return RedirectToAction("Index");
            }

            if (archivo != null)
            {
                var nombreArchivo = Path.GetFileName(archivo.FileName);
                var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }

                var evidencia = new Evidencia
                {
                    FechaEntrega = DateTime.Now,
                    Estado = "Pendiente",
                    IdEstudiante = IdEstudiante,
                    NombreArchivo = nombreArchivo,
                    NombreEstudiante = estudiante.Nombre
                };

                _context.Evidencias.Add(evidencia);
                _context.SaveChanges();
                TempData["Mensaje"] = "✅ Archivo subido correctamente";
            }

            return RedirectToAction("Index");
        }

        // Vista para calificar evidencia
        public IActionResult Calificar(int id)
        {
            var evidencia = _context.Evidencias.Find(id);

            if (evidencia == null)
            {
                return NotFound();
            }

            return View(evidencia);
        }

        // Guardar calificación con reglas de logros
        [HttpPost]
        public IActionResult GuardarCalificacion(int id, decimal nota, string? observacion)
        {
            var evidencia = _context.Evidencias.Find(id);

            if (evidencia != null)
            {
                evidencia.Nota = nota;
                evidencia.Observacion = observacion;
                evidencia.Estado = "Calificado";
                _context.SaveChanges();

                // ✅ Regla: Trabajo destacado
                if (nota == 5.0m)
                {
                    CrearLogro("Trabajo destacado", "Obtuvo la nota máxima en una evidencia", "fa-medal", evidencia.IdEstudiante);
                }

                // ✅ Regla: Constancia (3 evidencias aprobadas)
                var aprobadas = _context.Evidencias
                    .Count(e => e.IdEstudiante == evidencia.IdEstudiante && e.Nota >= 3.0m);

                if (aprobadas >= 3)
                {
                    CrearLogro("Constancia", "Ha entregado varias evidencias aprobadas seguidas", "fa-trophy", evidencia.IdEstudiante);
                }
            }

            return RedirectToAction("Index");
        }

        // Método auxiliar para crear logros
        private void CrearLogro(string nombre, string descripcion, string icono, int idEstudiante)
        {
            bool existe = _context.Logros
                .Any(l => l.IdEstudiante == idEstudiante && l.NombreLogro == nombre);

            if (!existe)
            {
                var logro = new Logro
                {
                    NombreLogro = nombre,
                    Descripcion = descripcion,
                    Icono = icono,
                    FechaObtencion = DateTime.Now,
                    IdEstudiante = idEstudiante
                };

                _context.Logros.Add(logro);
                _context.SaveChanges();
            }
        }
    }
}
