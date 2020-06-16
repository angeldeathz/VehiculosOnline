using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Cotizaciones;
using VehiculosOnline.CommonServices.Vehiculos;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Vehiculos.DAL.ClassJoin;
using VehiculosOnline.Ventas.DAL.Tables;
using VehiculosOnlineSite.Model.Clases;

namespace VehiculosOnline.Ventas.BLL
{
    public class VentaBl
    {
        private readonly VentaDal _ventaDal;
        private readonly CotizacionService _cotizacionService;
        private readonly VehiculoService _vehiculoService;

        public VentaBl()
        {
            _ventaDal = new VentaDal();
            _cotizacionService = new CotizacionService();
            _vehiculoService = new VehiculoService();
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await _ventaDal.ObtenerTodosAsync();
        }

        public async Task<int> InsertarVentaAsync(Venta venta)
        {
            var cotizacion = await _cotizacionService.ObtenerPorIdAsync(venta.IdCotizacion);
            if (cotizacion == null) throw new Exception($"La cotización {venta.IdCotizacion} no existe");
            if (venta.Detalle == null) throw new Exception($"El detalle de la venta no puede ser null");

            venta.TotalVenta = cotizacion.TotalFinal;
            var idVenta = await _ventaDal.InsertarAsync(venta);
            venta.Detalle.IdVenta = idVenta;
            await _ventaDal.InsertarDetalleAsync(venta.Detalle);

            await _vehiculoService.ActualizarStock(cotizacion.Solicitud.IdVehiculo);
            
            return idVenta;
        }

        public async Task<List<VentaDataGrid>> ObtenerVentasListado(string nombre, string correo, int tipoPago, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var ventas = await _ventaDal.ObtenerVentasListado(nombre, correo, tipoPago, idMarca, idModelo, anio, fechaDesde, fechaHasta);
            if (!ventas.Any()) return new List<VentaDataGrid>();

            return ventas.Select(x => new VentaDataGrid
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Correo = x.Correo,
                Marca = x.NombreMarca,
                Modelo = x.NombreModelo,
                Anio = x.Anio,
                TipoPago = x.NombreTipoPago,
                PrecioVenta = x.TotalVenta,
                FechaVenta = x.FecVenta
            }).ToList();
        }
    }
}
