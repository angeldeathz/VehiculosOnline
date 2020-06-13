using System;
using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class VentaBL
    {
        private readonly VentaService _ventaService;
        
        public VentaBL()
        {
            _ventaService = new VentaService();
        }

        public List<TipoPago> ObtenerTipoPago()
        {
            var tipopagos = new List<TipoPago> { new TipoPago { Id = 0, Nombre = "Seleccione..." } };
            tipopagos.AddRange(_ventaService.ObtenerTipoPago());
            return tipopagos;
        }

        public int RealizarVenta(Venta venta)
        {
            return _ventaService.RealizarVenta(venta);
        }

        public List<VehiculoDataGrid> ObtenerVentasListado(string nombre,string correo, int tipoPago, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var ventas = new List<VehiculoDataGrid>();
            var ventasService = _ventaService.ObtenerVentasListado(nombre, correo, tipoPago, idMarca, idModelo, anio,fechaDesde,fechaHasta);

            foreach (var v in ventasService)
            {
                ventas.Add(new VentaDataGrid
                {
                    Id = v.Id,
                    Marca = v.Modelo.Marca.Nombre,
                    Modelo = v.Modelo.Nombre,
                    TipoVehiculo = v.TipoVehiculo.Nombre,
                    TipoCombustible = v.TipoCombustible.Nombre,
                    Pais = v.PaisOrigen.Nombre,
                    Anio = v.Anio,
                    Color = v.Color,
                    Precio = v.Precio,
                    Stock = v.Stock
                });
            }

            return ventas;
        }

    }
}
