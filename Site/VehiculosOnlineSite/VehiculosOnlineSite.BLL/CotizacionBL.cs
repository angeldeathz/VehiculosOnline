using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class CotizacionBL
    {
        private readonly CotizacionService _cotizacionService;

        public CotizacionBL()
        {
            _cotizacionService = new CotizacionService();
        }

        public PagoDto IngresarCotizacion(Cotizacion solicitud)
        {
            return _cotizacionService.IngresarCotizacion(solicitud);
        }

    }
}
