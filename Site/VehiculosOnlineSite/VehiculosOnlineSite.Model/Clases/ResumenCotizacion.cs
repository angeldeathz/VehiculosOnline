namespace VehiculosOnlineSite.Model.Clases
{
    public class ResumenCotizacion
    {
        public int IdSolicitud { get; set; }
        public int IdCotizacion { get; set; }
        public int PrecioSinIva { get; set; }
        public int Iva { get; set; }
        public int PrecioFinal { get; set; }
        public int Cuotas { get; set; }
        public int ValorCuota { get; set; }
        public int CostoTotalCredito { get; set; }
    }
}
