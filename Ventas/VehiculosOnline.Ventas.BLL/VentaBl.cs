using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Cotizaciones;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
{
    public class VentaBl
    {
        private readonly VentaDal _ventaDal;
        private readonly CotizacionService _cotizacionService;

        public VentaBl()
        {
            _ventaDal = new VentaDal();
            _cotizacionService = new CotizacionService();
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await _ventaDal.ObtenerTodosAsync();
        }

        public async Task<int> InsertarVentaAsync(Venta venta)
        {
            var cotizacion = await _cotizacionService.ObtenerPorIdAsync(venta.IdCotizacion);
            if (cotizacion == null) throw new Exception($"La cotización {venta.IdCotizacion} no existe");

            venta.TotalVenta = cotizacion.ValorVehiculo;
            return await _ventaDal.InsertarAsync(venta);
        }
    }
}
