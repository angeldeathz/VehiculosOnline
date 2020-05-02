using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class RegionDal
    {
        private readonly Repository _repository;
            
        public RegionDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Region>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre
                        from region";
            return await _repository.GetAllAsync<Region>(sql);
        }
    }
}
