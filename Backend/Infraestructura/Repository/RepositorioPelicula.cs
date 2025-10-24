using Infraestructura.Entidades;
using Infraestructura.Persistencias;
using Infraestructura.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CineDbContext = Infraestructura.Persistencias.CineDbContext;

namespace Infraestructura.Repository
{
    public class RepositorioPelicula: IRepositorioPelicula
    {
        private readonly CineDbContext _context;

        public RepositorioPelicula(CineDbContext context)
        {
            _context = context;
        }

        public async Task<bool> actualizarPeliculaAsync(int id, Pelicula pelicula)
        {
            var existente = await _context.Peliculas.FindAsync(id);
            if (existente == null) return false;

            existente.Nombre = pelicula.Nombre;
            existente.Duracion = pelicula.Duracion;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> eliminarPeliculaAsync(int id)
        {
            var existente = await _context.Peliculas.FindAsync(id);
            if (existente == null) return false;

            _context.Peliculas.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Pelicula>> getPeliculasAsync()
        {
            return await _context.Peliculas.ToListAsync();
        }

        public async Task registrarPeliculaAsync(Pelicula pelicula)
        {
            _context.Peliculas.Add(pelicula);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pelicula>> buscarPeliculaPorNombreAsync(string nombre)
        {

            var parametroNombre = new SqlParameter("@nombre", nombre);

            var peliculas = await _context.Peliculas
                .FromSqlRaw("EXEC sp_BuscarPeliculaPorNombre @nombre", parametroNombre)
                .ToListAsync();

            return peliculas;
        }
    }
}
