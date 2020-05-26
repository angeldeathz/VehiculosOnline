using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    public class VehiculoService
    {
        private readonly RestClientHttp _restClientHttp;

        public VehiculoService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public Vehiculo ObtenerPorId(int id)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/{id}";
            return _restClientHttp.GetObject<Vehiculo>(url);
        }
    }
}
