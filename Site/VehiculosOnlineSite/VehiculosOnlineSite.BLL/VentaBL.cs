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

        public List<Banco> ObtenerBancos()
        {
            var bancos = new List<Banco> { new Banco { Id = 0, Nombre = "Seleccione..." } };
            bancos.AddRange(_ventaService.ObtenerBancos());
            return bancos;
        }

        public List<TarjetaCredito> ObtenerTarjetasDeCredito()
        {
            var tarjetasDeCredito = new List<TarjetaCredito> { new TarjetaCredito { Id = 0, Nombre = "Seleccione..." } };
            tarjetasDeCredito.AddRange(_ventaService.ObtenerTarjetasDeCredito());
            return tarjetasDeCredito;
        }

        public int RealizarVenta(Venta venta)
        {
            return _ventaService.RealizarVenta(venta);
        }

        public List<VentaDataGrid> ObtenerVentasListado(string nombre, int tipoPago, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var ventas = new List<VentaDataGrid>();
            var ventasService = _ventaService.ObtenerVentasListado(nombre, tipoPago, idMarca, idModelo, anio,fechaDesde,fechaHasta);

            foreach (var v in ventasService)
            {
                ventas.Add(new VentaDataGrid
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Correo = v.Correo,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Anio = v.Anio,
                    TipoPago = v.TipoPago,
                    PrecioVenta = v.PrecioVenta,
                    FechaVenta = v.FechaVenta
                });
            }

            return ventas;
        }

    }
}
