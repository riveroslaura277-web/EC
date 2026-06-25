using System.ComponentModel.DataAnnotations;

namespace EC.Models
{
    public class Mensaje
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Asunto { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;

        public DateTime FechaEnvio { get; set; } = DateTime.Now;
        public bool Leido { get; set; } = false;
    }
}
