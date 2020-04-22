using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class MarcaBl
    {
        private readonly MarcaDal _marcaDal;

        public MarcaBl()
        {
            _marcaDal = new MarcaDal();
        }

        public async Task<List<Marca>> ObtenerTodosAsync()
        {
            return await _marcaDal.ObtenerTodosAsync();
        }
    }
}
