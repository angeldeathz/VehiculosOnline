using System;
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

        public List<Vehiculo> ObtenerPorIdMarcaModelo(int idMarca, int idModelo, int anio)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos?idModelo={idModelo}&idMarca={idMarca}&anio={anio}";
            var respuesta = _restClientHttp.Get<List<Vehiculo>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<Vehiculo>();
            return respuesta.Response;
        }

        public Vehiculo ObtenerPorId(int id)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/{id}";
            var respuesta = _restClientHttp.Get<Vehiculo>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return null;
            return respuesta.Response;
        }

        public List<TipoVehiculo> ObtenerTipoVehiculos()
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/tipos";
            var respuesta = _restClientHttp.Get<List<TipoVehiculo>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<TipoVehiculo>();
            return respuesta.Response;
        }

        public List<TipoCombustible> ObtenerTipoCombustibles()
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos/tiposCombustibles";
            var respuesta = _restClientHttp.Get<List<TipoCombustible>>(url);
            if (respuesta.StatusName != HttpStatusCode.OK) return new List<TipoCombustible>();
            return respuesta.Response;
        }

        public int InsertarAsync(Vehiculo vehiculo)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos";
            var respuesta = _restClientHttp.Post<int>(url, vehiculo);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
        public int ModificarAsync(Vehiculo vehiculo)
        {
            var url = $"http://localhost/VehiculosOnline/vehiculos/api/vehiculos";
            var respuesta = _restClientHttp.Put<int>(url, vehiculo);
            if (respuesta.StatusName != HttpStatusCode.OK) throw new Exception(respuesta.Message);
            return respuesta.Response;
        }
    }
}
