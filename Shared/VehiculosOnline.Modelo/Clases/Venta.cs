namespace VehiculosOnline.Modelo.Clases
{
    public class Venta
    {

        public int Id { get; set; }

        public int IdCotizacion { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime FecVenta { get; set; }

        public int TotalVenta { get; set; }

    }
}
