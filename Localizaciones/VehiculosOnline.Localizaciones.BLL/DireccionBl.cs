using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class DireccionBl
    {
        private readonly DireccionDal _direccionDal;

        public DireccionBl()
        {
            _direccionDal = new DireccionDal();
        }

        public async Task<List<Direccion>> ObtenerTodosAsync()
        {
            return await _direccionDal.ObtenerTodosAsync();
        }
    }
}
