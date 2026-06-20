using System.ComponentModel.DataAnnotations;

namespace EC.Models
{
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }   // ✅ Primary Key

        public int EstudianteId { get; set; }     // Clave foránea si quieres relacionar con Estudiante
        public string NombreEstudiante { get; set; } = string.Empty; // ✅ Aquí está la propiedad
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Presente"; // Presente, Ausente, Tarde

        // Relación con Estudiantes
        public Estudiantes Estudiante { get; set; }
    }
}
