namespace EC.Models
{
    public class Rector
    {
            public int Id { get; set; }               // PK
            public string? Telefono { get; set; }

            // Clave foránea hacia Usuarios
            public int UsuarioId { get; set; }

            // Propiedad de navegación (puede ser nula)
            public Usuarios? Usuario { get; set; }
        }
    }

