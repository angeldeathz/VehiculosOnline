using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;

namespace VehiculosOnline.Ventas.DAL.Tables
{
    public class VentaDal
    {
        private readonly Repository _repository;
            
        public VentaDal()
        {
            _repository = new Repository(ConnectionStrings.VehiculosOnline);
        }

        public async Task<List<Venta>> ObtenerTodosAsync()
        {
            const string sql = @"select 
                        id,
                        id_cotizacion AS IdCotizacion,
                        fec_venta,
                        total_venta
                        from venta";
            return await _repository.GetAllAsync<Venta>(sql);
        }

        public async Task<int> InsertarAsync(Venta venta)
        {
            const string sql =
                @"INSERT INTO venta 
                    (id_cotizacion,
                    fec_venta,
                    total_venta)
                    VALUES
                    (@IdCotizacion,
                    @FecVenta,
                    @TotalVenta)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdCotizacion", venta.IdCotizacion},
                {"@FecVenta", DateTime.Now},
                {"@TotalVenta", venta.TotalVenta}
            });
        }

        public async Task<int> InsertarDetalleAsync(VentaDetalle detalle)
        {
            const string sql =
                @"INSERT INTO ventaDetalle 
                  (id_venta
                  ,id_banco
                  ,id_tipo_tarjeta
                  ,dia_vencimiento
                  ,num_cuenta_corriente
                  ,num_tarjeta_credito
                  ,venc_tarjeta_credito
                  ,cvv_tarjeta_credito)
                    VALUES
                  (@IdVenta,
                   @IdBanco,
                   @IdTipoTarjeta,
                   @DiaVencimiento,
                   @NumeroCuentaCorriente,
                   @NumeroTarjetaCredito,
                   @VencimientoTarjetaCredito,
                   @CvvTarjetaCredito)";

            return await _repository.InsertAsync(sql, new Dictionary<string, object>
            {
                {"@IdVenta", detalle.IdVenta},
                {"@IdBanco", detalle.IdBanco},
                {"@IdTipoTarjeta", detalle.IdTipoTarjeta},
                {"@DiaVencimiento", detalle.DiaVencimiento},
                {"@NumeroCuentaCorriente", detalle.NumeroCuentaCorriente},
                {"@NumeroTarjetaCredito", detalle.NumeroTarjetaCredito},
                {"@VencimientoTarjetaCredito", detalle.VencimientoTarjetaCredito},
                {"@CvvTarjetaCredito", detalle.CvvTarjetaCredito}
            });
        }
    }
}
