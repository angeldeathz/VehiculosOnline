using System;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    /// <summary>
    /// Servicio de API Cotizaciones
    /// </summary>
    public class CotizacionService
    {
        private readonly RestClientHttp _restClientHttp;

        public CotizacionService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public Cotizacion IngresarCotizacion(Cotizacion cotizacion)
        {
            var url = "http://localhost/VehiculosOnline/cotizaciones/api/cotizaciones";
            var respuesta = _restClientHttp.Post<Cotizacion>(url, cotizacion);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
    }
}
