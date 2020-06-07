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

        [HttpGet, Route("ultimasolicitud")]
        public async Task<IActionResult> Get()
        {
            int idSolicitud = await _solicitudFacade.ObtenerUltimoId();
            var ultimaSolicitud = await _solicitudFacade.ObtenerPorIdAsync(idSolicitud);
            if (ultimaSolicitud == null) return NoContent();
            return Ok(ultimaSolicitud);
        }
        [HttpGet, Route("insertarventaactualizastockvehiculo")]
        public async Task<IActionResult> GetVenta()
        {
            int idSolicitud = await _solicitudFacade.ObtenerUltimoId();
            var registraVenta = await _solicitudFacade.ActualizarPorIdAsync(idSolicitud);
            if (registraVenta == null) return NoContent();
            return Ok(1);
        }

        
    }
}