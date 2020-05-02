using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class CiudadBl
    {
        private readonly CiudadDal _ciudadDal;

        public CiudadBl()
        {
            _ciudadDal = new CiudadDal();
        }

        public async Task<List<Ciudad>> ObtenerTodosAsync()
        {
            return await _ciudadDal.ObtenerTodosAsync();
        }
    }
}
