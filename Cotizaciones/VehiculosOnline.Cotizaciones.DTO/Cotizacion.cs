using System;
using System.Collections.Generic;
using VehiculosOnline.Model.Clases;

namespace VehiculosOnline.Cotizaciones.DTO
{
    public class Cotizacion
    {
        public int IdSolicitud { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime FechaIngresoCotizacion { get; set; }
        public bool EsPagoDiferido { get; set; }
        public int CantidadMesesDiferido { get; set; }
        public int CantidadCuotas { get; set; }
        public int ValorVehiculo { get; set; }
        public Solicitud Solicitud { get; set; }
        public TipoPago TipoPago { get; set; }
        public List<CotizacionSeguro> Seguros { get; set; }
    }
}
