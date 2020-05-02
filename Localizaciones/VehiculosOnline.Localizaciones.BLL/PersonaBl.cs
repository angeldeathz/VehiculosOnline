using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Localizaciones.DAL.Tables;
using VehiculosOnline.Modelo.Clases;

namespace VehiculosOnline.Localizaciones.BLL
{
    public class PersonaBl
    {
        private readonly PersonaDal _personaDal;

        public PersonaBl()
        {
            _personaDal = new PersonaDal();
        }

        public async Task<List<Persona>> ObtenerTodosAsync()
        {
            return await _personaDal.ObtenerTodosAsync();
        }
    }
}
