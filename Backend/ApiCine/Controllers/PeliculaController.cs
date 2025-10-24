using Infraestructura.Dtos.PeliculaDto;
using Infraestructura.Entidades;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{
    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculaService _servicio;

        public PeliculaController(IPeliculaService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<PeliculasObtenerDto>>> GetPeliculas()
        {
            var peliculas = await _servicio.getPeliculasAsync();

            if (peliculas == null || !peliculas.Any())
                return Ok(new { mensaje = "No hay peliculas registradas" });

            return Ok(peliculas);
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarPelicula([FromBody] PeliculaRegistrarDto dto)
        {
            try
            {
                var peliculaCreada = await _servicio.registrarPeliculaAsync(dto);
                return Ok(peliculaCreada);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error al registrar pelicula" });
            }
        }

        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarPelicula(int id, [FromBody] PeliculaActualizarDto dto)
        {
            try
            {
                var actualizado = await _servicio.actualizarPeliculaAsync(id, dto);

                if (!actualizado)
                    return NotFound(new { error = "Pelicula no encontrada" });

                return Ok(new { mensaje = "Pelicula actualizada exitosamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error al actualizar pelicula" });
            }
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            try
            {
                var eliminado = await _servicio.eliminarPeliculaAsync(id);

                if (!eliminado)
                    return NotFound(new { error = "Pelicula no encontrada" });

                return Ok(new { mensaje = "Pelicula eliminada exitosamente", id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error al eliminar pelicula" });
            }
        }

        [HttpGet("buscar/{nombre}")]
        public async Task<ActionResult<IEnumerable<PeliculasObtenerDto>>> BuscarPorNombre(string nombre)
        {
            try
            {
                var peliculas = await _servicio.buscarPeliculaPorNombreAsync(nombre);

                if (peliculas == null || !peliculas.Any())
                    return NotFound(new { error = $"No se encontraron peliculas con el nombre '{nombre}'" });

                return Ok(peliculas);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error al buscar peliculas" });
            }
        }
    }
}
