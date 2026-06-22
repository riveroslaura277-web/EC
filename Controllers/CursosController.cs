using Microsoft.AspNetCore.Mvc;
using EC.Data;
using EC.Models;

namespace EC.Controllers
{
    public class CursosController : Controller
    {
        private static List<CursoViewModel> _datos = DatosPrueba.Cursos();

        public IActionResult Index(string estado = "")
        {
            var lista = _datos.AsQueryable();
            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(c => c.Estado == estado);

            ViewBag.Estado = estado;
            ViewBag.Total = _datos.Count;
            ViewBag.Activos = _datos.Count(c => c.Estado == "Activo");
            ViewBag.Alerta = _datos.Count(c => c.Estado == "Alerta");
            ViewBag.Docentes = DatosPrueba.Docentes();
            return View(lista.ToList());
        }

        [HttpPost]
        public IActionResult Agregar(CursoViewModel curso)
        {
            curso.Id = _datos.Any() ? _datos.Max(c => c.Id) + 1 : 1;
            curso.NumEstudiantes = 0;
            curso.Promedio = 0;
            _datos.Add(curso);
            TempData["Mensaje"] = $"Curso '{curso.Nombre}' agregado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(CursoViewModel curso)
        {
            var item = _datos.FirstOrDefault(c => c.Id == curso.Id);
            if (item != null)
            {
                item.Nombre = curso.Nombre;
                item.Grado = curso.Grado;
                item.Docente = curso.Docente;
                item.Periodo = curso.Periodo;
                item.Estado = curso.Estado;
            }
            TempData["Mensaje"] = $"Curso '{curso.Nombre}' actualizado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var item = _datos.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _datos.Remove(item);
                TempData["Mensaje"] = $"Curso eliminado correctamente";
            }
            return RedirectToAction("Index");
        }
    }
}
