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
                        cant_cuotas as CantidadCuotas,
                        valor_cuota as ValorCuota,
                        con_factura as ConFactura,
                        total_sin_iva as TotalSinIva,
                        iva as Iva,
                        total_final as TotalFinal
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
                        cant_cuotas as CantidadCuotas,
                        valor_cuota as ValorCuota,
                        con_factura as ConFactura,
                        total_sin_iva as TotalSinIva,
                        iva as Iva,
                        total_final as TotalFinal
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
                cant_cuotas,
                valor_cuota,
                con_factura,
                total_sin_iva,
                iva,
                total_final
                )
                VALUES
                (
                @IdSolicitud,
                @IdTipoPago,
                @FechaIngresoCotizacion,
                @EsPagoDiferido,
                @CantidadMesesDiferido,
                @CantidadCuotas,
                @ValorCuota,
                @ConFactura,
                @TotalSinIva,
                @Iva,
                @TotalFinal
                );";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdSolicitud", cotizacion.IdSolicitud},
                {"@IdTipoPago", cotizacion.IdTipoPago},
                {"@FechaIngresoCotizacion", DateTime.Now},
                {"@EsPagoDiferido", cotizacion.EsPagoDiferido},
                {"@CantidadMesesDiferido", cotizacion.CantidadMesesDiferido},
                {"@CantidadCuotas", cotizacion.CantidadCuotas},
                {"@ValorCuota", cotizacion.ValorCuota},
                {"@ConFactura", cotizacion.ConFactura},
                {"@TotalSinIva", cotizacion.TotalSinIva},
                {"@Iva", cotizacion.Iva},
                {"@TotalFinal", cotizacion.TotalFinal}
            });
        }
    }
}
