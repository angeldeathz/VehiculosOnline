using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Personas.BLL;
using VehiculosOnline.Personas.Facade;

namespace VehiculosOnline.Personas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly PersonaBl _personaBl;
        private readonly PersonaFacade _personaFacade;

        public PersonasController()
        {
            _personaBl = new PersonaBl();
            _personaFacade = new PersonaFacade();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _personaFacade.InsertarAsync(persona);
            if (id == 0) return BadRequest();

            return Ok(id);
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
            var persona = await _personaFacade.ObtenerPorIdAsync(id);
            if (persona == null) return NoContent();

            return Ok(persona);
        }

        [HttpGet, Route("filter")] //api/personas?rut=11.111.111-1, 111111111, 11111111-1 etc...
        public async Task<IActionResult> Get([FromQuery] string rut)
        {
            var persona = await _personaBl.ObtenerPorRutAsync(rut);
            if (persona == null) return NoContent();

            return Ok(persona);
        }
    }
}