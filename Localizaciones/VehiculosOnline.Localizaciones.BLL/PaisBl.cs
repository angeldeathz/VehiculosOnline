using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class PaisBl
    {
        private readonly PaisDal _paisDal;

        public PaisBl()
        {
            _paisDal = new PaisDal();
        }

        public async Task<List<Pais>> ObtenerTodosAsync()
        {
            return await _paisDal.ObtenerTodosAsync();
        }
    }
}
