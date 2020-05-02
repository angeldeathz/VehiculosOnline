namespace VehiculosOnline.Modelo.Clases
{
    public class Cotizacion
    {
        public int Id { get; set; }

        public int IdSolicitud { get; set; }

        public int IdVehiculo { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime FecIngresoCotizacion { get; set; }

        public bool EstaCerrada { get; set; }
    }
}
