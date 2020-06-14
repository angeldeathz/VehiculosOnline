using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Personas;
using VehiculosOnline.CommonServices.Solicitudes;
using VehiculosOnline.Cotizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.Facade
{
    public class CotizacionFacade
    {
        private readonly SolicitudService _solicitudService;
        private readonly CotizacionDal _cotizacionDal;
        private readonly PersonaService _personaService;

        public CotizacionFacade()
        {
            _solicitudService = new SolicitudService();
            _cotizacionDal = new CotizacionDal();
            _personaService = new PersonaService();
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

        public async Task<Cotizacion> InsertarAsync(Cotizacion cotizacion)
        {
            if (cotizacion.IdSolicitud <= 0) throw new Exception("IdSolicitud es inválido");
            if (cotizacion.IdTipoPago <= 0) throw new Exception("IdTipoPago es inválido");
            if (cotizacion.CantidadMesesDiferido < 0) throw new Exception("CantidadMesesDiferido es inválido");
            if (cotizacion.CantidadCuotas < 0) throw new Exception("CantidadCuotas es inválido");
            if (cotizacion.Solicitud == null) throw new Exception("Solicitud no puede ser nulo");
            if (cotizacion.Solicitud.Persona == null) throw new Exception("Solicitud.Persona no puede ser nulo");

            var solicitud = await _solicitudService.ObtenerPorIdAsync(cotizacion.IdSolicitud);
            if (solicitud == null) throw new Exception($"La solicitud {cotizacion.IdSolicitud} no existe");

            if (!cotizacion.ConFactura)
            {
                var ivaDelVehiculo = solicitud.Vehiculo.Precio * 0.19;
                cotizacion.Iva = int.Parse(Math.Round(ivaDelVehiculo).ToString());
                cotizacion.TotalFinal = solicitud.Vehiculo.Precio + cotizacion.Iva;
            }
            else
            {
                cotizacion.TotalFinal = solicitud.Vehiculo.Precio;
            }

            if (cotizacion.IdTipoPago == 2)
            {
                var valorCuota = Convert.ToDouble(cotizacion.TotalFinal) / Convert.ToDouble(cotizacion.CantidadCuotas);
                cotizacion.CantidadCuotas = cotizacion.CantidadCuotas;
                cotizacion.ValorCuota = int.Parse(Math.Round(valorCuota).ToString());
            }

            cotizacion.TotalSinIva = solicitud.Vehiculo.Precio;
            cotizacion.Id = await _cotizacionDal.InsertarAsync(cotizacion);

            await _personaService.InsertarAsync(cotizacion.Solicitud.Persona);

            return cotizacion;
        }
    }
}
