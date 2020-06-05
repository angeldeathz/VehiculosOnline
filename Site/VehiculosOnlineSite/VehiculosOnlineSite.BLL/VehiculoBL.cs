using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class VehiculoBL
    {
        private readonly VehiculoService _vehiculoService;

        public VehiculoBL()
        {
            _vehiculoService = new VehiculoService();
        }

        public List<VehiculoDataGrid> ObtenerPorIdMarcaModelo(int idMarca, int idModelo, int anio)
        {
            var vehiculos = new List<VehiculoDataGrid>();
            var vehiculosService = _vehiculoService.ObtenerPorIdMarcaModelo(idMarca, idModelo, anio);

            foreach (var v in vehiculosService)
            {
                vehiculos.Add(new VehiculoDataGrid
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

            return vehiculos;
        }

        public List<TipoVehiculo> ObtenerTipoVehiculos()
        {
            var tipoVehiculos = new List<TipoVehiculo> { new TipoVehiculo { Id = 0, Nombre = "Seleccione..." } };
            tipoVehiculos.AddRange(_vehiculoService.ObtenerTipoVehiculos());
            return tipoVehiculos;
        }

        public List<TipoCombustible> ObtenerTipoCombustibles()
        {
            var tipoCombustibles = new List<TipoCombustible> { new TipoCombustible { Id = 0, Nombre = "Seleccione..." } };
            tipoCombustibles.AddRange(_vehiculoService.ObtenerTipoCombustibles());
            return tipoCombustibles;
        }

        public int InsertarAsync(Vehiculo vehiculo)
        {
            return _vehiculoService.InsertarAsync(vehiculo);
        }
    }
}
