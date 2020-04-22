using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
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
