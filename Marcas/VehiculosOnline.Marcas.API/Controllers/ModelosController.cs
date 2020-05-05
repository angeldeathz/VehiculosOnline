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
    public class ModelosController : ControllerBase
    {
        private readonly ModeloBl _modeloBl;

        public ModelosController()
        {
            _modeloBl = new ModeloBl();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modelos = await _modeloBl.ObtenerTodosAsync();
            if (!modelos.Any()) return NoContent();

            return Ok(modelos);
        }
    }
}
