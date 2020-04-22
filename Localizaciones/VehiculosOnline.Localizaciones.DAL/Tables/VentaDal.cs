using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Modelo.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Localizaciones.DAL.Tables
{
    public class CotizacionDal
    {
        private readonly Repository _repository;
            
        public CotizacionDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Cotizacion>> ObtenerTodosAsync()
        {
            var sql = @"select 
                        id,
                        id_solicitud AS IdSolicitud,
                        id_vehiculo AS IdVehiculo,
                        fec_ingreso_cotizacion,
                        estaCerrada
                        from cotizacion";
            return await _repository.GetAllAsync<Cotizacion>(sql);
        }
    }
}
