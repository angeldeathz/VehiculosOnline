using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;
using VehiculosOnline.Vehiculos.DAL.ClassJoin;

namespace VehiculosOnline.Vehiculos.DAL.Tables
{
    public class VehiculoDal
    {
        private readonly Repository _repository;
            
        public VehiculoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<VehiculoJoin> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        v.id,
                        v.id_modelo as IdModelo,
                        mo.nombre as NombreModelo,
                        ma.id as IdMarca,
                        ma.nombre as NombreMarca,
                        v.id_tipo_vehiculo as IdTipoVehiculo,
                        tv.nombre as NombreTipoVehiculo,
                        v.id_tipo_combustible as IdTipoCombustible,
                        tc.nombre as NombreTipoCombustible,
                        v.id_pais_origen as IdPaisOrigen,
                        p.nombre as NombrePaisOrigen,
                        v.anio,
                        v.color,
                        v.precio,
                        v.stock
                        from vehiculo v
                        join modelo mo on v.id_modelo = mo.id
                        join marca ma on mo.id_marca = ma.id
                        join TipoVehiculo tv on v.id_tipo_vehiculo = tv.id
                        join TipoCombustible tc on v.id_tipo_combustible = tc.id
                        join Pais p on v.id_pais_origen = p.id
                        WHERE v.id = @Id";

            return await _repository.GetAsync<VehiculoJoin>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }

        public async Task<List<VehiculoJoin>> ObtenerPorMarcaModeloAsync(int idMarca, int idModelo, int anio)
        {
            const string sql = @"select 
                        v.id,
                        v.id_modelo as IdModelo,
                        mo.nombre as NombreModelo,
                        ma.id as IdMarca,
                        ma.nombre as NombreMarca,
                        v.id_tipo_vehiculo as IdTipoVehiculo,
                        tv.nombre as NombreTipoVehiculo,
                        v.id_tipo_combustible as IdTipoCombustible,
                        tc.nombre as NombreTipoCombustible,
                        v.id_pais_origen as IdPaisOrigen,
                        p.nombre as NombrePaisOrigen,
                        v.anio,
                        v.color,
                        v.precio,
                        v.stock
                        from vehiculo v
                        join modelo mo on v.id_modelo = mo.id
                        join marca ma on mo.id_marca = ma.id
                        join TipoVehiculo tv on v.id_tipo_vehiculo = tv.id
                        join TipoCombustible tc on v.id_tipo_combustible = tc.id
                        join Pais p on v.id_pais_origen = p.id
                        WHERE (v.id_modelo = @IdModelo OR 0 = @IdModelo) 
                        AND (ma.id = @IdMarca OR 0 = @IdMarca)
                        AND (v.anio = @Anio OR 0 = @Anio)";

            return await _repository.GetAllAsync<VehiculoJoin>(sql, new Dictionary<string, object>
            {
                {"@IdMarca", idMarca},
                {"@IdModelo", idModelo},
                {"@Anio", anio}
            });
        }

        public async Task<int> InsertarAsync(Vehiculo vehiculo)
        {
            const string sql = 
                @"INSERT INTO VEHICULO 
                    (id_modelo,
                    id_tipo_vehiculo,
                    id_tipo_combustible,
                    id_pais_origen,
                    anio,
                    color,
                    precio,
                    stock)
                    VALUES
                    (@IdModelo,
                    @IdTipoVehiculo,
                    @IdTipoCombustible,
                    @IdPaisOrigen,
                    @Anio,
                    @Color,
                    @Precio,
                    @Stock)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdModelo", vehiculo.IdModelo},
                {"@IdTipoVehiculo", vehiculo.IdTipoVehiculo},
                {"@IdTipoCombustible", vehiculo.IdTipoCombustible},
                {"@IdPaisOrigen", vehiculo.IdPaisOrigen},
                {"@Anio", vehiculo.Anio},
                {"@Color", vehiculo.Color},
                {"@Precio", vehiculo.Precio},
                {"@Stock", vehiculo.Stock}
            });
        }
    }
}
