using System.ComponentModel.DataAnnotations;

public class Rol
{
    [Key]
    public int IdRol { get; set; }

    public string? NombreRol { get; set; } // "Acudiente", "Estudiante"
}