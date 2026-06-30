using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EC.Models
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        public string NombreRol { get; set; } = string.Empty;

        // Relación inversa (opcional)
        public ICollection<Usuarios>? Usuarios { get; set; }
    }
}
