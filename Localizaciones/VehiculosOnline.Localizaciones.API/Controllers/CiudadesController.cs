using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Localizaciones.BLL;

namespace VehiculosOnline.Localizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadesController : ControllerBase
    {
        private readonly CiudadBl _ciudadBl;
        private readonly ComunaBl _comunaBl;

        public CiudadesController()
        {
            _ciudadBl = new CiudadBl();
            _comunaBl = new ComunaBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ciudades = await _ciudadBl.ObtenerTodosAsync();
            if (!ciudades.Any()) return NoContent();

            return Ok(ciudades);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ciudad = await _ciudadBl.ObtenerPorIdAsync(id);
            if (ciudad == null) return NoContent();

            return Ok(ciudad);
        }

        [HttpGet, Route("{idRegion}/Ciudades")]
        public async Task<IActionResult> GetCiudades(int idRegion)
        {
            var ciudades = await _comunaBl.ObtenerPorIdRegionAsync(idRegion);
            if (!ciudades.Any()) return NoContent();

            return Ok(ciudades);
        }

        [HttpGet, Route("{id}/comunas")]
        public async Task<IActionResult> GetComunas(int id)
        {
            var comunas = await _comunaBl.ObtenerPorIdCiudadAsync(id);
            if (!comunas.Any()) return NoContent();

            return Ok(comunas);
        }
    }
}