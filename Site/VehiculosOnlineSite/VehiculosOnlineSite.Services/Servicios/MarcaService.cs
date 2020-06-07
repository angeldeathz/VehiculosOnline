using System.Collections.Generic;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    /// <summary>
    /// Servicio de API Marcas
    /// </summary>
    public class MarcaService
    {
        private readonly RestClientHttp _restClientHttp;

        public MarcaService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public List<Marca> ObtenerMarcas()
        {
            var url = $"http://localhost/VehiculosOnline/marcas/api/marcas";
            var respuesta = _restClientHttp.Get<List<Marca>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Marca>();
            return respuesta.Response;
        }

        public List<Modelo> ObtenerModelos(int idMarca)
        {
            var url = $"http://localhost/VehiculosOnline/marcas/api/marcas/{idMarca}/modelos";
            var respuesta = _restClientHttp.Get<List<Modelo>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Modelo>();
            return respuesta.Response;
        }
    }
}
