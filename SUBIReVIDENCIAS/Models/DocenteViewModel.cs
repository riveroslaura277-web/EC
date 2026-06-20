using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SUBIReVIDENCIAS.Models
{
    public class DocenteViewModel

    {
        [Key]
        public string Nombre { get; set; } = string.Empty;

        // Listas que alimentan las secciones del panel
        public List<Calificacion>? Calificaciones { get; set; }
        public List<Asistencia>? Asistencia { get; set; }
        public List<Rendimiento>? Rendimiento { get; set; }
    }

    public class Calificacion
    {
        [Key]
        public int Id { get; set; }
        public string NombreEstudiante { get; set; } = string.Empty;
        public string NombreMateria { get; set; } = string.Empty;
        public double Nota { get; set; }
    }

    public class Rendimiento
    {
        [Key]
        public string NombreMateria { get; set; } = string.Empty;
        public double Promedio { get; set; }
    }
}
