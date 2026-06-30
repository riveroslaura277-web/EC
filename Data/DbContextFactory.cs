using EC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EC.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // ✅ Aquí va la cadena de conexión completa
            optionsBuilder.UseSqlServer(
                "Server=LAPTOP-NPRGSLU9\\SQLEXPRESS;Database=web_EC;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
            );

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
