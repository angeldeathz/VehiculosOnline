using System;

namespace VehiculosOnlineSite.Model.Clases
{
    public class Venta : Base
    {
        public int IdCotizacion { get; set; }
        public DateTime FechaVenta { get; set; }
        public int TotalVenta { get; set; }
    }
}
