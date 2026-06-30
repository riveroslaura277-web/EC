using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC.Models
{
    public class Estudiantes
    {
        [Key]   // PK
        public int IdEstudiante { get; set; }

        public int IdUsuario { get; set; }

        public int Edad { get; set; }

        // Todos obligatorios
        public required string Nombre { get; set; }
        public required string Correo { get; set; }
        public required string Curso { get; set; }

        // Relación con Evidencias y Logros
        public ICollection<Evidencia> Evidencias { get; set; } = new List<Evidencia>();
    }
}
