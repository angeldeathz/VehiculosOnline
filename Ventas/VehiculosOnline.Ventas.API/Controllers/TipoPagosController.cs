using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.BLL;

namespace VehiculosOnline.Ventas.API.Controllers
{
    [Route("api/ventas/formasDePago")]
    [ApiController]
    public class TipoPagosController : ControllerBase
    {
        private readonly TipoPagoBl _tipoPagosBl;

        public TipoPagosController()
        {
            _tipoPagosBl = new TipoPagoBl();
        }


        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            if (venta == null) return BadRequest("El objeto no puede estar nulo");
            var idVenta = await _tipoPagosBl.InsertarVentaAsync(venta);
            if (idVenta == 0) return BadRequest("El vehículo no pudo ser ingresado");
            return Ok(idVenta);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tiposDePago = await _tipoPagosBl.ObtenerTodosAsync();
            if (!tiposDePago.Any()) return NoContent();

            return Ok(tiposDePago);
        }
    }
}
