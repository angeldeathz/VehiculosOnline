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

        public CiudadesController()
        {
            _ciudadBl = new CiudadBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ciudades = await _ciudadBl.ObtenerTodosAsync();
            if (!ciudades.Any()) return NoContent();

            return Ok(ciudades);
        }
    }
}