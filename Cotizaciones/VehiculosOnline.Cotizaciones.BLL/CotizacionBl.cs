using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Cotizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.BLL
{
    public class CotizacionBl
    {
        private readonly CotizacionDal _cotizacionDal;

        public CotizacionBl()
        {
            _cotizacionDal = new CotizacionDal();
        }

        public async Task<List<Cotizacion>> ObtenerTodosAsync()
        {
            return await _cotizacionDal.ObtenerTodosAsync();
        }
    }
}
