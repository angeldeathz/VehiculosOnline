using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class CiudadDal
    {
        private readonly Repository _repository;
            
        public CiudadDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Ciudad>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre,
                        id_region AS IdRegion
                        from region";
            return await _repository.GetAllAsync<Ciudad>(sql);
        }
    }
}
