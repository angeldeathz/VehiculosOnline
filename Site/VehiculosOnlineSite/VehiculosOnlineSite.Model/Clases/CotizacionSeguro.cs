namespace VehiculosOnlineSite.Model.Clases
{
    public class CotizacionSeguro : Base
    {
        public int IdCotizacion { get; set; }
        public int IdSeguro { get; set; }
        public int Valor { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public Seguro Seguro { get; set; }
    }
}
