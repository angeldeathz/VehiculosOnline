using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class SolicitudBl
    {
        private readonly SolicitudDal _solicitudDal;

        public SolicitudBl()
        {
            _solicitudDal = new SolicitudDal();
        }

        public async Task<List<Solicitud>> ObtenerTodosAsync()
        {
            return await _solicitudDal.ObtenerTodosAsync();
        }
    }
}
