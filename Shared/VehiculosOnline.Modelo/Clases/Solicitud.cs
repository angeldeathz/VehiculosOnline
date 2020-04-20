namespace VehiculosOnline.Modelo.Clases
{
    public class Solicitud
    {
        public int Id { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "6/6/2079")]
        public DateTime FecIngresoSolicitud { get; set; }

        public int Telefono { get; set; }

    }
}
