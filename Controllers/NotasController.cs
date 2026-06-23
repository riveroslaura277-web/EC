using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class NotasController : Controller
    {
        private static List<NOTARectorViewModel> _datos = DatosPrueba.Notas();

        public IActionResult Index(int grado = 1, string curso = "", string estado = "")
        {
            var lista = _datos.Where(n => n.Grado == grado);

            if (!string.IsNullOrEmpty(curso))
                lista = lista.Where(n => n.Curso == curso);

            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(n => n.Estado == estado);

            ViewBag.Grado = grado;
            ViewBag.Curso = curso;
            ViewBag.Estado = estado;
            ViewBag.Cursos = _datos.Where(n => n.Grado == grado).Select(n => n.Curso).Distinct().ToList();

            return View(lista.ToList());
        }
    }
}
