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
    }
}
