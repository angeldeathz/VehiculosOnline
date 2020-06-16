using System;
using System.Collections.Generic;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Cotizacion : Base
    {
        public int IdSolicitud { get; set; }
        public int IdTipoPago { get; set; }
        public DateTime FechaIngresoCotizacion { get; set; }
        public bool EsPagoDiferido { get; set; }
        public int CantidadMesesDiferido { get; set; }
        public int CantidadCuotas { get; set; }
        public int ValorCuota { get; set; }
        public bool ConFactura { get; set; }
        public int TotalSinIva { get; set; }
        public int Iva { get; set; }
        public int TotalFinal { get; set; }
        public Solicitud Solicitud { get; set; }
        public TipoPago TipoPago { get; set; }
        public List<CotizacionSeguro> Seguros { get; set; }
    }
}
