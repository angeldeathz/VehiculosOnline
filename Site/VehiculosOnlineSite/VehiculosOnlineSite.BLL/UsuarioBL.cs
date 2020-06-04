using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class UsuarioBL
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioBL()
        {
            _usuarioService = new UsuarioService();
        }

        public bool Autenticar(string rut, string clave)
        {
            return _usuarioService.Autenticar(new UsuarioAutenticador
            {
                Clave = clave,
                Rut = rut
            });
        }
    }
}
