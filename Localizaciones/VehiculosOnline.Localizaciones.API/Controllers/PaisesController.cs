using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Localizaciones.BLL;

namespace VehiculosOnline.Localizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisBl _paisBl;

        public PaisesController()
        {
            _paisBl = new PaisBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comunas = await _paisBl.ObtenerTodosAsync();
            if (!comunas.Any()) return NoContent();

            return Ok(comunas);
        }
    }
}
