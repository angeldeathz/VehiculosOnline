using System;
using System.Net;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Personas;
using VehiculosOnline.CommonServices.Vehiculos;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.DAL.Tables;

namespace VehiculosOnline.Solicitudes.Facade
{
    public class SolicitudFacade
    {
        private readonly SolicitudDal _solicitudDal;
        private readonly PersonaService _personaService;
        private readonly VehiculoService _vehiculoService;

        public SolicitudFacade()
        {
            _solicitudDal = new SolicitudDal();
            _personaService = new PersonaService();
            _vehiculoService = new VehiculoService();
        }

        public async Task<int> InsertarAsync(Solicitud solicitud)
        {
            var respuestaPersona = await _personaService.InsertarAsync(solicitud.Persona);

            if (respuestaPersona.StatusName != HttpStatusCode.OK) 
                throw new Exception($"No se ha podido ingresar la persona. Error: {respuestaPersona.Message}");

            var respuestaVehiculo = await _vehiculoService.InsertarAsync(solicitud.Vehiculo);

            if (respuestaVehiculo.StatusName != HttpStatusCode.OK)
                throw new Exception($"No se ha podido ingresar el vehiculo. Error: {respuestaVehiculo.Message}");

            solicitud.IdPersona = respuestaPersona.Response;
            solicitud.IdVehiculo = respuestaVehiculo.Response;

            return await _solicitudDal.InsertarAsync(solicitud);
        }
    }
}
