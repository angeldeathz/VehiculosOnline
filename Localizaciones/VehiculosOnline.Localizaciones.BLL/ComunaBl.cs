using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class ComunaBl
    {
        private readonly ComunaDal _comunaDal;

        public ComunaBl()
        {
            _comunaDal = new ComunaDal();
        }

        public async Task<List<Comuna>> ObtenerTodosAsync()
        {
            return await _comunaDal.ObtenerTodosAsync();
        }
    }
}
