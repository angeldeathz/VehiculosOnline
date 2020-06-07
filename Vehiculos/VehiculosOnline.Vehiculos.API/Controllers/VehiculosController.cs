using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
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
        public async Task<IActionResult> Get([FromQuery] int idMarca, [FromQuery] int idModelo, [FromQuery] int anio)
        {
            var vehiculos = await _vehiculoBl.ObtenerPorMarcaModeloAsync(idMarca, idModelo, anio);
            if (!vehiculos.Any()) return NoContent();

            return Ok(vehiculos);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null) return BadRequest("El objeto no puede estar nulo");
            var idVehiculo = await _vehiculoBl.InsertarAsync(vehiculo);
            if (idVehiculo == 0) return BadRequest("El vehículo no pudo ser ingresado");
            return Ok(idVehiculo);
        }
        [HttpPut, Route("")]
        public async Task<IActionResult> Put([FromBody] Vehiculo vehiculo)
        {
            if (vehiculo == null) return BadRequest("El objeto no puede estar nulo");
            var idVehiculo = await _vehiculoBl.ModificarAsync(vehiculo);
            if (idVehiculo == 0) return BadRequest("El vehículo no pudo ser ingresado");
            return Ok(idVehiculo);
        }

    }
}