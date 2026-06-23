using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class BoletinesController : Controller
    {
        public IActionResult Index(int grado = 1)
        {
            var notas = DatosPrueba.Notas();

            var boletines = notas
                .Where(n => n.Grado == grado)
                .GroupBy(n => new { n.CodigoEstudiante, n.NombreEstudiante, n.Curso, n.Grado })
                .Select(g => new BoletinesViewModel
                {
                    CodigoEstudiante = g.Key.CodigoEstudiante,
                    NombreEstudiante = g.Key.NombreEstudiante,
                    Curso = g.Key.Curso,
                    Grado = g.Key.Grado,
                    Materias = g.ToList()
                })
                .ToList();

            ViewBag.Grado = grado;
            return View(boletines);
        }

        public IActionResult Detalle(string codigo)
        {
            var notas = DatosPrueba.Notas().Where(n => n.CodigoEstudiante == codigo).ToList();

            if (!notas.Any())
                return NotFound();

            var boletin = new BoletinesViewModel
            {
                CodigoEstudiante = notas.First().CodigoEstudiante,
                NombreEstudiante = notas.First().NombreEstudiante,
                Curso = notas.First().Curso,
                Grado = notas.First().Grado,
                Materias = notas
            };

            return View(boletin);
        }
    }
}
