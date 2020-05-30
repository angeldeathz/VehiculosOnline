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

        public List<VehiculoDataGrid> ObtenerPorIdMarcaModelo(int idMarca, int idModelo)
        {
            var vehiculos = new List<VehiculoDataGrid>();
            var vehiculosService = _vehiculoService.ObtenerPorIdMarcaModelo(idMarca, idModelo);

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
                    Precio = v.Precio
                });
            }

            return vehiculos;
        }
    }
}
