using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Ventas.DAL.Tables
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
            const string sql = @"select 
                        id,
                        nombre,
                        activo
                        from TipoPago";
            return await _repository.GetAllAsync<TipoPago>(sql);
        }

    }
}
