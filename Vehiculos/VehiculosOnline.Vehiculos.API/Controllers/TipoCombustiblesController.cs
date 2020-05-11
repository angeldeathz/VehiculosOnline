using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Vehiculos.BLL;

namespace VehiculosOnline.Vehiculos.API.Controllers
{
    [Route("api/vehiculos/tiposCombustibles")]
    [ApiController]
    public class TipoCombustiblesController : ControllerBase
    {
        private readonly TipoCombustibleBl _tipoCombustibleBl;

        public TipoCombustiblesController()
        {
            _tipoCombustibleBl = new TipoCombustibleBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipoCombustibles = await _tipoCombustibleBl.ObtenerTodosAsync();
            if (!tipoCombustibles.Any()) return NoContent();

            return Ok(tipoCombustibles);
        }
    }
}