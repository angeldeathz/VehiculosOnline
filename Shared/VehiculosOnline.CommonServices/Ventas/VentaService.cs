using System.Net;
using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Ventas
{
    public class VentaService
    {
        private readonly RestClientHttp _restClientHttp;

        public VentaService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<int> ObtenerIdCotizacion()
        {
            var url = $"http://localhost/VehiculosOnline/cotizaciones/api/cotizaciones/idcotizacion";
            var respuesta = await _restClientHttp.GetAsync<int>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return 0;
            return respuesta.Response;
        }
    }
}
