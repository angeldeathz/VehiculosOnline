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

        public async Task<RestClientResponse<int>> InsertarAsync(Vehiculo vehiculo)
        {
            const string url = "http://localhost/VehiculosOnline/vehiculos/api/vehiculos/";
            return await _restClientHttp.PostAsync<int>(url, vehiculo);
        }

        public async Task<Vehiculo> ObtenerPorIdAsync(int id)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/{id}";
            return await _restClientHttp.GetObjectAsync<Vehiculo>(url);
        }
    }
}
