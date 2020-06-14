namespace VehiculosOnlineSite.Model.Clases
{
    public class VentaDetalle : Base
    {
        public int IdVenta { get; set; }
        public int IdBanco { get; set; }
        public int IdTipoTarjeta { get; set; }
        public int DiaVencimiento { get; set; }
        public string NumeroCuentaCorriente { get; set; }
        public string NumeroTarjetaCredito { get; set; }
        public string VencimientoTarjetaCredito { get; set; }
        public int CvvTarjetaCredito { get; set; }
    }
}
