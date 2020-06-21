using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.DAL.ClassJoin;
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
                        s.id,
                        pe.nombres + ' ' + pe.apellidos as Nombre,
                        cast(pe.rut as nvarchar) + '-' + pe.dv as Rut,
                        ma.nombre as Marca,
                        mo.nombre as Modelo,
                        ve.anio as Anio,
                        s.fec_ingreso_solicitud as FechaSolicitud
                        from solicitud s
                        join persona pe on s.id_persona = pe.id
                        join vehiculo ve on s.id_vehiculo = ve.id
                        join modelo mo on ve.id_modelo = mo.id
                        join marca ma on mo.id_marca = ma.id
                        WHERE(ve.id_modelo = @IdModelo OR 0 = @IdModelo)
                        AND(ma.id = @IdMarca OR 0 = @IdMarca)
                        AND(ve.anio = @Anio OR 0 = @Anio)";

            if (rut != null)
            {
                rut = "%" + rut + "%";
                sql = sql + "AND(pe.rut = @Rut)";
            }
            if (fechaDesde != DateTime.MinValue)
            {
                sql = sql + "AND(s.fec_ingreso_solicitud >= @FechDesde)";
            }
            else
            {
                fechaDesde = DateTime.Now;
            }
            if (fechaHasta != DateTime.MinValue)
            {
                sql = sql + "AND(s.fec_ingreso_solicitud <= @FechHasta)";
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
