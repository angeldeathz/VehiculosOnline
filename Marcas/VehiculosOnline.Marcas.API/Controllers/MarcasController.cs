using System;
using System.Collections.Generic;
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

        public MarcasController()
        {
            _marcaBl = new MarcaBl();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var marcas = await _marcaBl.ObtenerTodosAsync();
            if (!marcas.Any()) return NoContent();

            return Ok(marcas);
        }
    }
}
