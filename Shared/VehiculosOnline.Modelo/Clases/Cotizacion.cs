using System;
using System.Collections.Generic;

namespace VehiculosOnline.Model.Clases
{
    public class Cotizacion : Base
    {
        public int IdSolicitud { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime FechaIngresoCotizacion { get; set; }
        public bool EsPagoDiferido { get; set; }
        public int CantidadMesesDiferido { get; set; }
        public bool EstaCerrada { get; set; }
        public int CantidadCuotas { get; set; }
        public int ValorVehiculo { get; set; }
        public Solicitud Solicitud { get; set; }
        public TipoPago TipoPago { get; set; }
        public List<CotizacionSeguro> Seguros { get; set; }
    }
}
