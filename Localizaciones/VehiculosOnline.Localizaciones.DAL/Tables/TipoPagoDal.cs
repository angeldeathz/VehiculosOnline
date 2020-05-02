using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Modelo.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class TipoPagoDal
    {
        private readonly Repository _repository;
            
        public TipoPagoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<TipoPago>> ObtenerTodosAsync()
        {
            var sql = @"select 
                        id,
                        nombre,
                        activo
                        from TipoPago";
            return await _repository.GetAllAsync<TipoPago>(sql);
        }
    }
}
