using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Persona.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class PersonaDal
    {
        private readonly Repository _repository;
            
        public PersonaDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Persona>> ObtenerTodosAsync()
        {
            var sql = @"select 
                        id,
                        id_direccion AS IdDireccion,
                        nombres,
                        apellidos,
                        fec_nacimiento,
                        email,
                        celular,
                        telefono
                        from persona";
            return await _repository.GetAllAsync<Persona>(sql);
        }
    }
}
