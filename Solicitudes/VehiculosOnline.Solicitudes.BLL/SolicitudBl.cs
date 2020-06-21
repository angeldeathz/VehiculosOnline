using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiculosOnline.Model.Clases;
using VehiculosOnline.Solicitudes.DAL.Tables;

namespace VehiculosOnline.Solicitudes.BLL
{
    public class SolicitudBl
    {
        private readonly SolicitudDal _solicitudDal;

        public SolicitudBl()
        {
            _solicitudDal = new SolicitudDal();
        }

        public async Task<List<Solicitud>> ObtenerTodosAsync()
        {
            return await _solicitudDal.ObtenerTodosAsync();
        }
        public async Task<List<SolicitudDataGrid>> ObtenerSolicitudListado(string rut, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var solicitudes = await _solicitudDal.ObtenerSolicitudListado(rut, idMarca, idModelo, anio, fechaDesde, fechaHasta);
            if (!solicitudes.Any()) return new List<SolicitudDataGrid>();

            return solicitudes.Select(x => new SolicitudDataGrid
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Rut = x.Rut,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Anio = x.Anio,
                FechaSolicitud = x.FechaSolicitud
            }).ToList();
        }
    }
}
