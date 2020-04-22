using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class VehiculoBl
    {
        private readonly VehiculoDal _vehiculoDal;

        public VehiculoBl()
        {
            _vehiculoDal = new VehiculoDal();
        }

        public async Task<List<Vehiculo>> ObtenerTodosAsync()
        {
            return await _vehiculoDal.ObtenerTodosAsync();
        }
    }
}
