using System;
using System.Net;
using System.Threading.Tasks;
using VehiculosOnline.CommonServices.Direcciones;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Personas.DAL.Tables;

namespace VehiculosOnline.Personas.Facade
{
    public class PersonaFacade
    {
        private readonly PersonaDal _personaDal;
        private readonly DireccionService _direccionService;

        public PersonaFacade()
        {
            _personaDal = new PersonaDal();
            _direccionService = new DireccionService();
        }

        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            var persona = await _personaDal.ObtenerPorIdAsync(id);
            if (persona == null) return null;

            persona.Direccion = await _direccionService.ObtenerPorIdAsync(persona.IdDireccion);
            return persona;
        }

        public async Task<int> InsertarAsync(Persona persona)
        {
            if (!persona.ValidaRut(persona.ObtenerRutCompleto()))
                throw new Exception("Rut es inválido");

            var personaBdd = await _personaDal.ObtenerPorRutAsync(persona.Rut);

            if (personaBdd == null)
            {
                var direccionRespuesta = await _direccionService.InsertarAsync(persona.Direccion);

                if (direccionRespuesta.StatusName != HttpStatusCode.OK)
                    throw new Exception($"No se pudo ingresar la direccion. Error {direccionRespuesta.Message}");

                persona.IdDireccion = direccionRespuesta.Response;
                var id = await _personaDal.InsertarAsync(persona);
                persona.Id = id;
            }
            else
            {
                var direccionRespuesta = await _direccionService.ActualizarAsync(personaBdd.IdDireccion, persona.Direccion);

                if (direccionRespuesta.StatusName != HttpStatusCode.OK)
                    throw new Exception($"No se pudo actualizar la direccion. Error {direccionRespuesta.Message}");

                persona.Id = personaBdd.Id;
                persona.IdDireccion = personaBdd.IdDireccion;
                var esActualizado = await _personaDal.ActualizarAsync(persona);

                if (esActualizado == 0)
                    throw new Exception("No se pudo actualizar la persona");
            }

            return persona.Id;
        }
    }
}
