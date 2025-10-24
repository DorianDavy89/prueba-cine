using Infraestructura.Entidades;

namespace Infraestructura.Repository
{
    public interface IRepositorioSalaCine
    {
        Task<SalaCine> buscarSalaPorNombreAsync(string nombreSala);
        Task<int> obtenerCantidadPeliculasPorSalaAsync(int idSalaCine);
    }
}
