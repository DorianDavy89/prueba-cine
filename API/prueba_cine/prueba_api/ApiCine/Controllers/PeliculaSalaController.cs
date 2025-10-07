using Infraestructura.Repository;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{

    [ApiController]
    [Route("api/pelicula-sala")]
    public class PeliculaSalaController: ControllerBase
    {
        private readonly InterfacePeliculaSalaCine _repositorio;

        public PeliculaSalaController(InterfacePeliculaSalaCine repositorio)
        {
            _repositorio = repositorio;
        }


        // buscar por fecha
        [HttpGet("fecha/{fecha}")]
        public async Task<IActionResult> BuscarPorFecha(DateTime fecha)
        {
            try
            {
                var peliculas = await _repositorio.buscarPeliculasPorFechaPublicacionAsync(fecha);

                if (peliculas == null || !peliculas.Any())
                    return NotFound($"No se encontraron peliculas publicadas en la fecha {fecha:yyyy-MM-dd}");

                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar peliculas por fecha: {ex.Message}");
            }
        }
    }
}
