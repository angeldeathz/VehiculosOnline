using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Vehiculos.DAL.Tables
{
    public class VehiculoDal
    {
        private readonly Repository _repository;
            
        public VehiculoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Vehiculo>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        anio,
                        id_modelo AS IdModelo
                        from vehiculo";
            return await _repository.GetAllAsync<Vehiculo>(sql);
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
                    precio)
                    VALUES
                    (@IdModelo,
                    @IdTipoVehiculo,
                    @IdTipoCombustible,
                    @IdPaisOrigen,
                    @Anio,
                    @Color,
                    @Precio)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdModelo", vehiculo.IdModelo},
                {"@IdTipoVehiculo", vehiculo.IdTipoVehiculo},
                {"@IdTipoCombustible", vehiculo.IdTipoCombustible},
                {"@IdPaisOrigen", vehiculo.IdPaisOrigen},
                {"@Anio", vehiculo.Anio},
                {"@Color", vehiculo.Color},
                {"@Precio", vehiculo.Precio},
            });
        }
    }
}
