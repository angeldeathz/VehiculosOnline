using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.DAL.Tables;

namespace VehiculosOnline.Solicitudes.BLL
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
