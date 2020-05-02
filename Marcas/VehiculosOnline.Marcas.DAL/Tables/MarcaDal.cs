using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Marcas.DAL.Tables
{
    public class MarcaDal
    {
        private readonly Repository _repository;
            
        public MarcaDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Marca>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre
                        from marca";
            return await _repository.GetAllAsync<Marca>(sql);
        }
    }
}
