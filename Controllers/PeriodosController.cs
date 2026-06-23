using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class PeriodosController : Controller
    {
        private static List<PeriodoViewModel> _datos = DatosPrueba.Periodos();

        public IActionResult Index()
        {
            return View(_datos);
        }

        [HttpPost]
        public IActionResult Agregar(PeriodoViewModel periodo)
        {
            periodo.Id = _datos.Any() ? _datos.Max(p => p.Id) + 1 : 1;
            periodo.Estado = "Próximo";
            _datos.Add(periodo);
            TempData["Mensaje"] = $"{periodo.Nombre} agregado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(PeriodoViewModel periodo)
        {
            var item = _datos.FirstOrDefault(p => p.Id == periodo.Id);
            if (item != null)
            {
                item.Nombre = periodo.Nombre;
                item.FechaInicio = periodo.FechaInicio;
                item.FechaFin = periodo.FechaFin;
                item.AnioEscolar = periodo.AnioEscolar;
            }
            TempData["Mensaje"] = $"{periodo.Nombre} actualizado correctamente";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id, string estado)
        {
            var item = _datos.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                item.Estado = estado;
                TempData["Mensaje"] = $"{item.Nombre} marcado como {estado}";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var item = _datos.FirstOrDefault(p => p.Id == id);
            if (item != null)
            {
                _datos.Remove(item);
                TempData["Mensaje"] = "Período eliminado correctamente";
            }
            return RedirectToAction("Index");
        }
    }
}
