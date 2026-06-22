using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ClosedXML.Excel;

namespace EC.Controllers
{
    public class ESTUController : Controller
    {
        // Lista en memoria (reemplazar por BD cuando esté lista)
        private static List<Estudiante> _datos = DatosPrueba.Estudiantes();

        public IActionResult Index(int grado = 1, string estado = "")
        {
            var lista = _datos.Where(e => e.Grado == grado);
            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(e => e.Estado == estado);

            ViewBag.Grado = grado;
            ViewBag.Estado = estado;
            ViewBag.TotalGrado = _datos.Count(e => e.Grado == grado);
            return View("ESTU",lista.ToList());
        }

        // Agregar
        [HttpPost]
        public IActionResult Agregar(Estudiante est)
        {
            est.Id = _datos.Any() ? _datos.Max(e => e.Id) + 1 : 1;
            est.Codigo = $"EST{est.Id:D3}";
            _datos.Add(est);
            return RedirectToAction("Index", new { grado = est.Grado });
        }

        // Editar
        [HttpPost]
        public IActionResult Editar(Estudiante est)
        {
            var item = _datos.FirstOrDefault(e => e.Id == est.Id);
            if (item != null)
            {
                item.Nombres = est.Nombres;
                item.Apellidos = est.Apellidos;
                item.Estado = est.Estado;
            }
            return RedirectToAction("Index", new { grado = est.Grado });
        }

        // Eliminar
        [HttpPost]
        public IActionResult Eliminar(int id, int grado)
        {
            var item = _datos.FirstOrDefault(e => e.Id == id);
            if (item != null) _datos.Remove(item);
            return RedirectToAction("Index", new { grado });
        }

        // Descargar Excel
        public IActionResult DescargarExcel(int grado)
        {
            var lista = _datos.Where(e => e.Grado == grado).ToList();

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add($"Grado {grado}");

            // Encabezado
            string[] headers = { "Código", "Nombres", "Apellidos", "Grado", "Estado" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1D9E75");
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            // Datos
            for (int r = 0; r < lista.Count; r++)
            {
                var e = lista[r];
                ws.Cell(r + 2, 1).Value = e.Codigo;
                ws.Cell(r + 2, 2).Value = e.Nombres;
                ws.Cell(r + 2, 3).Value = e.Apellidos;
                ws.Cell(r + 2, 4).Value = $"Grado {e.Grado}";
                ws.Cell(r + 2, 5).Value = e.Estado;
                if (e.Estado == "Inactivo")
                    ws.Row(r + 2).Style.Font.FontColor = XLColor.Gray;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Estudiantes_Grado{grado}.xlsx");
        }
    }
}
