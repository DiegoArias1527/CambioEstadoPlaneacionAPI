using InterfacesComunes.DTO;
using Microsoft.AspNetCore.Mvc;
using Negocio.Clases.BL;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaneacionController : ControllerBase
    {
        private readonly IPlaneacionService _service;

        public PlaneacionController(IPlaneacionService service)
        {
            _service = service;
        }

        [HttpPost("cambiar-estado")]
        public async Task<IActionResult> CambiarEstado([FromBody] CambioEstadoDTO request)
        {
            try
            {
                await _service.CambiarEstadoPlaneacion(request);
                return Ok("Estado de la planeación actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
