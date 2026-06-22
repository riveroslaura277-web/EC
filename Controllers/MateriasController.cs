using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class MateriasController : Controller
    {
        private static List<MateriaViewModel> _datos = DatosPrueba.Materias();

        public IActionResult Index(int grado = 1, string estado = "")
        {
            var lista = _datos.Where(m => m.Grado == grado);
            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(m => m.Estado == estado);

            ViewBag.Grado = grado;
            ViewBag.Estado = estado;
            ViewBag.Docentes = DatosPrueba.Docentes();
            return View(lista.ToList());
        }

        [HttpPost]
        public IActionResult Agregar(MateriaViewModel materia)
        {
            materia.Id = _datos.Any() ? _datos.Max(m => m.Id) + 1 : 1;
            _datos.Add(materia);
            TempData["Mensaje"] = $"Materia '{materia.Nombre}' agregada correctamente";
            return RedirectToAction("Index", new { grado = materia.Grado });
        }

        [HttpPost]
        public IActionResult Editar(MateriaViewModel materia)
        {
            var item = _datos.FirstOrDefault(m => m.Id == materia.Id);
            if (item != null)
            {
                item.Nombre = materia.Nombre;
                item.Descripcion = materia.Descripcion;
                item.Docente = materia.Docente;
                item.HorasSemana = materia.HorasSemana;
                item.Estado = materia.Estado;
            }
            TempData["Mensaje"] = $"Materia '{materia.Nombre}' actualizada correctamente";
            return RedirectToAction("Index", new { grado = materia.Grado });
        }

        [HttpPost]
        public IActionResult Eliminar(int id, int grado)
        {
            var item = _datos.FirstOrDefault(m => m.Id == id);
            if (item != null)
            {
                _datos.Remove(item);
                TempData["Mensaje"] = "Materia eliminada correctamente";
            }
            return RedirectToAction("Index", new { grado });
        }
    }
}
