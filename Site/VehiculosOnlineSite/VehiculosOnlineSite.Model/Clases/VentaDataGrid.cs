using System;

namespace VehiculosOnlineSite.Model.Clases
{
    //Cliente nombre,correo cliente,  Marca, Modelo, Anio, tipoPago, precio de venta, fecha de venta
    public class VentaDataGrid
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public int Anio { get; set; }
        public string tipoPago { get; set; }
        public int precioVenta { get; set; }
        public DateTime fechaVenta { get; set; }
    }
}
