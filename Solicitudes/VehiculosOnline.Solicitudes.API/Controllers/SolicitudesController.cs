using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Solicitudes.DTO;
using VehiculosOnline.Solicitudes.Facade;

namespace VehiculosOnline.Solicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly SolicitudFacade _solicitudFacade;

        public SolicitudesController()
        {
            _solicitudFacade = new SolicitudFacade();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var solicitud = await _solicitudFacade.ObtenerPorIdAsync(id);
            if (solicitud == null) return NoContent();

            return Ok(solicitud);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(SolicitudDto solicitud)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _solicitudFacade.InsertarAsync(solicitud);
            if (id == 0) return NoContent();

            return Ok(id);
        }
    }
}