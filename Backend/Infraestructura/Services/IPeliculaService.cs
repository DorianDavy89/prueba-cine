using Infraestructura.Dtos.PeliculaDto;
using Infraestructura.Entidades;

namespace Infraestructura.Services
{
    public interface IPeliculaService
    {
        Task<PeliculasObtenerDto> registrarPeliculaAsync(PeliculaRegistrarDto dto);
        Task<List<PeliculasObtenerDto>> getPeliculasAsync();
        Task<bool> actualizarPeliculaAsync(int id, PeliculaActualizarDto dto);
        Task<bool> eliminarPeliculaAsync(int id);
        Task<List<PeliculasObtenerDto>> buscarPeliculaPorNombreAsync(string nombre);
    }
}