using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Vehiculos.BLL;

namespace VehiculosOnline.Vehiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        private readonly VehiculoBl _vehiculoBl;

        public VehiculosController()
        {
            _vehiculoBl = new VehiculoBl();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehiculo = await _vehiculoBl.ObtenerPorIdAsync(id);
            if (vehiculo == null) return NoContent();

            return Ok(vehiculo);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery] int idMarca, [FromQuery] int idModelo)
        {
            var vehiculos = await _vehiculoBl.ObtenerPorMarcaModeloAsync(idMarca, idModelo);
            if (!vehiculos.Any()) return NoContent();

            return Ok(vehiculos);
        }
    }
}