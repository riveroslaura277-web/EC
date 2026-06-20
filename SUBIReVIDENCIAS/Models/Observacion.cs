using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Necesario para ForeignKey

namespace SUBIReVIDENCIAS.Models
{
    public class Observacion
    {
        [Key] // Asegura que sea la clave primaria
        public int Id { get; set; }

        [Required] // La observación debe pertenecer a alguien
        public int EstudianteId { get; set; }

        [Required] // Evita que se guarden notas vacías
        [StringLength(1000)] // Define un límite razonable para el texto
        public string Texto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        // Relación explícita
        [ForeignKey("EstudianteId")]
        public virtual Estudiantes Estudiante { get; set; }
    }
}