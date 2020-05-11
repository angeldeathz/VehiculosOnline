using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Vehiculos.BLL;

namespace VehiculosOnline.Vehiculos.API.Controllers
{
    [Route("api/vehiculos/tipos")]
    [ApiController]
    public class TipoVehiculosController : ControllerBase
    {
        private readonly TipoVehiculoBl _tipoVehiculoBl;

        public TipoVehiculosController()
        {
            _tipoVehiculoBl = new TipoVehiculoBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tipoVehiculos = await _tipoVehiculoBl.ObtenerTodosAsync();
            if (!tipoVehiculos.Any()) return NoContent();

            return Ok(tipoVehiculos);
        }
    }
}