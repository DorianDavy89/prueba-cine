using Infraestructura.Repository;
using Infraestructura.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCine.Controllers
{

    [ApiController]
    [Route("api/sala-cine")]
    public class SalaCineController : ControllerBase
    {
        private readonly InterfaceSalaCine _repositorio;

        public SalaCineController(InterfaceSalaCine repositorio)
        {
            _repositorio = repositorio;
        }


        // disponibilidad
        [HttpGet("disponibilidad/{nombreSala}")]
        public async Task<IActionResult> ConsultarDisponibilidad(string nombreSala)
        {
            try
            {
                var resultado = await _repositorio.buscarDisponibilidadSalaPorNombreAsync(nombreSala);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al consultar disponibilidad: {ex.Message}");
            }
        }
    }
}
