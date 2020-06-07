using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    /// <summary>
    /// Servicio de API Usuarios
    /// </summary>
    public class UsuarioService
    {
        private readonly RestClientHttp _restClientHttp;

        public UsuarioService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public bool Autenticar(UsuarioAutenticador autenticador)
        {
            var url = "http://localhost/VehiculosOnline/usuarios/api/usuarios/autenticar";
            var respuesta = _restClientHttp.Post<bool>(url, autenticador);
            if (respuesta.StatusName != HttpStatusCode.OK) return false;
            return true;
        }
    }
}
