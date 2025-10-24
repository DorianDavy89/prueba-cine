using Infraestructura.Repository;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{
    [ApiController]
    [Route("api/sala-cine")]
    public class SalaCineController : ControllerBase
    {
        private readonly ISalaCineService _servicio;

        public SalaCineController(ISalaCineService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("disponibilidad/{nombreSala}")]
        public async Task<ActionResult<string>> ConsultarDisponibilidad(string nombreSala)
        {
            try
            {
                var resultado = await _servicio.buscarDisponibilidadSalaPorNombreAsync(nombreSala);
                return Ok(new { disponibilidad = resultado });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // En producción no exponer detalles técnicos
                return StatusCode(500, new { error = "Error al consultar disponibilidad" });
            }
        }
    }
}
