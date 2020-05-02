using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Ventas.DAL.Tables;

namespace VehiculosOnline.Ventas.BLL
{
    public class VentaBl
    {
        private readonly VentaDal _ventaDal;

        public VentaBl()
        {
            _ventaDal = new VentaDal();
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            return await _ventaDal.ObtenerTodosAsync();
        }
    }
}
