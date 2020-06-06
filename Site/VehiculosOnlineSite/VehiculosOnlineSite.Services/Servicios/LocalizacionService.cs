using System.Collections.Generic;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    public class LocalizacionService
    {
        private readonly RestClientHttp _restClientHttp;

        public LocalizacionService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public List<Pais> ObtenerPaises()
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/paises";
            var respuesta = _restClientHttp.Get<List<Pais>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Pais>();
            return respuesta.Response;
        }
    }
}
