using ApiCine.Dtos.PeliculaDto;
using Infraestructura.Entidades;
using Infraestructura.Repository;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{

    [ApiController]
    [Route("api/pelicula")]
    public class PeliculaController : ControllerBase
    {
        private readonly InterfacePelicula _repositorio;

        public PeliculaController(InterfacePelicula repositorio)
        {
            _repositorio = repositorio;
        }


        // Listar peliculas
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            try
            {
                var peliculas = await _repositorio.getPeliculasAsync();

                if (peliculas == null || !peliculas.Any())
                    return Ok("vacío");

                return Ok(peliculas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener peliculas: {ex.Message}");
            }
        }

        // Registrar pelicula
        [HttpPost("registrar")]
        public async Task<ActionResult<Pelicula>> RegistrarPelicula([FromBody] PeliculaRegistrarDto dto)
        {
            try
            {
                var nuevaPelicula = new Pelicula
                {
                    Nombre = dto.Nombre,
                    Duracion = dto.Duracion,
                };

                await _repositorio.registrarPeliculaAsync(nuevaPelicula);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al registrar película: {ex.Message}");
            }
        }

        //Actualizar pelicula
        [HttpPut("actualizar/{id}")]
        public async Task<IActionResult> ActualizarPelicula(int id, [FromBody] PeliculaActualizarDto dto)
        {
            try
            {
                var peli = new Pelicula
                {
                    Nombre = dto.Nombre,
                    Duracion = dto.Duracion,
                };

                var actualizado = await _repositorio.actualizarPeliculaAsync(id, peli);
                if (!actualizado)
                    return NotFound("Pelicula no encontrada");

                return Ok(peli);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar pelicula: {ex.Message}");
            }
        }

        //Eliminar pelicula
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            try
            {
                var eliminado = await _repositorio.eliminarPeliculaAsync(id);
                if (!eliminado)
                    return NotFound("Película no encontrada");

                return Ok(new { eliminado = true, id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al eliminar pelicula: {ex.Message}");
            }
        }

        // busqueda por nombre

        [HttpGet("buscar/{nombre}")]
        public async Task<IActionResult> BuscarPorNombre(string nombre)
        {
            try
            {
                var peliculas = await _repositorio.buscarPeliculaPorNombreAsync(nombre);

                if (peliculas == null || !peliculas.Any())
                    return NotFound($"No se encontraron peliculas con el nombre '{nombre}'");

                var resultado = peliculas.Select(p => new PeliculasObtenerDto
                {
                    IdPelicula = p.IdPelicula,
                    Nombre = p.Nombre,
                    Duracion = p.Duracion
                });

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al buscar peliculas: {ex.Message}");
            }
        }
    }
}
