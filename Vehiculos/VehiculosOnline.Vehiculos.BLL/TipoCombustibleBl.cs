using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Vehiculos.DAL.Tables;

namespace VehiculosOnline.Vehiculos.BLL
{
    public class TipoCombustibleBl
    {
        private readonly TipoCombustibleDal _tipoCombustibleDal;

        public TipoCombustibleBl()
        {
            _tipoCombustibleDal = new TipoCombustibleDal();
        }

        public async Task<List<TipoCombustible>> ObtenerTodosAsync()
        {
            return await _tipoCombustibleDal.ObtenerTodosAsync();
        }
    }
}
