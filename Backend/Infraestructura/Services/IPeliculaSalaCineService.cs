using Infraestructura.Dtos.PeliculaDto;

namespace Infraestructura.Services
{
    public interface IPeliculaSalaCineService
    {
        Task<List<PeliculasObtenerDto>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion);
    }
}
