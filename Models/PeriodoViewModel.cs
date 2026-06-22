namespace EC.Models
{
    public class PeriodoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; } = string.Empty; // "Activo","Cerrado","Próximo"
        public string AnioEscolar { get; set; } = string.Empty;
    }
}
