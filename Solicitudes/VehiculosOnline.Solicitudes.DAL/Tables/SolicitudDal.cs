using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Transversal.Repositorios;
using VehiculosOnline.Vehiculos.DAL.ClassJoin;

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
                        fec_ingreso_solicitud as FechaIngresoSolicitud,
                        id_persona AS IdPersona,
                        id_vehiculo AS IdVehiculo
                        from solicitud";

            return await _repository.GetAllAsync<Solicitud>(sql);
        }

        public async Task<Solicitud> ObtenerPorIdAsync(int id)
        {
            const string sql = @"select 
                        id,
                        fec_ingreso_solicitud as FechaIngresoSolicitud,
                        id_persona AS IdPersona,
                        id_vehiculo AS IdVehiculo
                        from solicitud
                        WHERE id = @Id";

            return await _repository.GetAsync<Solicitud>(sql, new Dictionary<string, object>
            {
                {"@Id", id}
            });
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


        public async Task<List<SolicitudJoin>> ObtenerSolicitudListado(string rut, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = @"select 
                        v.id,
                        v.id_cotizacion as IdCotizacion,
                        v.fec_venta as FecVenta,
                        v.total_venta as TotalVenta,
                        co.id_tipo_pago as IdTipoPago,
                        tp.nombre as NombreTipoPago,
                        co.id_solicitud as IdSolicitud,
                        so.id_persona as IdPersona,
                        pe.email as Correo,
                        pe.nombres + ' ' + pe.apellidos as Nombre,
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
                        join marca ma on mo.id_marca = ma.id
                        WHERE(co.id_tipo_pago = @TipoPago OR 0 = @TipoPago)
                        AND(ve.id_modelo = @IdModelo OR 0 = @IdModelo)
                        AND(ma.id = @IdMarca OR 0 = @IdMarca)
                        AND(ve.anio = @Anio OR 0 = @Anio)";

            if (rut != null)
            {
                rut = "%" + rut + "%";
                sql = sql + "AND(pe.nombres LIKE @Nombre or pe.apellidos LIKE @Nombre)";
            }
            if (fechaDesde != DateTime.MinValue)
            {
                sql = sql + "AND(v.fec_venta >= @FechDesde)";
            }
            else
            {
                fechaDesde = DateTime.Now;
            }
            if (fechaHasta != DateTime.MinValue)
            {
                sql = sql + "AND(v.fec_venta <= @FechHasta)";
            }
            else
            {
                fechaHasta = DateTime.Now;
            }
            return await _repository.GetAllAsync<SolicitudJoin>(sql, new Dictionary<string, object>
            {
                {"@Rut", rut},
                {"@IdMarca", idMarca},
                {"@IdModelo", idModelo},
                {"@Anio", anio},
                {"@FechDesde", fechaDesde},
                {"@FechHasta", fechaHasta}
            });
        }


    }
}
