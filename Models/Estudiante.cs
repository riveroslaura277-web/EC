namespace EC.Models
{
    public class Estudiante
    {

        public int Id { get; set; }
        public int IdUsuario { get; set; }

        public string Codigo { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int Grado { get; set; }   // 1 al 5
        public string Estado { get; set; } = string.Empty;
    }
}



