using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Modelo.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
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
            var sql = @"select 
                        id,
                        nombre,
                        id_marca AS IdMarca
                        from modelo";
            return await _repository.GetAllAsync<Modelo>(sql);
        }
    }
}
