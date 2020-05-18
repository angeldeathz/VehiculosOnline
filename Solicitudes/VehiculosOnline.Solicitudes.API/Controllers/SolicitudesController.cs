using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
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

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(Solicitud solicitud)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _solicitudFacade.InsertarAsync(solicitud);
            if (id == 0) return NoContent();

            return Ok(id);
        }
    }
}