using Microsoft.EntityFrameworkCore;
using SUBIReVIDENCIAS.Models;

namespace SUBIReVIDENCIAS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asistencia> Asistencias{ get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evidencia>()
                .Property(e => e.Nota)
                .HasPrecision(3, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
