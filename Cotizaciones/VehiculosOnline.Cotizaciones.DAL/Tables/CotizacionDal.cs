using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Cotizaciones.DAL.Tables
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
            const string sql = @"select 
                        id,
                        id_solicitud AS IdSolicitud,
                        id_vehiculo AS IdVehiculo,
                        fec_ingreso_cotizacion,
                        estaCerrada
                        from cotizacion";

            return await _repository.GetAllAsync<Cotizacion>(sql);
        }

        public async Task<int> InsertarAsync(Cotizacion cotizacion)
        {
            const string sql = @"INSERT INTO COTIZACION
                (
                id_solicitud,
                id_tipo_pago,
                fec_ingreso_cotizacion,
                es_pago_diferido,
                cant_meses_diferido,
                estaCerrada,
                cant_cuotas,
                valor_vehiculo
                )
                VALUES
                (
                @IdSolicitud,
                @IdTipoPago,
                @FechaIngresoCotizacion,
                @EsPagoDiferido,
                @CantidadMesesDiferido,
                @EstaCerrada,
                @CantidadCuotas,
                @ValorVehiculo
                );";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdSolicitud", cotizacion.IdSolicitud},
                {"@IdTipoPago", cotizacion.IdTipoPago},
                {"@FechaIngresoCotizacion", cotizacion.FechaIngresoCotizacion},
                {"@EsPagoDiferido", cotizacion.EsPagoDiferido},
                {"@CantidadMesesDiferido", cotizacion.CantidadMesesDiferido},
                {"@EstaCerrada", cotizacion.EstaCerrada},
                {"@CantidadCuotas", cotizacion.CantidadCuotas},
                {"@ValorVehiculo", cotizacion.ValorVehiculo}
            });
        }
    }
}
