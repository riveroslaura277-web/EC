using Microsoft.AspNetCore.Mvc;
using EC.Models;
using System.Collections.Generic;
using System.Linq;

namespace EC.Controllers
{
    public class DocenteController3 : Controller
    {
        private static List<NOTARectorViewModel> notas = new List<NOTARectorViewModel>
        {
            new NOTARectorViewModel { Id = 1, NombreEstudiante = "María López", Asistencias = 20, Faltas = 2 },
            new NOTARectorViewModel { Id = 2, NombreEstudiante = "Julian Paredes", Asistencias = 15, Faltas = 4 },
            new NOTARectorViewModel { Id = 3, NombreEstudiante = "Lorena Cristancho", Asistencias = 25, Faltas = 0 }
        };

        public IActionResult Index()
        {
            return View("Docente", notas);
        }

        [HttpPost]
        public IActionResult Editar(NOTARectorViewModel nota)
        {
            var existente = notas.FirstOrDefault(n => n.Id == nota.Id);
            if (existente != null)
            {
                existente.NombreEstudiante = nota.NombreEstudiante;
                existente.Asistencias = nota.Asistencias;
                existente.Faltas = nota.Faltas;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var nota = notas.FirstOrDefault(n => n.Id == id);
            if (nota != null)
            {
                notas.Remove(nota);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(NOTARectorViewModel nota)
        {
            nota.Id = notas.Count > 0 ? notas.Max(n => n.Id) + 1 : 1;
            notas.Add(nota);
            return RedirectToAction("Index");
        }
    }
}
