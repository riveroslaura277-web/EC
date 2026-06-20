using System;
using System.ComponentModel.DataAnnotations;

namespace SUBIReVIDENCIAS.Models
{
    public class Logro
    {
        [Key]
        public int IdLogro { get; set; }
        public string NombreLogro { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public DateTime FechaObtencion { get; set; }

        // ✅ Solo UNA FK
        public int IdEstudiante { get; set; }
        public Estudiantes Estudiante { get; set; }
    }
}
