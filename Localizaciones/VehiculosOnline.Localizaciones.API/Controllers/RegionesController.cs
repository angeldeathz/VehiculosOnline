using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Localizaciones.BLL;

namespace VehiculosOnline.Localizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionesController : ControllerBase
    {
        private readonly RegionBl _regionBl;

        public RegionesController()
        {
            _regionBl = new RegionBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var regiones = await _regionBl.ObtenerTodosAsync();
            if (!regiones.Any()) return NoContent();

            return Ok(regiones);
        }

        
    }
}