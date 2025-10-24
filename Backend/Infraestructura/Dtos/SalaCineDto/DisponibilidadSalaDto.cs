namespace ApiCine.Dtos.SalaCineDto
{
    public class DisponibilidadSalaDto
    {
        public int IdSalaCine { get; set; }
        public string NombreSala { get; set; }
        public string Estado { get; set; }
        public int CantidadPeliculas { get; set; }
        public string Mensaje { get; set; }
        public string Disponibilidad { get; set; }
    }
}
