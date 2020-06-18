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

            foreach (var v in solicitudesService)
            {
                solicitudes.Add(new VentaDataGrid
                {
                    Id = v.Id,
                    Nombre = v.Nombre,
                    Correo = v.Correo,
                    Marca = v.Marca,
                    Modelo = v.Modelo,
                    Anio = v.Anio,
                    TipoPago = v.TipoPago,
                    PrecioVenta = v.PrecioVenta,
                    FechaVenta = v.FechaVenta
                });
            }

            return solicitudes;
        }
    }
}
