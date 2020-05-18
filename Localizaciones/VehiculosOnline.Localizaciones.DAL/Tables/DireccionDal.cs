using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class DireccionDal
    {
        private readonly Repository _repository;
            
        public DireccionDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<Direccion> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id,
                        calle,
                        numero,
                        id_comuna AS IdComuna
                        from direccion
                        WHERE id = @Id";

            return await _repository.GetAsync<Direccion>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }

        public async Task<int> InsertarAsync(Direccion direccion)
        {
            const string sql =
                @"INSERT INTO DIRECCION 
                    (calle, 
                    numero, 
                    id_comuna)
                  VALUES 
                    (@Calle,
                    @Numero,
                    @IdComuna)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@Calle", direccion.Calle},
                {"@Numero", direccion.Numero},
                {"@IdComuna", direccion.IdComuna}
            });
        }

        public async Task<int> ActualizarAsync(Direccion direccion)
        {
            const string sql =
                @"UPDATE DIRECCION 
                  SET
                    calle = @Calle,
                    numero = @Numero,
                    id_comuna = @IdComuna
                  Where id = @Id";

            return await _repository.UpdateAsync(sql, new Dictionary<string, object>
            {
                {"@Id", direccion.Id},
                {"@Calle", direccion.Calle},
                {"@Numero", direccion.Numero},
                {"@IdComuna", direccion.IdComuna}
            });
        }
    }
}
