using System;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    public class SolicitudService
    {
        private readonly RestClientHttp _restClientHttp;

        public SolicitudService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public int IngresarSolicitud(SolicitudDto solicitud)
        {
            var url = "http://localhost/VehiculosOnline/solicitudes/api/solicitudes";
            var respuesta = _restClientHttp.Post<int>(url, solicitud);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public Solicitud ObtenerUltimaSolicitud()
        {
            var url = "http://localhost/VehiculosOnline/solicitudes/api/solicitudes/ultimasolicitud";
            var respuesta = _restClientHttp.Get<Solicitud>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public int InsertarVentaActualizaStockVehiculo()
        {
            var url = "http://localhost/VehiculosOnline/solicitudes/api/solicitudes/insertarventaactualizastockvehiculo";
            var respuesta = _restClientHttp.Get<int>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
    }
}
