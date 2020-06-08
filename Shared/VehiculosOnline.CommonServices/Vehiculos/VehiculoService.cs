using System;
using System.Net;
using System.Threading.Tasks;
using RestClient.Core;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.CommonServices.Vehiculos
{
    public class VehiculoService
    {
        private readonly RestClientHttp _restClientHttp;

        public VehiculoService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public async Task<Vehiculo> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/{id}";
            var respuesta =  await _restClientHttp.GetAsync<Vehiculo>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public async Task<bool> ActualizarStock(int id)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/{id}/stock";
            var respuesta = await _restClientHttp.PutAsync<bool>(url, null);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
    }
}
