using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Localizaciones.BLL;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DireccionesController : ControllerBase
    {
        private readonly DireccionBl _direccionBl;

        public DireccionesController()
        {
            _direccionBl = new DireccionBl();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var direccion = await _direccionBl.ObtenerPorIdAsync(id);
            if (direccion == null) return NoContent();

            return Ok(direccion);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] Direccion direccion)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _direccionBl.InsertarAsync(direccion);
            if (id == 0) return NoContent();

            return Ok(id);
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Put([FromBody] Direccion direccion, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var esActualizado = await _direccionBl.ActualizarAsync(id, direccion);
            if (esActualizado == 0) return NoContent();

            return Ok(true);
        }
    }
}