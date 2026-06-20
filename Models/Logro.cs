using System;
using System.ComponentModel.DataAnnotations;

namespace EC.Models
{
    public class Logro
    {
        [Key]
        public int IdLogro { get; set; }
        public string NombreLogro { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public DateTime FechaObtencion { get; set; }

        // ✅ Relación con Estudiantes
        public int IdEstudiante { get; set; }
        public Estudiantes Estudiante { get; set; }
    }
}
