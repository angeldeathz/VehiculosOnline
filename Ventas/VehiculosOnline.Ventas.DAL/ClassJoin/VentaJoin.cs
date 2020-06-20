using System;

namespace VehiculosOnline.Vehiculos.DAL.ClassJoin
{
    public class VentaJoin
    {
        public int Id { get; set; }
        public int IdCotizacion { get; set; }
        public DateTime FecVenta { get; set; }
        public int TotalVenta { get; set; }
        public int IdTipoPago { get; set; }
        public string NombreTipoPago { get; set; }
        public int IdSolicitud { get; set; }
        public int IdPersona { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public int IdVehiculo { get; set; }
        public int IdModelo { get; set; }
        public string NombreModelo { get; set; }
        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public int Anio { get; set; }

    }


}
