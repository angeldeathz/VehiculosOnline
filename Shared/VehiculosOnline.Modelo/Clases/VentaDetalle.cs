namespace VehiculosOnline.Model.Clases
{
    public class VentaDetalle : Base
    {
        public int IdVenta { get; set; }
        public int IdBanco { get; set; }
        public int DiaVencimiento { get; set; }
        public long NumeroCuentaCorriente { get; set; }
        public long NumeroTarjetaCredito { get; set; }
        public string VencimientoTarjetaCredito { get; set; }
        public int CvvTarjetaCredito { get; set; }
    }
}
