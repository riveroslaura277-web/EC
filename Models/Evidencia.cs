using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EC.Models
{
    public class Evidencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{ get; set; }   // PK única

        // Campos obligatorios
        public required string NombreEstudiante { get; set; }
        public required string NombreArchivo { get; set; }
        public DateTime FechaEntrega { get; set; }
        public required string Estado { get; set; }
        public required string Texto { get; set; }

        // Campos opcionales
        public decimal? Nota { get; set; }
        public string? Observacion { get; set; }
        public string? MensajeConfirmacion { get; set; }

        // 🔑 Relación con Estudiantes
        public int IdEstudiante { get; set; }
        [ForeignKey("IdEstudiante")]
        public required Estudiantes Estudiante { get; set; }
    }
}
