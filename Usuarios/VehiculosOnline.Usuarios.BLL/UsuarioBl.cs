using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Usuarios.DAL.Tables;
using VehiculosOnline.Usuarios.DTO;

namespace VehiculosOnline.Usuarios.BLL
{
    public class UsuarioBl
    {
        private readonly UsuarioDal _usuarioDal;

        public UsuarioBl()
        {
            _usuarioDal = new UsuarioDal();
        }

        public async Task<int> InsertarAsync(Usuario usuario)
        {
            return await _usuarioDal.InsertarAsync(usuario);
        }

        public async Task<bool> AutenticarAsync(UsuarioAutenticador autenticador)
        {
            var persona = new Persona();
            if (!persona.ValidaRut(autenticador.Rut)) return false;

            return await _usuarioDal.AutenticarAsync(persona.Rut, autenticador.Clave);
        }
    }
}
