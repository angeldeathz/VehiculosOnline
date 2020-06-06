using System.Collections.Generic;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    public class LocalizacionService
    {
        private readonly RestClientHttp _restClientHttp;

        public LocalizacionService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public List<Pais> ObtenerPaises()
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/paises";
            var respuesta = _restClientHttp.Get<List<Pais>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Pais>();
            return respuesta.Response;
        }

        public List<Region> ObtenerRegiones()
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/regiones";
            var respuesta = _restClientHttp.Get<List<Region>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Region>();
            return respuesta.Response;
        }

        public List<Ciudad> ObtenerCiudades(int idRegion)
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/ciudades/{idRegion}/ciudades";
            var respuesta = _restClientHttp.Get<List<Ciudad>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Ciudad>();
            return respuesta.Response;
        }

        public List<Comuna> ObtenerComunas(int idCiudad)
        {
            var url = $"http://localhost/VehiculosOnline/localizaciones/api/ciudades/{idCiudad}/comunas";
            var respuesta = _restClientHttp.Get<List<Comuna>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Comuna>();
            return respuesta.Response;
        }
    }
}
