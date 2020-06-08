using System;
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
                Stock = vehiculoCompleto.Stock,
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

        public async Task<List<Vehiculo>> ObtenerPorMarcaModeloAsync(int idMarca, int idModelo, int anio)
        {
            var vehiculos = await _vehiculoDal.ObtenerPorMarcaModeloAsync(idMarca, idModelo, anio);
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
                Stock = x.Stock,
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

        public async Task<int> InsertarAsync(Vehiculo vehiculo)
        {
            if (vehiculo.IdModelo == 0) throw new Exception("IdModelo no puede ser cero");
            if (vehiculo.IdTipoVehiculo == 0) throw new Exception("IdTipoVehiculo no puede ser cero");
            if (vehiculo.IdTipoCombustible == 0) throw new Exception("IdTipoCombustible no puede ser cero");
            if (vehiculo.IdPaisOrigen == 0) throw new Exception("IdPaisOrigen no puede ser cero");
            if (vehiculo.Anio < 2000 || vehiculo.Anio > 2020) throw new Exception("Anio debe estar entre 2000 y 2020");
            if (string.IsNullOrEmpty(vehiculo.Color)) throw new Exception("Color no puede estar vacios");
            if (vehiculo.Precio < 500000) throw new Exception("Precio debe igual o mayor a 500.000 pesos");

            return await _vehiculoDal.InsertarAsync(vehiculo);
        }

        public async Task<int> ModificarAsync(Vehiculo vehiculo)
        {
            if (vehiculo.IdModelo == 0) throw new Exception("IdModelo no puede ser cero");
            if (vehiculo.IdTipoVehiculo == 0) throw new Exception("IdTipoVehiculo no puede ser cero");
            if (vehiculo.IdTipoCombustible == 0) throw new Exception("IdTipoCombustible no puede ser cero");
            if (vehiculo.IdPaisOrigen == 0) throw new Exception("IdPaisOrigen no puede ser cero");
            if (vehiculo.Anio < 2000 || vehiculo.Anio > 2020) throw new Exception("Anio debe estar entre 2000 y 2020");
            if (string.IsNullOrEmpty(vehiculo.Color)) throw new Exception("Color no puede estar vacios");
            if (vehiculo.Precio < 500000) throw new Exception("Precio debe igual o mayor a 500.000 pesos");

            return await _vehiculoDal.ModificarAsync(vehiculo);
        }

        public async Task<int> ActualizarStock(int id)
        {
            var vehiculo = await _vehiculoDal.ObtenerPorIdAsync(id);
            if (vehiculo == null) throw new Exception($"Vehiculo con id {id} no existe");
            var stock = vehiculo.Stock - 1;
            return await _vehiculoDal.ActualizarStock(stock, vehiculo.Id);
        }
    }
}
