using EC.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EC.Models
{
    public class Estudiantes
    {
        [Key]   // PK
        public int IdEstudiante { get; set; }

        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Curso { get; set; }

        public int ? Edad { get; set; }
        public string? IdUsuario { get; set; }
        // Relación con Evidencias y Logros
        public ICollection<Evidencia> Evidencias { get; set; }
    }
}
