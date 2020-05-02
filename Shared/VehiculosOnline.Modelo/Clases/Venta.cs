using System;

namespace VehiculosOnline.Model.Clases
{
    public class Venta : Base
    {
        public int IdCotizacion { get; set; }
        public DateTime FecVenta { get; set; }
        public int TotalVenta { get; set; }
    }
}
