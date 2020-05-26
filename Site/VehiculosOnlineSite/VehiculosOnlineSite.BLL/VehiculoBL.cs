using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class VehiculoBL
    {
        private readonly VehiculoService _vehiculoService;

        public VehiculoBL()
        {
            _vehiculoService = new VehiculoService();
        }

        public Vehiculo ObtenerPorIdAsync(int id)
        {
            return _vehiculoService.ObtenerPorId(id);
        }
    }
}
