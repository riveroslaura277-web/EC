namespace EC.Models
{
    public class BoletinesViewModel
    {
        public string CodigoEstudiante { get; set; } = string.Empty;
        public string NombreEstudiante { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public int Grado { get; set; }
        public List<NOTARectorViewModel> Materias { get; set; } = new();

        public double PromedioGeneral => Materias.Any()
            ? Math.Round(Materias.Average(m => m.Promedio), 1)
            : 0;

        public string Estado => PromedioGeneral >= 6 ? "Aprobado" : PromedioGeneral >= 5 ? "Recuperación" : "Reprobado";

    }
}
