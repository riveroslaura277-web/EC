namespace EC.Models
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Grado { get; set; }
        public string Docente { get; set; } = string.Empty;
        public int NumEstudiantes { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public double Promedio { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
