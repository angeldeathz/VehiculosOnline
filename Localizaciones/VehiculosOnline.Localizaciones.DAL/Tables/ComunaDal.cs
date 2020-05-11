using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class ComunaDal
    {
        private readonly Repository _repository;
            
        public ComunaDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Comuna>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_ciudad AS IdCiudad
                        from comuna";

            return await _repository.GetAllAsync<Comuna>(sql);
        }

        public async Task<List<Comuna>> ObtenerPorIdCiudadAsync(int idCiudad)
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_ciudad AS IdCiudad
                        from comuna
                        where id_ciudad = @IdCiudad";

            return await _repository.GetAllAsync<Comuna>(sql, new Dictionary<string, object>
            {
                {"IdCiudad", idCiudad}
            });
        }

        public async Task<Comuna> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_ciudad AS IdCiudad
                        from comuna
                        where id = @Id";

            return await _repository.GetAsync<Comuna>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }
    }
}
