using Infraestructura.Entidades;
using Infraestructura.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repository
{
    public class RepositorioSalaCine : IRepositorioSalaCine
    {
        private readonly CineDbContext _context;

        public RepositorioSalaCine(CineDbContext context)
        {
            _context = context;
        }

        public async Task<SalaCine> buscarSalaPorNombreAsync(string nombreSala)
        {
            var sala = await _context.SalaCines
                .FirstOrDefaultAsync(s => s.Nombre.ToLower().Contains(nombreSala.ToLower()));

            return sala;
        }

        public async Task<int> obtenerCantidadPeliculasPorSalaAsync(int idSalaCine)
        {
            var cantidad = await (
                from ps in _context.PeliculaSalacines
                where ps.IdSalaCine == idSalaCine
                select ps
            ).CountAsync();

            return cantidad;
        }
    }
}
