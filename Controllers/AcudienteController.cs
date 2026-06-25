using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using EC.Models;
namespace WebApplication1.Controllers
{
    public class AcudienteController : Controller
    {
        public IActionResult padres()
        {
            return View();
        }

        public IActionResult Notas()
        {
            return View();
        }

        public IActionResult Asistencia()
        {
            return View();
        }

        public IActionResult InformacionEstudiante()
        {
            return View();
        }

        public IActionResult RendimientoAcademico()
        {
            return View();
        }

        public IActionResult Mensajes()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            var acudiente = new Acudiente
            {
                Nombres = "María López",
                Correo = "maria.lopez@educlick.com",
                Telefono = "3104567890",
                Direccion = "Calle 12 #8-45",
                Hijos = new List<string> { "Carlos López", "Ana López" }
            };

            return View(acudiente);
        }

        [HttpPost]
        public IActionResult Perfil(Acudiente model)
        {
            if (ModelState.IsValid)
            {
                // Aquí guardas en BD
                ViewBag.Mensaje = "Perfil actualizado correctamente ✅";
            }

            return View(model);
        }
    }
}