using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Marcas.DAL.Tables
{
    public class ModeloDal
    {
        private readonly Repository _repository;
            
        public ModeloDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Modelo>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_marca AS IdMarca
                        from modelo";

            return await _repository.GetAllAsync<Modelo>(sql);
        }

        public async Task<List<Modelo>> ObtenerPorIdMarcaAsync(int idMarca)
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_marca AS IdMarca
                        from modelo
                        where id_marca = @IdMarca";

            return await _repository.GetAllAsync<Modelo>(sql, new Dictionary<string, object>
            {
                {"IdMarca", idMarca}
            });
        }

        public async Task<Modelo> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_marca AS IdMarca
                        from modelo
                        where id = @Id";

            return await _repository.GetAsync<Modelo>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }
    }
}
