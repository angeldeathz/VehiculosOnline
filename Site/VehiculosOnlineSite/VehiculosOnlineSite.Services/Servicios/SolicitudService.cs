using System;
using System.Collections.Generic;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    /// <summary>
    /// Servicio de API Solicitudes
    /// </summary>
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

        public List<SolicitudDataGrid> ObtenerSolicitudListado(string rut, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var url = $"http://localhost/VehiculosOnline/solicitudes/api/solicitudes?rut={rut}&idMarca={idMarca}&idModelo={idModelo}&anio={anio}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}";
            var respuesta = _restClientHttp.Get<List<SolicitudDataGrid>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<SolicitudDataGrid>();
            return respuesta.Response;
        }
    }
}
