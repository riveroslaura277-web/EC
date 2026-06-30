using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ClosedXML.Excel;

namespace EC.Controllers
{
    public class ACUController : Controller
    {
        private static List<Acudiente> _datos = DatosPrueba.Acudientes();

        public IActionResult Index(string estado = "")
        {
            var lista = _datos.AsQueryable();
            if (!string.IsNullOrEmpty(estado))
                lista = lista.Where(a => a.Estado == estado);

            ViewBag.Estado = estado;
            return View("ACU",lista.ToList());
        }

        [HttpPost]
        public IActionResult Agregar(Acudiente acu)
        {
            acu.Id = _datos.Any() ? _datos.Max(a => a.Id) + 1 : 1;
            _datos.Add(acu);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Editar(Acudiente acu)
        {
            var item = _datos.FirstOrDefault(a => a.Id == acu.Id);
            if (item != null)
            {
                item.Nombres = acu.Nombres;
                item.Apellidos = acu.Apellidos;
                item.Direccion = acu.Direccion;
                item.Telefono = acu.Telefono;
                item.NombreEstudiante = acu.NombreEstudiante;
                item.Estado = acu.Estado;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var item = _datos.FirstOrDefault(a => a.Id == id);
            if (item != null) _datos.Remove(item);
            return RedirectToAction("Index");
        }

        public IActionResult DescargarExcel(string estado = "")
        {
            var lista = string.IsNullOrEmpty(estado)
                ? _datos
                : _datos.Where(a => a.Estado == estado).ToList();

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Acudientes");

            string[] headers = { "ID", "Nombres", "Apellidos", "Dirección", "Teléfono", "Estudiante", "Estado" };
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
                var a = lista[r];
                ws.Cell(r + 2, 1).Value = a.Id;
                ws.Cell(r + 2, 2).Value = a.Nombres;
                ws.Cell(r + 2, 3).Value = a.Apellidos;
                ws.Cell(r + 2, 4).Value = a.Direccion;
                ws.Cell(r + 2, 5).Value = a.Telefono;
                ws.Cell(r + 2, 6).Value = a.NombreEstudiante;
                ws.Cell(r + 2, 7).Value = a.Estado;
                if (a.Estado == "Inactivo")
                    ws.Row(r + 2).Style.Font.FontColor = XLColor.Gray;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Acudientes.xlsx");
        }
        public IActionResult VerClaims()
        {
            var claims = User.Claims.Select(c => $"{c.Type}: {c.Value}");
            return Content(string.Join("\n", claims));
        }

    }
}
