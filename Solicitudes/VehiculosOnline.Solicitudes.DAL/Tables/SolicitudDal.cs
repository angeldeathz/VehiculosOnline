using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Solicitudes.DAL.Tables
{
    public class SolicitudDal
    {
        private readonly Repository _repository;
            
        public SolicitudDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Solicitud>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        fec_ingreso_solicitud,
                        id_persona AS IdPersona
                        from solicitud";
            return await _repository.GetAllAsync<Solicitud>(sql);
        }

        public async Task<int> InsertarAsync(Solicitud solicitud)
        {
            const string sql =
                @"INSERT INTO SOLICITUD 
                    (fec_ingreso_solicitud,
                    id_persona,
                    id_vehiculo)
                    VALUES
                    (@FechaIngreso,
                     @IdPersona,
                     @IdVehiculo)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@FechaIngreso", solicitud.FechaIngresoSolicitud},
                {"@IdPersona", solicitud.IdPersona},
                {"@IdVehiculo", solicitud.IdVehiculo}
            });
        }
    }
}
