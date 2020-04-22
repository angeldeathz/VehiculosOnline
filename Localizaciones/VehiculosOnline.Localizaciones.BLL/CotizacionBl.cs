using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
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
