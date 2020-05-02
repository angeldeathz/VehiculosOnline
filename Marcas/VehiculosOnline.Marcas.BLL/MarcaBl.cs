using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Marcas.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Marcas.BLL
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
