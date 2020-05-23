using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Solicitudes;
using VehiculosOnline.Cotizaciones.DTO;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.Facade
{
    public class CotizacionFacade
    {
        private readonly SolicitudService _solicitudService;

        public CotizacionFacade()
        {
            _solicitudService = new SolicitudService();
        }

        public async Task<int> InsertarAsync(CotizacionDTO cotizacion)
        {
            var solicitud = await _solicitudService.ObtenerPorIdAsync(cotizacion.IdSolicitud);
            if (solicitud.Persona.Rut != cotizacion.Cliente.Rut) throw new Exception("El cliente es diferente al de la solicitud");

            return 0;
        }
    }
}
