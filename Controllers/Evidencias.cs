using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class EvidenciasController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Mensaje = TempData["Mensaje"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubirArchivo(IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                string carpeta = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads");

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                string rutaArchivo = Path.Combine(
                    carpeta,
                    archivo.FileName);

                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    await archivo.CopyToAsync(stream);
                }

                TempData["Mensaje"] = "✅ Archivo subido correctamente";
            }
            else
            {
                TempData["Mensaje"] = "❌ Debes seleccionar un archivo";
            }

            return RedirectToAction("Index");
        }
    }
}