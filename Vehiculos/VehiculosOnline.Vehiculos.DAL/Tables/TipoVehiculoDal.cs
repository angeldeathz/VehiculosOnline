using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Vehiculos.DAL.Tables
{
    public class TipoVehiculoDal
    {
        private readonly Repository _repository;

        public TipoVehiculoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<TipoVehiculo>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        nombre,
                        descripcion,
                        activo
                        from tipovehiculo";
            return await _repository.GetAllAsync<TipoVehiculo>(sql);
        }
    }
}
