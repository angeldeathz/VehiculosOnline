using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Personas;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Usuarios.DAL.Tables;

namespace VehiculosOnline.Usuarios.Facade
{
    public class UsuarioFacade
    {
        private readonly UsuarioDal _usuarioDal;
        private readonly PersonaService _personaService;

        public UsuarioFacade()
        {
            _usuarioDal = new UsuarioDal();
            _personaService = new PersonaService();
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            var usuario = await _usuarioDal.ObtenerPorIdAsync(id);
            if (usuario == null) return null;
            usuario.Persona = await _personaService.ObtenerPorIdAsync(usuario.IdPersona);
            return usuario;
        }
    }
}
