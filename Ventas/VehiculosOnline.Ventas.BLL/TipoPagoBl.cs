using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
{
    public class TipoPagoBl
    {
        private readonly TipoPagoDal _tipopagoDal;
        private readonly VentaDal _ventaDal;

        public TipoPagoBl()
        {
            _tipopagoDal = new TipoPagoDal();
            _ventaDal = new VentaDal();
        }

        public async Task<List<TipoPago>> ObtenerTodosAsync()
        {
            return await _tipopagoDal.ObtenerTodosAsync();
        }

        public async Task<int> InsertarVentaAsync(Venta venta)
        {
            return await _ventaDal.InsertarAsync(venta);
        }
    }
}
