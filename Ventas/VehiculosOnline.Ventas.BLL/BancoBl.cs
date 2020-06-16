using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
{
    public class BancoBl
    {
        private readonly BancoDal _bancoDal;

        public BancoBl()
        {
            _bancoDal = new BancoDal();
        }

        public async Task<List<Banco>> ObtenerTodosAsync()
        {
            return await _bancoDal.ObtenerTodosAsync();
        }
    }
}
