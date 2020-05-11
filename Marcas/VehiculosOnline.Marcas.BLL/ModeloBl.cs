using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Marcas.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Marcas.BLL
{
    public class ModeloBl
    {
        private readonly ModeloDal _modeloDal;

        public ModeloBl()
        {
            _modeloDal = new ModeloDal();
        }

        public async Task<List<Modelo>> ObtenerTodosAsync()
        {
            return await _modeloDal.ObtenerTodosAsync();
        }

        public async Task<List<Modelo>> ObtenerPorIdMarcaAsync(int idMarca)
        {
            return await _modeloDal.ObtenerPorIdMarcaAsync(idMarca);
        }

        public async Task<Modelo> ObtenerPorIdAsync(int id)
        {
            return await _modeloDal.ObtenerPorIdAsync(id);
        }
    }
}
