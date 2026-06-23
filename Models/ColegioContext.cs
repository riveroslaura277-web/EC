using Microsoft.EntityFrameworkCore;

namespace EC.Models
{
    public class ColegioContext : DbContext
    {
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }

        public DbSet<NOTARectorViewModel> Notas { get; set; }
    }
}
