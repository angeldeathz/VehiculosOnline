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
    }
}