using System;
using System.Net;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Personas;
using VehiculosOnline.CommonServices.Vehiculos;
using VehiculosOnline.CommonServices.Ventas;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.DAL.Tables;
using VehiculosOnline.Solicitudes.DTO;

namespace VehiculosOnline.Solicitudes.Facade
{
    public class SolicitudFacade
    {
        private readonly SolicitudDal _solicitudDal;
        private readonly PersonaService _personaService;
        private readonly VehiculoService _vehiculoService;
        private readonly VentaService _ventaService;

        public SolicitudFacade()
        {
            _solicitudDal = new SolicitudDal();
            _personaService = new PersonaService();
            _vehiculoService = new VehiculoService();
            _ventaService = new VentaService();

        }

        public async Task<int> InsertarAsync(SolicitudDto solicitudDto)
        {
            var respuestaCliente = await _personaService.InsertarAsync(solicitudDto.Cliente);

            if (respuestaCliente.StatusName != HttpStatusCode.OK) 
                throw new Exception($"No se ha podido ingresar el cliente. Error: {respuestaCliente.Message}");

            var idPersona = respuestaCliente.Response;

            var solicitud = new Solicitud
            {
                IdVehiculo = solicitudDto.IdVehiculo,
                IdPersona = idPersona,
                FechaIngresoSolicitud = DateTime.Now
            };

            return await _solicitudDal.InsertarAsync(solicitud);
        }

        public async Task<Solicitud> ObtenerPorIdAsync(int id)
        {
            var solicitud = await _solicitudDal.ObtenerPorIdAsync(id);
            if (solicitud == null) return null;

            var persona = await _personaService.ObtenerPorIdAsync(solicitud.IdPersona);
            solicitud.Persona = persona ?? throw new Exception($"La persona id {solicitud.IdPersona} no existe para la solicitud {id}");

            var vehiculo = await _vehiculoService.ObtenerPorIdAsync(solicitud.IdVehiculo);
            solicitud.Vehiculo = vehiculo ?? throw new Exception($"El vehiculo id {solicitud.IdVehiculo} no existe para la solicitud {id}");

            return solicitud;
        }

        public async Task<int> ActualizarPorIdAsync(int id)
        {
            var solicitud = await _solicitudDal.ObtenerPorIdAsync(id);
            if (solicitud == null) return 0;

            var persona = await _personaService.ObtenerPorIdAsync(solicitud.IdPersona);
            solicitud.Persona = persona ?? throw new Exception($"La persona id {solicitud.IdPersona} no existe para la solicitud {id}");

            var vehiculo = await _vehiculoService.ObtenerPorIdAsync(solicitud.IdVehiculo);
            solicitud.Vehiculo = vehiculo ?? throw new Exception($"El vehiculo id {solicitud.IdVehiculo} no existe para la solicitud {id}");

            solicitud.Vehiculo.Stock = solicitud.Vehiculo.Stock - 1;
            
            Venta nuevaVenta = new Venta();
            nuevaVenta.FechaVenta = DateTime.Now;
            //estare equivocado
            //
            var idCo = await _ventaService.ObtenerIdCotizacion();
            nuevaVenta.IdCotizacion = idCo;
            nuevaVenta.TotalVenta = vehiculo.Precio;

            //var cotizaciones = _vehiculoService.ObtenerCotizacionesAsync();
            _vehiculoService.InsertarVentaAsync(nuevaVenta);

            _vehiculoService.ModificarAsync(solicitud.Vehiculo);

            return 1;
        }

        public async Task<int> ObtenerUltimoId()
        {
            var solicitud = await _solicitudDal.ObtenerUltimoIdAsync();
            return solicitud;
        }
        
    }
}
