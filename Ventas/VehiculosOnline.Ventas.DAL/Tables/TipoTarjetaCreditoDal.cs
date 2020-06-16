using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Ventas.DAL.Tables
{
    public class TipoTarjetaCreditoDal
    {
        private readonly Repository _repository;

        public TipoTarjetaCreditoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<TarjetaCredito>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre
                        from TipoTarjetaCredito where activo = 1";
            return await _repository.GetAllAsync<TarjetaCredito>(sql);
        }
    }
}
