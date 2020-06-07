using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Solicitudes;
using VehiculosOnline.Cotizaciones.DAL.Tables;
using VehiculosOnline.Cotizaciones.DTO;
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

        public async Task<int> InsertarAsync(CotizacionDTO cotizacion)
        {
            var solicitud = await _solicitudService.ObtenerPorIdAsync(cotizacion.IdSolicitud);
            if (solicitud.Persona.Rut != cotizacion.Cliente.Rut) throw new Exception("El cliente es diferente al de la solicitud");

            return 0;
        }

        public async Task<List<Cotizacion>> ObtenerTodosAsync()
        {
            return await _cotizacionDal.ObtenerTodosAsync();
        }
        public async Task<int> GetIdCotizacionAsync()
        {
            return await _cotizacionDal.ObtenerIdCotizacionAsync();
        }
        

        public async Task<PagoDto> InsertaYCalculaPagoAsync(Cotizacion cotizacion)
        {
            var solicitud = await _cotizacionDal.InsertarAsync(cotizacion);
            PagoDto calculaCotizacion = new PagoDto();
            double precioSinIva = Convert.ToDouble(cotizacion.ValorVehiculo);
            if (cotizacion.IdTipoPago==2)
            {
                int costoTotal = 2 * cotizacion.ValorVehiculo;
                double valorCuota = Convert.ToDouble(costoTotal) / Convert.ToDouble(cotizacion.CantidadCuotas);
                calculaCotizacion.PrecioSinIVA = Convert.ToInt32(precioSinIva - (precioSinIva * 0.19));
                calculaCotizacion.PrecioVehiuclo = cotizacion.ValorVehiculo;
                calculaCotizacion.Cuota = cotizacion.CantidadCuotas;
                calculaCotizacion.ValorCuota = Convert.ToInt32(valorCuota);
                calculaCotizacion.CostoTotalCredito = costoTotal;
            }
            else
            {
                calculaCotizacion.PrecioSinIVA = Convert.ToInt32(precioSinIva - (precioSinIva * 0.19));
                calculaCotizacion.PrecioVehiuclo = cotizacion.ValorVehiculo;
                calculaCotizacion.Cuota = 0;
                calculaCotizacion.ValorCuota = 0;
                calculaCotizacion.CostoTotalCredito = 0;
            }
            
            

            return calculaCotizacion;

        }

    }
}
