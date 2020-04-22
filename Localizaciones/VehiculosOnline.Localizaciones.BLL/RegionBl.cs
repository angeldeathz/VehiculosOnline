using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class RegionBl
    {
        private readonly RegionDal _regionDal;

        public RegionBl()
        {
            _regionDal = new RegionDal();
        }

        public async Task<List<Region>> ObtenerTodosAsync()
        {
            return await _regionDal.ObtenerTodosAsync();
        }
    }
}
