using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;
using VehiculosOnline.Vehiculos.DAL.ClassJoin;

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

        public async Task<List<VentaJoin>> ObtenerVentasListado(string nombre, string correo, int tipoPago, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            const string sql = @"select 
                        v.id,
                        v.id_cotizacion as IdCotizacion,
                        v.fec_venta as FecVenta,
                        v.total_venta as TotalVenta,
                        co.id_tipo_pago as IdTipoPago,
                        tp.nombre as NombreTipoPago,
                        co.id_solicitud as IdSolicitud,
                        so.id_persona as IdPersona,
                        pe.email as Correo,
                        pe.nombres as Nombre,
                        so.id_vehiculo as IdVehiculo,
                        ve.id_modelo as IdModelo,
                        mo.nombre as NombreModelo,
                        mo.id_marca as IdMarca,
                        ma.nombre as NombreMarca,
                        ve.anio as Anio
                        from venta v
                        join cotizacion co on v.id_cotizacion = co.id
                        join tipopago tp on co.id_tipo_pago = tp.id
                        join solicitud so on co.id_solicitud = so.id
                        join persona pe on so.id_persona = pe.id
                        join vehiculo ve on so.id_vehiculo = ve.id
                        join modelo mo on ve.id_modelo = mo.id
                        join marca ma on mo.id_marca = ma.id";
            //WHERE(v.id_modelo = @IdModelo OR 0 = @IdModelo)
            //            AND(ma.id = @IdMarca OR 0 = @IdMarca)
            //            AND(v.anio = @Anio OR 0 = @Anio)
            return await _repository.GetAllAsync<VentaJoin>(sql, new Dictionary<string, object>
            {
                //{"@Nombre", nombre},
                //{"@Correo", correo},
                //{"@TipoPago", tipoPago},
                //{"@IdMarca", idMarca},
                //{"@IdModelo", idModelo},
                //{"@Anio", anio},
                //{"@FechDesde", fechaDesde},
                //{"@FechHasta", fechaHasta}
            });
        }

    }
}
