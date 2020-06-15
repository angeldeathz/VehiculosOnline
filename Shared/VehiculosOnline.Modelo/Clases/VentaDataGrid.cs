using System;

namespace VehiculosOnlineSite.Model.Clases
{
    //Cliente nombre,correo cliente,  Marca, Modelo, Anio, tipoPago, precio de venta, fecha de venta
    public class VentaDataGrid
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string TipoPago { get; set; }
        public int PrecioVenta { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
