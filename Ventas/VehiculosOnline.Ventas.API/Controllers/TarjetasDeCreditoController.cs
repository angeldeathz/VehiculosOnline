using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Ventas.BLL;

namespace VehiculosOnline.Ventas.API.Controllers
{
    [Route("api/ventas/TarjetasDeCredito")]
    [ApiController]
    public class TarjetasDeCreditoController : ControllerBase
    {
        private readonly TipoTarjetaCreditoBl _tipoTarjetaCreditoBl;

        public TarjetasDeCreditoController()
        {
            _tipoTarjetaCreditoBl = new TipoTarjetaCreditoBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tarjetasDeCredito = await _tipoTarjetaCreditoBl.ObtenerTodosAsync();
            if (!tarjetasDeCredito.Any()) return NoContent();

            return Ok(tarjetasDeCredito);
        }
    }
}
