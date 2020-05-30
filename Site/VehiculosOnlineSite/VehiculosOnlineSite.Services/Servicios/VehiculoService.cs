using System.Collections.Generic;
using System.Net;
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

        public List<Vehiculo> ObtenerPorIdMarcaModelo(int idMarca, int idModelo)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos?idModelo={idModelo}&idMarca={idMarca}";
            var respuesta = _restClientHttp.Get<List<Vehiculo>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Vehiculo>();
            return respuesta.Response;
        }
    }
}
