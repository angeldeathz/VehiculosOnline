using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class ComunaBl
    {
        private readonly ComunaDal _comunaDal;

        public ComunaBl()
        {
            _comunaDal = new ComunaDal();
        }

        public async Task<List<Comuna>> ObtenerTodosAsync()
        {
            return await _comunaDal.ObtenerTodosAsync();
        }

        public async Task<List<Comuna>> ObtenerPorIdCiudadAsync(int idCiudad)
        {
            return await _comunaDal.ObtenerPorIdCiudadAsync(idCiudad);
        }

        public async Task<List<Ciudad>> ObtenerPorIdRegionAsync(int idRegion)
        {
            return await _comunaDal.ObtenerPorIdRegionAsync(idRegion);
        }

        public async Task<Comuna> ObtenerPorIdAsync(int id)
        {
            return await _comunaDal.ObtenerPorIdAsync(id);
        }
    }
}
