using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Ventas.BLL;

namespace VehiculosOnline.Ventas.API.Controllers
{
    [Route("api/ventas/bancos")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly BancoBl _bancoBl;

        public BancosController()
        {
            _bancoBl = new BancoBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bancos = await _bancoBl.ObtenerTodosAsync();
            if (!bancos.Any()) return NoContent();

            return Ok(bancos);
        }
    }
}
