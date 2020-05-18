using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class DireccionBl
    {
        private readonly DireccionDal _direccionDal;
        private readonly ComunaDal _comunaDal;
        private readonly CiudadDal _ciudadDal;

        public DireccionBl()
        {
            _direccionDal = new DireccionDal();
            _comunaDal = new ComunaDal();
            _ciudadDal = new CiudadDal();
        }

        public async Task<Direccion> ObtenerPorIdAsync(int id)
        {
            var direccion = await _direccionDal.ObtenerPorIdAsync(id);
            if (direccion == null) return null;

            direccion.Comuna = await _comunaDal.ObtenerPorIdAsync(direccion.IdComuna);
            direccion.Comuna.Ciudad = await _ciudadDal.ObtenerPorIdAsync(direccion.Comuna.IdCiudad);
            return direccion;
        }

        public async Task<int> InsertarAsync(Direccion direccion)
        {
            return await _direccionDal.InsertarAsync(direccion);
        }

        public async Task<int> ActualizarAsync(int id, Direccion direccion)
        {
            direccion.Id = id;
            return await _direccionDal.ActualizarAsync(direccion);
        }
    }
}
