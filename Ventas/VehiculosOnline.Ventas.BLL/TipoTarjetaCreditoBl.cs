using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
{
    public class TipoTarjetaCreditoBl
    {
        private readonly TipoTarjetaCreditoDal _tipoTarjetaCreditoDal;

        public TipoTarjetaCreditoBl()
        {
            _tipoTarjetaCreditoDal = new TipoTarjetaCreditoDal();
        }

        public async Task<List<TarjetaCredito>> ObtenerTodosAsync()
        {
            var tipoTarjetas = await _tipoTarjetaCreditoDal.ObtenerTodosAsync();
            return tipoTarjetas.Where(x => x.Id > 0).ToList();
        }
    }
}
