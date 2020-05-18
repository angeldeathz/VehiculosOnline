using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Personas.DAL.Tables
{
    public class PersonaDal
    {
        private readonly Repository _repository;
            
        public PersonaDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<int> InsertarAsync(Persona persona)
        {
            const string sql =
                @"INSERT INTO PERSONA 
                    (id_direccion, 
                    rut, 
                    dv, 
                    nombres,
                    apellidos,
                    fec_nacimiento,
                    email,
                    celular,
                    telefono)
                  VALUES 
                    (@IdDireccion,
                    @Rut,
                    @Dv,
                    @Nombres,
                    @Apellidos,
                    @FechaNacimiento,
                    @Email,
                    @Celular,
                    @Telefono)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdDireccion", persona.IdDireccion},
                {"@Rut", persona.Rut},
                {"@Dv", persona.Dv},
                {"@Nombres", persona.Nombres},
                {"@Apellidos", persona.Apellidos},
                {"@FechaNacimiento", persona.FechaNacimiento},
                {"@Email", persona.Email},
                {"@Celular", persona.Celular},
                {"@Telefono", persona.Telefono}
            });
        }

        public async Task<int> ActualizarAsync(Persona persona)
        {
            const string sql =
                @"UPDATE PERSONA 
                  SET
                    id_direccion = @IdDireccion,
                    nombres = @Nombres,
                    apellidos = @Apellidos,
                    fec_nacimiento = @FechaNacimiento,
                    email = @Email,
                    celular = @Celular,
                    telefono = @Telefono
                  Where id = @Id";

            return await _repository.UpdateAsync(sql, new Dictionary<string, object>
            {
                {"@Id", persona.Id},
                {"@IdDireccion", persona.IdDireccion},
                {"@Nombres", persona.Nombres},
                {"@Apellidos", persona.Apellidos},
                {"@FechaNacimiento", persona.FechaNacimiento},
                {"@Email", persona.Email},
                {"@Celular", persona.Celular},
                {"@Telefono", persona.Telefono}
            });
        }

        public async Task<List<Persona>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        rut,
                        dv,
                        id_direccion AS IdDireccion,
                        nombres,
                        apellidos,
                        fec_nacimiento as FechaNacimiento,
                        email,
                        celular,
                        telefono
                        from persona";

            return await _repository.GetAllAsync<Persona>(sql);
        }

        public async Task<Persona> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id,
                        rut,
                        dv,
                        id_direccion AS IdDireccion,
                        nombres,
                        apellidos,
                        fec_nacimiento as FechaNacimiento,
                        email,
                        celular,
                        telefono
                        from persona
                        where id = @Id";

            return await _repository.GetAsync<Persona>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }

        public async Task<Persona> ObtenerPorRutAsync(int rut)
        {
            const string sql = @"select 
                        id,
                        rut,
                        dv,
                        id_direccion AS IdDireccion,
                        nombres,
                        apellidos,
                        fec_nacimiento as FechaNacimiento,
                        email,
                        celular,
                        telefono
                        from persona
                        where rut = @Rut";

            return await _repository.GetAsync<Persona>(sql, new Dictionary<string, object>
            {
                {"@Rut", rut}
            });
        }
    }
}
