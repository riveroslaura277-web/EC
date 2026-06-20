using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUBIReVIDENCIAS.Data;
using SUBIReVIDENCIAS.Models;
using System.Linq;

namespace SUBIReVIDENCIAS.Controllers
{
    public class DocenteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Panel principal del docente (menú)
        public IActionResult PanelDocente()
        {
            var modelo = new DocenteViewModel
            {
                Nombre = "Profesor Juan"
            };
            return View(modelo);
        }

        // Acción para listar todas las evidencias subidas
        public IActionResult Tareas()
        {
            var evidencias = _context.Evidencias.ToList();
            return View(evidencias);
        }

        // Acción para calificar una evidencia
        public IActionResult Calificar(int id)
        {
            var evidencia = _context.Evidencias.Find(id);
            if (evidencia != null)
            {
                evidencia.Estado = "Calificado";
                evidencia.MensajeConfirmacion = "Tu evidencia ha sido revisada y calificada ✅";
                _context.SaveChanges();
            }
            return RedirectToAction("Tareas");
        }

        // Acción para ver estudiantes
        public IActionResult Estudiantes()
        {
            var estudiantes = _context.Estudiantes.ToList();
            return View(estudiantes);
        }

        // Acción para ver asistencia
        public IActionResult Asistencia()
        {
            var asistencia = _context.Asistencias.ToList();
            return View(asistencia);
        }

        [HttpPost]
        public IActionResult GuardarCalificacion(int id, decimal nota, string? observacion)
        {
            var evidencia = _context.Evidencias.Find(id);

            if (evidencia != null)
            {
                evidencia.Nota = nota;
                evidencia.Observacion = observacion;
                evidencia.Estado = "Calificado";
                evidencia.MensajeConfirmacion = "✅ Calificación guardada correctamente";

                _context.SaveChanges();
            }
            TempData["Mensaje"] = "✅ Calificación guardada correctamente";
            return RedirectToAction("Tareas");
        }

        public IActionResult Logros()
        {
            var logros = _context.Logros.Include(l => l.Estudiante).ToList();
            return View(logros);
        }

        [HttpPost]
        public IActionResult EditarEstudiante(int IdEstudiante, string Nombre, string Correo, string Curso)
        {
            var estudiante = _context.Estudiantes.Find(IdEstudiante);
            if (estudiante != null)
            {
                estudiante.Nombre = Nombre;
                estudiante.Correo = Correo;
                estudiante.Curso = Curso;

                _context.Update(estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "✅ Estudiante actualizado correctamente";
            }
            else
            {
                TempData["Mensaje"] = "⚠️ No se encontró el estudiante";
            }

            return RedirectToAction("Estudiantes");
        }

        [HttpPost]
        public IActionResult EliminarEstudiante(int IdEstudiante)
        {
            var estudiante = _context.Estudiantes.Find(IdEstudiante);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                _context.SaveChanges();
                TempData["Mensaje"] = "🗑️ Estudiante eliminado correctamente";
            }
            else
            {
                TempData["Mensaje"] = "⚠️ No se encontró el estudiante";
            }

            return RedirectToAction("Estudiantes");
        }

        [HttpPost]
        public IActionResult EditarAsistencia(int Id, string Estado, DateTime Fecha)
        {
            var registro = _context.Asistencias.Find(Id);
            if (registro != null)
            {
                registro.Estado = Estado;
                registro.Fecha = Fecha;

                _context.Update(registro);
                _context.SaveChanges();
                TempData["Mensaje"] = "✅ Asistencia actualizada correctamente";
            }
            else
            {
                TempData["Mensaje"] = "⚠️ No se encontró el registro de asistencia";
            }

            return RedirectToAction("Asistencia");
        }

        [HttpPost]
        public IActionResult EliminarAsistencia(int Id)
        {
            var registro = _context.Asistencias.Find(Id);
            if (registro != null)
            {
                _context.Asistencias.Remove(registro);
                _context.SaveChanges();
                TempData["Mensaje"] = "🗑️ Registro de asistencia eliminado correctamente";
            }
            else
            {
                TempData["Mensaje"] = "⚠️ No se encontró el registro de asistencia";
            }

            return RedirectToAction("Asistencia");
        }

        public IActionResult Observaciones()
        {
            var todasLasNotas = _context.Observaciones
                                        .Include(o => o.Estudiante)
                                        .OrderByDescending(o => o.Fecha)
                                        .ToList();

            return View(todasLasNotas);
        }

        // GET: Perfil
        public IActionResult Perfil()
        {

            var correoUsuario = User.Identity?.Name;
            var profesor = _context.Profesores.FirstOrDefault(p => p.Correo == correoUsuario);

            if (profesor == null)
            {
                profesor = new Profesor { Nombre = "Nuevo Profesor", Correo = correoUsuario ?? "correo@ejemplo.com" };
                _context.Profesores.Add(profesor);
                _context.SaveChanges();
            }

            // SIEMPRE envía un objeto, aunque sea nuevo.
            return View(profesor);
        }



        // POST: Editar Perfil
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> EditarPerfil(Profesor perfil, IFormFile? foto)
        {
            var profesorExistente = _context.Profesores.Find(perfil.Id);

            if (profesorExistente != null)
            {
                profesorExistente.Nombre = perfil.Nombre;
                profesorExistente.Correo = perfil.Correo;
                profesorExistente.Especialidad = perfil.Especialidad;

                if (foto != null && foto.Length > 0)
                {
                    var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                    var ruta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", nombreArchivo);
                    using (var stream = new FileStream(ruta, FileMode.Create))
                    {
                        await foto.CopyToAsync(stream);
                    }
                    profesorExistente.FotoRuta = "/imagenes/" + nombreArchivo;
                }

                _context.SaveChanges();
            }

            // En lugar de redirigir, regresamos a la vista actual
            return View("Perfil", _context.Profesores.Find(perfil.Id));
        }
    }
}