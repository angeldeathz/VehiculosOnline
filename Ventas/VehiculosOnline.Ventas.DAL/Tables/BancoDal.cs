using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Ventas.DAL.Tables
{
    public class BancoDal
    {
        private readonly Repository _repository;

        public BancoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Banco>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre
                        from Banco where activo = 1 and id > 0
                        order by id asc";
            return await _repository.GetAllAsync<Banco>(sql);
        }
    }
}
