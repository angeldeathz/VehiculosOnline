using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Vehiculos.DAL.Tables;

namespace VehiculosOnline.Vehiculos.BLL
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
