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
    }
}
