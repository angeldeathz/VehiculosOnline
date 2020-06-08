using System;
using System.Net;
using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Direcciones
{
    public class DireccionService
    {
        private readonly RestClientHttp _restClientHttp;

        public DireccionService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<Direccion> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/direcciones/{id}";
            var respuesta = await _restClientHttp.GetAsync<Direccion>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public async Task<RestClientResponse<int>> InsertarAsync(Direccion direccion)
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/direcciones/";
            return await _restClientHttp.PostAsync<int>(url, direccion);
        }

        public async Task<RestClientResponse<bool>> ActualizarAsync(int id, Direccion direccion)
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/direcciones/{id}";
            return await _restClientHttp.PutAsync<bool>(url, direccion);
        }
    }
}
