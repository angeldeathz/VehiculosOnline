using System;
using System.Collections.Generic;
using System.Net;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Shared;

namespace VehiculosOnlineSite.Services.Servicios
{
    public class VentaService
    {
        private readonly RestClientHttp _restClientHttp;

        public VentaService()
        {
            _restClientHttp = new RestClientHttp();
        }

        public List<TipoPago> ObtenerTipoPago()
        {
            var url = "http://localhost/VehiculosOnline/ventas/api/ventas/formasDePago";
            var respuesta = _restClientHttp.Get<List<TipoPago>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<TipoPago>();
            return respuesta.Response;
        }

        public int RealizarVenta(Venta venta)
        {
            var url = "http://localhost/VehiculosOnline/ventas/api/ventas";
            var respuesta = _restClientHttp.Post<int>(url, venta);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }

        public List<VentaDataGrid> ObtenerVentasListado(string nombre, string correo, int tipoPago, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var url = $"http://localhost/VehiculosOnline/ventas/api/ventas?nombre={nombre}&correo={correo}&tipoPago={tipoPago}&idMarca={idMarca}&idModelo={idModelo}&anio={anio}&fechaDesde={fechaDesde}&fechaHasta={fechaHasta}";
            var respuesta = _restClientHttp.Get<List<VentaDataGrid>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<VentaDataGrid>();
            return respuesta.Response;
        }
    }
}
