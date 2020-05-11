using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Personas.BLL;

namespace VehiculosOnline.Personas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaBl _personaBl;

        public PersonasController()
        {
            _personaBl = new PersonaBl();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var personas = await _personaBl.ObtenerTodosAsync();
            if (!personas.Any()) return NoContent();

            return Ok(personas);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var persona = await _personaBl.ObtenerPorIdAsync(id);
            if (persona == null) return NoContent();

            return Ok(persona);
        }

        [HttpGet, Route("filter")] //api/personas?rut=11.111.111-1
        public async Task<IActionResult> Get([FromQuery] string rut)
        {
            var persona = await _personaBl.ObtenerPorRutAsync(rut);
            if (persona == null) return NoContent();

            return Ok(persona);
        }
    }
}