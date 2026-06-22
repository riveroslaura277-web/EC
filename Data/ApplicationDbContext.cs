using Microsoft.EntityFrameworkCore;
using EC.Models;


namespace EC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evidencia> Evidencias { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }
        public DbSet<Logro> Logros { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Docente> Docentes { get; set; }
        public DbSet<Acudiente> Acudientes2 { get; set; }
        public DbSet<Rector> Rectores { get; set; }
        public DbSet<Estudiantes> Estudiante { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evidencia>()
                .Property(e => e.Nota)
                .HasPrecision(3, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
