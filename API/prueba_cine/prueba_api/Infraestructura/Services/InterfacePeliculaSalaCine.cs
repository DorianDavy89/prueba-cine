using ApiCine.Dtos.PeliculaDto;

namespace Infraestructura.Services
{
    public interface InterfacePeliculaSalaCine
    {
        Task<List<PeliculasObtenerDto>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion);
    }
}
