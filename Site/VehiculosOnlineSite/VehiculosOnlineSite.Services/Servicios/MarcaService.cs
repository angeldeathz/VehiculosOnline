using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
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
            return _restClientHttp.GetObject<List<Marca>>(url);
        }

        public List<Modelo> ObtenerModelos(int idMarca)
        {
            var url = $"http://localhost/VehiculosOnline/marcas/api/marcas/{idMarca}/modelos";
            return _restClientHttp.GetObject<List<Modelo>>(url);
        }
    }
}
