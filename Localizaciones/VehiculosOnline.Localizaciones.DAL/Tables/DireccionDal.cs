using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class DireccionDal
    {
        private readonly Repository _repository;
            
        public DireccionDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Direccion>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        calle,
                        numero,
                        id_comuna AS IdComuna
                        from direccion";
            return await _repository.GetAllAsync<Direccion>(sql);
        }
    }
}
