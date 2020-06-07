using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Solicitudes
{
    public class SolicitudService
    {
        private readonly RestClientHttp _restClientHttp;

        public SolicitudService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<Solicitud> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/solicitudes/api/solicitudes/{id}";
            return await _restClientHttp.GetObjectAsync<Solicitud>(url);
        }
    }
}
