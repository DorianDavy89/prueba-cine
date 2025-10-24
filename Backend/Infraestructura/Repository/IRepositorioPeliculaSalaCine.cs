using Infraestructura.Dtos.PeliculaDto;

using Infraestructura.Entidades;

namespace Infraestructura.Repository
{
    public interface IRepositorioPeliculaSalaCine
    {
        Task<List<Pelicula>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion);
    }
}
