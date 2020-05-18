using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Usuarios.DAL.Tables
{
    public class UsuarioDal
    {
        private readonly Repository _repository;

        public UsuarioDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<int> InsertarAsync(Usuario usuario)
        {
            const string sql =
                @"INSERT INTO USUARIO (id_persona, clave, fecha_registro, activo)
                  VALUES (@IdPersona, @Clave, @FechaRegistro, @Activo);";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdPersona", usuario.IdPersona},
                {"@Clave", usuario.Clave},
                {"@FechaRegistro", usuario.FechaRegistro},
                {"@Activo", usuario.Activo},
            });
        }

        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            const string sql =
                @"SELECT id
                      ,id_persona as IdPersona
                      ,clave
                      ,fecha_registro as FechaRegistro
                      ,activo
                  FROM Usuario
                  WHERE id = @Id";

            return await _repository.GetAsync<Usuario>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }

        public async Task<bool> AutenticarAsync(int rut, string clave)
        {
            const string sql =
                @"SELECT 
                       1
                  FROM Usuario u
                  JOIN Persona p ON u.id_persona = p.id
                  WHERE rut = @Rut AND u.clave = @Clave AND u.activo = 1";

            return await _repository.GetAsync<bool>(sql, new Dictionary<string, object>
            {
                {"@Rut", rut},
                {"@Clave", clave}
            });
        }
    }
}
