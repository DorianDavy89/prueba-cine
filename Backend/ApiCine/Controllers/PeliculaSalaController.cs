using Infraestructura.Dtos.PeliculaDto;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{
    [ApiController]
    [Route("api/pelicula-sala")]
    public class PeliculaSalaController : ControllerBase
    {
        private readonly IPeliculaSalaCineService _servicio;

        public PeliculaSalaController(IPeliculaSalaCineService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("fecha/{fecha}")]
        public async Task<ActionResult<IEnumerable<PeliculasObtenerDto>>> BuscarPorFecha(DateTime fecha)
        {
            try
            {
                var peliculas = await _servicio.buscarPeliculasPorFechaPublicacionAsync(fecha);

                if (peliculas == null || !peliculas.Any())
                    return NotFound(new
                    {
                        error = $"No se encontraron peliculas publicadas en la fecha {fecha:yyyy-MM-dd}"
                    });

                return Ok(peliculas);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // En producción no exponer detalles técnicos
                return StatusCode(500, new { error = "Error al buscar peliculas por fecha" });
            }
        }
    }
}
