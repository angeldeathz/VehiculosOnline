using System;
using System.Collections.Generic;
using VehiculosOnlineSite.Model.Clases;
using VehiculosOnlineSite.Services.Servicios;

namespace VehiculosOnlineSite.BLL
{
    public class SolicitudBL
    {
        private readonly SolicitudService _solicitudService;

        public SolicitudBL()
        {
            _solicitudService = new SolicitudService();
        }

        public int IngresarSolicitud(SolicitudDto solicitud)
        {
            return _solicitudService.IngresarSolicitud(solicitud);
        }

        public List<SolicitudDataGrid> ObtenerSolicitudListado(string rut, int idMarca, int idModelo, int anio, DateTime fechaDesde, DateTime fechaHasta)
        {
            var solicitudes = new List<SolicitudDataGrid>();
            var solicitudesService = _solicitudService.ObtenerSolicitudListado(rut, idMarca, idModelo, anio, fechaDesde, fechaHasta);

            foreach (var x in solicitudesService)
            {
                solicitudes.Add(new SolicitudDataGrid
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Rut = x.Rut,
                    Marca = x.Marca,
                    Modelo = x.Modelo,
                    Anio = x.Anio,
                    FechaSolicitud = x.FechaSolicitud
                });

            }

            return solicitudes;
        }
    }
}
