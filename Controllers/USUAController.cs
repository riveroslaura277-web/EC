using EC.Data;
using EC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ClosedXML.Excel;

namespace EC.Controllers
{
    public class USUAController : Controller
    {
        private static List<Usuarios> _datos = DatosPrueba.Usuarios();

        public IActionResult Index(string estado = "", string rol = "")
        {
            var lista = _datos.AsQueryable();
            if (!string.IsNullOrEmpty(estado)) lista = lista.Where(u => u.Estado == estado);
            if (!string.IsNullOrEmpty(rol)) lista = lista.Where(u => u.Rol == rol);

            ViewBag.Estado = estado;
            ViewBag.Rol = rol;
            ViewBag.Pendientes = _datos.Count(u => u.Estado == "Pendiente");
            return View("USUA",lista.ToList());
        }

        [HttpPost]
        public IActionResult Agregar(Usuarios usr)
        {
            usr.Id = _datos.Any() ? _datos.Max(u => u.Id) + 1 : 1;
            usr.FechaRegistro = DateTime.Now;
            usr.Estado = "Pendiente";
            _datos.Add(usr);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CambiarEstado(int id, string estado)
        {
            var item = _datos.FirstOrDefault(u => u.Id == id);
            if (item != null) item.Estado = estado;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var item = _datos.FirstOrDefault(u => u.Id == id);
            if (item != null) _datos.Remove(item);
            return RedirectToAction("Index");
        }

        public IActionResult DescargarExcel(string estado = "")
        {
            var lista = string.IsNullOrEmpty(estado)
                ? _datos
                : _datos.Where(u => u.Estado == estado).ToList();

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Usuarios");

            string[] headers = { "ID", "Nombres", "Apellidos", "Correo", "Rol", "Estado", "Fecha Registro" };
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
                var u = lista[r];
                ws.Cell(r + 2, 1).Value = u.Id;
                ws.Cell(r + 2, 2).Value = u.Nombres;
                ws.Cell(r + 2, 3).Value = u.Apellidos;
                ws.Cell(r + 2, 4).Value = u.Correo;
                ws.Cell(r + 2, 5).Value = u.Rol;
                ws.Cell(r + 2, 6).Value = u.Estado;
                ws.Cell(r + 2, 7).Value = u.FechaRegistro.ToString("dd/MM/yyyy");
                if (u.Estado == "Bloqueado")
                    ws.Row(r + 2).Style.Font.FontColor = XLColor.Red;
                else if (u.Estado == "Pendiente")
                    ws.Row(r + 2).Style.Font.FontColor = XLColor.Orange;
            }

            ws.Columns().AdjustToContents();

            using var stream = new MemoryStream();
            wb.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Usuarios.xlsx");
        }
    }
}
