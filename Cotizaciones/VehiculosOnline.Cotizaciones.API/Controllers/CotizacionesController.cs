using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Cotizaciones.DTO;
using VehiculosOnline.Cotizaciones.Facade;

namespace VehiculosOnline.Cotizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CotizacionesController : ControllerBase
    {
        private readonly CotizacionFacade _cotizacionFacade;

        public CotizacionesController()
        {
            _cotizacionFacade = new CotizacionFacade();
        }
        
        [HttpPost, Route("")]
        public async Task<IActionResult> Post(CotizacionDTO cotizacion)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _cotizacionFacade.InsertarAsync(cotizacion);
            if (id == 0) return NoContent();

            return Ok(id);
        }
    }
}