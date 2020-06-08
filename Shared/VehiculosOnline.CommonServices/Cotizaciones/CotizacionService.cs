using System;
using System.Net;
using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Cotizaciones
{
    public class CotizacionService
    {
        private readonly RestClientHttp _restClientHttp;

        public CotizacionService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<Cotizacion> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/cotizaciones/api/cotizaciones/{id}";
            var respuesta = await _restClientHttp.GetAsync<Cotizacion>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
    }
}
