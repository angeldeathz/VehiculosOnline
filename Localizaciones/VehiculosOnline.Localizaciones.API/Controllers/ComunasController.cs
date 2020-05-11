using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Localizaciones.BLL;

namespace VehiculosOnline.Localizaciones.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComunasController : ControllerBase
    {
        private readonly ComunaBl _comunaBl;

        public ComunasController()
        {
            _comunaBl = new ComunaBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comunas = await _comunaBl.ObtenerTodosAsync();
            if (!comunas.Any()) return NoContent();

            return Ok(comunas);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comuna = await _comunaBl.ObtenerPorIdAsync(id);
            if (comuna == null) return NoContent();

            return Ok(comuna);
        }
    }
}