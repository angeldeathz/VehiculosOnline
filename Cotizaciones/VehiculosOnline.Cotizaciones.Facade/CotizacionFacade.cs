using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Solicitudes;
using VehiculosOnline.Cotizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;
using Cotizacion = VehiculosOnline.Model.Clases.Cotizacion;

namespace VehiculosOnline.Cotizaciones.Facade
{
    public class CotizacionFacade
    {
        private readonly SolicitudService _solicitudService;
        private readonly CotizacionDal _cotizacionDal;

        public CotizacionFacade()
        {
            _solicitudService = new SolicitudService();
            _cotizacionDal = new CotizacionDal();
        }

        public async Task<List<Cotizacion>> ObtenerTodosAsync()
        {
            return await _cotizacionDal.ObtenerTodosAsync();
        }

        public async Task<Cotizacion> ObtenerPorIdAsync(int id)
        {
            var cotizacion = await _cotizacionDal.ObtenerPorIdAsync(id);
            if (cotizacion == null) return null;

            var solicitud = await _solicitudService.ObtenerPorIdAsync(cotizacion.IdSolicitud);
            if (solicitud == null) throw new Exception($"La solicitud {cotizacion.IdSolicitud} no existe");

            cotizacion.Solicitud = solicitud;
            return cotizacion;
        }

        public async Task<ResumenCotizacion> InsertarAsync(Cotizacion cotizacion)
        {
            if (cotizacion.IdSolicitud <= 0) throw new Exception("IdSolicitud es inválido");
            if (cotizacion.IdTipoPago <= 0) throw new Exception("IdTipoPago es inválido");
            if (cotizacion.CantidadMesesDiferido < 0) throw new Exception("CantidadMesesDiferido es inválido");
            if (cotizacion.CantidadCuotas < 0) throw new Exception("CantidadCuotas es inválido");

            var solicitud = await _solicitudService.ObtenerPorIdAsync(cotizacion.IdSolicitud);
            if (solicitud == null) throw new Exception($"La solicitud {cotizacion.IdSolicitud} no existe");

            cotizacion.ValorVehiculo = solicitud.Vehiculo.Precio;
            var idCotizacion = await _cotizacionDal.InsertarAsync(cotizacion);
            var resumenCotizacion = new ResumenCotizacion
            {
                IdSolicitud = cotizacion.IdSolicitud, 
                IdCotizacion = idCotizacion
            };

            var ivaDelVehiculo = solicitud.Vehiculo.Precio * 0.19;
            resumenCotizacion.PrecioSinIva = solicitud.Vehiculo.Precio;
            resumenCotizacion.Iva = int.Parse(Math.Round(ivaDelVehiculo).ToString());
            resumenCotizacion.PrecioFinal = solicitud.Vehiculo.Precio + resumenCotizacion.Iva;

            if (cotizacion.IdTipoPago == 2)
            {
                var valorCuota = Convert.ToDouble(resumenCotizacion.PrecioFinal) / Convert.ToDouble(cotizacion.CantidadCuotas);
                resumenCotizacion.Cuotas = cotizacion.CantidadCuotas;
                resumenCotizacion.ValorCuota = int.Parse(Math.Round(valorCuota).ToString());
                resumenCotizacion.CostoTotalCredito = resumenCotizacion.PrecioFinal;
            }

            return resumenCotizacion;
        }
    }
}
