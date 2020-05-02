using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class TipoPagoBl
    {
        private readonly TipoPagoDal _tipopagoDal;

        public TipoPagoBl()
        {
            _tipopagoDal = new TipoPagoDal();
        }

        public async Task<List<TipoPago>> ObtenerTodosAsync()
        {
            return await _tipopagoDal.ObtenerTodosAsync();
        }
    }
}
