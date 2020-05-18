using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Usuarios.BLL;
using VehiculosOnline.Usuarios.DTO;
using VehiculosOnline.Usuarios.Facade;

namespace VehiculosOnline.Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioBl _usuarioBl;
        private readonly UsuarioFacade _usuarioFacade;

        public UsuariosController()
        {
            _usuarioBl = new UsuarioBl();
            _usuarioFacade = new UsuarioFacade();
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var usuario = await _usuarioFacade.ObtenerPorIdAsync(id);
            if (usuario == null) return NoContent();

            return Ok(usuario);
        }

        [HttpPost, Route("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioAutenticador autenticador)
        {
            var esValido = await _usuarioBl.AutenticarAsync(autenticador);
            if (!esValido) return NoContent();

            return Ok(true);
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var id = await _usuarioBl.InsertarAsync(usuario);
            if (id == 0) return NoContent();

            return Ok(id);
        }
    }
}