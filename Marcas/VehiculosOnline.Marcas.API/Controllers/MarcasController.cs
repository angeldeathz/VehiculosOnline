using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Marcas.BLL;

namespace VehiculosOnline.Marcas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MarcaBl _marcaBl;
        private readonly ModeloBl _modeloBl;

        public MarcasController()
        {
            _marcaBl = new MarcaBl();
            _modeloBl = new ModeloBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marcas = await _marcaBl.ObtenerTodosAsync();
            if (!marcas.Any()) return NoContent();

            return Ok(marcas);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var marca = await _marcaBl.ObtenerPorIdAsync(id);
            if (marca == null) return NoContent();

            return Ok(marca);
        }

        [HttpGet, Route("{idMarca}/Modelos")]
        public async Task<IActionResult> GetModelos(int idMarca)
        {
            var modelos = await _modeloBl.ObtenerPorIdMarcaAsync(idMarca);
            if (!modelos.Any()) return NoContent();

            return Ok(modelos);
        }
    }
}
