using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
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
