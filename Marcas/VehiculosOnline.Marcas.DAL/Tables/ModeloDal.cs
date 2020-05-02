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
    }
}
