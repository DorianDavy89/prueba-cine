using Infraestructura.Dtos.PeliculaDto;
using Infraestructura.Entidades;
using Infraestructura.Repository;

namespace Infraestructura.Services
{
    public class ServicioPelicula : IPeliculaService
    {
        private readonly IRepositorioPelicula _repositorio;

        public ServicioPelicula(IRepositorioPelicula repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<PeliculasObtenerDto> registrarPeliculaAsync(PeliculaRegistrarDto dto)
        {
            // Validar que no exista
            var existentes = await _repositorio.buscarPeliculaPorNombreAsync(dto.Nombre);
            if (existentes.Any())
                throw new InvalidOperationException("Ya existe una pelicula con ese nombre");

            // Crear entidad
            var entidad = new Pelicula
            {
                Nombre = dto.Nombre,
                Duracion = dto.Duracion
            };

            // Guardar en repositorio
            await _repositorio.registrarPeliculaAsync(entidad);

            // Retornar DTO
            return new PeliculasObtenerDto
            {
                IdPelicula = entidad.IdPelicula,
                Nombre = entidad.Nombre,
                Duracion = entidad.Duracion
            };
        }

        public async Task<List<PeliculasObtenerDto>> getPeliculasAsync()
        {
            // Obtener entidades del repositorio
            var peliculas = await _repositorio.getPeliculasAsync();

            // Mapear a DTOs
            return peliculas.Select(p => new PeliculasObtenerDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            }).ToList();
        }

        public async Task<bool> actualizarPeliculaAsync(int id, PeliculaActualizarDto dto)
        {
            // Obtener todas las películas
            var existentes = await _repositorio.getPeliculasAsync();
            var pelicula = existentes.FirstOrDefault(p => p.IdPelicula == id);

            if (pelicula == null)
                return false;

            // Actualizar datos
            pelicula.Nombre = dto.Nombre;
            pelicula.Duracion = dto.Duracion;

            return await _repositorio.actualizarPeliculaAsync(id, pelicula);
        }

        public async Task<bool> eliminarPeliculaAsync(int id)
        {
            return await _repositorio.eliminarPeliculaAsync(id);
        }

        public async Task<List<PeliculasObtenerDto>> buscarPeliculaPorNombreAsync(string nombre)
        {
            // Validación
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre de búsqueda es obligatorio");

            // Buscar en repositorio
            var peliculas = await _repositorio.buscarPeliculaPorNombreAsync(nombre);

            // Mapear a DTOs
            return peliculas.Select(p => new PeliculasObtenerDto
            {
                IdPelicula = p.IdPelicula,
                Nombre = p.Nombre,
                Duracion = p.Duracion
            }).ToList();
        }
    }
}
