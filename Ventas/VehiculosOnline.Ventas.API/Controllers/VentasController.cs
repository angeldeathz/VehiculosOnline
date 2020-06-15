using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.BLL;

namespace VehiculosOnline.Ventas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly VentaBl _ventaBl;

        public VentasController()
        {
            _ventaBl = new VentaBl();
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post([FromBody] Venta venta)
        {
            if (venta == null) return BadRequest("El objeto no puede estar nulo");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var idVenta = await _ventaBl.InsertarVentaAsync(venta);

            if (idVenta == 0) return BadRequest("La venta no se pudo realizar");
            return Ok(idVenta);
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Get([FromQuery] string nombre, [FromQuery] string correo, [FromQuery] int tipoPago, [FromQuery] int idMarca, [FromQuery] int idModelo, [FromQuery] int anio, [FromQuery] DateTime fechaDesde, [FromQuery] DateTime fechaHasta)
        {
            var ventas = await _ventaBl.ObtenerVentasListado(nombre, correo, tipoPago, idMarca, idModelo, anio, fechaDesde, fechaHasta);
            if (!ventas.Any()) return NoContent();

            return Ok(ventas);
        }

    }
}