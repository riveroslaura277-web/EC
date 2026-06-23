namespace EC.Models
{
    public class NOTARectorViewModel
    {
        public int Id { get; set; }
        public string CodigoEstudiante { get; set; } = string.Empty;
        public string NombreEstudiante { get; set; } = string.Empty;
        public string Curso { get; set; } = string.Empty;
        public int Grado { get; set; }
        public string Materia { get; set; } = string.Empty;
        public string Docente { get; set; } = string.Empty;
        public double Periodo1 { get; set; }
        public double Periodo2 { get; set; }
        public double Periodo3 { get; set; }
        public double Periodo4 { get; set; }
        public int Asistencias { get; set; }
        public int Faltas { get; set; }

        public double Promedio => Math.Round((Periodo1 + Periodo2 + Periodo3 + Periodo4) / 4, 1);
        public string Estado => Promedio >= 6 ? "Aprobado" : Promedio >= 5 ? "Recuperación" : "Reprobado";

    }
}
