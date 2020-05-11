using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Vehiculos.DAL.Tables;

namespace VehiculosOnline.Vehiculos.BLL
{
    public class TipoVehiculoBl
    {
        private readonly TipoVehiculoDal _tipoVehiculoDal;

        public TipoVehiculoBl()
        {
            _tipoVehiculoDal = new TipoVehiculoDal();
        }

        public async Task<List<TipoVehiculo>> ObtenerTodosAsync()
        {
            return await _tipoVehiculoDal.ObtenerTodosAsync();
        }
    }
}
