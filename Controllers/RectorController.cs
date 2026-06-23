using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace EC.Controllers
{
    // [Authorize(Roles = "Rector")]
    public class RectorController : Controller
    {
        // Acción que muestra el panel del rector
        public IActionResult RolRector()
        {
            ViewBag.NombreUsuario = User.FindFirstValue(ClaimTypes.Name) ?? "Usuario";
            ViewBag.TotalEstudiantes = 850;
            ViewBag.NuevosEstudiantes = 12;
            ViewBag.TotalDocentes = 45;
            ViewBag.NuevosDocentes = 2;
            ViewBag.TotalAcudientes = 600;
            ViewBag.TotalUsuarios = 150;
            ViewBag.UsuariosPendientes = 3;

            ViewBag.Cursos = new List<dynamic> {
                new { Nombre="11° A", Docente="Prof. García", Promedio=7.8, Estado="Activo"   },
                new { Nombre="10° B", Docente="Prof. López",  Promedio=6.9, Estado="Activo"   },
                new { Nombre="9° C",  Docente="Prof. Ruiz",   Promedio=5.4, Estado="Alerta"   },
                new { Nombre="8° A",  Docente="Prof. Mora",   Promedio=8.1, Estado="Activo"   },
                new { Nombre="7° B",  Docente="Prof. Díaz",   Promedio=7.2, Estado="Revisión" },
            };

            ViewBag.RendLabelsJson = "[\"Ene\",\"Feb\",\"Mar\",\"Abr\",\"May\",\"Jun\"]";
            ViewBag.RendActualJson = "[72,80,68,60,64,66]";
            ViewBag.RendAnteriorJson = "[65,63,48,44,62,50]";
            ViewBag.NotasLabelsJson = "[\"0-2\",\"2-4\",\"4-6\",\"6-8\",\"8-10\"]";
            ViewBag.NotasDataJson = "[18,102,340,255,135]";

            ViewBag.Noticias = new List<dynamic> {
                new { Titulo="Feria de Ciencias", Fecha=DateTime.Now.AddDays(2)  },
                new { Titulo="Reunión de Padres", Fecha=DateTime.Now.AddDays(9)  },
                new { Titulo="Salida Pedagógica", Fecha=DateTime.Now.AddDays(16) },
            };

            ViewBag.ProximoEvento = new
            {
                Titulo = "Día del Estudiante",
                Descripcion = "Actividades culturales y deportivas para toda la comunidad.",
                Fecha = DateTime.Now.AddDays(21)
            };

            return View();
        }

        public IActionResult Perfil()
        {
            var nombre = User.FindFirstValue(ClaimTypes.Name) ?? "Sin nombre";
            var correo = User.FindFirstValue(ClaimTypes.Email) ?? "Sin correo";

            var model = new PerfilViewModel
            {
                Nombre = nombre,
                Correo = correo,
                Telefono = "Sin teléfono",
                Cargo = "Rector",
                Institucion = "EduClick"
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Perfil(PerfilViewModel model)
        {
            TempData["Mensaje"] = "Perfil actualizado correctamente";
            return RedirectToAction("RolRector");
        }

        public IActionResult Roles()
        {
            var roles = DatosPrueba.Roles();
            return View(roles);
        }

        [HttpPost]
        public IActionResult EditarRol(RolViewModel rol)
        {
            TempData["Mensaje"] = $"Rol '{rol.Nombre}' actualizado correctamente";
            return RedirectToAction("Roles");
        }

        public IActionResult Modulos()
        {
            var modulos = DatosPrueba.Modulos();
            return View(modulos);
        }

        [HttpPost]
        public IActionResult CambiarEstadoModulo(int id, string estado)
        {
            var nombre = DatosPrueba.Modulos().FirstOrDefault(m => m.Id == id)?.Nombre;
            TempData["Mensaje"] = $"Módulo '{nombre}' {(estado == "Activo" ? "activado" : "desactivado")} correctamente";
            return RedirectToAction("Modulos");
        }

        [HttpPost]
        public IActionResult EditarModulo(ModuloViewModel modulo)
        {
            TempData["Mensaje"] = $"Módulo '{modulo.Nombre}' actualizado correctamente";
            return RedirectToAction("Modulos");
        }
    }
}