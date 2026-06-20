using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EC.Models
{
    public class Evidencia
    {
        public int Id { get; set; }
        public string NombreEstudiante { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public DateTime FechaEntrega { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal? Nota { get; set; }
        public string? Observacion { get; set; }
        public string? MensajeConfirmacion { get; set; }

        // 🔑 Relación con Estudiantes
        [ForeignKey("Estudiante")]
        public int IdEstudiante { get; set; }
        public Estudiantes Estudiante { get; set; }
    }
}
