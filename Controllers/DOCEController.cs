using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ClosedXML.Excel;

namespace EC.Controllers
{
    public class DOCEController : Controller
    {
        private static List<Docente> _datos = DatosPrueba.Docentes();

        public IActionResult Index(string estado = "")
        {
            var lista = _datos.AsQueryable();
            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(d => d.Estado == estado);

            ViewBag.Estado = estado;
            return View("DOCE",lista.ToList());
        }

        [HttpPost]
        public IActionResult Agregar(Docente doc)
        {
            doc.Id = _datos.Any() ? _datos.Max(d => d.Id) + 1 : 1;
            _datos.Add(doc);
            return RedirectToAction("Index");
        }
        [HttpPost]

        public IActionResult Editar(Docente doc)
        {
            var item = _datos.FirstOrDefault(d => d.Id == doc.Id);
            if (item != null)
            {
                item.Nombres = doc.Nombres;
                item.Apellidos = doc.Apellidos;
                item.Correo = doc.Correo;
                item.Telefono = doc.Telefono;
                item.Especialidad = doc.Especialidad;
                item.Estado = doc.Estado;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var item = _datos.FirstOrDefault(d => d.Id == id);
            if (item != null) _datos.Remove(item);
            return RedirectToAction("Index");
        }

        public IActionResult DescargarExcel(string estado = "")
        {
            var lista = string.IsNullOrEmpty(estado)
                ? _datos
                : _datos.Where(d => d.Estado == estado).ToList();

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Docentes");

            string[] headers = { "ID", "Nombres", "Apellidos", "Correo", "Teléfono", "Especialidad", "Estado" };
            for (int i = 0; i < headers.Length; i++)
            {
                var cell = ws.Cell(1, i + 1);
                cell.Value = headers[i];
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#1D9E75");
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            for (int r = 0; r < lista.Count; r++)
            {
                var d = lista[r];
                ws.Cell(r + 2, 1).Value = d.Id;
                ws.Cell(r + 2, 2).Value = d.Nombres;
                ws.Cell(r + 2, 3).Value = d.Apellidos;
                ws.Cell(r + 2, 4).Value = d.Correo;
                ws.Cell(r + 2, 5).Value = d.Telefono;
                ws.Cell(r + 2, 6).Value = d.Especialidad;
                ws.Cell(r + 2, 7).Value = d.Estado;
                if (d.Estado == "Inactivo")
                    ws.Row(r + 2).Style.Font.FontColor = XLColor.Gray;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Docentes.xlsx");
        }

    }
}
