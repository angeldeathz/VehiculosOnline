using System;
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

        public async Task<Cotizacion> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id_solicitud as IdSolicitud,
                        id_tipo_pago as IdTipoPago,
                        fec_ingreso_cotizacion as FechaIngresoCotizacion,
                        es_pago_diferido as EsPagoDiferido,
                        cant_meses_diferido as CantidadMesesDiferido,
                        estaCerrada,
                        cant_cuotas as CantidadCuotas,
                        valor_vehiculo as ValorVehiculo
                        from cotizacion 
                        where id = @Id";

            return await _repository.GetAsync<Cotizacion>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
        }

        public async Task<List<Cotizacion>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id_solicitud as IdSolicitud,
                        id_tipo_pago as IdTipoPago,
                        fec_ingreso_cotizacion as FechaIngresoCotizacion,
                        es_pago_diferido as EsPagoDiferido,
                        cant_meses_diferido as CantidadMesesDiferido,
                        estaCerrada,
                        cant_cuotas as CantidadCuotas,
                        valor_vehiculo as ValorVehiculo
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
                {"@FechaIngresoCotizacion", DateTime.Now},
                {"@EsPagoDiferido", cotizacion.EsPagoDiferido},
                {"@CantidadMesesDiferido", cotizacion.CantidadMesesDiferido},
                {"@EstaCerrada", cotizacion.EstaCerrada},
                {"@CantidadCuotas", cotizacion.CantidadCuotas},
                {"@ValorVehiculo", cotizacion.ValorVehiculo}
            });
        }
    }
}
