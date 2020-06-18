using System;

namespace VehiculosOnlineSite.Model.Clases
{
    //Cliente nombre,correo cliente,  Marca, Modelo, Anio, tipoPago, precio de venta, fecha de venta
    public class SolicitudDataGrid
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rut { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public DateTime FechaSolicitud { get; set; }
    }
}
