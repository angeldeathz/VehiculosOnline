using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Vehiculos.DAL.Tables;

namespace VehiculosOnline.Vehiculos.BLL
{
    public class VehiculoBl
    {
        private readonly VehiculoDal _vehiculoDal;

        public VehiculoBl()
        {
            _vehiculoDal = new VehiculoDal();
        }

        public async Task<List<Vehiculo>> ObtenerTodosAsync()
        {
            return await _vehiculoDal.ObtenerTodosAsync();
        }

        public async Task<Vehiculo> ObtenerPorIdAsync(int id)
        {
            var vehiculoCompleto = await _vehiculoDal.ObtenerPorIdAsync(id);
            if (vehiculoCompleto == null) return null;

            return new Vehiculo
            {
                Id = vehiculoCompleto.Id,
                IdModelo = vehiculoCompleto.IdModelo,
                IdTipoVehiculo = vehiculoCompleto.IdTipoVehiculo,
                IdTipoCombustible = vehiculoCompleto.IdTipoCombustible,
                IdPaisOrigen = vehiculoCompleto.IdPaisOrigen,
                Anio = vehiculoCompleto.Anio,
                Color = vehiculoCompleto.Color,
                Precio = vehiculoCompleto.Precio,
                Modelo = new Modelo
                {
                    Id = vehiculoCompleto.IdModelo,
                    Nombre = vehiculoCompleto.NombreModelo,
                    IdMarca = vehiculoCompleto.IdMarca,
                    Marca = new Marca
                    {
                        Id = vehiculoCompleto.IdMarca,
                        Nombre = vehiculoCompleto.NombreMarca
                    }
                },
                TipoVehiculo = new TipoVehiculo
                {
                    Id = vehiculoCompleto.IdTipoVehiculo,
                    Nombre = vehiculoCompleto.NombreTipoVehiculo
                },
                TipoCombustible = new TipoCombustible
                {
                    Id = vehiculoCompleto.IdTipoCombustible,
                    Nombre = vehiculoCompleto.NombreTipoCombustible
                },
                PaisOrigen = new Pais
                {
                    Id = vehiculoCompleto.IdPaisOrigen,
                    Nombre = vehiculoCompleto.NombrePaisOrigen
                }
            };
        }

        public async Task<List<Vehiculo>> ObtenerPorMarcaModeloAsync(int idMarca, int idModelo)
        {
            var vehiculos = await _vehiculoDal.ObtenerPorMarcaModeloAsync(idMarca, idModelo);
            if (!vehiculos.Any()) return new List<Vehiculo>();

            return vehiculos.Select(x => new Vehiculo
            {
                Id = x.Id,
                IdModelo = x.IdModelo,
                IdTipoVehiculo = x.IdTipoVehiculo,
                IdTipoCombustible = x.IdTipoCombustible,
                IdPaisOrigen = x.IdPaisOrigen,
                Anio = x.Anio,
                Color = x.Color,
                Precio = x.Precio,
                Modelo = new Modelo
                {
                    Id = x.IdModelo,
                    Nombre = x.NombreModelo,
                    IdMarca = x.IdMarca,
                    Marca = new Marca
                    {
                        Id = x.IdMarca,
                        Nombre = x.NombreMarca
                    }
                },
                TipoVehiculo = new TipoVehiculo
                {
                    Id = x.IdTipoVehiculo,
                    Nombre = x.NombreTipoVehiculo
                },
                TipoCombustible = new TipoCombustible
                {
                    Id = x.IdTipoCombustible,
                    Nombre = x.NombreTipoCombustible
                },
                PaisOrigen = new Pais
                {
                    Id = x.IdPaisOrigen,
                    Nombre = x.NombrePaisOrigen
                }
            }).ToList();
        }
    }
}
