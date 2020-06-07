using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Cotizaciones.DTO;
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
        public async Task<IActionResult> Post(CotizacionDTO cotizacion)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _cotizacionFacade.InsertarAsync(cotizacion);
            if (id == 0) return NoContent();

            return Ok(id);
        }

        [HttpPost, Route("pago")]
        public async Task<IActionResult> PostModelos(Cotizacion cotizacion)
        {
            //var modelos = await _cotizacionFacade.ObtenerPorIdMarcaAsync(idMarca);
            //if (!modelos.Any()) return NoContent();
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var detallePago = await _cotizacionFacade.InsertaYCalculaPagoAsync(cotizacion);
          
            return Ok(detallePago);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var cotizaciones = await _cotizacionFacade.ObtenerTodosAsync();
            //if (!cotizaciones.Any()) return NoContent();

            return Ok(cotizaciones);
        }
    }
}