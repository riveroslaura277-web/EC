namespace EC.Models
{
    public class RolViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool VerDashboard { get; set; }
        public bool GestionUsuarios { get; set; }
        public bool GestionAcademico { get; set; }
        public bool VerReportes { get; set; }
        public bool EditarNotas { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
