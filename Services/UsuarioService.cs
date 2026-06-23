using EC.Data;
using EC.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace EC.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        private string HashearContrasena(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public Usuarios? ValidarUsuario(string email, string password)
        {
            var hash = HashearContrasena(password);

            return _context.Usuarios
                .FirstOrDefault(x => x.Correo == email && x.Contrasena == hash);
        }
    }
}