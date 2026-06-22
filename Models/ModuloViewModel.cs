namespace EC.Models
{
    public class ModuloViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<string> RolesConAcceso { get; set; } = new();
    }
}
