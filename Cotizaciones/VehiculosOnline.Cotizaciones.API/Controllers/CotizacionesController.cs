using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Cotizaciones.Facade;
using Cotizacion = VehiculosOnline.Model.Clases.Cotizacion;

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
        public async Task<IActionResult> Post(Cotizacion cotizacion)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var detallePago = await _cotizacionFacade.InsertarAsync(cotizacion);
          
            return Ok(detallePago);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cotizaciones = await _cotizacionFacade.ObtenerTodosAsync();
            if (!cotizaciones.Any()) return NoContent();
            return Ok(cotizaciones);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cotizacion = await _cotizacionFacade.ObtenerPorIdAsync(id);
            if (cotizacion == null) return NoContent();
            return Ok(cotizacion);
        }
    }
}