using Infraestructura.Repository;

namespace Infraestructura.Services
{
    public class ServicioSalaCine : ISalaCineService
    {
        private readonly IRepositorioSalaCine _repositorio;

        public ServicioSalaCine(IRepositorioSalaCine repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<string> buscarDisponibilidadSalaPorNombreAsync(string nombreSala)
        {
            // Validacion
            if (string.IsNullOrWhiteSpace(nombreSala))
            {
                throw new ArgumentException("El nombre de la sala de cine es obligatorio");
            }

            var sala = await _repositorio.buscarSalaPorNombreAsync(nombreSala);

            // Validar que exista
            if (sala == null)
            {
                throw new KeyNotFoundException($"No se encontró la sala: '{nombreSala}'");
            }

            // Obtener cantidad de películas asignadas
            var cantidadPeliculas = await _repositorio.obtenerCantidadPeliculasPorSalaAsync(sala.IdSalaCine);

            string mensaje;
            if (cantidadPeliculas < 3)
            {
                mensaje = "Sala disponible";
            }
            else if (cantidadPeliculas >= 3 && cantidadPeliculas <= 5)
            {
                mensaje = $"Sala con {cantidadPeliculas} películas asignadas";
            }
            else
            {
                mensaje = "Sala no disponible";
            }

            return mensaje;
        }
    }
}
