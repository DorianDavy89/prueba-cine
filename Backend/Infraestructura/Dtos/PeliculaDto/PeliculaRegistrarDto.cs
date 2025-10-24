using System.ComponentModel.DataAnnotations;

namespace Infraestructura.Dtos.PeliculaDto
{
    public class PeliculaRegistrarDto
    {

        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La duracioon es obligatoria")]
        [Range(1, 500, ErrorMessage = "La duración debe estar entre 1 y 500 minutos")]
        public int Duracion { get; set; }
    }
}
