using Infraestructura.Entidades;
using Infraestructura.Persistencias;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repository
{
    public class RepositorioPeliculaSala : IRepositorioPeliculaSalaCine
    {
        private readonly CineDbContext _context;

        public RepositorioPeliculaSala(CineDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pelicula>> buscarPeliculasPorFechaPublicacionAsync(DateTime fechaPublicacion)
        {
            var peliculas = await (from ps in _context.PeliculaSalacines
                                   join p in _context.Peliculas on ps.IdPelicula equals p.IdPelicula
                                   where ps.FechaPublicacion.Date == fechaPublicacion.Date
                                   select p)
                           .Distinct()
                           .ToListAsync();

            return peliculas;
        }
    }
}
