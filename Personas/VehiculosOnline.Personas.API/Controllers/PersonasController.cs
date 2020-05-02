using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    }
}