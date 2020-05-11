using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Personas.DAL.Tables;

namespace VehiculosOnline.Personas.BLL
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

        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            return await _personaDal.ObtenerPorIdAsync(id);
        }

        public async Task<Persona> ObtenerPorRutAsync(string rut)
        {
            // TODO: Aca hay que recibir el rut completo, y validar el rut
            return await _personaDal.ObtenerPorRutAsync(0);
        }
    }
}
