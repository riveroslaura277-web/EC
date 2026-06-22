using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace EC.Controllers
{
    public class RegistroController : Controller
    {
        private readonly string _conexion =
            "Server=LAPTOP-2IVQ34EB\\SQLEXPRESS;Database=Educlick;Trusted_Connection=True;TrustServerCertificate=True;";

        // VISTA PRINCIPAL
        public IActionResult Index()
        {
            return View();
        }

        // REGISTRAR USUARIO
        [HttpPost]
        public IActionResult Registrar(
            string Nombres,
            string Apellidos,
            string Correo,
            string Contrasena,
            string ConfirmarContrasena)
        {
            // VALIDAR CONTRASEÑAS
            if (Contrasena != ConfirmarContrasena)
            {
                TempData["Mensaje"] = "❌ Las contraseñas no coinciden.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
            }

            try
            {
                using (SqlConnection con = new SqlConnection(_conexion))
                {
                    con.Open();

                    string query = @"INSERT INTO Usuarios
                                    (Nombres, Apellidos, Correo, Contrasena, FechaRegistro)
                                    VALUES
                                    (@Nombres, @Apellidos, @Correo, @Contrasena, GETDATE())";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombres", Nombres);
                        cmd.Parameters.AddWithValue("@Apellidos", Apellidos);
                        cmd.Parameters.AddWithValue("@Correo", Correo);
                        cmd.Parameters.AddWithValue("@Contrasena", Contrasena);

                        cmd.ExecuteNonQuery();
                    }
                }

                // MENSAJE ÉXITO
                TempData["Mensaje"] = "✅ Registro exitoso.";
                TempData["Tipo"] = "success";

                return RedirectToAction("Index");
            }
            catch (SqlException ex)
            {
                // CORREO DUPLICADO
                if (ex.Number == 2627)
                {
                    TempData["Mensaje"] = "⚠️ Este correo ya está registrado.";
                    TempData["Tipo"] = "error";

                    return RedirectToAction("Index");
                }

                TempData["Mensaje"] = "❌ Ocurrió un error al registrar.";
                TempData["Tipo"] = "error";

                return RedirectToAction("Index");
            }
        }
    }
}