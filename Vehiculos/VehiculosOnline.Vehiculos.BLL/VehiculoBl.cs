using System.Collections.Generic;
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
    }
}
