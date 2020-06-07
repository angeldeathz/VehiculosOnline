namespace VehiculosOnline.Cotizaciones.BLL
{
    public class PagoDto
    {
        public int PrecioSinIVA { get; set; }
        public int PrecioVehiuclo { get; set; }
        public int Cuota { get; set; }
        public int ValorCuota { get; set; }
        public int CostoTotalCredito { get; set; }
    }
}