using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Vehiculos.DAL.Tables
{
    public class VehiculoDal
    {
        private readonly Repository _repository;
            
        public VehiculoDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Vehiculo>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        anio,
                        id_modelo AS IdModelo
                        from vehiculo";
            return await _repository.GetAllAsync<Vehiculo>(sql);
        }

    }
}
