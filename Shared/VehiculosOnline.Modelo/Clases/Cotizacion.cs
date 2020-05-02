using System;

namespace VehiculosOnline.Model.Clases
{
    public class Cotizacion : Base
    {
        public int IdSolicitud { get; set; }
        public int IdVehiculo { get; set; }
        public DateTime FecIngresoCotizacion { get; set; }
        public bool EstaCerrada { get; set; }
    }
}
