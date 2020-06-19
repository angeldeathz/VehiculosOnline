using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.BLL;
using VehiculosOnline.Solicitudes.DTO;
using VehiculosOnline.Solicitudes.Facade;

namespace VehiculosOnline.Solicitudes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly SolicitudFacade _solicitudFacade;
        private readonly SolicitudBl _solicitudBl;

        public SolicitudesController()
        {
            _solicitudBl = new SolicitudBl();
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
        [HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery] string rut, [FromQuery] int idMarca, [FromQuery] int idModelo, [FromQuery] int anio, [FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            var solicitudes = await _solicitudBl.ObtenerSolicitudListado(rut, idMarca, idModelo, anio, fechaDesde, fechaHasta);
            

            return Ok(solicitudes);
        }
    }
}